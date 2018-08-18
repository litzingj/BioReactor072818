using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BioReactor072818.Models;


namespace BioReactor072818
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupPage : Rg.Plugins.Popup.Pages.PopupPage
	{
		public PopupPage (int typeOfList, string txt="Name")
		{
			InitializeComponent ();
            switch (typeOfList)
            {
                case App.CHEMICAL_t:
                    DialogTitle.Text = "New Chemical";
                    break;

                case App.ADDITIVE_t:
                    DialogTitle.Text = "New Additive";
                    break;

                default:
                    DialogTitle.Text = "New Item";
                    break;
            }
            ItemName.Placeholder = txt;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void OnOk()
        {
            MessagingCenter.Send<PopupPage, string>(this, "OK", ItemName.Text);
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync(true);
        }

        private async void OnCancel()
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync(true);
        }
    }
}