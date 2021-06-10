using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker
{
    /// <summary>
    /// Dockerfile
    /// </summary>
    public class DockerFile
    {
        /// <summary>
        /// directives
        /// </summary>
        public List<Directive> DirectiveList { get; set; }
    }
}
