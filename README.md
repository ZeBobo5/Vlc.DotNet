Vlc.DotNet
==========

[![Join the chat at https://gitter.im/Vlc-DotNet/Lobby](https://badges.gitter.im/Vlc-DotNet/Lobby.svg)](https://gitter.im/Vlc-DotNet/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Vlc.DotNet is a .net library that hosts the audio/video capabilities of the VLC libraries. In other words, it's a .net wrapper around `libvlc`.

It can work on any .net framework version starting from .net 2.0. (.net standard support is planned for core libraries)

On the front-end side, two components are currently available to make it easy to integrate in your apps. One is for WinForms, the other for WPF.

How to use
----------
It all starts with those three steps :
- Install one of the NuGet Packages below
- Install `libvlc` libraries from one of the official distributions (To be improved, see #288)
- Integrate it into your app

See the [Getting started wiki](https://github.com/ZeBobo5/Vlc.DotNet/wiki/Getting-started)

Continuous Integration
----------------------


Branch | Build | Description
--- | --- | ---
master | [![Build status](https://ci.appveyor.com/api/projects/status/lkx1ojkcgq51yfro/branch/master?svg=true)](https://ci.appveyor.com/project/ZeBobo5/vlc-dotnet/branch/master) | Latest stable version
develop | [![Build status](https://ci.appveyor.com/api/projects/status/lkx1ojkcgq51yfro/branch/develop?svg=true)](https://ci.appveyor.com/project/ZeBobo5/vlc-dotnet/branch/develop) | Latest features (may be experimental)

NuGet Packages
--------------
Packages are available for Vlc libraries

- [Vlc.DotNet.Core.Interops](https://www.nuget.org/packages/Vlc.DotNet.Core.Interops/) : You probably don't want to use this one directly
- [Vlc.DotNet.Core](https://www.nuget.org/packages/Vlc.DotNet.Core/) : If you don't want to have a video interface, this might be the package to use.
- [Vlc.DotNet.Forms](https://www.nuget.org/packages/Vlc.DotNet.Forms/) : To be used in WinForms projects
- [Vlc.DotNet.Wpf](https://www.nuget.org/packages/Vlc.DotNet.Wpf/) : You guessed it, for WPF applications

Prereleases packages are built each time a push is made on `develop`

# Other links

- [Contributing](https://github.com/ZeBobo5/Vlc.DotNet/blob/develop/.github/CONTRIBUTING.md)
- [Changelog](https://github.com/ZeBobo5/Vlc.DotNet/blob/develop/CHANGELOG.md)
- [Wiki](https://github.com/ZeBobo5/Vlc.DotNet/wiki)
- [Ask questions](https://gitter.im/Vlc-DotNet/Lobby)
