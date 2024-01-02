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
    public partial class Form1 : Form
    {
       libraryEntities2 db =new libraryEntities2();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            users user = new users();
            user.first_name = registerFirstName.Text;
            user.last_name = registerLastName.Text;
            user.email = registerEmail.Text;
            user.password = registerPassword.Text; 
            user.address = registerAddress.Text;
            user.birth_date = dateTimePicker1.Value;
            db.users.Add(user);
            db.SaveChanges();
            MessageBox.Show("Registered!!");
            tabControl1.SelectedIndex = 0;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            users existingUser = db.users.Where(user => user.email == textBoxEmail.Text && user.password == textBoxPassword.Text).FirstOrDefault();
            if (existingUser == null)
            {
                MessageBox.Show("Your credentials are wrong!!");
                return;
            }
            UserDetail frmUserDetail = new UserDetail();
            frmUserDetail.activeUser = existingUser;
            frmUserDetail.ShowDialog();


        }
    }
}
