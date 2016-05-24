using System;
using System.Collections.Generic;
using CocosSharp;

namespace manySprites
{
    public class GameLayer : CCLayerColor
    {
		private CCNode _containingNode;

        public GameLayer() : base (CCColor4B.AliceBlue)
        {
			_containingNode = new CCNode (){Position = new CCPoint(Constants.HalfWidth, Constants.HalfHeight)};
			for (int i = 0; i < Constants.NumSprites; i++) {
				_containingNode.AddChild (new MySprite ());
			}
			AddChild (_containingNode);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            var touchListener = new CCEventListenerTouchAllAtOnce();
			touchListener.OnTouchesMoved = OnTouchesMoved;

            AddEventListener(touchListener, this);
        }

		void OnTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
			if (touches.Count == 1) {
				MoveContainingNode ((touches [0].Location.X - touches [0].PreviousLocation.X),
					(touches [0].Location.Y - touches [0].PreviousLocation.Y));
			} else if (touches.Count == 2) {
				Zoom (touches [0].PreviousLocation, touches [1].PreviousLocation,
					touches [0].Location, touches [1].Location);
			}
        }

		private void MoveContainingNode(float dX, float dY){
			_containingNode.PositionX += dX;
			_containingNode.PositionY += dY;
		}

		private void Zoom(
			CCPoint touch1Location1, 
			CCPoint touch2Location1, 
			CCPoint touch1Location2, 
			CCPoint touch2Location2){
			var distance1 = CCPoint.Distance (touch1Location1, touch2Location1);
			var distance2 = CCPoint.Distance (touch1Location2, touch2Location2);

			_containingNode.ScaleX += (distance2 - distance1) * Constants.ScalingFactor;
			_containingNode.ScaleY += (distance2 - distance1) * Constants.ScalingFactor;

			if (_containingNode.ScaleX < 0) {
				_containingNode.ScaleX = 0.0f;
			}
			if (_containingNode.ScaleY < 0) {
				_containingNode.ScaleY = 0.0f;
			}
		}
    }
}
