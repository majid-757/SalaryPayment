using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace SalaryPayment
{
    public partial class frmJobs : Office2007Form
    {
        public frmJobs()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void MaxId()
        {
            var Maxf = db.tblJobs.Select(u=>u.JobsId).DefaultIfEmpty(0).Max();
            string id = Convert.ToString(Maxf);
            if (id=="")
                txtId.Text = "1";
            else
            {
                Int64 IdFinal = 1 + Int64.Parse(id);
                txtId.Text = IdFinal.ToString();
            }
        }
        private void frmJobs_Load(object sender, EventArgs e)
        {
            if (lblFlg.Text=="0")
            {
                btnEdit.Enabled = false;
                MaxId();
            }
            if (lblFlg.Text != "0")
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            { errorProvider1.SetError(txtId, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtBaseSalary.Text == string.Empty)
            { errorProvider1.SetError(txtBaseSalary, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            tblJobs tbl = new tblJobs();
            tbl.JobsId = Convert.ToInt32(txtId.Text);
            tbl.JobName = txtName.Text;
            tbl.BaseSalary = Convert.ToInt64(txtBaseSalary.Text.Replace(",",""));

            db.tblJobs.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("ثبت اطلاعات انجام شد");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            { errorProvider1.SetError(txtId, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtBaseSalary.Text == string.Empty)
            { errorProvider1.SetError(txtBaseSalary, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            var chk = db.Set<tblJobs>().Local.FirstOrDefault(u => u.JobsId == Convert.ToInt32(txtId.Text));
            if (chk != null)
            {
                db.Entry(chk).State = System.Data.Entity.EntityState.Detached;
            }

            tblJobs tbl = new tblJobs();
            tbl.JobsId = Convert.ToInt32(txtId.Text);
            tbl.JobName = txtName.Text;
            tbl.BaseSalary = Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""));

            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaxId();
            txtName.Text = "";
            txtBaseSalary.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBaseSalary_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBaseSalary.Text))
            {
                txtBaseSalary.Text = string.Format("{0:n0}",Convert.ToInt64(txtBaseSalary.Text.Replace(",","")));
                txtBaseSalary.Select(txtBaseSalary.TextLength,0);
            }
        }

        private void frmJobs_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
