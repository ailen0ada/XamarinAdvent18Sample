using System;
using UIKit;
using Foundation;
namespace XamarinAdvent18Sample
{
    [Register(nameof(ColorTableViewCell))]
    public partial class ColorTableViewCell : UITableViewCell
    {
        public ColorTableViewCell(IntPtr handle) : base(handle)
        {
        }

        public void UpdateByColor(UIColor color)
        {
            color.GetRGBA(out var r, out var g, out var b, out var _);
            this.TitleLabel.Text = $"#{(int)(r * 255):X2}{(int)(g * 255):X2}{(int)(b * 255):X2}";
            this.TitleLabel.TextColor = color;
        }
    }
}
