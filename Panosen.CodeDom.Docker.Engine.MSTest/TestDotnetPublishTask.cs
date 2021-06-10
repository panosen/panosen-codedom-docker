using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Panosen.CodeDom.Docker.Engine.MSTest
{
    [TestClass]
    public class TestDotnetPublishTask
    {
        /// <summary>
        /// DotnetPublish 运行时基础镜像
        /// </summary>
        public string DotnetSdkBaseImage { get; set; } = "mcr.microsoft.com/dotnet/sdk:5.0";

        /// <summary>
        /// DotnetPublish 运行时基础镜像
        /// </summary>
        public string DotnetSdkBaseImageAlias { get; set; } = "DOTNET_CORE_SDK";


        [TestMethod]
        public void TestGenerateDotnetPublishTask()
        {
            var dockerFile = new DockerFile();

            dockerFile.AddFromDirective(DotnetSdkBaseImage, DotnetSdkBaseImageAlias);
            dockerFile.AddCopyDirective("./", "/tmp/");
            dockerFile.AddCopyDirective("/from", "/to", "SAMPLE");
            dockerFile.AddWorkdirDirective("/tmp");
            dockerFile.AddRunDirective("dotnet publish -c Release");
            dockerFile.AddEntrypointDirective("dotnet", "Sample.dll");

            var builder = new StringBuilder();
            new DockerFileEngine().Generate(dockerFile, builder, new GenerateOptions
            {
                Loose = true
            });

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private string PrepareExpected()
        {
            return @"FROM mcr.microsoft.com/dotnet/sdk:5.0 AS DOTNET_CORE_SDK

COPY ./ /tmp/

COPY --from=SAMPLE /from /to

WORKDIR /tmp

RUN dotnet publish -c Release

ENTRYPOINT [""dotnet"", ""Sample.dll""]
";
        }
    }
}
