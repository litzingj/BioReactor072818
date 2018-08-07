using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BioReactor072818
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage ()
		{
			InitializeComponent ();
		}

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //Get the todoItem referenced through the BindingContext
            //Passed in when this page is created
            var todoItem = (TodoItem)BindingContext;
            //Asynchronously delete this item from the database
            await PrerunCheckoff.Database.DeleteItemAsync(todoItem);
            //Asynchronously pop this page off the top of the views stack
            await Navigation.PopAsync();
        }
         
        async void OnSaveClicked(object sender, EventArgs e)
        {
            //Get the todoItem
            var todoItem = (TodoItem)BindingContext;
            //await pushing the item onto the database
            await PrerunCheckoff.Database.SaveItemAsync(todoItem);
            //pop this page off the stack
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            //pop page off, no need to do anything
            await Navigation.PopAsync();
        }
    }
}