# Unreleased
- FIXED #[74](https://github.com/ZeBobo5/Vlc.DotNet/issues/74) by adding support for UTF-8 in options #[302](https://github.com/ZeBobo5/Vlc.DotNet/pull/302)
- FIXED #[305](https://github.com/ZeBobo5/Vlc.DotNet/issues/305) by String interop conversions are now made in UTF-8 and avoid memory leaks #[306](https://github.com/ZeBobo5/Vlc.DotNet/pull/306) #[310](https://github.com/ZeBobo5/Vlc.DotNet/pull/310)
- FIXED #[276](https://github.com/ZeBobo5/Vlc.DotNet/issues/276) by changing NuGet package folder structure #[309](https://github.com/ZeBobo5/Vlc.DotNet/pull/309)
- FIXED potential NullReferenceException when using an uninitialized instance #[312](https://github.com/ZeBobo5/Vlc.DotNet/pull/312)
- ADDED support for netstandard 1.3 and 2.0 #[308](https://github.com/ZeBobo5/Vlc.DotNet/pull/308)
- ADDED Playing from a Stream object #[207](https://github.com/ZeBobo5/Vlc.DotNet/pull/207) and #[315](https://github.com/ZeBobo5/Vlc.DotNet/pull/315)
- ADDED a method `VlcManager.CreateNewMediaFromFileDescriptor` #[314](https://github.com/ZeBobo5/Vlc.DotNet/pull/314)
- ADDED methods `VlcMediaPlayerInstance.SetVideoCallbacks` and `VlcMediaPlayerInstance.SetVideoFormatCallbacks` #[313](https://github.com/ZeBobo5/Vlc.DotNet/pull/313)

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
