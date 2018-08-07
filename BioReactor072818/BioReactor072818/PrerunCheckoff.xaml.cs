﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BioReactor072818
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrerunCheckoff : ContentPage
    {
        /// <summary>
        /// Database to hold all of the items in the checklist
        /// </summary>
        static TodoItemDatabase database;

        public PrerunCheckoff()
        {
            InitializeComponent();
            createTasks();
        }

        /// <summary>
        /// A method to create all the things needed to checkoff
        /// </summary>
        async void createTasks()
        {

            TodoItem td = new TodoItem
            {
                Name = "Check/Secure Probes/Ports",
                Notes = "",
                Done = false,
            };
            await Database.SaveItemAsync(td);
            td = new TodoItem
            {
                Name = "Check Sensor Calibrations",
                Notes = "",
                Done = false,
            };
            await Database.SaveItemAsync(td);
            td = new TodoItem
            {
                Name = "Prepare Media",
                Notes = "",
                Done = false,
            };
            await Database.SaveItemAsync(td);
            td = new TodoItem
            {
                Name = "Set Up Initial Conditions",
                Notes = "",
                Done = false,
            };
            await Database.SaveItemAsync(td);
            td = new TodoItem
            {
                Name = "Prepare Additives",
                Notes = "",
                Done = false,
            };
            await Database.SaveItemAsync(td);
            td = new TodoItem
            {
                Name = "Check and Prime Gas Lines",
                Notes = "",
                Done = false,
            };
            await Database.SaveItemAsync(td);
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await Database.GetItemsAsync();
        }

        
        /// <summary>
        /// Create a database if there isn't already one, else return that one
        /// </summary>
        public static TodoItemDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new TodoItemDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

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
                
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}