using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehavior: DependencyObject, IBehavior
    {
        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            if (this.AssociatedObject is Page)
            {
                (this.AssociatedObject as Page).RightTapped += WarningDialog_RightTapped;
            }
        }

        private async void WarningDialog_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            await new MessageDialog("Thank you for trying the demo.", "Thank you").ShowAsync();
        }

        public void Detach()
        {
            (this.AssociatedObject as Page).RightTapped -= WarningDialog_RightTapped;
        }

        public DependencyObject AssociatedObject { get; private set; }
    }
}
