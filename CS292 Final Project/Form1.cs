using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS292_Final_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        List<Music> music = new List<Music>();
        bool dataChanged = false;
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        WaveChannel32 wave;
        bool musicAdded = false;

        TagLib.File tagFile = TagLib.File.Create("Green Forest.mp3");

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try {
                waveOutDevice.Stop();
            } catch { }
            waveOutDevice = new WaveOut();
            Console.WriteLine(dgv.Rows.GetRowCount(DataGridViewElementStates.Selected));
            int rowIndex = dgv.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgv.Rows[rowIndex];
            Console.WriteLine(txtFilePath.Text + "\\" + selectedRow.Cells["colFileName"].Value.ToString());
            try {
                audioFileReader = new AudioFileReader(txtFilePath.Text + "\\" + selectedRow.Cells["colFileName"].Value.ToString());
                
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
                wave.Volume = 0.5f;
                btnRaise.Enabled = true;
                btnLower.Enabled = true;
            } catch {
                Console.WriteLine("Failed to play song.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnLoadMusic_Click(object sender, EventArgs e)
        {
            dgv.ClearSelection();
            string fileName = "";
            try {
                var musicFiles = Directory.EnumerateFiles(txtFilePath.Text, "*.mp3");
                foreach (string s in musicFiles)
                {
                    TagLib.File tagFile = TagLib.File.Create(s);
                    Console.WriteLine(txtFilePath.Text.Length);
                    Console.WriteLine(s.Length);
                    fileName = s.Substring(txtFilePath.Text.Length + 1, s.Length - txtFilePath.Text.Length - 1);
                    string title = tagFile.Tag.Title;
                    string[] artist = tagFile.Tag.Performers;
                    string year = tagFile.Tag.Year.ToString();
                    string album = tagFile.Tag.Album;
                    string[] genre = tagFile.Tag.Genres;
                    string trackNumber = tagFile.Tag.Track.ToString();
                    string filePath = txtFilePath.Text;
                    Music temp = new Music(fileName, title, artist, year, album, trackNumber, genre, filePath);

                    music.Add(temp);
                    displayData(temp);
                }
            } catch
            {
                Console.WriteLine("Error at " + fileName);

            }
        }

        private void displayData(Music temp)
        {
            string genreString = "";
            //foreach (string s in temp.Genres)
            //{
            //    genreString += s + ", ";
            //}
            //if (!genreString.Equals("")) { 
            //    genreString = genreString.Substring(0, genreString.Length - 2);
            //}

            //string artistString = "";
            //foreach (string s in temp.Artist)
            //{
            //    artistString += s + ", ";
            //}
            //if (!artistString.Equals(""))
            //{
            //    artistString = artistString.Substring(0, artistString.Length - 2);
            //}
            //string[] row = new string[] { temp.Title, artistString, temp.Year, temp.Album, genreString, temp.FileName, temp.FilePath };
            //dgv.Rows.Add(row);

        }

        private void saveData()
        {
            foreach(Music m in music)
            {
                String fileName = m.FileName;
                String title = m.Title;
                String artist = m.Artist;
                String year = m.Year;
                String album = m.Album;
                String genre = m.Genres;
                

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged)
            {
                MessageBox.Show("There were some changes made to the database.  Would you like to save them?", "", MessageBoxButtons.YesNoCancel);
                saveData();
            }
            
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            dataChanged = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnRaise_Click(object sender, EventArgs e)
        {
            wave.Volume += .01f;
            lblVolume.Text = "" + (int.Parse(lblVolume.Text.TrimEnd('%')) + 1);
        }

        private void Shuffle()
        {
            Random rand = new Random();
            int val1;
            int val2;
            for (int i = 0; i < 50; i++)
            {
                val1 = rand.Next(music.Count);
                val2 = rand.Next(music.Count);
                Music temp = music[val1];
                music[val1] = music[val2];
                music[val2] = temp;
            }
        }

        private void AddMusic()
        {
            
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            Add_Music newForm = new Add_Music();
            newForm.Show();
            //String test = newForm.musicToAdd[0];
            musicAdded = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (musicAdded)
            {
                AddMusic();
                musicAdded = false;
            }
        }
    }
}
