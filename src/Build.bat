cls

@rem Add path to MSBuild Binaries
@if exist "%ProgramFiles%\MSBuild\12.0\bin" set PATH=%ProgramFiles%\MSBuild\12.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\12.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\12.0\bin;%PATH%

msbuild Vlc.DotNet.sln /t:Rebuild /p:Configuration=Debug;Platform=AnyCPU
msbuild Vlc.DotNet.sln /t:Rebuild /p:Configuration=Release;Platform=AnyCPU
