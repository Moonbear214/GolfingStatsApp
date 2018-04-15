using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(GolfingStats.iOS.CustomContentPageRenderer))]
namespace GolfingStats.iOS
{
    class CustomContentPageRenderer : PageRenderer
    {
        public new ContentPage Element
        {
            get { return (ContentPage)base.Element; }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ConfigureToolbarItems();
        }

        private void ConfigureToolbarItems()
        {
            if (NavigationController != null)
            {
                UINavigationItem navigationItem = NavigationController.TopViewController.NavigationItem;
                var orderedItems = Element.ToolbarItems.OrderBy(x => x.Priority);

                // add right side items
                var rightItems = orderedItems.Where(x => x.Priority >= 0).Select(x => x.ToUIBarButtonItem()).ToArray();
                navigationItem.SetRightBarButtonItems(rightItems, false);

                // add left side items
                var leftItems = orderedItems.Where(x => x.Priority < 0).Select(x => x.ToUIBarButtonItem()).ToArray();
                //if (navigationItem.LeftBarButtonItems != null) // keep any already there(Bug, adds button multiple times)
                //    leftItems = navigationItem.LeftBarButtonItems.Union(leftItems).ToArray();
                navigationItem.SetLeftBarButtonItems(leftItems, false);
            }
        }
    }
}