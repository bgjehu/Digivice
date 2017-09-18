using System;
using CoreGraphics;
using Foundation;
using SpriteKit;
using UIKit;

namespace DigiviceAlpha
{
	public class GameScene : SKScene
	{


		public GameScene (IntPtr handle) : base (handle)
		{
			Size = EX.DeviceScreen.Size;
			ScaleMode = SKSceneScaleMode.AspectFit;
			AnchorPoint = new CGPoint (0.5, 0.5);
			BackgroundColor = UIColor.Green;
		}

		public GameScene () : base ()
		{
			
		}

		public override void DidMoveToView (SKView view)
		{
			AddChild (new Digivice ());
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{

		}

		public override void Update (double currentTime)
		{
			// Called before each frame is rendered
		}
	}
}

