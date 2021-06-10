using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker
{
    public class RunDirective : Directive
    {
        public override DirectiveType DirectiveType => DirectiveType.Run;

        public List<string> Runs { get; set; }
    }
}
