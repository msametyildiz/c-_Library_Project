using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class NewRecordForm : Form
    {
        public delegate void AddNewRecordDelegate(string book_name, string author, int page_count, DateTime reading_date);
        public event AddNewRecordDelegate AddNewRecordEvent;
        public NewRecordForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Close();
            AddNewRecordEvent(bookName.Text,author.Text,int.Parse(pageCount.Text), dateTimePicker1.Value);
        }
    }
}
