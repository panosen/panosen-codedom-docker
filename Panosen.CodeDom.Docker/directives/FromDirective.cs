using System;
using System.Collections.Generic;
using System.Text;

namespace Savory.CodeDom.Docker
{
    public class FromDirective : Directive
    {
        public override DirectiveType DirectiveType => DirectiveType.From;

        /// <summary>
        /// 运行时基础镜像
        /// </summary>
        public string BaseImage { get; set; }

        /// <summary>
        /// 镜像别名
        /// </summary>
        public string BaseImageAlias { get; set; }
    }
}
