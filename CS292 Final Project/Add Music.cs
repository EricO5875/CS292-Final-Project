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
    public partial class Add_Music : Form
    {
        public String[] musicToAdd;
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
            foreach(int i in chkLstAddMusic.CheckedIndices)
            {
                musicToAdd[count] = chkLstAddMusic.Items[i].ToString();
                Console.WriteLine(chkLstAddMusic.Items[i].ToString());
                count++;
            }
        }
    }
}
