using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BioReactor072818.Data;
using BioReactor072818.Models;

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
            if(PrerunCheckoff.database.Contains(todoItem))
                PrerunCheckoff.database.Remove(todoItem);
            //Asynchronously pop this page off the top of the views stack
            await Navigation.PopAsync();
        }
         
        async void OnSaveClicked(object sender, EventArgs e)
        {
            //Get the todoItem
            var todoItem = (TodoItem)BindingContext;

            //Replace if need be
            bool replacing = false;
            for (int i = 0; i < PrerunCheckoff.database.Count; i++)
            {
                if(PrerunCheckoff.database[i] == todoItem)
                {
                    PrerunCheckoff.database[i] = todoItem;
                    replacing = true;
                }
            }
            //if it is new, add it
            if (!replacing)
                PrerunCheckoff.database.Add(todoItem);
            
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