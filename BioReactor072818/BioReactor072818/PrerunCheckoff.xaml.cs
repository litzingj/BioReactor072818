using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using SQLite;
using BioReactor072818.Data;
using BioReactor072818.Models;
using System.Collections.ObjectModel;

namespace BioReactor072818
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrerunCheckoff : ContentPage
    {
        /// <summary>
        /// Database to hold all of the items in the checklist
        /// </summary>
        //TODO: Make a method that deletes all the tasks nonasync
        public static ObservableCollection<TodoItem> database { get; set; }

        public PrerunCheckoff(Vessel currVessel)
        {
            Vessel = currVessel;
            database = new ObservableCollection<TodoItem>();
            InitializeComponent();
            //CreateTasksDebug();
            CreateTasks();
            CheckComplete();

        }


        private void CreateTasksDebug()
        {
            TodoItem td = new TodoItem
            {
                Name = "Check/Secure Probes/Ports",
                Notes = "",
                Done = true,
            };
            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Check Sensor Calibrations",
                Notes = "",
                Done = true,
            };
            if (!database.Contains(td))
                database.Add(td);

            td = new TodoItem
            {
                Name = "Prepare Media",
                Notes = "",
                Done = true,
            };

            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Set Up Initial Conditions",
                Notes = "",
                Done = true,
            };
            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Prepare Additives",
                Notes = "",
                Done = true,
            };

            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Check and Prime Gas Lines",
                Notes = "",
                Done = true,
            };

            if (!database.Contains(td))
                database.Add(td);
        }




        /// <summary>
        /// A method to create all the things needed to checkoff
        /// </summary>
        private void CreateTasks()
        {

            TodoItem td = new TodoItem
            {
                Name = "Check/Secure Probes/Ports",
                Notes = "",
                Done = false,
            };
            if(!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Check Sensor Calibrations",
                Notes = "",
                Done = false,
            };
            if (!database.Contains(td))
                database.Add(td);

            td = new TodoItem
            {
                Name = "Prepare Media",
                Notes = "",
                Done = false,
            };

            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Set Up Initial Conditions",
                Notes = "",
                Done = false,
            };
            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Prepare Additives",
                Notes = "",
                Done = false,
            };

            if (!database.Contains(td))
                database.Add(td);
            td = new TodoItem
            {
                Name = "Check and Prime Gas Lines",
                Notes = "",
                Done = false,
            };

            if (!database.Contains(td))
                database.Add(td);
        }




      //namespace System.Windows.Forms.MessageBox.Show("Test");



    /// <summary>
    /// Pop all existing pages off the stack
    /// </summary>
    async void OnHomeClicked()
        {
            //Go to the base page  
            await Navigation.PopToRootAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = database;
            CheckComplete();
        }


        private Vessel Vessel{get; set;}


        /// <summary>
        /// This adds a new item. If the plus is selected, a new item is created
        /// and passed to the TodoItemPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnItemAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        /// <summary>
        /// If an item is selected on the screen, it will bring up a page
        /// (TodoItemPage using Navigation.PushAsync) and pass it the 
        /// selected item as an argument using BindingContext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                
                //For editable and viewable descriptions
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
            listView.ItemsSource = database;

        }

        async void CheckComplete()
        {
            
            if (database.Count <= 0)
                return;

            foreach (TodoItem item in database)
            {
                if (!item.Done)
                {
                    return;
                }
            }
            //Dialog to continue
            string message = "Initial set up for vessel " + Vessel.ID + " complete. Would you like to continue to recipes?";
            bool cont = await DisplayAlert("", message, "Continue", "Cancel");
            if (cont)
            {

                //recipe page
                await Navigation.PushAsync(new RecipeSelect(Vessel));
            }
            else
            {
                foreach(TodoItem i in database)
                {
                    i.Done = false;
                }
            }
        }
    }
}