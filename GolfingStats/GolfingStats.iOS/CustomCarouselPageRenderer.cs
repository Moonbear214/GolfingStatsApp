using GolfingStats.Controls;
using System;
using System.Collections.Generic;
using System.Text;

using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CarouselPage), typeof(CustomCarouselPageRenderer))]
namespace GolfingStats.Controls
{
    public class CustomCarouselPageRenderer : CarouselPageRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            UIView view = this.NativeView;
            UIScrollView scrollView = (UIKit.UIScrollView)view.Subviews[0];
            scrollView.ShowsVerticalScrollIndicator = false;
            scrollView.ContentSize = new CoreGraphics.CGSize(scrollView.ContentSize.Width, scrollView.Frame.Size.Height);
            AutomaticallyAdjustsScrollViewInsets = false;
        }
    }
}

