using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMedia : IDisposable
    {
        public string Title
        {
            get { return GetMetaData(MediaMetadatas.Title); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Title, value); }
        }

        public string Artist
        {
            get { return GetMetaData(MediaMetadatas.Artist); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Artist, value); }
        }

        public string Genre
        {
            get { return GetMetaData(MediaMetadatas.Genre); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Genre, value); }
        }

        public string Copyright
        {
            get { return GetMetaData(MediaMetadatas.Copyright); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Copyright, value); }
        }

        public string Album
        {
            get { return GetMetaData(MediaMetadatas.Album); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Album, value); }
        }

        public string TrackNumber
        {
            get { return GetMetaData(MediaMetadatas.TrackNumber); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.TrackNumber, value); }
        }

        public string Description
        {
            get { return GetMetaData(MediaMetadatas.Description); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Description, value); }
        }

        public string Rating
        {
            get { return GetMetaData(MediaMetadatas.Rating); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Rating, value); }
        }

        public string Date
        {
            get { return GetMetaData(MediaMetadatas.Date); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Date, value); }
        }

        public string Setting
        {
            get { return GetMetaData(MediaMetadatas.Setting); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Setting, value); }
        }

        public string URL
        {
            get { return GetMetaData(MediaMetadatas.URL); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.URL, value); }
        }

        public string Language
        {
            get { return GetMetaData(MediaMetadatas.Language); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Language, value); }
        }

        public string NowPlaying
        {
            get { return GetMetaData(MediaMetadatas.NowPlaying); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.NowPlaying, value); }
        }

        public string Publisher
        {
            get { return GetMetaData(MediaMetadatas.Publisher); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.Publisher, value); }
        }

        public string EncodedBy
        {
            get { return GetMetaData(MediaMetadatas.EncodedBy); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.EncodedBy, value); }
        }

        public string ArtworkURL
        {
            get { return GetMetaData(MediaMetadatas.ArtworkURL); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.ArtworkURL, value); }
        }

        public string TrackID
        {
            get { return GetMetaData(MediaMetadatas.TrackID); }
            set { myVlcMediaPlayer.Manager.SetMediaMeta(MediaInstance, MediaMetadatas.TrackID, value); }
        }

        public void Parse()
        {
            myVlcMediaPlayer.Manager.ParseMedia(MediaInstance);
        }

        public void ParseAsync()
        {
            myVlcMediaPlayer.Manager.ParseMediaAsync(MediaInstance);
        }

        private string GetMetaData(MediaMetadatas metadata)
        {
            if (MediaInstance == IntPtr.Zero)
                return null;
            if (myVlcMediaPlayer.Manager.IsParsedMedia(MediaInstance))
                myVlcMediaPlayer.Manager.ParseMedia(MediaInstance);
            return myVlcMediaPlayer.Manager.GetMediaMeta(MediaInstance, metadata);
        }
    }
}