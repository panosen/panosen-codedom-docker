using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Docker.Engine
{
    /// <summary>
    /// 生成选项
    /// </summary>
    public class GenerateOptions
    {
        /// <summary>
        /// 宽松模式
        /// </summary>
        public bool Loose { get; set; }

        /// <summary>
        /// 如果 RUN 后面的总长度达到 ${RunMaxLength}，自动换行每一项
        /// </summary>
        public int RunMaxLength { get; set; }

        /// <summary>
        /// DotnetPublish 运行时基础镜像
        /// mcr.microsoft.com/dotnet/aspnet:5.0
        /// </summary>
        public string DotnetAspnetBaseImage { get; set; } = "mcr.microsoft.com/dotnet/aspnet:5.0";

        /// <summary>
        /// DotnetPublish 运行时基础镜像
        /// mcr.microsoft.com/dotnet/runtime:5.0
        /// </summary>
        public string DotnetRuntimeBaseImage { get; set; } = "mcr.microsoft.com/dotnet/runtime:5.0";


    }
}
