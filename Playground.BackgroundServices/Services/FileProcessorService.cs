using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.BackgroundServices.Services
{
    public class FileProcessorService : IHostedService
    {
        private readonly TimeSpan interval = TimeSpan.FromSeconds(30);
        private readonly TimeSpan throttleRate = TimeSpan.FromSeconds(5);
        private readonly string DATA_PATH = "data/in";
        private CancellationTokenSource _cts;

        private readonly ILogger<FileProcessorService> _logger;

        public FileProcessorService(ILogger<FileProcessorService> logger)
        {
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a linked token so we can trigger cancellation outside of this token's cancellation
            _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            Task task = Task.Run(async () =>
            {
                EnsureDirectoryExists(this.DATA_PATH);

                while (!_cts.IsCancellationRequested)
                {
                    await ProcessFiles();

                    Thread.Sleep(this.interval);
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"FileProcessorService is stopping.");

            _cts.Cancel();

            return Task.CompletedTask;
        }

        private async Task ProcessFiles()
        {
            try
            {
                var files = this.ReadFiles();

                if (files.Count() > 0)
                {
                    _logger.LogInformation($"{files.Count()} file(s) were found. Starting to process them.");

                    foreach (var file in files)
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (IOException)
                        {
                            _logger.LogWarning($"An error occured when trying to delete the file {file.Name}");
                            break;
                        }
                        catch (Exception ex)
                        {
                            file.MoveTo(file.FullName + ".error");
                            _logger.LogError(ex, $"An error occured while processing {file.Name}");
                        }

                        await Task.Delay(this.throttleRate);
                    }

                    _logger.LogInformation($"Finished processing all files");
                }
                else
                {
                    _logger.LogInformation($"There are no files to be processed");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A exception occurred: {ex.Message}");
            }
        }

        private void EnsureDirectoryExists(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        private IEnumerable<FileInfo> ReadFiles()
            => new DirectoryInfo(this.DATA_PATH)
                .EnumerateFiles("*.txt", SearchOption.TopDirectoryOnly)
                .OrderBy(file => file.CreationTime);
    }
}
