using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS292_Final_Project
{
    class Music
    {
        private string fileName;
        private string title;
        private string artist;
        private string year;
        private string album;
        private string trackNumber;
        private string genre;
        private string filePath;

        public Music(string fileName, string title, string[] artists, string year, string album, string trackNumber, string[] genres, string filePath)
        {
            this.fileName = fileName;
            this.title = title;

            if (artists != null)
            {
                for (int i = 0; i < artists.Length; i++)
                {
                    artist = artists[i] + ", ";
                }
                artist = artist.Substring(0, artist.Length - 2);
            }

            this.year = year;
            this.album = album;
            this.trackNumber = trackNumber;
            this.genre = "";
            //if (genres != null)
            //{
            //    for (int i = 0; i < genre.Length; i++)
            //    {
            //        genre = genres[i] + ", ";

            //    }
            //}
            //genre = genre.Substring(0, genre.Length - 2);
            this.filePath = filePath;

        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Album
        {
            get { return album; }
            set { album = value; }
        }

        public string TrackNumber
        {
            get { return trackNumber; }
            set { trackNumber = value; }
        }

        public string Genres
        {
            get { return genre; }
            set { genre = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
    } 
}
