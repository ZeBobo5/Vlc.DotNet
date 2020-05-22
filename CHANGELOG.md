# 3.1.0
- ADDED support for .net core 3.0 for Vlc.DotNet.Forms and Vlc.DotNet.Wpf
- DROPPED support for .net framework 2.0
- FIXED race conditions on Dispose() [#641](https://github.com/ZeBobo5/Vlc.DotNet/pull/641). Fixes [#639](https://github.com/ZeBobo5/Vlc.DotNet/issues/639) and [#640](https://github.com/ZeBobo5/Vlc.DotNet/issues/640)
- FIXED Media created from non-seekable .NET Streams were declared as seekable for libvlc [#648](https://github.com/ZeBobo5/Vlc.DotNet/pull/648). See [#647](https://github.com/ZeBobo5/Vlc.DotNet/issues/647).
- CHANGED The buffer size for media created from .NET Streams from 16kiB to 16MiB. It takes more memory, but allows to read more data at once. [#648](https://github.com/ZeBobo5/Vlc.DotNet/pull/648)

# 3.0.0
- BREAKING CHANGE : Created a new WPF control using ImageSource [#365](https://github.com/ZeBobo5/Vlc.DotNet/pull/365) see how to use in wiki!
- ADDED `SetMouseInput`/`SetKeyInput` methods [#424](https://github.com/ZeBobo5/Vlc.DotNet/pull/424). Fixes [#379](https://github.com/ZeBobo5/Vlc.DotNet/issues/379) and [#107](https://github.com/ZeBobo5/Vlc.DotNet/issues/107). Thanks @CrookedFingerGuy
- ADDED Rendering support for alpha channel videos in WPF control [#439](https://github.com/ZeBobo5/Vlc.DotNet/pull/439)
- ADDED Dialog management API [#373](https://github.com/ZeBobo5/Vlc.DotNet/pull/373)
- ADDED A new ResetMedia method [#539](https://github.com/ZeBobo5/Vlc.DotNet/pull/539)
- ADDED A binding for fullscreen functions [#516](https://github.com/ZeBobo5/Vlc.DotNet/pull/516) (This doesn't mean that fullscreen is supported by Vlc.DotNet. Handling Fullscreen in Vlc.DotNet is not as simple as setting a flag to true/false) (Thanks @LinoBarreca  and @samarthshroff)
- ADDED A binding for user agent and app ID functions [#485](https://github.com/ZeBobo5/Vlc.DotNet/pull/485)
- ADDED A new SetVideoTitleDisplay() binding [#466](https://github.com/ZeBobo5/Vlc.DotNet/pull/466) (Thanks @HoraceYork88)
- ADDED A SetPause(bool) API because Pause() toggles the pause [#471](https://github.com/ZeBobo5/Vlc.DotNet/pull/471)
- CHANGED The internal management of the libvlc instances. This fixes several memory leaks and crashes on dispose, especially when using multiple controls at the same time [#474](https://github.com/ZeBobo5/Vlc.DotNet/pull/490), [#477](https://github.com/ZeBobo5/Vlc.DotNet/pull/477) (Thanks @dilandau2001) [#490](https://github.com/ZeBobo5/Vlc.DotNet/pull/490)
- CHANGED PR [#490](https://github.com/ZeBobo5/Vlc.DotNet/pull/490) also changed the behavior when trying to set `VlcMediaPlayerOptions` or `VlcLibDirectory` after initialization. An exception is now thrown in those cases, because this is a bad API usage.
- CHANGED name of internal handle class from `SafeUnmanagedMemoryHandle` to `Utf8StringHandle` [#337](https://github.com/ZeBobo5/Vlc.DotNet/pull/337)
- CHANGED Replaced the legacy API for getting audio devices and media tracks with newer API [#402](https://github.com/ZeBobo5/Vlc.DotNet/pull/402)
- CHANGED the `IsInDesigner` detection method [#459](https://github.com/ZeBobo5/Vlc.DotNet/pull/459) (Thanks @MarcLandis)
- FIXED invalid types for `Position` (must be a `float`) and `Length` (must be a `long`).  [#469](https://github.com/ZeBobo5/Vlc.DotNet/pull/469) (Thanks @Arashz22)
- FIXED the type of the `NewTitle` property (int -> string) in `VlcMediaPlayerTitleChangedEventArgs` [#364](https://github.com/ZeBobo5/Vlc.DotNet/pull/364)
- FIXED the return type of `DetachEvent` [#488](https://github.com/ZeBobo5/Vlc.DotNet/pull/488) (Thanks @mfkl)
- FIXED the return type of `TakeSnapshot` [#449](https://github.com/ZeBobo5/Vlc.DotNet/pull/449)
- FIXED AccessViolationException when setting Audio.Outputs.Current [#493](https://github.com/ZeBobo5/Vlc.DotNet/pull/493) (Thanks @Rukhlov)
- FIXED Patched wrong info received from the WPF video callback [#526](https://github.com/ZeBobo5/Vlc.DotNet/pull/526) (Thanks @Sep95), [#531](https://github.com/ZeBobo5/Vlc.DotNet/pull/531)

# 2.2.1
- FIXED assembly file version that was incorrect #[326](https://github.com/ZeBobo5/Vlc.DotNet/pull/326)

# 2.2.0
- CHANGED versionning model to adopt [SEMVER 2.0](http://semver.org/)
- FIXED #[74](https://github.com/ZeBobo5/Vlc.DotNet/issues/74) by adding support for UTF-8 in options #[302](https://github.com/ZeBobo5/Vlc.DotNet/pull/302)
- FIXED #[305](https://github.com/ZeBobo5/Vlc.DotNet/issues/305) by String interop conversions are now made in UTF-8 and avoid memory leaks #[306](https://github.com/ZeBobo5/Vlc.DotNet/pull/306) #[310](https://github.com/ZeBobo5/Vlc.DotNet/pull/310)
- FIXED #[276](https://github.com/ZeBobo5/Vlc.DotNet/issues/276) by changing NuGet package folder structure #[309](https://github.com/ZeBobo5/Vlc.DotNet/pull/309)
- FIXED potential NullReferenceException when using an uninitialized instance #[312](https://github.com/ZeBobo5/Vlc.DotNet/pull/312)
- ADDED support for netstandard 1.3 and 2.0 #[308](https://github.com/ZeBobo5/Vlc.DotNet/pull/308)
- ADDED Playing from a Stream object #[315](https://github.com/ZeBobo5/Vlc.DotNet/pull/315) and #[317](https://github.com/ZeBobo5/Vlc.DotNet/pull/317)
- ADDED a method `VlcManager.CreateNewMediaFromFileDescriptor` #[314](https://github.com/ZeBobo5/Vlc.DotNet/pull/314)
- ADDED methods `VlcMediaPlayerInstance.SetVideoCallbacks` and `VlcMediaPlayerInstance.SetVideoFormatCallbacks` #[313](https://github.com/ZeBobo5/Vlc.DotNet/pull/313)
- ADDED overload methods to `TakeSnapshot` to be able to specify the size of the snapshot (Fixes #[211](https://github.com/ZeBobo5/Vlc.DotNet/issues/211)) #[320](https://github.com/ZeBobo5/Vlc.DotNet/pull/320)
- ADDED public getter `VlcMediaPlayer` on WinForms `VlcControl` #[321](https://github.com/ZeBobo5/Vlc.DotNet/pull/321)
- CHANGED visibility of `Manager` in `VlcMediaPlayer` to make it public #[321](https://github.com/ZeBobo5/Vlc.DotNet/pull/321)

# 2.1.154
- Nothing, just a few commits to change README files

# 2.1.151
- FIXED: Log messages are emitted on another thread to avoid locking VLC #[284](https://github.com/ZeBobo5/Vlc.DotNet/pull/284)

# 2.1.149
- ADDED: Feature to get VLC logs from Vlc.DotNet #[278](https://github.com/ZeBobo5/Vlc.DotNet/pull/278)

# 2.1.144
- Nothing for the library, just a modification for the code examples #[277](https://github.com/ZeBobo5/Vlc.DotNet/pull/277)

# 2.1.142
- FIXED: Library is now AnyCPU! #[271](https://github.com/ZeBobo5/Vlc.DotNet/pull/271)
