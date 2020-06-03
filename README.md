Vlc.DotNet
==========

_**As more and more effort is put into [LibVLCSharp](https://code.videolan.org/videolan/LibVLCSharp), fewer evolutions are expected to be made to this project.**_

_**Bugfixes will still be fixed on the maintainer's free time, but as of 2020-05-06, support for libvlc 4 is not planned. You are encouraged to [migrate](https://code.videolan.org/videolan/LibVLCSharp/-/blob/3.x/docs/migrating_from_Vlc.DotNet.md) and create new projects with [LibVLCSharp](https://code.videolan.org/videolan/LibVLCSharp)**_


[![Join the chat at https://discord.gg/SyUpk57](https://img.shields.io/discord/716939396464508958?label=discord)](https://discord.gg/SyUpk57)

Vlc.DotNet is a .net library that hosts the audio/video capabilities of the VLC libraries. In other words, it's a .net wrapper around `libvlc`.

It can work on any .net framework version starting from .net 2.0 and .net standard 1.3 (starting from Vlc.DotNet 2.2.1).

On the front-end side, two components are currently available to make it easy to integrate in your apps. One is for WinForms, the other for WPF.

Writing a WPF app / Migrating WPF control from 2.x
----------
_**Please Read this if you are writing a WPF app! This is super important!**_

_tl;dr : Use Vlc.DotNet.Forms in a WindowsFormsHost, unless you know what you're doing_

The WPF control has been rewritten from scratch from 2.x.

The old WPF control was just a wrapper around the WinForms control.
This led to some issues (Airspace issue...) and lacked some WPF-ish features.

That's why a new control has been written. To be fair, first versions of Vlc.DotNet
were built with that technique, but back then, there were issues in the .net framework
causing the memory usage to explode. As of 2018, this issue is resolved.

You have in fact two options:
- Use the new WPF control. You might notice a performance impact when reading, for example, a 4k @ 60 fps video on a low-end computer. However, you can do whatever you like, just as a normal ImageSource in WPF.
- Wrap the Vlc.DotNet.WinForms control in a WindowsFormsHost. It offers better performance, but you will experience Airspace issues (see [#296](https://github.com/ZeBobo5/Vlc.DotNet/issues/296)) if you need to write over the video.

The right option to use depends on your needs.

See the discussion [#249](https://github.com/ZeBobo5/Vlc.DotNet/issue/249) and pull request : [#365](https://github.com/ZeBobo5/Vlc.DotNet/pull/365)


How to use
----------
It all starts with those three steps :
- Install one of the NuGet Packages below
- Install `libvlc` libraries manually or from the [NuGet package](https://github.com/mfkl/libvlc-nuget)(recommended)
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
Packages are available for Vlc libraries. Releases packages follow [SEMVER 2.0.0](http://semver.org/)

- [Vlc.DotNet.Core.Interops](https://www.nuget.org/packages/Vlc.DotNet.Core.Interops/) : You probably don't want to use this one directly
- [Vlc.DotNet.Core](https://www.nuget.org/packages/Vlc.DotNet.Core/) : If you don't want to have a video interface, this might be the package to use.
- [Vlc.DotNet.Forms](https://www.nuget.org/packages/Vlc.DotNet.Forms/) : To be used in WinForms projects
- [Vlc.DotNet.Wpf](https://www.nuget.org/packages/Vlc.DotNet.Wpf/) : You guessed it, for WPF applications

Prereleases packages are built each time a push is made on `develop`

# Other links

- [Contributing](https://github.com/ZeBobo5/Vlc.DotNet/blob/develop/.github/CONTRIBUTING.md)
- [Changelog](https://github.com/ZeBobo5/Vlc.DotNet/blob/develop/CHANGELOG.md)
- [Wiki](https://github.com/ZeBobo5/Vlc.DotNet/wiki)
- [Ask questions & chat](https://discord.gg/SyUpk57)
- [LibVLCSharp](https://github.com/videolan/libvlcsharp) : The officially supported and cross-platform libvlc to .net binding which will eventually replace this project at some point. A [migration guide](https://code.videolan.org/videolan/LibVLCSharp/-/blob/3.x/docs/migrating_from_Vlc.DotNet.md) is available for Vlc.DotNet users migrating to LibVLCSharp.
