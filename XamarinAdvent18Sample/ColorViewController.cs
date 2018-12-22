using System;
using UIKit;
using Foundation;

namespace XamarinAdvent18Sample
{
    public class ColorViewController : UIViewController
    {
        private UIColor _color;

        public ColorViewController(UIColor color)
        {
            this._color = color;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.ApplyColor();

            var tapGesture = new UITapGestureRecognizer(this.HandleTap);

            // Approach B;
            // var tapGesture = new UITapGestureRecognizer(this, new ObjCRuntime.Selector(nameof(HandleTap)));


            this.View.AddGestureRecognizer(tapGesture);
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            base.DidMoveToParentViewController(parent);
            // approach A;
            /*
            if (parent == null)
            {
                foreach (var recognizer in this.View.GestureRecognizers)
                {
                    this.View.RemoveGestureRecognizer(recognizer);
                }
            }
            */
        }

        [Action(nameof(HandleTap))]
        private void HandleTap()
        {
            this._color.GetRGBA(out _, out _, out _, out var oldAlpha);
            var newAlpha = oldAlpha - 0.1f;
            if (newAlpha < 0.1f) newAlpha = 1f;
            this._color = this._color.ColorWithAlpha(newAlpha);
            this.ApplyColor();
        }

        private void ApplyColor()
        {
            this.View.BackgroundColor = this._color;

            this._color.GetRGBA(out var r, out var g, out var b, out var _);
            this.NavigationItem.Title = $"#{(int) (r * 255):X2}{(int) (g * 255):X2}{(int) (b * 255):X2}";
        }

        ~ColorViewController()
        {
            System.Diagnostics.Debug.WriteLine($"{nameof(ColorViewController)} has finalized.");
        }
    }
}
