using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;


namespace SalaryPayment
{
    public partial class Form1 : Office2007Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            lblDate.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");

            if (AccessLevel.Users == 1)
                btnUser.Enabled = true;
            else
                btnUser.Enabled = false;

            if (AccessLevel.BK == 1)
                btnBakUp.Enabled = true;
            else
                btnBakUp.Enabled = false;

            if (AccessLevel.RS == 1)
                btnRestore.Enabled = true;
            else
                btnRestore.Enabled = false;

            if (AccessLevel.Info == 1)
                btnInfo.Enabled = true;
            else
                btnInfo.Enabled = false;

            if (AccessLevel.PersonGroup == 1)
                btnPersonGroup.Enabled = true;
            else
                btnPersonGroup.Enabled = false;

            if (AccessLevel.Person == 1)
            {
                btnPerson.Enabled = true;
                btnPersonList.Enabled = true;
            }         
            else
            {
                btnPerson.Enabled = false;
                btnPersonList.Enabled = false;
            }

            if (AccessLevel.Jobs == 1)
            {
                btnJob.Enabled = true;
                btnJobList.Enabled = true;
            }
            else
            {
                btnJob.Enabled = false;
                btnJobList.Enabled = false;
            }

            if (AccessLevel.SalaryGroup == 1)
            {
                btnSalaryGroup.Enabled = true;
                btnSalaryGroupList.Enabled = true;
            }
            else
            {
                btnSalaryGroup.Enabled = false;
                btnSalaryGroupList.Enabled = false;
            }

            if (AccessLevel.Salary== 1)
            {
                btnSalary.Enabled = true;
                btnSalaryList.Enabled = true;
            }
            else
            {
                btnSalary.Enabled = false;
                btnSalaryList.Enabled = false;
            }

            if (AccessLevel.Deduction == 1)
            {
                btnDeduction.Enabled = true;
                btnDeductionList.Enabled = true;
            }
            else
            {
                btnDeduction.Enabled = false;
                btnDeductionList.Enabled = false;
            }

            if (AccessLevel.Vam == 1)
            {
                btnVam.Enabled = true;
                btnVamList.Enabled = true;
            }
            else
            {
                btnVam.Enabled = false;
                btnVamList.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.Hour.ToString();
            lblTime.Text += ":";
            lblTime.Text += DateTime.Now.Minute.ToString();
            lblTime.Text += ":";
            lblTime.Text += DateTime.Now.Second.ToString();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            frmJobs frm = new frmJobs();
            frm.ShowDialog();
        }

        private void btnJobList_Click(object sender, EventArgs e)
        {
            frmJobsList frm = new frmJobsList();
            frm.ShowDialog();
        }

        private void btnPersonGroup_Click(object sender, EventArgs e)
        {
            frmPersonGroup frm = new frmPersonGroup();
            frm.ShowDialog();
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            frmPerson frm = new frmPerson();
            frm.ShowDialog();
        }

        private void btnPersonList_Click(object sender, EventArgs e)
        {
            frmPersonList frm = new frmPersonList();
            frm.ShowDialog();
        }

        private void btnSalaryGroup_Click(object sender, EventArgs e)
        {
            frmSalaryGroup frm = new frmSalaryGroup();
            frm.ShowDialog();
        }

        private void btnSalaryGroupList_Click(object sender, EventArgs e)
        {
            frmSalaryGroupList frm = new frmSalaryGroupList();
            frm.ShowDialog();
        }

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            frmDeduction frm = new frmDeduction();
            frm.ShowDialog();
        }

        private void btnDeductionList_Click(object sender, EventArgs e)
        {
            frmDeductionList frm = new frmDeductionList();
            frm.ShowDialog();
        }

        private void btnVam_Click(object sender, EventArgs e)
        {
            frmVam frm = new frmVam();
            frm.ShowDialog();
        }

        private void btnVamList_Click(object sender, EventArgs e)
        {
            frmVamList frm = new frmVamList();
            frm.ShowDialog();
        }

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            frmEditPass frm = new frmEditPass();
            frm.txtCodeM.Text = AccessLevel.CodeM;
            frm.ShowDialog();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            frmSalary frm = new frmSalary();
            frm.ShowDialog();
        }

        private void btnSalaryList_Click(object sender, EventArgs e)
        {
            frmSalaryList frm = new frmSalaryList();
            frm.ShowDialog();
        }
        SalaryDBEntities db = new SalaryDBEntities();
        private void btnBakUp_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Salary" + string.Format("{0:yyyyMMdd-HHmmss}", Convert.ToDateTime(DateTime.Now.ToString()));
            dlg.DefaultExt = ".bak";
            dlg.Filter = "DataBase Backup (.Bak)|*.bak";
            dlg.Title = "پشتیبان گیری از دیتابیس";
            dlg.ShowDialog();
            string _Name = dlg.FileName;
            try
            {
                var backup = "Backup DataBase SalaryDB to Disk=N'" + _Name + "'";
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, backup);
                MessageBox.Show("پشتیبان گیری انجام شده");
            }
            catch
            {
                MessageBox.Show("پشتیبان گیری با مشکل واجه شد");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.DefaultExt = ".bak";
            op.Filter = "DataBase Backup (.Bak)|*.bak";
            op.Title = "بازیابی پشتیبان از دیتابیس";
            op.ShowDialog();
            string _Name = op.FileName;
            try
            {
                var restore = "ALTER DATABASE SalaryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE" + " USE master; RESTORE DATABASE SalaryDB FROM DISK =N'" + _Name + "'WITH REPLACE ;" + "ALTER DATABASE SalaryDB SET MULTI_USER WITH ROLLBACK IMMEDIATE USE MASTER";
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, restore);
                MessageBox.Show("بازیابی پشتیبان انجام شده");
            }
            catch
            {
                MessageBox.Show("بازیابی پشتیبان با مشکل واجه شد");
            }
        }
    }
}
