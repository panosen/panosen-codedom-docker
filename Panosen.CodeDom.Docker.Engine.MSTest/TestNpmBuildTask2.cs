using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Panosen.CodeDom.Docker.Engine.MSTest
{
    [TestClass]
    public class TestNpmBuildTask2
    {
        /// <summary>
        /// NpmBuild 运行时基础镜像
        /// </summary>
        public string NodeBaseImage { get; set; } = "node:16.3.0";

        /// <summary>
        /// NpmBuild 运行时基础镜像
        /// </summary>
        public string NodeBaseImageAlias { get; set; } = "NODE";

        [TestMethod]
        public void GenerateNpmBuildTask()
        {
            var dockerFile = new DockerFile();

            dockerFile.AddFromDirective(NodeBaseImage, NodeBaseImageAlias);
            dockerFile.AddCopyDirective("./", "/tmp/");
            dockerFile.AddWorkdirDirective("/tmp");
            dockerFile.AddRunDirective("npm install", "npm run build");

            var builder = new StringBuilder();
            new DockerFileEngine().Generate(dockerFile, builder, new GenerateOptions
            {
                Loose = true,
                RunMaxLength = 1
            });

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private string PrepareExpected()
        {
            return @"FROM node:16.3.0 AS NODE

COPY ./ /tmp/

WORKDIR /tmp

RUN npm install \
  && npm run build
";
        }
    }
}
