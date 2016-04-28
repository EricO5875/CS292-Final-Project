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

        private string lastStatus;

        public string LastStatus
        {
            get { return lastStatus; }
        }

        //Adds music to the database.
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

        //Edits the information in the database.
        public bool Edit(string title, string[] artists, int year, string album, string[] genres, string filePath)
        {
            bool isEdited = true;

            string artist = "";
            if (artists.Length != 0)
            {
                foreach(string s in artists)
                {
                    artist += s + ", ";
                }
                artist = artist.Remove(artist.LastIndexOf(','));
            }

            string genre = "";
            if (genres.Length != 0)
            {
                foreach (string s in genres)
                {
                    genre += s + ", ";
                }
                genre = genre.Remove(genre.LastIndexOf(','));
            }

            sql = "UPDATE MUSIC SET Title = '" + title + "', Artist = '" + artist + "', Year = " + year + ", Album = '" + album + "', Genre = '" + genre + "' WHERE FilePath = '" + filePath + "'";

            command = new SQLiteCommand(sql, connection);

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

        //Removes information from the database.
        public bool Delete(string filePath)
        {
            bool isDeleted = true;

            sql = "DELETE FROM Music WHERE FilePath = '" + filePath + "'";

            command = new SQLiteCommand(sql, connection);

            if (!UpdateDatabase(command))
            {
                isDeleted = false;
                lastStatus = "Error removing song.";
            } else
            {
                lastStatus = "Song removed.";
            }

            return isDeleted;
        }
        
        //Returns all values in database.
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

        //Updates the database with respective command.
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
