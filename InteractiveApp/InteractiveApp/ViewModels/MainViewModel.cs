using System.Threading.Tasks;
using System.Windows.Input;
using WhiteMvvm.Bases;
using WhiteMvvm.Services.Locator;
using WhiteMvvm.Services.Navigation;
using WhiteMvvm.Utilities;

namespace InteractiveApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand GoToFingerPaintingCommand { get; set; }
        public ICommand GoToLocalVideoCommand { get; set; }
        public ICommand GoToLocalSoundCommand { get; set; }
        public ICommand GoToDragAndDropCommand { get; set; }
        public ICommand GoToShapesCommand { get; set; }
        public MainViewModel()
        {
            GoToFingerPaintingCommand = new TaskCommand(OnGoToFingerPainting);
            GoToLocalVideoCommand = new TaskCommand(OnGoToLocalVideo);
            GoToLocalSoundCommand = new TaskCommand(OnGoToLocalSound);
            GoToDragAndDropCommand = new TaskCommand(GoToDragAndDrop);
            GoToShapesCommand = new TaskCommand(GoToShapes);
        }

        private Task GoToShapes()
        {
            return NavigationService.NavigateToAsync<ShapesViewModel>();
        }

        private Task GoToDragAndDrop()
        {
            return NavigationService.NavigateToAsync<DragAndDropViewModel>();
        }

        private Task OnGoToLocalSound()
        {
            return NavigationService.NavigateToAsync<LocalSoundViewModel>();
        }

        private Task OnGoToLocalVideo()
        {
            return NavigationService.NavigateToAsync<LocalVideoViewModel>();
        }

        private Task OnGoToFingerPainting()
        {
            return NavigationService.NavigateToAsync<FingerPaintingViewModel>();
        }
    }
}