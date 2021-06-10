using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker
{
    /// <summary>
    /// 拷贝文件
    /// </summary>
    public class CopyDirective : Directive
    {

        public override DirectiveType DirectiveType => DirectiveType.Copy;

        /// <summary>
        /// 从镜像中拷贝
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public string Target { get; set; }
    }
}
