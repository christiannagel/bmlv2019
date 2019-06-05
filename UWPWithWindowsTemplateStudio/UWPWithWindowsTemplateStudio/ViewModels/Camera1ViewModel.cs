﻿using System;
using System.Windows.Input;

using UWPWithWindowsTemplateStudio.EventHandlers;
using UWPWithWindowsTemplateStudio.Helpers;

using Windows.UI.Xaml.Media.Imaging;

namespace UWPWithWindowsTemplateStudio.ViewModels
{
    public class Camera1ViewModel : Observable
    {
        private ICommand _photoTakenCommand;
        private BitmapImage _photo;

        public BitmapImage Photo
        {
            get { return _photo; }
            set { Set(ref _photo, value); }
        }

        public ICommand PhotoTakenCommand => _photoTakenCommand ?? (_photoTakenCommand = new RelayCommand<CameraControlEventArgs>(OnPhotoTaken));

        private void OnPhotoTaken(CameraControlEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Photo))
            {
                Photo = new BitmapImage(new Uri(args.Photo));
            }
        }
    }
}
