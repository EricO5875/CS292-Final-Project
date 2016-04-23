using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS292_Final_Project
{
    public partial class Edit_Music : Form
    {
        public Edit_Music()
        {
            InitializeComponent();
        }

        private void displayData()
        {
            foreach (Music m in Program.musicList)
            {
                dgvMusic.Rows.Clear();
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
                string[] row = new string[] { m.Title, artistString, m.Year, m.Album, genreString, m.FileName, m.FilePath };
                dgvMusic.Rows.Add(row);
            }

        }

        private void dgvMusic_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusic.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
                txtTitle.Text = selectedRow.Cells["colTitle"].Value.ToString();
                txtArtist.Text = selectedRow.Cells["colArtist"].Value.ToString();
                txtYear.Text = selectedRow.Cells["colYear"].Value.ToString();
                txtAlbum.Text = selectedRow.Cells["colAlbum"].Value.ToString();
                txtGenre.Text = selectedRow.Cells["colGenre"].Value.ToString();
                txtFileName.Text = selectedRow.Cells["colFileName"].Value.ToString();
                lblFilePath.Text = selectedRow.Cells["colFilePath"].Value.ToString();
            }
        }

        private void Edit_Music_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
            Console.WriteLine(selectedRow.Cells["colFilePath"].Value.ToString());
            try
            {
                TagLib.File file = TagLib.File.Create(selectedRow.Cells["colFilePath"].Value.ToString());
                file.Tag.Title = txtTitle.Text;
                file.Tag.Performers = new string[] { txtArtist.Text };
                file.Tag.Genres = new string[] { txtGenre.Text };
                file.Tag.Album = txtAlbum.Text;
                if (!int.TryParse(txtYear.Text, out selectedRowIndex)) {
                    file.Tag.Year = (uint)selectedRowIndex;
                }
                file.Save();
               // System.IO.File.Move(@selectedRow.Cells["colFilePath"].Value.ToString(), @txtFileName.Text);

            }
            catch { }
            displayData();
        }
    }
}
