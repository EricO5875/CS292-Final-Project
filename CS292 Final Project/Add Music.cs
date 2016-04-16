using System;
using System.IO;
using System.Windows.Forms;

namespace CS292_Final_Project
{
    public partial class Add_Music : Form
    {
        public Add_Music()
        {
            InitializeComponent();
        }

        private void btnLoadMusic_Click(object sender, EventArgs e)
        {
            string fileName = "";
            try
            {
                var musicFiles = Directory.EnumerateFiles(txtFilePath.Text, "*.mp3");
                foreach (string s in musicFiles)
                {
                    TagLib.File tagFile = TagLib.File.Create(s);
                    Console.WriteLine(txtFilePath.Text.Length);
                    Console.WriteLine(s.Length);
                    fileName = s.Substring(txtFilePath.Text.Length + 1, s.Length - txtFilePath.Text.Length - 1);
                    chkLstAddMusic.Items.Add(fileName);
                }
            }
            catch
            {
                Console.WriteLine("Error at " + fileName);

            }
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            int count = 0;
            string filePath = txtFilePath.Text;
            Program.musicToAdd.Add(filePath);
            foreach(object itemChecked in chkLstAddMusic.CheckedItems)
            {
                Program.musicToAdd.Add((string)itemChecked);
                Console.WriteLine(itemChecked.ToString());
                count++;
            }
            this.Close();
        }
    }
}
