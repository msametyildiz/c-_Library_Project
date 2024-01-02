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

        public delegate void LogoutDelegate();
        public event LogoutDelegate LogoutEvent;
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
        public void addNewRecord(string book_name, string author,int page_count, DateTime reading_date) {
            books book1 = new books();
            book1.book_name = book_name;
            book1.autor = author;
            book1.page_count = page_count;
            book1.user_id = activeUser.id;
            book1.reading_date = reading_date;

            db.books.Add(book1);
            db.SaveChanges();
            MessageBox.Show("Added!!");
            loadData(); // Get All Records From Database

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
            LogoutEvent();

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
            frmNewRecord.AddNewRecordEvent += addNewRecord;
            frmNewRecord.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LogoutEvent();
        }
    }
}
