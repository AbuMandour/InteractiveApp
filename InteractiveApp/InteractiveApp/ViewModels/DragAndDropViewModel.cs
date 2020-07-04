using System.Windows.Input;
using WhiteMvvm.Bases;
using Xamarin.Forms;

namespace InteractiveApp.ViewModels
{
    public class DragAndDropViewModel : BaseViewModel
    {
        public ICommand DropReceivedCommand { get; set; }

        public DragAndDropViewModel()
        {
            DropReceivedCommand = new Command(OnDropReceived);
        }

        private void OnDropReceived(object obj)
        {
            
        }
    }
}