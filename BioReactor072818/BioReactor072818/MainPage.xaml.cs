using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BioReactor072818
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}


        async void Container_One_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrerunCheckoff(1));
        }

        private void Container_Two_Pressed(object sender, EventArgs e)
        {

        }


        private void Container_Three_Pressed(object sender, EventArgs e)
        {

        }

        private void All_Vessels(object sender, EventArgs e)
        {

        }

    }
}
