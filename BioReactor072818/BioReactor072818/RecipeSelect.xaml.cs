using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using BioReactor072818.Models;
using BioReactor072818.Data;

namespace BioReactor072818
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeSelect : ContentPage
    {
        public static RecipeDatabase recipeDatabase;

        public RecipeSelect()
        {
            Debug.Print("Recipe Selection");
            InitializeComponent();
            Debug.Print("Recipe Sel Initialized");
        }

        /// <summary>
        /// Recipes database
        /// </summary>
        public static RecipeDatabase Recipes
        {
            get
            {
                if (recipeDatabase == null)
                {
                    recipeDatabase = new RecipeDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipes.db3"));
                }
                return recipeDatabase;
            }
        }

        /// <summary>
        /// When page appears
        /// </summary>
        protected async override void OnAppearing()
        {
            Debug.Print("Beginning to show page");
            List<Chemical> Chems = new List<Chemical>
            {
                new Chemical{Name="Chemical"},
            };
            List<Additive> Adds = new List<Additive>
            {
                new Additive{Name="Additive"},
            };
            Recipe r = new Recipe
            {
                Name = "Example",
                Descript = "This is where you write notes",
                Additives = Adds,
                Chemicals = Chems,
                Strain = "Strain",
                DateUsed = DateTime.Today,
                ID = 0
                
            };

            try
            {
                await Recipes.SaveItemAsync(r);
            }
            catch(Exception e)
            {
                Debug.Print(e.Source);
                Debug.Print("Error saving new recipe");
                Debug.Print(e.Message);
                Debug.Print(e.StackTrace);
            }
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            /*
             * 
             * 
             * 
             * Left off here, needing to find out why this call is timing out
             * It has something to do with changing the database type for some reason.
             * Maybe the 
             * 
             * 
             * 
             * 
             */
            try
            {
                RecipeList.ItemsSource = await Recipes.GetItemsNotDoneAsync();//await Recipes.GetItemsAsync();
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
                Debug.Print("SOMETHING WENT WRONG SOURCING THE RECIPES");
            }
                Debug.Print("Recipes Sourced");
        }

        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Recipe r = e.SelectedItem as Recipe;
                if (await DisplayAlert("Confirm Recipe", "Would you like to open " + r.Name + "?", "Yes", "No"))
                {
                    //populate the recipe edit page
                    await Navigation.PushAsync(new RecipePage
                    {
                        BindingContext = r
                    });
                    
                }
                else
                {
                    //do nothing
                }
            }
        }

        async void OnRecipeAdd(object sender, EventArgs e)
        {
            if(await DisplayAlert("New Recipe", "Are you sure you want to create a new recipe?", "Yes", "Cancel"))
            {
                
                //go to add recipe page
                await Navigation.PushAsync(new RecipePage
                {
                    BindingContext = new Recipe()
                });
            }
            else
            {
                //do nothing
            }
        }

        async void OnHomeClicked()
        {
            await Navigation.PopToRootAsync();
        }
    }
}