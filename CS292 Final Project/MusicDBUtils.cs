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
        private const string dbMusic = "Data Source = ../../Music.db; Version = 3;FailIfMissing = True;";

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
            bool isAdded = true;

            sql = "INSERT INTO Music (Title, Artist, Year, Album, Genre, FileName, FilePath) " +
               "VALUES ('" + m.Title + "', '" + m.Artist + "', " + m.Year + ", '" + m.Album + "', '" + m.Genres + "', '" + m.FileName + "', '" + m.FilePath + "')";

            command = new SQLiteCommand(sql, connection);

            if (!UpdateDatabase(command))
            {
                isAdded = false;
                lastStatus = "Error adding to database";
            } else
            {
                lastStatus = "Music added to database.";
            }
            Console.WriteLine(lastStatus);
            return true;
        }

        public bool Edit(string title, string artist, int year, string album, string genre)
        {
            bool isEdited = true;

            sql = "UPDATE MUSIC SET Title = " + title + ", Artist = " + artist + ", Year = " + year + ", Album = " + album + ", Genre = " + genre;

            command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("Title", title);
            command.Parameters.AddWithValue("Artist", artist);
            command.Parameters.AddWithValue("Year", year);
            command.Parameters.AddWithValue("Album", album);
            command.Parameters.AddWithValue("Genre", genre);

            if (!UpdateDatabase(command))
            {
                isEdited = false;
                lastStatus = "Error updating record.";
            } else
            {
                lastStatus = "Music information updated.";
            }

            return isEdited;
        }
        
        public DataTable GetAllMusic()
        {
            connection.Open();
            dataSet = new DataSet();

            sql = "SELECT * FROM Music ORDER BY Title";

            dataAdapter = new SQLiteDataAdapter(sql, connection);
            dataAdapter.Fill(dataSet);
            connection.Close();
            return dataSet.Tables[0];
        }

        public bool UpdateDatabase(SQLiteCommand cmd)
        {
            bool result;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                result = true;
            } catch (Exception ex)
            {
                result = false;
                connection.Close();
            }

            return result;
        }
    }
}
