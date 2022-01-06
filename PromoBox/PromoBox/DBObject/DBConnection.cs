using System;
using System.IO;

namespace PromoBox.DBObject
{
    public static class DBConnection
    {
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbPromoBox.db3");
    }
}
