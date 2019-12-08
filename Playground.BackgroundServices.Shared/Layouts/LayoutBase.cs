using Playground.BackgroundServices.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.BackgroundServices.Shared.Layouts
{
    public abstract class LayoutBase
    {
        public string Separator { get; set; }

        public string Pattern { get; set; }
    }
}
