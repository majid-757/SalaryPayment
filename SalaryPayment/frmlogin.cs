using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SalaryPayment
{
    public partial class frmlogin : Office2007Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }
        SalaryDBEntities db = new SalaryDBEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            Byte[] _pass = UTF32Encoding.UTF8.GetBytes(txtPassword.Text);
            Byte[] _hashpass = sha.ComputeHash(_pass);
            string _FinalHashPassword = BitConverter.ToString(_hashpass);

            bool _UserName = db.tblUser.Where(u => u.UserName == txtUserName.Text && u.Password == _FinalHashPassword).Any();
            if (_UserName == true) 
            {
                var _User = db.tblUser.Where(u => u.UserName == txtUserName.Text && u.Password == _FinalHashPassword).SingleOrDefault();
                string _CodeM = _User.CodeM;
                string _Name = _User.Name;

                AccessLevel.CodeM= _User.CodeM;
                AccessLevel.Name = _User.Name;
                AccessLevel.Users = Convert.ToInt32(_User.Users);
                AccessLevel.BK = Convert.ToInt32(_User.BK);
                AccessLevel.RS = Convert.ToInt32(_User.RS);
                AccessLevel.Info = Convert.ToInt32(_User.Info);
                AccessLevel.PersonGroup = Convert.ToInt32(_User.PersonGroup);
                AccessLevel.Person = Convert.ToInt32(_User.Person);
                AccessLevel.Jobs = Convert.ToInt32(_User.Jobs);
                AccessLevel.SalaryGroup = Convert.ToInt32(_User.SalaryGroup);
                AccessLevel.Deduction = Convert.ToInt32(_User.Deduction);
                AccessLevel.Salary = Convert.ToInt32(_User.Salary);
                AccessLevel.Vam = Convert.ToInt32(_User.Vam);
                this.Hide();
                Form1 frm = new Form1();
                frm.lblUser.Text = _Name;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
