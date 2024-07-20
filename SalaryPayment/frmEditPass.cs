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
    public partial class frmEditPass : Office2007Form
    {
        public frmEditPass()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            { errorProvider1.SetError(txtPassword, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtCodeM.Text == string.Empty)
            { errorProvider1.SetError(txtCodeM, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            Byte[] _pass = UTF32Encoding.UTF8.GetBytes(txtPassword.Text);
            Byte[] _hashpass = sha.ComputeHash(_pass);
            string _FinalHashPassword = BitConverter.ToString(_hashpass);

            bool _CodeM = db.tblUser.Where(u => u.CodeM == txtCodeM.Text).Any();
            if (_CodeM == false) { MessageBox.Show("این کد ملی ثبت نشده است"); return; }

            tblUser tbl = new tblUser();
            tbl = db.tblUser.Where(u => u.CodeM == txtCodeM.Text).SingleOrDefault();
            tbl.Password = _FinalHashPassword;
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
        }

        private void frmEditPass_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
