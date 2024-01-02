using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryProject.models;

namespace LibraryProject
{
    public partial class UserDetail : Form

    {
        public users activeUser;
        libraryEntities2 db = new libraryEntities2();
        public UserDetail()
        {
            InitializeComponent();
        }

        private void setProfile()
        {
            labelId.Text = activeUser.id.ToString();
            labelEmail.Text= activeUser.email;
            labelName.Text = activeUser.first_name + " " + activeUser.last_name;
            labelPassword.Text = activeUser.password;
            labelAddress.Text = activeUser.address;
            labelAge.Text = (DateTime.Now.Year - activeUser.birth_date.Year).ToString();

        }
        private void loadData()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = db.books.Where(book => book.user_id == activeUser.id).ToList();
            //dataGridView1.DataSource = db.books.Where(book => book.user_id == activeUser.id).Select()
        }
        private void contextMenuStrip5_Opening(object sender, CancelEventArgs e)
        {

        }

        private void newRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {
            if (this.activeUser == null)
            {
                this.Close();
                return;
            }
            setProfile();
            loadData();
            
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newRecordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewRecordForm frmNewRecord = new NewRecordForm();
            frmNewRecord.ShowDialog();
        }
    }
}
