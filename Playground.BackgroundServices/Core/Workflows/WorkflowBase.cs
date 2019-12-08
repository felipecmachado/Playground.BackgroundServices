﻿using Playground.BackgroundServices.Core.Workflows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Playground.BackgroundServices.Core
{
    public abstract class WorkflowBase : IWorkflow
    {
        public readonly FileInfo FileInfo;

        public WorkflowBase(FileInfo file)
        {
            this.FileInfo = file;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}