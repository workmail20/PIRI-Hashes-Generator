using DocumentFormat.OpenXml.Office2010.Excel;
using SQLite;

namespace PIRIHashesGenerator.units
{
    public class ConfigItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } = 0;
        public string Userhash { get; set; } = "";
        public string Settings1 { get; set; } = "";
        public string Settings2 { get; set; } = "";
        public string Settings3 { get; set; } = "";
        public string Settings4 { get; set; } = "";
        public string Settings5 { get; set; } = "";
        public string Settings6 { get; set; } = "";
        public string Settings7 { get; set; } = "";
        public string Settings8 { get; set; } = "";
        public string Settings9 { get; set; } = "";
        public string Settings10 { get; set; } = "";
        public string Settings11 { get; set; } = "";
        public string Settings12 { get; set; } = "";
        public string Settings13 { get; set; } = "";
        public string Settings14 { get; set; } = "";
        public string Settings15 { get; set; } = "";

    }
    public static class DBConstants
    {

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
    }
    public class Db_sql
    {
        readonly SQLiteAsyncConnection Database;

        public Db_sql(string path)
        {

            //   File.Delete(path);
            Database = new SQLiteAsyncConnection(path, DBConstants.Flags);
            Task.Run(async () => await Database.CreateTableAsync<ConfigItem>()).Wait();
        }

        public ConfigItem? GetItemAsync(int id)
        {
            ConfigItem? result = null;

            Task.Run(async () =>
            {
                result = await Database.Table<ConfigItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
            }).Wait();

            return result;
        }

        public int SaveItemAsync(ConfigItem item, bool _new)
        {
            int result = 0;

            Task.Run(async () =>
            {
                if (_new == false)
                    result = await Database.UpdateAsync(item);
                else
                    result = await Database.InsertAsync(item);
            }).Wait();
            return result;
        }

        public int DeleteItemAsync(ConfigItem item)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await Database.DeleteAsync(item);
            }).Wait();

            return result;
        }
    }

}
