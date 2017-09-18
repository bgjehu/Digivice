using System;
using System.Web;
using Foundation;
using Newtonsoft.Json;
using UIKit;
using CoreGraphics;

namespace DigiviceAlpha
{
	public static class EX
	{
		public static CGRect ApplicationScreen{ get { return UIScreen.MainScreen.ApplicationFrame; } }

		public static CGRect DeviceScreen{ get { return UIScreen.Screens [0].Bounds; } }

		public static CGRect StatueBar{ get { return new CGRect (0, 0, DeviceScreen.Width, ApplicationScreen.Y); } }

		public static string ToDecodedString (this NSUrl url)
		{
			var decoded = url != null ? HttpUtility.UrlDecode (url.ToString ()) : null;
			var result = decoded != null ? decoded.Replace ("file://", "") : null;
			return result;
		}

		public static string ToJson (this object obj)
		{
			string result;
			if (obj.GetType () == typeof(UIColor)) {
				nfloat R, G, B, A;
				(obj as UIColor).GetRGBA (out R, out G, out B, out A);
				result = new nfloat[]{ R, G, B, A }.ToJson ();
			} else if (obj.GetType () == typeof(CGPoint)) {
				var loc = (CGPoint)obj;
				result = new nfloat[]{ loc.X, loc.Y }.ToJson ();
			} else {
				result = JsonConvert.SerializeObject (obj);
			}
			return result;
		}

		public static UIColor UIColorFromJson (string json)
		{
			var rgba = JsonConvert.DeserializeObject<float[]> (json);
			return UIColor.FromRGBA (rgba [0], rgba [1], rgba [2], rgba [3]);
		}

		public static CGPoint CGPointFromeJson (string json)
		{
			var loc = JsonConvert.DeserializeObject<float[]> (json);
			return new CGPoint (loc [0], loc [1]);
		}
	}
}

