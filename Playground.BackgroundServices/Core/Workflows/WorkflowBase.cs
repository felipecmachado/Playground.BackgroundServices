using Playground.BackgroundServices.Core.Workflows;
using System;
using System.IO;

namespace Playground.BackgroundServices.Core
{
    public abstract class WorkflowBase : IWorkflow
    {
        public readonly FileInfo fileInfo;

        public WorkflowBase(FileInfo file)
        {
            this.fileInfo = file;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
