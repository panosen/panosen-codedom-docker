using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Docker
{
    /// <summary>
    /// DockerFileExtension
    /// </summary>
    public static class DockerFileExtension
    {
        /// <summary>
        /// AddDirective
        /// </summary>
        public static TDockerTask AddDirective<TDockerTask>(this TDockerTask dockerTask, Directive directive)
            where TDockerTask : DockerFile
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            dockerTask.DirectiveList.Add(directive);

            return dockerTask;
        }

        /// <summary>
        /// AddFromDirective
        /// </summary>
        public static EmptyDirective AddEmptyDirective(this DockerFile dockerTask)
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            EmptyDirective emptyDirective = new EmptyDirective();

            dockerTask.DirectiveList.Add(emptyDirective);

            return emptyDirective;
        }

        /// <summary>
        /// AddFromDirective
        /// </summary>
        public static FromDirective AddFromDirective(this DockerFile dockerTask, string baseImage, string baseImageAlias = null)
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            FromDirective fromDirective = new FromDirective();
            fromDirective.BaseImage = baseImage;
            fromDirective.BaseImageAlias = baseImageAlias;

            dockerTask.DirectiveList.Add(fromDirective);

            return fromDirective;
        }

        /// <summary>
        /// AddCopyDirective
        /// </summary>
        public static CopyDirective AddCopyDirective(this DockerFile dockerTask, string source, string target, string image = null)
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            CopyDirective copyFile = new CopyDirective();
            copyFile.Image = image;
            copyFile.Source = source;
            copyFile.Target = target;

            dockerTask.DirectiveList.Add(copyFile);

            return copyFile;
        }

        /// <summary>
        /// AddWorkdirDirective
        /// </summary>
        public static WorkdirDirective AddWorkdirDirective(this DockerFile dockerTask, string path)
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            WorkdirDirective workdirFile = new WorkdirDirective();
            workdirFile.Path = path;

            dockerTask.DirectiveList.Add(workdirFile);

            return workdirFile;
        }

        /// <summary>
        /// 拷贝文件
        /// </summary>
        public static RunDirective AddRunDirective(this DockerFile dockerTask, params string[] run)
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            RunDirective runDirective = new RunDirective();
            if (run != null && run.Length > 0)
            {
                runDirective.Runs = new List<string>();
                runDirective.Runs.AddRange(run);
            }

            dockerTask.DirectiveList.Add(runDirective);

            return runDirective;
        }

        /// <summary>
        /// ENTRYPOINT [...param]
        /// </summary>
        public static EntrypointDirective AddEntrypointDirective(this DockerFile dockerTask, params string[] @params)
        {
            if (dockerTask.DirectiveList == null)
            {
                dockerTask.DirectiveList = new List<Directive>();
            }

            EntrypointDirective runDirective = new EntrypointDirective();
            if (@params != null && @params.Length > 0)
            {
                runDirective.Params = new List<string>();
                runDirective.Params.AddRange(@params);
            }

            dockerTask.DirectiveList.Add(runDirective);

            return runDirective;
        }
    }
}
