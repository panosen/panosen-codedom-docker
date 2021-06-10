using Panosen.CodeDom;
using System;
using System.Linq;

namespace Panosen.CodeDom.Docker.Engine
{
    /// <summary>
    /// DockerFileEngine
    /// </summary>
    public partial class DockerFileEngine
    {
        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="dockerFile"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void Generate(DockerFile dockerFile, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (dockerFile == null)
            {
                return;
            }
            if (dockerFile.DirectiveList == null && dockerFile.DirectiveList.Count == 0)
            {
                return;
            }
            if (codeWriter == null)
            {
                return;
            }
            options = options ?? new GenerateOptions();

            for (int i = 0; i < dockerFile.DirectiveList.Count; i++)
            {
                if (i > 0)
                {
                    WriteNewLineIfLoose(codeWriter, options);
                }

                Generate(dockerFile.DirectiveList[i], codeWriter, options);
            }
        }

        /// <summary>
        /// 生成任务
        /// </summary>
        /// <param name="directive"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void Generate(Directive directive, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (directive == null)
            {
                return;
            }
            if (codeWriter == null)
            {
                return;
            }
            options = options ?? new GenerateOptions();

            switch (directive.DirectiveType)
            {
                case DirectiveType.Empty:
                    GenerateEmpty(directive as EmptyDirective, codeWriter);
                    break;
                case DirectiveType.From:
                    GenerateFrom(directive as FromDirective, codeWriter);
                    break;
                case DirectiveType.Run:
                    GenerateRun(directive as RunDirective, codeWriter, options);
                    break;
                case DirectiveType.Workdir:
                    GenerateWorkdir(directive as WorkdirDirective, codeWriter);
                    break;
                case DirectiveType.Copy:
                    GenerateCopy(directive as CopyDirective, codeWriter);
                    break;
                case DirectiveType.EntryPoint:
                    GenerateEntrypoint(directive as EntrypointDirective, codeWriter);
                    break;
                case DirectiveType.None:
                default:
                    break;
            }
        }

        private void GenerateWorkdir(WorkdirDirective workdirDirective, CodeWriter codeWriter)
        {
            if (workdirDirective == null)
            {
                return;
            }
            codeWriter.Write(Keywords.WORDDIR).Write(Marks.WHITESPACE).WriteLine(workdirDirective.Path);
        }

        public void GenerateEmpty(EmptyDirective emptyDirective, CodeWriter codeWriter)
        {
            if (emptyDirective == null)
            {
                return;
            }
            codeWriter.WriteLine();
        }

        public void GenerateFrom(FromDirective fromDirective, CodeWriter codeWriter)
        {
            if (fromDirective == null)
            {
                return;
            }

            codeWriter.Write($"{Keywords.FROM} {fromDirective.BaseImage}");

            if (!string.IsNullOrEmpty(fromDirective.BaseImageAlias))
            {
                codeWriter.Write($" AS {fromDirective.BaseImageAlias}");
            }

            codeWriter.WriteLine();
        }

        public void GenerateCopy(CopyDirective copyFile, CodeWriter codeWriter)
        {
            codeWriter.Write(Keywords.COPY);

            if (!string.IsNullOrEmpty(copyFile.Image))
            {
                codeWriter.Write(Marks.WHITESPACE);
                codeWriter.Write($"--{Params.FROM}={copyFile.Image}");
            }

            codeWriter.Write(Marks.WHITESPACE);
            codeWriter.Write(copyFile.Source);

            codeWriter.Write(Marks.WHITESPACE);
            codeWriter.WriteLine(copyFile.Target);
        }

        public void GenerateRun(RunDirective runDirective, CodeWriter codeWriter, GenerateOptions options)
        {
            if (runDirective == null)
            {
                return;
            }
            if (runDirective.Runs == null || runDirective.Runs.Count == 0)
            {
                return;
            }

            codeWriter.Write(Keywords.RUN);

            var autoBreakLine = options.RunMaxLength > 0 && runDirective.Runs.Sum(v => v.Length) > options.RunMaxLength;
            for (int i = 0; i < runDirective.Runs.Count; i++)
            {
                var current = runDirective.Runs[i];

                codeWriter.Write(Marks.WHITESPACE);
                if (i > 0)
                {
                    codeWriter.Write(Marks.AND).Write(Marks.AND).Write(Marks.WHITESPACE);
                }
                codeWriter.Write(current);

                if (autoBreakLine && i < runDirective.Runs.Count - 1)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(Marks.BACKSLASH)
                        .WriteLine().Write(Marks.WHITESPACE);
                }
            }

            codeWriter.WriteLine();
        }

        public void GenerateEntrypoint(EntrypointDirective entrypointDirective, CodeWriter codeWriter)
        {
            if (entrypointDirective == null)
            {
                return;
            }

            codeWriter.Write(Keywords.ENTRYPOINT).Write(Marks.WHITESPACE).Write(Marks.LEFT_SQUARE_BRACKET);

            if (entrypointDirective.Params != null && entrypointDirective.Params.Count > 0)
            {
                codeWriter.Write(string.Join(", ", entrypointDirective.Params.Select(v => DataValue.DoubleQuotationString(v).Value)));
            }

            codeWriter.Write(Marks.RIGHT_SQUARE_BRACKET);

            codeWriter.WriteLine();
        }

        private void WriteNewLineIfLoose(CodeWriter codeWriter, GenerateOptions options)
        {
            if (options.Loose)
            {
                codeWriter.WriteLine();
            }
        }
    }
}
