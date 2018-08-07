using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BioReactor072818
{
	public class Recipe
	{
		public Recipe (){ }

        public string Name { get; set; }
        public string Descript { get; set; }
        public string Strain { get; set; }
        public List<string> Chemicals { get; set; }
        public DateTime DateUsed { get; set; }
        public List<string> Additives { get; set; }
	}
}