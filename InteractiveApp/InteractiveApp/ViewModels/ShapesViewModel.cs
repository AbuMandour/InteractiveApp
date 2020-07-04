using System.Windows.Input;
using WhiteMvvm.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace InteractiveApp.ViewModels
{
    public class ShapesViewModel : BaseViewModel
    {
        public ICommand DropReceivedCommand { get; set; }
        public ShapesViewModel()
        {
            DropReceivedCommand = new Command(OnDropReceived);
        }

        private void OnDropReceived(object obj)
        {
            
        }
    }
}