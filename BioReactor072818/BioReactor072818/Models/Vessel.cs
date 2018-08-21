using Com.Syncfusion.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BioReactor072818.Models
{
    public class Vessel : BindableObject
    {
        public Vessel()
        {
            pH_Data = new ObservableCollection<ChartDataPoint>();
            DO2_Data = new ObservableCollection<ChartDataPoint>();
            Temp_Data = new ObservableCollection<ChartDataPoint>();
            populate_demo_data();
        }



        public void populate_demo_data()
        {
            Random rnd = new Random();
            for(int i = 0; i < 50; i++)
            {
                pH_Data.Add(new ChartDataPoint(rnd.Next(1, 30), rnd.Next(1, 30)));
                Temp_Data.Add(new ChartDataPoint(rnd.Next(1, 30), rnd.Next(1, 30)));
                DO2_Data.Add(new ChartDataPoint(rnd.Next(1, 30), rnd.Next(1, 30)));
            }
            pH = rnd.Next(1,14);
            DissolvedO2 = rnd.Next(0, 40);
            Temperature = rnd.Next(20, 70);


        }


        public float pH { get; set; }
        public float DissolvedO2 { get; set; }
        public float Temperature { get; set; }
        public ObservableCollection<ChartDataPoint> pH_Data { get; set; }
        public ObservableCollection<ChartDataPoint> DO2_Data { get; set; }
        public ObservableCollection<ChartDataPoint> Temp_Data { get; set; }

    }
}
