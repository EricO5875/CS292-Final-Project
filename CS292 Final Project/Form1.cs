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
        List<TagLib.File> music = new List<TagLib.File>();
        bool dataChanged = false;
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;

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
            Console.WriteLine(txtFilePath.Text + "\\" + selectedRow.Cells["colFileName"]);
            try {
                audioFileReader = new AudioFileReader(txtFilePath.Text + "\\" + selectedRow.Cells["colFileName"].Value.ToString());

                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
            } catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.Anchor =
    AnchorStyles.Bottom |
    AnchorStyles.Right |
    AnchorStyles.Top |
    AnchorStyles.Left;

        }

        private void btnLoadMusic_Click(object sender, EventArgs e)
        {
            dgv.ClearSelection();
            try {
                var musicFiles = Directory.EnumerateFiles(txtFilePath.Text, "*.mp3");
                foreach (string s in musicFiles)
                {
                    TagLib.File tagFile = TagLib.File.Create(s);
                    Console.WriteLine(txtFilePath.Text.Length);
                    Console.WriteLine(s.Length);
                    string fileName = s.Substring(txtFilePath.Text.Length + 1, s.Length - txtFilePath.Text.Length - 1);
                    String title = tagFile.Tag.Title;
                    String year = tagFile.Tag.Year.ToString();
                    String album = tagFile.Tag.Year.ToString();

                    displayData(fileName, tagFile.Tag.Title, tagFile.Tag.Year.ToString(), tagFile.Tag.Album);
                }
            } catch
            {

            }
        }

        private void displayData(string fileName, string title, string year, string album)
        {
            string[] row = new string[] { fileName, title, year, album };
            dgv.Rows.Add(row);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged)
            {

            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
