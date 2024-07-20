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
    public partial class frmDeduction : Office2007Form
    {
        public frmDeduction()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void MaxId()
        {
            var Maxf = db.tblDeduction.Select(u => u.IdDeduction).DefaultIfEmpty(0).Max();
            string id = Convert.ToString(Maxf);
            if (id == "")
                txtId.Text = "1";
            else
            {
                Int64 IdFinal = 1 + Int64.Parse(id);
                txtId.Text = IdFinal.ToString();
            }
        }
        private void frmDeduction_Load(object sender, EventArgs e)
        {
            if (lblFlg.Text == "0")
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

            if (txtBasePrice.Text == string.Empty)
            { errorProvider1.SetError(txtBasePrice, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            tblDeduction tbl = new tblDeduction();
            tbl.IdDeduction = Convert.ToInt32(txtId.Text);
            tbl.NameDeduction = txtName.Text;
            tbl.BasePrice = Convert.ToInt64(txtBasePrice.Text.Replace(",", ""));

            db.tblDeduction.Add(tbl);
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

            if (txtBasePrice.Text == string.Empty)
            { errorProvider1.SetError(txtBasePrice, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            var chk = db.Set<tblDeduction>().Local.FirstOrDefault(u => u.IdDeduction == Convert.ToInt32(txtId.Text));
            if (chk != null)
            {
                db.Entry(chk).State = System.Data.Entity.EntityState.Detached;
            }

            tblDeduction tbl = new tblDeduction();
            tbl.IdDeduction = Convert.ToInt32(txtId.Text);
            tbl.NameDeduction = txtName.Text;
            tbl.BasePrice = Convert.ToInt64(txtBasePrice.Text.Replace(",", ""));

            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaxId();
            txtName.Text = "";
            txtBasePrice.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtBasePrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBasePrice.Text))
            {
                txtBasePrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtBasePrice.Text.Replace(",", "")));
                txtBasePrice.Select(txtBasePrice.TextLength, 0);
            }
        }
    }
}
