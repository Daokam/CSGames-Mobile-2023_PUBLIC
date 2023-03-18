using System;
namespace CSGames_Mobile.Services
{
	public class Air
	{
		private int int_air_quality;

		public Air(int int_air_quality)
		{
			this.int_air_quality = int_air_quality;
		}

		public int Int_air_quality => int_air_quality;
	}
}

