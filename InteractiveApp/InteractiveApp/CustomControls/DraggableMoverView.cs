using WhiteMvvm.CustomControls.DragAndDrop;
using WhiteMvvm.Extensions;
using Xamarin.Forms;

namespace InteractiveApp.CustomControls
{
    public class DraggableMoverView : View , IDragAndDropMovingView
    {
        public double ScreenX { get; set; }
        public double ScreenY { get; set; }
        protected override void OnParentSet()
        {
            base.OnParentSet();
            this.InitializeDragAndDrop();
        }
    }
}