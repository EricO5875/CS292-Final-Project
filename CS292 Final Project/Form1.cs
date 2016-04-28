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

        //Prevents the next song event from firing when the play button is pressed.
        bool stopped = false;

        bool musicAdded = false;
        bool paused = false;
        string filePath;

        MusicDBUtils dbUtils = new MusicDBUtils();

        public Form1()
        {
            InitializeComponent();
        }

        //Plays the selected song.
        private void Play(string filePath)
        {
            //Checks to see if there is a currently paused song.
            if (!paused)
            {
                //Stops the current playing song if there is one.
                try
                {
                    waveOutDevice.Stop();
                    stopped = true;
                }
                catch { }

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
                } catch (System.IO.FileNotFoundException e1)
                {
                    lblStatus.Text = "Could not find file.";
                } catch (Exception e2)
                {
                    Console.WriteLine("null");
                }

            } else
            {
                waveOutDevice.Play();
                paused = false;
            }
        }


        //Plays the next song when the current one is finished.
        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            //Prevents the event from firing when the play button is clicked.
            if (!stopped)
            {
                int selectedRowIndex;
                DataGridViewRow selectedRow;

                //Plays the songs in a random order.
                if (radShuffle.Checked)
                {
                    Random rand = new Random();
                    int song = rand.Next(0, dgvMusic.RowCount);
                    selectedRowIndex = song;
                    selectedRow = dgvMusic.Rows[selectedRowIndex];
                    selectedRow.Selected = true;
                    filePath = selectedRow.Cells["FilePath"].Value.ToString();
                    Play(filePath);

                //Repeats the current selected song.
                } else if (radLoop.Checked) {
                    filePath = getSelectedFile();
                    Play(filePath);

                //Plays the next song in the list.
                } else if (dgvMusic.RowCount > dgvMusic.SelectedCells[0].RowIndex + 1)
                {
                    selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex + 1;
                    selectedRow = dgvMusic.Rows[selectedRowIndex];
                    selectedRow.Selected = true;
                    filePath = selectedRow.Cells["FilePath"].Value.ToString();
                    Play(filePath);
                
                //Plays the first song in the list when at the end.
                } else
                {
                    dgvMusic.Rows[0].Selected = true;
                    selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                    selectedRow = dgvMusic.Rows[selectedRowIndex];
                    filePath = selectedRow.Cells["FilePath"].Value.ToString();
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

        //Gets the filepath of the selected row.
        private string getSelectedFile()
        {
            int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
            filePath = selectedRow.Cells["FilePath"].Value.ToString();
            return filePath;
        }

        //Displays the data from the database.
        private void displayData()
        {
            dgvMusic.DataSource = dbUtils.GetAllMusic();
        }

        //Removes the selected song from the database.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            filePath = getSelectedFile();
            dbUtils.Delete(filePath);
            lblStatus.Text = dbUtils.LastStatus;
            displayData();
        }

        //Brings up a new window to edit the information.
        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            Edit_Music edit = new Edit_Music();
            edit.Show();
        }

        //Brings up a new window to add music.
        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            Add_Music newForm = new Add_Music();
            newForm.Show();
            musicAdded = true;
        }


        //Adds music to the database when songs are selected from the add music window.
        private void AddMusic()
        {
            if (Program.musicToAdd.Count != 0)
            {
                string folderPath = Program.musicToAdd.ElementAt(0);
                for (int i = 1; i < Program.musicToAdd.Count; i++)
                {
                    string file = Program.musicToAdd[i];
                    TagLib.File tagFile = TagLib.File.Create(folderPath + "\\" + file);
                    string fileName = file;
                    string title = tagFile.Tag.Title;
                    string[] artist = tagFile.Tag.Performers;
                    int year = int.Parse(tagFile.Tag.Year.ToString());
                    string album = tagFile.Tag.Album;
                    string[] genre = tagFile.Tag.Genres;

                    Music temp = new Music(fileName, title, artist, year, album, genre, folderPath + "\\" + file);
                    dbUtils.Add(temp);
                    lblStatus.Text = dbUtils.LastStatus;
                    displayData();
                }
                Program.musicToAdd.Clear();
            }
        }

        //Adds music to the database if there is any and displays the new information.
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (musicAdded)
            {
                AddMusic();
                musicAdded = false;
                displayData();
            }
        }

        //Sets the filePath string to the filepath of the newly selected row.
        private void dgvMusic_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusic.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
                filePath = selectedRow.Cells["FilePath"].Value.ToString();
                paused = false;
            }
        }

        //Plays the selected song.
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play(filePath);
        }

        //Exits the program.
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Pauses the current song.
        private void btnPause_Click(object sender, EventArgs e)
        {
            waveOutDevice.Pause();
            paused = true;
        }

        //Raises the volume of the song.
        private void btnRaise_Click_1(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            int volume;
            int.TryParse(lblVolume.Text.TrimEnd('%'), out volume);
            if (volume < 100)
            {
                waveOutDevice.Volume += .01f;
                lblVolume.Text = "" + (int.Parse(lblVolume.Text.TrimEnd('%')) + 1) + "%";
            } else
            {
                lblStatus.Text = "Can't raise volume above 100!";
            }
        }

        //Lowers the volume of the song.
        private void btnLower_Click_1(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            int volume;
            int.TryParse(lblVolume.Text.TrimEnd('%'), out volume);
            if (volume > 0)
            {
                waveOutDevice.Volume -= .01f;
                lblVolume.Text = "" + (int.Parse(lblVolume.Text.TrimEnd('%')) - 1) + "%";
            } else 
            {
                lblStatus.Text = "Can't lower volume below 0!";
            }
        }
    }
}
