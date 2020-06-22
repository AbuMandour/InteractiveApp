using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using WhiteMvvm.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InteractiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerPaintingPage : BaseContentPage
    {
        private readonly Dictionary<long, SKPath> _inProgressPaths = new Dictionary<long, SKPath>();
        private readonly List<SKPath> _completedPaths = new List<SKPath>();
        private bool ClearRequest { get; set; }

        private readonly SKPaint _paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        public FingerPaintingPage()
        {
            InitializeComponent();
        }
        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!_inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(ConvertToPixel(args.Location));
                        _inProgressPaths.Add(args.Id, path);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (_inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = _inProgressPaths[args.Id];
                        path.LineTo(ConvertToPixel(args.Location));
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (_inProgressPaths.ContainsKey(args.Id))
                    {
                        _completedPaths.Add(_inProgressPaths[args.Id]);
                        _inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (_inProgressPaths.ContainsKey(args.Id))
                    {
                        _inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();
            if (ClearRequest)
            {
                ClearRequest = false;
                _inProgressPaths.Clear(); 
                _completedPaths.Clear();
                return;
            }
            foreach (SKPath path in _completedPaths)
            {
                canvas.DrawPath(path, _paint);
            }

            foreach (SKPath path in _inProgressPaths.Values)
            {
                canvas.DrawPath(path, _paint);
            }
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }

        private void Button_OnClicked(object sender, EventArgs e)
        { 
            ClearRequest = true;
            canvasView.InvalidateSurface();
        }
    }
}