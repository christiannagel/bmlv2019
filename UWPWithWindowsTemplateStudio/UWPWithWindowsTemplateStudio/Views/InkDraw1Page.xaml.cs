using System;

using UWPWithWindowsTemplateStudio.Services.Ink;
using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    // For more information regarding Windows Ink documentation and samples see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/ink.md
    public sealed partial class InkDraw1Page : Page
    {
        public InkDraw1ViewModel ViewModel { get; } = new InkDraw1ViewModel();

        public InkDraw1Page()
        {
            InitializeComponent();

            Loaded += (sender, eventArgs) =>
            {
                SetCanvasSize();

                var strokeService = new InkStrokesService(inkCanvas.InkPresenter);
                var selectionRectangleService = new InkSelectionRectangleService(inkCanvas, selectionCanvas, strokeService);

                ViewModel.Initialize(
                    strokeService,
                    new InkLassoSelectionService(inkCanvas, selectionCanvas, strokeService, selectionRectangleService),
                    new InkPointerDeviceService(inkCanvas),
                    new InkCopyPasteService(strokeService),
                    new InkUndoRedoService(inkCanvas, strokeService),
                    new InkFileService(inkCanvas, strokeService),
                    new InkZoomService(canvasScroll));
            };
        }

        private void SetCanvasSize()
        {
            inkCanvas.Width = Math.Max(canvasScroll.ViewportWidth, 1000);
            inkCanvas.Height = Math.Max(canvasScroll.ViewportHeight, 1000);
        }
    }
}
