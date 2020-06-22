using InteractiveApp.ViewModels;
using WhiteMvvm.Services.Locator;

namespace InteractiveApp.Constants
{
    public static class Locator
    {
        public static void Initialize()
        {
            LocatorService.Instance.Register<MainViewModel>(ControlType.SingleTone);
            LocatorService.Instance.Register<FingerPaintingViewModel>(ControlType.SingleTone);
        }
    }
}