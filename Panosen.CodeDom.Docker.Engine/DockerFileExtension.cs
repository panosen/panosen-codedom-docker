using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker.Engine
{
    public static class DockerFileExtension
    {
        public static string TransformText(this DockerFile dockerFile, GenerateOptions options = null)
        {
            var builder = new StringBuilder();

            new DockerFileEngine().Generate(dockerFile, builder, options);

            return builder.ToString();
        }
    }
}
