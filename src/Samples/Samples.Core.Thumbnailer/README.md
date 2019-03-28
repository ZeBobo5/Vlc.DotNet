# Thumbnailer sample

A .NET core application showing how to use the TakeSnapshot feature to get images from a video. This is not optimized at all, since you must play the whole video in order to get all the frames.

Please note : you can't use this method to get all frames from the video, as the `TimeChanged` event can be triggered very infrequently.
It's more a way to extract some pictures from the video. If you really need each frame, you should try `SetVideoFormatCallbacks`, as done in Vlc.DotNet.Wpf ( /!\ Expect performance impact )