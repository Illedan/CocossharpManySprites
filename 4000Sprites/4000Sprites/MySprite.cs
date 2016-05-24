using System;
using CocosSharp;

namespace manySprites
{
	public class MySprite : CCSprite
	{
		private static CCTexture2D BirdTexture = new CCTexture2D ("Bird.png");

		public MySprite () : base(BirdTexture)
		{
			Position = Utilities.GenerateBirdPosition ();
			Scale = 0.1f;
		}
	}
}

