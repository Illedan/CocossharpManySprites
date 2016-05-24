using System;
using CocosSharp;

namespace manySprites
{
	public static class Utilities
	{
		public static Random _random = new Random();

		public static CCPoint GenerateBirdPosition(){
			return new CCPoint (_random.Next (Constants.MinSpriteWidth, Constants.MaxSpriteWidth), 
							_random.Next(Constants.MinSpriteHeight, Constants.MaxSpriteHeight));
		}
	}
}

