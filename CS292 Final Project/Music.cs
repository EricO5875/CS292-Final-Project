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

        public Music(string fileName, string title, string[] artists, string year, string album, string trackNumber, string[] genres)
        {
            this.fileName = fileName;
            this.title = title;

            for (int i = 0; i < artists.Length; i++)
            {
                artist = artists[i] + ", ";
            }

            this.year = year;
            this.album = album;
            this.trackNumber = trackNumber;

            for (int i = 0; i < genre.Length; i++)
            {
                genre = genres[i] + ", ";

            }
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

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
    } 
}
