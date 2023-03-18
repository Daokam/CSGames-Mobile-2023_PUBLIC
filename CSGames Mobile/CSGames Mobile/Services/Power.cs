using System;
namespace CSGames_Mobile.Services
{
	public class Power
	{
		private double power_levels;

		public Power(double power_levels)
		{
			this.power_levels = power_levels;
		}

		public double Power_levels => power_levels;
	}
}

