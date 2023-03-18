using System;
namespace CSGames_Mobile.Services
{
	public class Temperature
	{
		private double ext_water_temp;
		private double int_temp;

        public Temperature(double ext_water_temp, double int_temp)
		{
			this.ext_water_temp = ext_water_temp;
			this.int_temp = int_temp;
		}

        public double Ext_water_temp => ext_water_temp;
		public double Int_temp => int_temp;	
    }
}

