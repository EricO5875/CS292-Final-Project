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

        TagLib.File tagFile = TagLib.File.Create("Green Forest.mp3");

        private void btnPlay_Click(object sender, EventArgs e)
        {
            uint year = tagFile.Tag.Year;
            Console.WriteLine(year);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.ColumnCount = 3;
            dgv.Columns[0].Name = "Title";
            dgv.Columns[1].Name = "Year";
            dgv.Columns[2].Name = "Album";

        }

        private void btnLoadMusic_Click(object sender, EventArgs e)
        {
            dgv.ClearSelection();
            var musicFiles = Directory.EnumerateFiles(txtFilePath.Text, "*.mp3");
            foreach (string s in musicFiles)
            {
                TagLib.File tagFile = TagLib.File.Create(s);
                Console.WriteLine(s);
                Console.WriteLine(tagFile.Tag.Album);
                displayData(tagFile.Tag.Title, tagFile.Tag.Year.ToString(), tagFile.Tag.Album);
            }
        }

        private void displayData(string title, string year, string album)
        {
            string[] row = new string[] { title, year, album };
            dgv.Rows.Add(row);

        }
    }
}
