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
        MusicDBUtils dbUtils = new MusicDBUtils();

        public Edit_Music()
        {
            InitializeComponent();
        }

        private void displayData()
        {
            dgvMusic.DataSource = dbUtils.GetAllMusic();
        }

        //Displays the information in the boxes below of the selected row.
        private void dgvMusic_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusic.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];
                txtTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                txtArtist.Text = selectedRow.Cells["Artist"].Value.ToString();
                txtYear.Text = selectedRow.Cells["Year"].Value.ToString();
                txtAlbum.Text = selectedRow.Cells["Album"].Value.ToString();
                txtGenre.Text = selectedRow.Cells["Genre"].Value.ToString();
                lblFileName.Text = selectedRow.Cells["FileName"].Value.ToString();
                lblFilePath.Text = selectedRow.Cells["FilePath"].Value.ToString();
            }
        }

        private void Edit_Music_Load(object sender, EventArgs e)
        {
            displayData();
        }

        //Saves the information of the song.
        private void btnSave_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            int selectedRowIndex = dgvMusic.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvMusic.Rows[selectedRowIndex];

            string title = txtTitle.Text;
            string[] artists = txtArtist.Text.Split(',');
            string[] genres = txtGenre.Text.Split(',');
            string album = txtAlbum.Text;
            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                lblStatus.Text = "Invalid year.";
                txtYear.Focus();
                return;
            }
            string filePath = selectedRow.Cells["FilePath"].Value.ToString();

            //Changes the file information
            try {
                TagLib.File file = TagLib.File.Create(filePath);
                file.Tag.Title = title;
                file.Tag.Composers = artists;
                file.Tag.Genres = genres;
                file.Tag.Album = album;
                file.Tag.Year = (uint)year;

                file.Save();
            } catch
            {
                lblStatus.Text = "Error editing file.";
                return;
            }

            //Updates information in database.
            dbUtils.Edit(title, artists, year, album, genres, filePath);
            lblStatus.Text = dbUtils.LastStatus;

            displayData();
        }
    }
}
