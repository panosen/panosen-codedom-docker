using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker
{
    /// <summary>
    /// 用于插入空行
    /// </summary>
    public class EmptyDirective : Directive
    {
        public override DirectiveType DirectiveType => DirectiveType.Empty;
    }
}
