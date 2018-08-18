﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;

namespace BioReactor072818.Models
{
	public class Recipe : BindableObject
	{
		public Recipe ()
        {

            Chemicals = new List<Chemical>();
            Additives = new List<Additive>();
           
        }
        public Recipe(string filename)
        {
            
            Recipe r = ParseFromFile(filename);
            this.Name = r.Name;
            this.ID = r.ID;
            this.Chemicals = r.Chemicals;
            this.Descript = r.Descript;
            this.Additives = r.Additives;
            this.DateUsed = r.DateUsed;
            this.Strain = r.Strain;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }
        public string Strain { get; set; }
        public List<Chemical> Chemicals { get; set; }
        public DateTime DateUsed { get; set; }
        public List<Additive> Additives { get; set; }

        public string[] ParseToFile()
        {
            string[] lines = new string[7+Chemicals.Count+Additives.Count];
            string id = "ID:" + ID.ToString();
            string name = "NAME:" + Name;
            string descript = "DESCRIPT:" + Descript;
            string strain = "STRAIN:" + Strain;
            string date = "DATE:" + DateUsed.ToString("d");
            string chemsHeader = "CHEMICALS:"+Chemicals.Count.ToString();
            string addsHeader = "ADDITIVES:"+Additives.Count.ToString();
            lines[0] = id;
            lines[1] = name;
            lines[2] = descript;
            lines[3] = strain;
            lines[4] = date;
            lines[5] = chemsHeader;
            for(int i = 6; i < Chemicals.Count + 6; i++)
            {
                
                lines[i] = Chemicals[i-6].Name;
             
            }
            lines[6 + Chemicals.Count] = addsHeader;
            for (int i = 0; i < Additives.Count; i++)
            {
                lines[i + 5 + Chemicals.Count + 2] = Additives[i].Name;
            }
            
            return lines;
        }


        

        /// <summary>
        /// Must Check Existence of file before calling this function, use:
        /// File.Exists(Path.Combine(App.EXTERN_PUBLIC_PATH, Name + ".recipe"))
        /// </summary>
        public void WriteToFile()
        {

            string[] lines = ParseToFile();

            using (StreamWriter file = new StreamWriter(Path.Combine(App.EXTERN_PUBLIC_PATH, Name + ".recipe")))
            {
                foreach(string line in lines)
                {

                    file.WriteLine(line);
                }
            }
        }

        public Recipe ParseFromFile(String filename)
        {
            string line;
            Recipe rec = new Recipe();
            using (StreamReader file = new StreamReader(Path.Combine(App.EXTERN_PUBLIC_PATH, filename)))
            {
                while((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    
                    if(parts[0].Equals("NAME"))
                    {
                        rec.Name = parts[1];
                    }
                    else if (parts[0].Equals("ID"))
                    {
                        Int32 id = 0;
                        Int32.TryParse(parts[1], out id);
                        rec.ID = id;
                    }
                    else if (parts[0].Equals("DESCRIPT"))
                    {
                        rec.Descript = parts[1];
                    }
                    else if (parts[0].Equals("STRAIN"))
                    {
                        rec.Strain = parts[1];
                    }
                    else if (parts[0].Equals("DATE"))
                    {
                        rec.DateUsed = DateTime.Parse(parts[1]);
                    }
                    else if (parts[0].Equals("CHEMICALS"))
                    {
                        rec.Chemicals = new List<Chemical>();
                        Int32 i;
                        Int32.TryParse(parts[1], out i);
                        for(int j = 0; j < i; j++)
                        {
                            line = file.ReadLine();
                            Chemical chem = new Chemical();
                            chem.Name = line;
                            rec.Chemicals.Add(chem);
                        }
                    }
                    else if (parts[0].Equals("ADDITIVES"))
                    {
                        rec.Additives = new List<Additive>();
                        Int32 i;
                        Int32.TryParse(parts[1], out i);

                        for (int j = 0; j < i; j++)
                        {
                            line = file.ReadLine();
                            Additive add = new Additive ();
                            add.Name = line;
                            rec.Additives.Add(add);
                        }
                    }
                    
                    
                }
            }
            return rec;
        }


        public void DEBUG_PRINT()
        {
            Debug.Print("DEBUG RECIPE");
            Debug.Print(Name);
            Debug.Print(Descript);
            Debug.Print(Strain);
            Debug.Print(DateUsed.ToString());
            foreach(Chemical chem in Chemicals)
            {
                Debug.Print(chem.Name);
            }
            foreach(Additive ad in Additives)
            {
                Debug.Print(ad.Name);
            }
        }
	}
}