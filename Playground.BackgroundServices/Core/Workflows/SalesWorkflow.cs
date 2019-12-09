using Playground.BackgroundServices.Core.Reports;
using Playground.BackgroundServices.Shared.Layouts;
using System.IO;

namespace Playground.BackgroundServices.Core
{
    public class SalesWorkflow : WorkflowBase
    {
        public SalesWorkflow(FileInfo file) : base(file) { }

        public override void Execute()
        {
            // Step 1: Parse file
            var layout = new SalesLayout();
            layout.Parse(this.FileInfo);

            // Step 2: Generate reports
            var report = new SalesReport();
            report.Run(layout);
        }
    }
}
