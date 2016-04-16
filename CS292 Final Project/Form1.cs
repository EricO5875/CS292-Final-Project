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
        string filePath = "";
        DataTable dt = new DataTable();
        List<Music> music = new List<Music>();
        bool dataChanged = false;
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        bool musicAdded = false;

        TagLib.File tagFile = TagLib.File.Create("Green Forest.mp3");

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try {
                waveOutDevice.Stop();
            } catch { }
            waveOutDevice = new WaveOut();
            try {
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
                waveOutDevice.Volume = 0.25f;
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
            btnRaise.Enabled = false;
            btnLower.Enabled = false;

        }

        private void displayData(Music temp)
        {
            string genreString = "";
            //foreach (string s in temp.Genres)
            //{
            //    genreString += s + ", ";
            //}
            if (!genreString.Equals(""))
            {
                genreString = genreString.Substring(0, genreString.Length - 2);
            }

            string artistString = "";
            //foreach (string s in temp.Artist)
            //{
            //    artistString += s + ", ";
            //}
            if (!artistString.Equals(""))
            {
                artistString = artistString.Substring(0, artistString.Length - 2);
            }
            string[] row = new string[] { temp.Title, artistString, temp.Year, temp.Album, genreString, temp.FileName, temp.FilePath };
            dgvMusic.Rows.Add(row);

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
            dgvMusic.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnRaise_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            try {
                waveOutDevice.Volume += .01f;
                lblVolume.Text = "" + (int.Parse(lblVolume.Text.TrimEnd('%')) + 1) + "%";
            } catch
            {
                lblStatus.Text = "Can't raise volume above 100!";
            }
        }
 
        private void btnLower_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            try {
                waveOutDevice.Volume -= .01f;
                lblVolume.Text = "" + (int.Parse(lblVolume.Text.TrimEnd('%')) - 1) + "%";
            } catch
            {
                lblStatus.Text = "Can't lower volume below 0!";
            }
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
            string fileName = "";
            string folderPath = Program.musicToAdd.ElementAt(0);
            for (int i = 1; i < Program.musicToAdd.Count; i++)
            {
                string file = Program.musicToAdd[i];
                TagLib.File tagFile = TagLib.File.Create(folderPath + "\\" + file);
                fileName = file;
                string title = tagFile.Tag.Title;
                string[] artist = tagFile.Tag.Performers;
                string year = tagFile.Tag.Year.ToString();
                string album = tagFile.Tag.Album;
                string[] genre = tagFile.Tag.Genres;
                string trackNumber = tagFile.Tag.Track.ToString();
                Music temp = new Music(fileName, title, artist, year, album, trackNumber, genre, folderPath + "\\" + file);

                music.Add(temp);
                displayData(temp);
                Console.WriteLine("Done");
            }
            Program.musicToAdd.Clear();
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

        private void dgvMusic_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusic.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
                filePath = selectedRow.Cells["colFilePath"].Value.ToString();
            }
        }

        private void btnRaise_Click_1(object sender, EventArgs e)
        {
            try 
            {
                waveOutDevice.Volume += .01f;
                lblVolume.Text = (int.Parse(lblVolume.Text.Trim('%')) + 1).ToString() + "%";
            } catch
            {
                lblStatus.Text = "Cannot raise above 100.";
            }
        }

        private void btnLower_Click_1(object sender, EventArgs e)
        {
            try
            {
                waveOutDevice.Volume -= .01f;
                lblVolume.Text = (int.Parse(lblVolume.Text.Trim('%')) - 1).ToString() + "%";
            }
            catch
            {
                lblStatus.Text = "Cannot lower below 0.";
            }
        }
    }
}
