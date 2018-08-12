using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BioReactor072818.Models
{
	public class Recipe
	{
		public Recipe ()
        {
           /* ID = 0;
            Name = "";
            Descript = "";
            Strain = "";
            DateUsed = DateTime.Today;
            Chemicals = new List<Chemical>();
            Additives = new List<Additive>();*/
           
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }
        public string Strain { get; set; }
        public List<Chemical> Chemicals { get; set; }
        public DateTime DateUsed { get; set; }
        public List<Additive> Additives { get; set; }
	}
}