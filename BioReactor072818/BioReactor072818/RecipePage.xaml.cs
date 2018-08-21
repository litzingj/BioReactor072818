

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using System.Diagnostics;
using BioReactor072818.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BioReactor072818
{
    
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipePage : ContentPage
	{
        
		public RecipePage ()
		{
			InitializeComponent ();
		}

        void OnDateSelected (object sender, DateChangedEventArgs e)
        {

        }

        void OnChemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        void OnAddSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }



        async void OnAddAdditive(object sender, EventArgs e)
        {
           
            Additive add = new Additive();
            var recipe = (Recipe)BindingContext;
            MessagingCenter.Subscribe<PopupPage, string>(this, "OK", (page, arg) => {
                Debug.Print(add.Name);
                add.Name = arg;
                recipe.Additives.Add(add);
            });
            
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopupPage(App.ADDITIVE_t){BindingContext = add}, true);
            MessagingCenter.Unsubscribe<PopupPage>(this, "OK");
        }

        async void OnAddChemical(object sender, EventArgs e)
        {
            Chemical chem = new Chemical();
            MessagingCenter.Subscribe<PopupPage, string>(this, "OK", (page, args) => {
                var recipe = (Recipe)BindingContext;
                chem.Name = args;
                recipe.Chemicals.Add(chem);
            });

            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopupPage(App.CHEMICAL_t) { BindingContext = chem }, true);
            MessagingCenter.Unsubscribe<PopupPage>(this, "OK");
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            var rec = (Recipe)BindingContext;

            if(await DisplayAlert("Confirm Recipe", "Are you sure all this inforation is correct?", "Yes", "No"))
            {
                if(await DisplayAlert("Continue", "Clicking continue will start the batch. Would you like to proceed?", "Continue", "No"))
                {
                    rec.WriteToFile();
                    /*
                     * 
                     * 
                     *  START THE PROCESS 
                     * 
                     * 
                     * 
                     */

                     await Navigation.PopToRootAsync();
                }
            }
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var rec = (Recipe)BindingContext;
            Chemicals.ItemsSource = rec.Chemicals;
            Additives.ItemsSource = rec.Additives;
        }

    }
}