﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker
{
    public class WorkdirDirective : Directive
    {
        public override DirectiveType DirectiveType => DirectiveType.Workdir;

        public string Path { get; set; }
    }
}
