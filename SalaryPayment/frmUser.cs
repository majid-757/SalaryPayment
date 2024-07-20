using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Security.Cryptography;

namespace SalaryPayment
{
    public partial class frmUser : Office2007Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void display()
        {
            SalaryDBEntities db = new SalaryDBEntities();
            dataGridViewX1.DataSource = db.View_User.ToList();
            dataGridViewX1.Columns[0].HeaderText = "نام کاربری";
            dataGridViewX1.Columns[1].HeaderText = "کلمه عبور";
            dataGridViewX1.Columns[2].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns[3].HeaderText = "کد ملی";
            dataGridViewX1.Columns[2].Width = 200;
            dataGridViewX1.Columns[4].Visible = false;

        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            display();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkUser.Checked = true;
                chkBk.Checked = true;
                chkRs.Checked = true;
                chkInfo.Checked = true;
                chkPersonGroup.Checked = true;
                chkPerson.Checked = true;
                chkJobs.Checked = true;
                chkSalaryGroup.Checked = true;
                chkDeduction.Checked = true;
                chkSalary.Checked = true;
                chkVam.Checked = true;
            }
            else if (chkAll.Checked==false)
            {
                chkUser.Checked = false;
                chkBk.Checked = false;
                chkRs.Checked = false;
                chkInfo.Checked = false;
                chkPersonGroup.Checked = false;
                chkPerson.Checked = false;
                chkJobs.Checked = false;
                chkSalaryGroup.Checked = false;
                chkDeduction.Checked = false;
                chkSalary.Checked = false;
                chkVam.Checked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            { errorProvider1.SetError(txtUserName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

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

            bool _CodeM = db.tblUser.Where(u => u.CodeM==txtCodeM.Text).Any();
            if (_CodeM==true)  { MessageBox.Show("این کد ملی قبلا ثبت شده است"); return;}

            bool _UserName = db.tblUser.Where(u => u.UserName == txtUserName.Text).Any();
            if (_UserName == true) { MessageBox.Show("این کاربری قبلا ثبت شده است"); return; }

            tblUser tbl = new tblUser();
            tbl.UserName = txtUserName.Text;
            tbl.Password = _FinalHashPassword;
            tbl.Name = txtName.Text;
            tbl.CodeM = txtCodeM.Text;

            tbl.Users = Convert.ToInt32(chkUser.Checked);
            tbl.BK = Convert.ToInt32(chkBk.Checked);
            tbl.RS = Convert.ToInt32(chkRs.Checked);
            tbl.Info = Convert.ToInt32(chkInfo.Checked);
            tbl.PersonGroup = Convert.ToInt32(chkPersonGroup.Checked);
            tbl.Person = Convert.ToInt32(chkPerson.Checked);
            tbl.Jobs = Convert.ToInt32(chkJobs.Checked);
            tbl.SalaryGroup = Convert.ToInt32(chkSalaryGroup.Checked);
            tbl.Deduction = Convert.ToInt32(chkDeduction.Checked);
            tbl.Salary = Convert.ToInt32(chkSalary.Checked);
            tbl.Vam = Convert.ToInt32(chkVam.Checked);
            db.tblUser.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("ثبت اطلاعات انجام شد");
            display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            { errorProvider1.SetError(txtUserName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

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

            if (dataGridViewX1.CurrentRow.Cells[3].Value.ToString() !=txtCodeM.Text)
            {
                bool _CodeM = db.tblUser.Where(u => u.CodeM == txtCodeM.Text).Any();
                if (_CodeM == true) { MessageBox.Show("این کد ملی قبلا ثبت شده است"); return; }
            }

            if (dataGridViewX1.CurrentRow.Cells[0].Value.ToString() != txtUserName.Text)
            {
                bool _UserName = db.tblUser.Where(u => u.UserName == txtUserName.Text).Any();
                if (_UserName == true) { MessageBox.Show("این کاربری قبلا ثبت شده است"); return; }
            }

            tblUser tbl = new tblUser();
            int _id = Convert.ToInt32(dataGridViewX1.CurrentRow.Cells[4].Value);
            tbl = db.tblUser.Find(_id);
            tbl.UserName = txtUserName.Text;
            //tbl.Password = _FinalHashPassword;
            tbl.Name = txtName.Text;
            tbl.CodeM = txtCodeM.Text;

            tbl.Users = Convert.ToInt32(chkUser.Checked);
            tbl.BK = Convert.ToInt32(chkBk.Checked);
            tbl.RS = Convert.ToInt32(chkRs.Checked);
            tbl.Info = Convert.ToInt32(chkInfo.Checked);
            tbl.PersonGroup = Convert.ToInt32(chkPersonGroup.Checked);
            tbl.Person = Convert.ToInt32(chkPerson.Checked);
            tbl.Jobs = Convert.ToInt32(chkJobs.Checked);
            tbl.SalaryGroup = Convert.ToInt32(chkSalaryGroup.Checked);
            tbl.Deduction = Convert.ToInt32(chkDeduction.Checked);
            tbl.Salary = Convert.ToInt32(chkSalary.Checked);
            tbl.Vam = Convert.ToInt32(chkVam.Checked);
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
            display();
        }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;

            if (MessageBox.Show("از حذف اطلاعات مطمئن هستید؟","تایید حذف",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                tblUser Tbl = new tblUser();
                Tbl = db.tblUser.Where(u=>u.CodeM==txtCodeM.Text).SingleOrDefault();

                if (AccessLevel.CodeM== txtCodeM.Text)
                {
                    MessageBox.Show("شما نمی توانید اطلاعات کاربری خود را حذف کنید");return;
                }

                db.tblUser.Remove(Tbl);
                db.SaveChanges();
                display();
                Clear();
                MessageBox.Show("حذف اطلاعات انجام شد");
            }
        }

        void Clear()
        {
            txtUserName.Text = txtPassword.Text = txtName.Text = txtCodeM.Text = "";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewX1_MouseUp(object sender, MouseEventArgs e)
        {
            txtUserName.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            txtPassword.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
            txtCodeM.Text = dataGridViewX1.CurrentRow.Cells[3].Value.ToString();

            var load = db.tblUser.Where(u=>u.CodeM==txtCodeM.Text).SingleOrDefault();

            if (load.Users == 1)
                chkUser.Checked = true;
            else
                chkUser.Checked = false;

            if (load.RS == 1)
                chkRs.Checked = true;
            else
                chkRs.Checked = false;

            if (load.BK == 1)
                chkBk.Checked = true;
            else
                chkBk.Checked = false;

            if (load.Info == 1)
                chkInfo.Checked = true;
            else
                chkInfo.Checked = false;

            if (load.PersonGroup == 1)
                chkPersonGroup.Checked = true;
            else
                chkPersonGroup.Checked = false;

            if (load.Person == 1)
                chkPerson.Checked = true;
            else
                chkPerson.Checked = false;

            if (load.Jobs == 1)
                chkJobs.Checked = true;
            else
                chkJobs.Checked = false;

            if (load.SalaryGroup == 1)
                chkSalaryGroup.Checked = true;
            else
                chkSalaryGroup.Checked = false;

            if (load.Salary == 1)
                chkSalary.Checked = true;
            else
                chkSalary.Checked = false;

            if (load.Deduction == 1)
                chkDeduction.Checked = true;
            else
                chkDeduction.Checked = false;

            if (load.Vam == 1)
                chkVam.Checked = true;
            else
                chkVam.Checked = false;
        }

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            frmEditPass frm = new frmEditPass();
            frm.txtCodeM.Text = txtCodeM.Text;
            frm.ShowDialog();
        }
    }
}
