using Playground.BackgroundServices.Core.Workflows;
using System;
using System.IO;

namespace Playground.BackgroundServices.Core
{
    public static class WorkflowFactory
    {
        public static IWorkflow GetWorkflow(FileInfo fileInfo)
        {
            switch (fileInfo.Extension)
            {
                case ".txt":
                    return new SalesWorkflow(fileInfo);

                default:
                    throw new ArgumentException("Workflow not implemented;");
            }
        }
    }
}
