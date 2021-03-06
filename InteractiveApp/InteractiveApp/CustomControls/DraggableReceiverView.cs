using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WhiteMvvm.CustomControls.DragAndDrop;
using Xamarin.Forms;

namespace InteractiveApp.CustomControls
{
    public class DraggableReceiverView : View , IDragAndDropReceivingView , IDragAndDropHoverableView
    {
        public static readonly BindableProperty HoveredCommandProperty =
            BindableProperty.Create(
                nameof(HoveredCommand),
                typeof(ICommand),
                typeof(DraggableReceiverView),
                defaultValue: null);
        public ICommand HoveredCommand
        {
            get => (ICommand)GetValue(HoveredCommandProperty);
            set => SetValue(HoveredCommandProperty, value);
        }

        public static readonly BindableProperty DropReceivedCommandProperty =
            BindableProperty.Create(
                nameof(DropReceivedCommand),
                typeof(ICommand),
                typeof(DraggableReceiverView),
                defaultValue: null);
        public ICommand DropReceivedCommand
        {
            get => (ICommand)GetValue(DropReceivedCommandProperty);
            set => SetValue(DropReceivedCommandProperty, value);
        }
        public void OnDropReceived(IDragAndDropMovingView view)
        {
            DropReceivedCommand?.Execute(view);
        }

        public void OnHovered(List<IDragAndDropMovingView> views)
        {
            if (views.Any())
            {
                HoveredCommand?.Execute(views);    
            }
        }
    }
}