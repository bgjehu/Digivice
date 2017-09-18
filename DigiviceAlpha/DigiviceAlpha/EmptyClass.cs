using System;
using System.Threading.Tasks;

namespace temp
{

	public class YourFutureEmployee : CoolGuy
	{
		static readonly char[] Name = "Jieyi Hu".ToCharArray ();

		Task DoItNow = Task.Run (() => E.mail ("BEJEHU@ME.COM"));

		//	Address:	2209 Tenbrink Drive, Rolla, MO, 65401

		var Phone = DateTime.Now != "23:00" ? 3146000288 : "Zzzzz";

		public bool HiredHim { get { return true; } set; }
	}

	public class CoolGuy
	{

	}

	public class Eamil
	{

	}

	public static class E
	{
		public void mail (string str);
	}
}

