using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioReactor072818.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BioReactor072818
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DataPage : TabbedPage
	{
		public DataPage (Vessel v)
		{
            //Takes away Navbar at the top, but also takes away the large padding on top
            NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent ();
            DO_Graph.BindingContext = v;
            ph_Graph.BindingContext = v;
            Temp_Graph.BindingContext = v;
            Curr_Cond.BindingContext = v;

		}
	}
}