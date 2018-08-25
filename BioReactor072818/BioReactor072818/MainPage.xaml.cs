using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BioReactor072818.Models;

namespace BioReactor072818
{
	public partial class MainPage : ContentPage
	{

        public Vessel[] vessels { get; set; }
		public MainPage(Vessel[] ves)
		{
			InitializeComponent();
            Title = "BMES Bio Reactor";
            vessels = ves;
		}


        /// <summary>
        /// If container one is pressed, check to see if the corresponding vessel is already running.
        /// If it is running, display data page, if not, display the prerun checklist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Container_One_Pressed(object sender, EventArgs e)
        {
            if (!vessels[0].running)
                await Navigation.PushAsync(new PrerunCheckoff(vessels[0]));
            else
                await Navigation.PushAsync(new DataPage(vessels[0]));
        }

        /// <summary>
        /// If container two is pressed, check to see if the corresponding vessel is already running.
        /// If it is running, display data page, if not, display the prerun checklist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Container_Two_Pressed(object sender, EventArgs e)
        {
            if (!vessels[1].running)
                await Navigation.PushAsync(new PrerunCheckoff(vessels[1]));
            else
                await Navigation.PushAsync(new DataPage(vessels[1]));
            
        }


        /// <summary>
        /// If container three is pressed, check to see if the corresponding vessel is already running.
        /// If it is running, display data page, if not, display the prerun checklist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Container_Three_Pressed(object sender, EventArgs e)
        {
            if (!vessels[2].running)
                await Navigation.PushAsync(new PrerunCheckoff(vessels[2]));
            else
                await Navigation.PushAsync(new DataPage(vessels[2]));

        }

        private void All_Vessels(object sender, EventArgs e)
        {

        }

    }
}
