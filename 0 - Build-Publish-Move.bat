@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Docker\bin\Release\Panosen.CodeDom.Docker.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Docker.Engine\bin\Release\Panosen.CodeDom.Docker.Engine.*.nupkg D:\LocalSavoryNuget\

pause