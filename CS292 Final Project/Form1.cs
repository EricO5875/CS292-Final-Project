using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CS292_Final_Project
{
    public partial class Form1 : Form
    {
        IWavePlayer waveOutDevice;
        Mp3FileReader mp3;

        bool stopped = false;
        bool musicAdded = false;
        bool paused = false;
        string filePath;

        MusicDBUtils dbUtils = new MusicDBUtils();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play(filePath);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            waveOutDevice.Pause();
            paused = true;
        }


        private void Play(string filePath)
        {
            Console.WriteLine("Playing Song!");
            if (!paused)
            {
                try
                {
                    waveOutDevice.Stop();
                    stopped = true;
                } catch { }

                waveOutDevice = new WaveOut();

                try
                {
                    mp3 = new Mp3FileReader(filePath);
                    waveOutDevice.Init(mp3);
                    waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(WaveOutDevice_PlaybackStopped);
                    waveOutDevice.Volume = 0.25f;
                    waveOutDevice.Play();


                    btnRaise.Enabled = true;
                    btnLower.Enabled = true;
                } catch { }
            } else
            {
                waveOutDevice.Play();
                paused = false;
            }
        }

        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (!stopped)
            {
                int selectedRowIndex;
                DataGridViewRow selectedRow;
                if (dgvMusic.RowCount > dgvMusic.SelectedCells[0].RowIndex + 1)
                {
                    selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex + 1;
                    selectedRow = dgvMusic.Rows[selectedRowIndex];
                    selectedRow.Selected = true;
                    filePath = selectedRow.Cells["colFilePath"].Value.ToString();
                    Play(filePath);
                } else
                {
                    dgvMusic.Rows[0].Selected = true;
                    selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                    selectedRow = dgvMusic.Rows[selectedRowIndex];
                    filePath = selectedRow.Cells["colFilePath"].Value.ToString();
                    Play(filePath);
                }
            }
            stopped = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRaise.Enabled = false;
            btnLower.Enabled = false;
            displayData();
        }

        private void displayData()
        {
            dgvMusic.DataSource = dbUtils.GetAllMusic();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            dataChanged = true;
            Edit_Music edit = new Edit_Music();
            edit.Show();
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
                dbUtils.Add(temp);
                Program.musicList.Add(temp);
                displayData();
                Console.WriteLine("Done");
            }
            Program.musicToAdd.Clear();
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            Add_Music newForm = new Add_Music();
            newForm.Show();
            musicAdded = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (musicAdded)
            {
                try {
                    AddMusic();
                    musicAdded = false;
                } catch { }
            }
        }

        private void dgvMusic_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine(dgvMusic.SelectedCells.Count);
            if (dgvMusic.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
                filePath = selectedRow.Cells["FilePath"].Value.ToString();
                paused = false;
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
