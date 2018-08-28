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
using System.Collections.ObjectModel;

namespace BioReactor072818
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeSelect : ContentPage
    {

        private Vessel ves;
        public RecipeSelect(Vessel v)
        {
            ves = v;
            InitializeComponent();
            CreateExampleRec();
        }


        void CreateExampleRec()
        {
            ObservableCollection<Chemical> Chems = new ObservableCollection<Chemical>
            {
                new Chemical{Name="Chemical"},
            };
            ObservableCollection<Additive> Adds = new ObservableCollection<Additive>
            {
                new Additive{Name="Additive"},
            };
            DateTime date = DateTime.Today;
            TimeSpan time = new TimeSpan(5, 2, 8);
            date = date + time;
            Recipe r = new Recipe
            {
                Name = "Example",
                Descript = "This is where you write notes",
                Additives = Adds,
                Chemicals = Chems,
                Strain = "Strain",
                DateUsed = date,
                TimeUsed = time,
                ID = 0

            };
            r.WriteToFile();
        }

        /// <summary>
        /// When page appears
        /// </summary>
        protected override void OnAppearing()
        {
            Debug.Print("Beginning to show page");

            CreateExampleRec();
            String[] files = Directory.GetFiles(App.EXTERN_PUBLIC_PATH, "*.recipe");
            ObservableCollection<Recipe> StoredRecipes = new ObservableCollection<Recipe>();

            for(int i = 0; i < files.Length; i++)
            {
                Recipe rec = new Recipe(files[i]);
               // rec.DEBUG_PRINT();
                StoredRecipes.Add(rec);
            }
           
          
            RecipeList.ItemsSource = StoredRecipes;

            base.OnAppearing();
          
        }

        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Recipe r = e.SelectedItem as Recipe;
                if (await DisplayAlert("", "Would you like to open " + r.Name + "?", "Yes", "No"))
                {
                    //populate the recipe edit page
                    await Navigation.PushAsync(new RecipePage
                    {
                        BindingContext = e.SelectedItem as Recipe,
                        vessel = ves
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
            if(await DisplayAlert("", "Are you sure you want to create a new recipe?", "Yes", "Cancel"))
            {

                //go to add recipe page
                await Navigation.PushAsync(new RecipePage
                {
                    BindingContext = new Recipe(),
                    vessel = ves
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