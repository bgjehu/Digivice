using System;
using Mono.Data.Sqlite;
using SQLite;
using System.IO;
using Foundation;
using System.Linq;


namespace DigiviceAlpha
{
	public enum LocalDB
	{
		GameData
	}

	public static class DB
	{
		#region Initializa

		public static void Init ()
		{
			foreach (LocalDB localDB in Enum.GetValues(typeof(LocalDB))) {
				Init (localDB);
			}
		}

		private static void Init (LocalDB localDB)
		{
			var databaseString = localDB.ToDBString ();
			if (!File.Exists (databaseString)) {
				SqliteConnection.CreateFile (databaseString);
				var conn = TradConn (localDB);
				conn.Open ();
				var command = conn.CreateCommand ();
				command.CommandText = File.ReadAllText (localDB.ToString () + "DBInit.txt");
				command.ExecuteNonQuery ();
				conn.Close ();
			}
		}

		/// <summary>
		/// Connectino in traditional fashion
		/// </summary>
		/// <returns>The conn.</returns>
		/// <param name="localDB">Local D.</param>
		public static SqliteConnection TradConn (LocalDB localDB)
		{
			var databaseString = localDB.ToDBString ();
			return new SqliteConnection ("Data Source=" + databaseString);
		}

		#endregion

		#region Public Utilities

		/// <summary>
		/// Connection in Object Relational Mapping fashion
		/// </summary>
		/// <returns>The OS conn.</returns>
		/// <param name="localDB">Local D.</param>
		public static SQLiteConnection ORMConn (LocalDB localDB)
		{
			var databaseString = localDB.ToDBString ();
			return new SQLiteConnection (databaseString, false);
		}

		#endregion


		#region Private Utilities

		public static string ToDBString (this LocalDB localDB)
		{
			var iOSDocumentsFolder = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User) [0].ToDecodedString ();
			var databaseString = Path.Combine (iOSDocumentsFolder, localDB.ToString () + ".db");
			return databaseString;
		}


		public static void Delete (LocalDB localDB)
		{
			var databaseString = localDB.ToDBString ();
			File.Delete (databaseString);
		}

		#endregion

		#region Temp

		public static DigimonProfile GetDigimon (int id)
		{
			using (var conn = ORMConn (LocalDB.GameData)) {
				var result = conn.Get<DigimonProfile> (id);
				return result;
			}
		}

		#endregion

	}
}

