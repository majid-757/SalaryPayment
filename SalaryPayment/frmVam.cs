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
    public partial class frmVam : Office2007Form
    {
        public frmVam()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void MaxId()
        {
            var Maxf = db.tblVam.Select(u => u.IdVam).DefaultIfEmpty(0).Max();
            string id = Convert.ToString(Maxf);
            if (id == "")
                txtId.Text = "1";
            else
            {
                Int64 IdFinal = 1 + Int64.Parse(id);
                txtId.Text = IdFinal.ToString();
            }
        }
        private void frmVam_Load(object sender, EventArgs e)
        {
            if (lblFlg.Text == "0")
            {
                btnEdit.Enabled = false;
                MaxId();

                System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
                mskDateReg.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
                mskStartDate.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
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

            if (lblPersonId.Text=="0")
            {
                MessageBox.Show("لطفا شخص را انتخاب کنید");return;
            }

            if (txtFName.Text == string.Empty)
            { errorProvider1.SetError(txtFName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtLName.Text == string.Empty)
            { errorProvider1.SetError(txtLName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtNumAgsat.Text == "0" || txtNumAgsat.Text == "")
            {
                MessageBox.Show("لطفا تعداد اقساط را وارد کنید"); return;
            }
            if (txtPrice.Text == "0" || txtPrice.Text == "")
            {
                MessageBox.Show("لطفا مبلغ وام را وارد کنید"); return;
            }
            if (txtPriceAgsat.Text == "0" || txtPriceAgsat.Text == "")
            {
                MessageBox.Show("لطفا مبلغ اقساط را وارد کنید"); return;
            }
            tblVam tbl = new tblVam();
            tbl.IdVam = Convert.ToInt32(txtId.Text);
            tbl.CodeP = Convert.ToInt32(lblPersonId.Text);
            tbl.DateReg = mskDateReg.Text;
            tbl.StartDate = mskStartDate.Text;
            tbl.NumAgsat = Convert.ToInt32(txtNumAgsat.Text);
            tbl.Price = Convert.ToInt64(txtPrice.Text.Replace(",", ""));
            tbl.PriceAgsat = Convert.ToInt64(txtPriceAgsat.Text.Replace(",", ""));
            tbl.Remainig = Convert.ToInt64(txtPrice.Text.Replace(",", ""));
            db.tblVam.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("ثبت اطلاعات انجام شد");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            { errorProvider1.SetError(txtId, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (lblPersonId.Text == "0")
            {
                MessageBox.Show("لطفا شخص را انتخاب کنید"); return;
            }

            if (txtFName.Text == string.Empty)
            { errorProvider1.SetError(txtFName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtLName.Text == string.Empty)
            { errorProvider1.SetError(txtLName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtNumAgsat.Text == "0" || txtNumAgsat.Text == "")
            {
                MessageBox.Show("لطفا تعداد اقساط را وارد کنید"); return;
            }
            if (txtPrice.Text == "0" || txtPrice.Text == "")
            {
                MessageBox.Show("لطفا مبلغ وام را وارد کنید"); return;
            }
            if (txtPriceAgsat.Text == "0" || txtPriceAgsat.Text == "")
            {
                MessageBox.Show("لطفا مبلغ اقساط را وارد کنید"); return;
            }

            var chk = db.Set<tblVam>().Local.FirstOrDefault(u => u.IdVam == Convert.ToInt32(txtId.Text));
            if (chk != null)
            {
                db.Entry(chk).State = System.Data.Entity.EntityState.Detached;
            }

            tblVam tbl = new tblVam();
            tbl.IdVam = Convert.ToInt32(txtId.Text);
            tbl.CodeP = Convert.ToInt32(lblPersonId.Text);
            tbl.DateReg = mskDateReg.Text;
            tbl.StartDate = mskStartDate.Text;
            tbl.NumAgsat = Convert.ToInt32(txtNumAgsat.Text);
            tbl.Price = Convert.ToInt64(txtPrice.Text.Replace(",", ""));
            tbl.PriceAgsat = Convert.ToInt64(txtPriceAgsat.Text.Replace(",", ""));
            tbl.Remainig = Convert.ToInt64(txtRemainig.Text.Replace(",", ""));
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaxId();
            txtFName.Text = txtLName.Text=mskDateReg.Text=mskStartDate.Text=  "";
            txtPrice.Text = txtPriceAgsat.Text = txtNumAgsat.Text =lblPersonId.Text= txtRemainig.Text="0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVam_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                txtPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtPrice.Text.Replace(",", "")));
                txtPrice.Select(txtPrice.TextLength, 0);
            }
        }

        private void txtPriceAgsat_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPriceAgsat.Text))
            {
                txtPriceAgsat.Text = string.Format("{0:n0}", Convert.ToInt64(txtPriceAgsat.Text.Replace(",", "")));
                txtPriceAgsat.Select(txtPriceAgsat.TextLength, 0);
            }
        }

        public void GetPerson(string _CodeP,string _FName,string _LName)
        {
            lblPersonId.Text = _CodeP;
            txtFName.Text = _FName;
            txtLName.Text = _LName;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmPersonList frm = new frmPersonList();
            frm.lblFlg.Text = "vam";
            frm.ShowDialog();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text == "" || txtPrice.Text == "0")
                return;
            if (txtNumAgsat.Text == "" || txtNumAgsat.Text == "0")
                return;

            Int64 Result = Convert.ToInt64(txtPrice.Text.Replace(",","")) / Convert.ToInt64(txtNumAgsat.Text);
            txtPriceAgsat.Text = Result.ToString();
        }
    }
}
