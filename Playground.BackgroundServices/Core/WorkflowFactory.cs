using Playground.BackgroundServices.Core.Workflows;
using System;
using System.IO;

namespace Playground.BackgroundServices.Core
{
    public static class WorkflowFactory
    {
        public static IWorkflow GetWorkflow(FileInfo fileInfo)
        {
            // this is unclear at the moment, so it lacks a more robust logic
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
