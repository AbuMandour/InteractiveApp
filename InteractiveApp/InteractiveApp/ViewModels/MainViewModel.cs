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
        public MainViewModel()
        {
            GoToFingerPaintingCommand = new TaskCommand(OnGoToFingerPainting);
            GoToLocalVideoCommand = new TaskCommand(OnGoToLocalVideo);
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