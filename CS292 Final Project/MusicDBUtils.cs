using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace CS292_Final_Project
{
    class MusicDBUtils
    {
        private const string dbMusic = "Data Source = Music.db; Version = 3;FailIfMissing = True;";

        private SQLiteConnection connection = new SQLiteConnection(dbMusic);
        private SQLiteDataAdapter dataAdapter;
        private SQLiteCommand command;
        private DataSet dataSet = new DataSet();
        private String sql;

        private const string MUSIC_TABLE = "Music";
        private const string TITLE_COLUMN = "Title";

        private string lastStatus;

        public string LastStatus
        {
            get { return lastStatus; }
        }

        public bool Add(Music m)
        {
            sql = "INSERT INTO Music (Title, Artist, Year, Album, Genre, File Name, File Path) " +
               "VALUES ('" + m.Title + "', '" + m.Artist + "', " + m.Year + ", '" + m.Album + "', '" + m.Genres + "', '" + m.FileName + "', '" + m.FilePath + "')";

            return true;
        }
    }
}
