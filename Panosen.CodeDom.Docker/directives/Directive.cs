using System;
using System.Collections.Generic;
using System.Text;

namespace Savory.CodeDom.Docker
{
    public abstract class Directive
    {
        public abstract DirectiveType DirectiveType { get; }
    }

    public enum DirectiveType
    {
        None,

        Empty,

        From,

        Run,

        Workdir,

        Copy,

        EntryPoint
    }
}
