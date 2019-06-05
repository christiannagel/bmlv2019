using System;
using System.Collections.Generic;
using System.Windows.Input;

using UWPWithWindowsTemplateStudio.Helpers;
using UWPWithWindowsTemplateStudio.Services;
using UWPWithWindowsTemplateStudio.Views;

using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace UWPWithWindowsTemplateStudio.ViewModels
{
    public class ShellViewModel : Observable
    {
        private readonly KeyboardAccelerator _altLeftKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu);
        private readonly KeyboardAccelerator _backKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.GoBack);
        private IList<KeyboardAccelerator> _keyboardAccelerators;

        private ICommand _loadedCommand;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuViewsWebView1Command;
        private ICommand _menuViewsMediaPlayer1Command;
        private ICommand _menuViewsMasterDetail1Command;
        private ICommand _menuViewsContentGrid1Command;
        private ICommand _menuViewsDataGrid1Command;
        private ICommand _menuViewsChart1Command;
        private ICommand _menuViewsTabbed1Command;
        private ICommand _menuViewsMap1Command;
        private ICommand _menuViewsCamera1Command;
        private ICommand _menuViewsImageGallery1Command;
        private ICommand _menuViewsInkDraw1Command;
        private ICommand _menuViewsInkSmartCanvas1Command;
        private ICommand _menuFileExitCommand;

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        public ICommand MenuViewsWebView1Command => _menuViewsWebView1Command ?? (_menuViewsWebView1Command = new RelayCommand(OnMenuViewsWebView1));

        public ICommand MenuViewsMediaPlayer1Command => _menuViewsMediaPlayer1Command ?? (_menuViewsMediaPlayer1Command = new RelayCommand(OnMenuViewsMediaPlayer1));

        public ICommand MenuViewsMasterDetail1Command => _menuViewsMasterDetail1Command ?? (_menuViewsMasterDetail1Command = new RelayCommand(OnMenuViewsMasterDetail1));

        public ICommand MenuViewsContentGrid1Command => _menuViewsContentGrid1Command ?? (_menuViewsContentGrid1Command = new RelayCommand(OnMenuViewsContentGrid1));

        public ICommand MenuViewsDataGrid1Command => _menuViewsDataGrid1Command ?? (_menuViewsDataGrid1Command = new RelayCommand(OnMenuViewsDataGrid1));

        public ICommand MenuViewsChart1Command => _menuViewsChart1Command ?? (_menuViewsChart1Command = new RelayCommand(OnMenuViewsChart1));

        public ICommand MenuViewsTabbed1Command => _menuViewsTabbed1Command ?? (_menuViewsTabbed1Command = new RelayCommand(OnMenuViewsTabbed1));

        public ICommand MenuViewsMap1Command => _menuViewsMap1Command ?? (_menuViewsMap1Command = new RelayCommand(OnMenuViewsMap1));

        public ICommand MenuViewsCamera1Command => _menuViewsCamera1Command ?? (_menuViewsCamera1Command = new RelayCommand(OnMenuViewsCamera1));

        public ICommand MenuViewsImageGallery1Command => _menuViewsImageGallery1Command ?? (_menuViewsImageGallery1Command = new RelayCommand(OnMenuViewsImageGallery1));

        public ICommand MenuViewsInkDraw1Command => _menuViewsInkDraw1Command ?? (_menuViewsInkDraw1Command = new RelayCommand(OnMenuViewsInkDraw1));

        public ICommand MenuViewsInkSmartCanvas1Command => _menuViewsInkSmartCanvas1Command ?? (_menuViewsInkSmartCanvas1Command = new RelayCommand(OnMenuViewsInkSmartCanvas1));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ShellViewModel()
        {
        }

        public void Initialize(Frame shellFrame, SplitView splitView, Frame rightFrame, IList<KeyboardAccelerator> keyboardAccelerators)
        {
            NavigationService.Frame = shellFrame;
            MenuNavigationHelper.Initialize(splitView, rightFrame);
            _keyboardAccelerators = keyboardAccelerators;
        }

        private void OnLoaded()
        {
            // Keyboard accelerators are added here to avoid showing 'Alt + left' tooltip on the page.
            // More info on tracking issue https://github.com/Microsoft/microsoft-ui-xaml/issues/8
            _keyboardAccelerators.Add(_altLeftKeyboardAccelerator);
            _keyboardAccelerators.Add(_backKeyboardAccelerator);
        }

        private void OnMenuViewsMain() => MenuNavigationHelper.UpdateView(typeof(MainPage));

        private void OnMenuViewsWebView1() => MenuNavigationHelper.UpdateView(typeof(WebView1Page));

        private void OnMenuViewsMediaPlayer1() => MenuNavigationHelper.UpdateView(typeof(MediaPlayer1Page));

        private void OnMenuViewsMasterDetail1() => MenuNavigationHelper.UpdateView(typeof(MasterDetail1Page));

        private void OnMenuViewsContentGrid1() => MenuNavigationHelper.UpdateView(typeof(ContentGrid1Page));

        private void OnMenuViewsDataGrid1() => MenuNavigationHelper.UpdateView(typeof(DataGrid1Page));

        private void OnMenuViewsChart1() => MenuNavigationHelper.UpdateView(typeof(Chart1Page));

        private void OnMenuViewsTabbed1() => MenuNavigationHelper.UpdateView(typeof(Tabbed1Page));

        private void OnMenuViewsMap1() => MenuNavigationHelper.UpdateView(typeof(Map1Page));

        private void OnMenuViewsCamera1() => MenuNavigationHelper.UpdateView(typeof(Camera1Page));

        private void OnMenuViewsImageGallery1() => MenuNavigationHelper.UpdateView(typeof(ImageGallery1Page));

        private void OnMenuViewsInkDraw1() => MenuNavigationHelper.UpdateView(typeof(InkDraw1Page));

        private void OnMenuViewsInkSmartCanvas1() => MenuNavigationHelper.UpdateView(typeof(InkSmartCanvas1Page));

        private void OnMenuFileExit()
        {
            Application.Current.Exit();
        }

        private static KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
        {
            var keyboardAccelerator = new KeyboardAccelerator() { Key = key };
            if (modifiers.HasValue)
            {
                keyboardAccelerator.Modifiers = modifiers.Value;
            }

            keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;
            return keyboardAccelerator;
        }

        private static void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            var result = NavigationService.GoBack();
            args.Handled = result;
        }
    }
}
