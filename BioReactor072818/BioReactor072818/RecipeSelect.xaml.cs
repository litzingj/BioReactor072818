using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace BioReactor072818
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeSelect : ContentPage
    {
        public static TodoItemDatabase recipeDatabase;

        public RecipeSelect()
        {
            Debug.Print("Recipe Selection");
            InitializeComponent();
            Debug.Print("Recipe Sel Initialized");
        }

        /// <summary>
        /// Recipes database
        /// </summary>
        public static TodoItemDatabase Recipes
        {
            get
            {
                if (recipeDatabase == null)
                {
                    recipeDatabase = new TodoItemDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PreviousRecipes.db3"));
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
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            RecipeList.ItemsSource = await Recipes.GetItemsAsync();
        }

        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Recipe r = e.SelectedItem as Recipe;
                if (await DisplayAlert("Confirm Recipe", "Would you like to open " + r.Name + "?", "Yes", "No"))
                {
                    //populate the recipe edit page
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