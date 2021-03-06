﻿using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Espera.Core;
using Rareform.Patterns.MVVM;

namespace Espera.View.ViewModels
{
    public class SongViewModel : SongViewModelBase<SongViewModel>
    {
        private BitmapImage thumbnail;

        public Song Model
        {
            get { return this.Wrapped; }
        }

        public ImageSource Thumbnail
        {
            get
            {
                var song = this.Model as YoutubeSong;

                return song == null
                           ? null
                           : (this.thumbnail ?? (this.thumbnail = new BitmapImage(song.ThumbnailSource)));
            }
        }

        public string Description
        {
            get
            {
                var song = this.Model as YoutubeSong;

                return song == null ? null : song.Description;
            }
        }

        public string Path
        {
            get { return this.Model.OriginalPath; }
        }

        public ICommand OpenPathCommand
        {
            get
            {
                return new RelayCommand(param => Process.Start(this.Path));
            }
        }

        public double? Rating
        {
            get
            {
                var song = this.Model as YoutubeSong;

                return song != null && song.Rating > 0 ? (double?)song.Rating : null;
            }
        }

        public SongViewModel(Song model)
            : base(model)
        { }
    }
}