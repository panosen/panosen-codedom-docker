using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker
{
    /// <summary>
    /// 用于插入空行
    /// </summary>
    public class EntrypointDirective : Directive
    {
        public override DirectiveType DirectiveType => DirectiveType.EntryPoint;

        public List<string> Params { get; set; }
    }
}
