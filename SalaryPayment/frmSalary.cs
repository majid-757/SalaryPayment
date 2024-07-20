using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Stimulsoft.Report;
namespace SalaryPayment
{
    public partial class frmSalary : Office2007Form
    {
        public frmSalary()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void MaxId()
        {
            var Maxf = db.tblSalary.Select(u => u.SalaryId).DefaultIfEmpty(0).Max();
            string id = Convert.ToString(Maxf);
            if (id == "")
                txtId.Text = "1";
            else
            {
                Int64 IdFinal = 1 + Int64.Parse(id);
                txtId.Text = IdFinal.ToString();
            }
        }

        Image imagebyte(byte[] bytes)
        {
            MemoryStream m = new MemoryStream(bytes);
            return Image.FromStream(m);
        }
        private void textBoxX26_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            if (lblFlg.Text == "0")
            {
                btnEdit.Enabled = false;
                MaxId();

                System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
                mskDateReg.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");

                string Month = p.GetMonth(DateTime.Now).ToString("0#");
                int Year = Int32.Parse(mskDateReg.Text.Substring(0, 4));

                if (Convert.ToInt32(Month) <= 6 && Convert.ToInt32(Month) >= 1) txtWorkDay.Text = "31";
                if (Convert.ToInt32(Month) >= 7 && Convert.ToInt32(Month) != 12) txtWorkDay.Text = "30";

                if (Convert.ToInt32(Month) == 12)
                {
                    if (p.IsLeapYear(Year) == true) txtWorkDay.Text = "30";
                    if (p.IsLeapYear(Year) == false) txtWorkDay.Text = "29";
                }

                switch (Month)
                {
                    case "01":
                        txtMonth.Text = "فروردین";
                        break;
                    case "02":
                        txtMonth.Text = "اردیبهشت";
                        break;
                    case "03":
                        txtMonth.Text = "خرداد";
                        break;
                    case "04":
                        txtMonth.Text = "تیر";
                        break;
                    case "05":
                        txtMonth.Text = "مرداد";
                        break;
                    case "06":
                        txtMonth.Text = "شهریور";
                        break;
                    case "07":
                        txtMonth.Text = "مهر";
                        break;
                    case "08":
                        txtMonth.Text = "آبان";
                        break;
                    case "09":
                        txtMonth.Text = "آذر";
                        break;
                    case "10":
                        txtMonth.Text = "دی";
                        break;
                    case "11":
                        txtMonth.Text = "بهمن";
                        break;
                    case "12":
                        txtMonth.Text = "اسفند";
                        break;
                }


            }
            if (lblFlg.Text != "0")
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false;
            }
        }

        private void btnLoadMonth_Click(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            string Month = mskDateReg.Text.Substring(5, 2);
            int Year = Int32.Parse(mskDateReg.Text.Substring(0, 4));

            if (Convert.ToInt32(Month) <= 6 && Convert.ToInt32(Month) >= 1) txtWorkDay.Text = "31";
            if (Convert.ToInt32(Month) >= 7 && Convert.ToInt32(Month) != 12) txtWorkDay.Text = "30";

            if (Convert.ToInt32(Month) == 12)
            {
                if (p.IsLeapYear(Year) == true) txtWorkDay.Text = "30";
                if (p.IsLeapYear(Year) == false) txtWorkDay.Text = "29";
            }

            switch (Month)
            {
                case "01":
                    txtMonth.Text = "فروردین";
                    break;
                case "02":
                    txtMonth.Text = "اردیبهشت";
                    break;
                case "03":
                    txtMonth.Text = "خرداد";
                    break;
                case "04":
                    txtMonth.Text = "تیر";
                    break;
                case "05":
                    txtMonth.Text = "مرداد";
                    break;
                case "06":
                    txtMonth.Text = "شهریور";
                    break;
                case "07":
                    txtMonth.Text = "مهر";
                    break;
                case "08":
                    txtMonth.Text = "آبان";
                    break;
                case "09":
                    txtMonth.Text = "آذر";
                    break;
                case "10":
                    txtMonth.Text = "دی";
                    break;
                case "11":
                    txtMonth.Text = "بهمن";
                    break;
                case "12":
                    txtMonth.Text = "اسفند";
                    break;
            }

        }
        public void GetPerson(string _CodeP, string _FName, string _LName, string _ChildNum, string _Post)
        {
            txtCodeP.Text = _CodeP;
            txtFLName.Text = _FName + " " + _LName;
            txtNumChild.Text = _ChildNum;
            txtPost.Text = _Post;
        }
        private void btnLoadPerson_Click(object sender, EventArgs e)
        {
            frmPersonList frm = new frmPersonList();
            frm.lblFlg.Text = "Salary";
            frm.ShowDialog();
        }

        private void txtCodeP_TextChanged(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(txtCodeP.Text);
            var load = db.tblPerson.Where(u => u.CodeP == id).SingleOrDefault();
            pic.Image = imagebyte(load.Pic);

            txtGestPrice.Text = "0";
            bool chk = db.tblVam.Where(u => u.CodeP == id && u.Remainig > 0).Any();
            if (chk == true)
            {
                var loadGest = db.tblVam.Where(u => u.CodeP == id && u.Remainig > 0).SingleOrDefault();
                txtGestPrice.Text = Convert.ToString(loadGest.PriceAgsat);
            }

        }

        private void txtPost_TextChanged(object sender, EventArgs e)
        {
            var load = db.tblJobs.Where(u => u.JobName == txtPost.Text).SingleOrDefault();
            txtBaseSalary.Text = Convert.ToString(load.BaseSalary);
        }

        private void txtOverTimePrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOverTimePrice.Text))
            {
                txtOverTimePrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtOverTimePrice.Text.Replace(",", "")));
                txtOverTimePrice.Select(txtOverTimePrice.TextLength, 0);
            }
        }

        private void txtWorkDeductionPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWorkDeductionPrice.Text))
            {
                txtWorkDeductionPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtWorkDeductionPrice.Text.Replace(",", "")));
                txtWorkDeductionPrice.Select(txtWorkDeductionPrice.TextLength, 0);
            }
        }

        private void txtMissionPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMissionPrice.Text))
            {
                txtMissionPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtMissionPrice.Text.Replace(",", "")));
                txtMissionPrice.Select(txtMissionPrice.TextLength, 0);
            }
        }

        private void txtOverDayPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOverDayPrice.Text))
            {
                txtOverDayPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtOverDayPrice.Text.Replace(",", "")));
                txtOverDayPrice.Select(txtOverDayPrice.TextLength, 0);
            }
        }

        private void txtDeductionDayPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDeductionDayPrice.Text))
            {
                txtDeductionDayPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtDeductionDayPrice.Text.Replace(",", "")));
                txtDeductionDayPrice.Select(txtDeductionDayPrice.TextLength, 0);
            }
        }

        private void txtHelpPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHelpPrice.Text))
            {
                txtHelpPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtHelpPrice.Text.Replace(",", "")));
                txtHelpPrice.Select(txtHelpPrice.TextLength, 0);
            }
        }

        private void txtGestPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGestPrice.Text))
            {
                txtGestPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtGestPrice.Text.Replace(",", "")));
                txtGestPrice.Select(txtGestPrice.TextLength, 0);
            }
        }

        private void txtDefDeductoinPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDefDeductoinPrice.Text))
            {
                txtDefDeductoinPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtDefDeductoinPrice.Text.Replace(",", "")));
                txtDefDeductoinPrice.Select(txtDefDeductoinPrice.TextLength, 0);
            }
        }

        private void txtDefSalaryPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDefSalaryPrice.Text))
            {
                txtDefSalaryPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtDefSalaryPrice.Text.Replace(",", "")));
                txtDefSalaryPrice.Select(txtDefSalaryPrice.TextLength, 0);
            }
        }

        private void txtBemeh_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBemeh.Text))
            {
                txtBemeh.Text = string.Format("{0:n0}", Convert.ToInt64(txtBemeh.Text.Replace(",", "")));
                txtBemeh.Select(txtBemeh.TextLength, 0);
            }
        }

        private void txtTaxPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaxPrice.Text))
            {
                txtTaxPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtTaxPrice.Text.Replace(",", "")));
                txtTaxPrice.Select(txtTaxPrice.TextLength, 0);
            }
        }

        private void txtSumSalary_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSumSalary.Text))
            {
                txtSumSalary.Text = string.Format("{0:n0}", Convert.ToInt64(txtSumSalary.Text.Replace(",", "")));
                txtSumSalary.Select(txtSumSalary.TextLength, 0);
            }
        }

        private void txtSumDeduction_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSumDeduction.Text))
            {
                txtSumDeduction.Text = string.Format("{0:n0}", Convert.ToInt64(txtSumDeduction.Text.Replace(",", "")));
                txtSumDeduction.Select(txtSumDeduction.TextLength, 0);
            }
        }

        private void txtBaseSalary_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBaseSalary.Text))
            {
                txtBaseSalary.Text = string.Format("{0:n0}", Convert.ToInt64(txtBaseSalary.Text.Replace(",", "")));
                txtBaseSalary.Select(txtBaseSalary.TextLength, 0);
            }
        }

        private void txtSalaryPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSalaryPrice.Text))
            {
                txtSalaryPrice.Text = string.Format("{0:n0}", Convert.ToInt64(txtSalaryPrice.Text.Replace(",", "")));
                txtSalaryPrice.Select(txtSalaryPrice.TextLength, 0);
            }
        }

        public DataTable dtSalaryGroup;
        public DataTable CreateSalaryGroup()
        {
            dtSalaryGroup = new DataTable();

            DataColumn IdSalaryGroup = new DataColumn("IdSalaryGroup", typeof(int));
            dtSalaryGroup.Columns.Add(IdSalaryGroup);

            DataColumn SalaryGroup = new DataColumn("SalaryGroup", typeof(string));
            dtSalaryGroup.Columns.Add(SalaryGroup);

            DataColumn BasePrice = new DataColumn("BasePrice", typeof(Int64));
            dtSalaryGroup.Columns.Add(BasePrice);

            return dtSalaryGroup;
        }

        DataTable DisplaySalaryGroup()
        {
            if (dtSalaryGroup == null) { CreateSalaryGroup(); }
            dtSalaryGroup.Rows.Clear();

            var _SalaryGroup = db.tblSalaryGroup.ToList();

            foreach (var item in _SalaryGroup)
            {
                DataRow dr = dtSalaryGroup.NewRow();
                dr["IdSalaryGroup"] = item.IdSalaryGroup;
                dr["SalaryGroup"] = item.SalaryGroup;
                dr["BasePrice"] = item.BasePrice;
                dtSalaryGroup.Rows.Add(dr);
            }
            dgvSalaryGroup.DataSource = null;
            dgvSalaryGroup.DataSource = dtSalaryGroup.DefaultView;
            return dtSalaryGroup;
        }
        void AddSalaryGroup()
        {
            if (txtNumChild.Text == "") txtNumChild.Text = "0";

            //حق اولاد
            for (int i = 0; i < dgvSalaryGroup.RowCount; i++)
            {
                if (dgvSalaryGroup.Rows[i].Cells[1].Value.ToString() == "حق اولاد")
                {
                    dgvSalaryGroup.Rows[i].Cells[2].Value = Convert.ToInt64(dgvSalaryGroup.Rows[i].Cells[2].Value) * Convert.ToInt64(txtNumChild.Text);
                }
            }

            //اضافه کار
            if (txtOverTimePrice.Text == "") txtOverTimePrice.Text = "0";
            if (txtOverTime.Text == "") txtOverTime.Text = "0";
            Int64 SumOverTimePrice = Convert.ToInt64(txtOverTimePrice.Text.Replace(",", "")) * Convert.ToInt64(txtOverTime.Text);

            if (dtSalaryGroup == null) { CreateSalaryGroup(); }
            DataRow dr = dtSalaryGroup.NewRow();
            dr["IdSalaryGroup"] = 0;
            dr["SalaryGroup"] = "اضافه کار";
            dr["BasePrice"] = SumOverTimePrice;
            dtSalaryGroup.Rows.Add(dr);
            dgvSalaryGroup.DataSource = null;
            dgvSalaryGroup.DataSource = dtSalaryGroup.DefaultView;

            //ماموریت
            if (txtMission.Text == "") txtMission.Text = "0";
            if (txtMissionPrice.Text == "") txtMissionPrice.Text = "0";
            Int64 SumMission = Convert.ToInt64(txtMissionPrice.Text.Replace(",", "")) * Convert.ToInt64(txtMission.Text);

            if (dtSalaryGroup == null) { CreateSalaryGroup(); }
            DataRow dr1 = dtSalaryGroup.NewRow();
            dr1["IdSalaryGroup"] = 0;
            dr1["SalaryGroup"] = "ماموریت";
            dr1["BasePrice"] = SumMission;
            dtSalaryGroup.Rows.Add(dr1);
            dgvSalaryGroup.DataSource = null;
            dgvSalaryGroup.DataSource = dtSalaryGroup.DefaultView;

            //اضافه کار روز تعطیل
            if (txtOverDay.Text == "") txtOverDay.Text = "0";
            if (txtOverDayPrice.Text == "") txtOverDayPrice.Text = "0";
            Int64 SumOverDay = Convert.ToInt64(txtOverDayPrice.Text.Replace(",", "")) * Convert.ToInt64(txtOverDay.Text);

            if (dtSalaryGroup == null) { CreateSalaryGroup(); }
            DataRow dr2 = dtSalaryGroup.NewRow();
            dr2["IdSalaryGroup"] = 0;
            dr2["SalaryGroup"] = "اضافه کار روز تعطیل";
            dr2["BasePrice"] = SumOverDay;
            dtSalaryGroup.Rows.Add(dr2);
            dgvSalaryGroup.DataSource = null;
            dgvSalaryGroup.DataSource = dtSalaryGroup.DefaultView;

            //سایر حقوق و مزایا
            if (txtDefSalaryPrice.Text == "") txtDefSalaryPrice.Text = "0";
            if (dtSalaryGroup == null) { CreateSalaryGroup(); }
            DataRow dr3 = dtSalaryGroup.NewRow();
            dr3["IdSalaryGroup"] = 0;
            dr3["SalaryGroup"] = "سایر حقوق و مزایا";
            dr3["BasePrice"] = txtDefSalaryPrice.Text.Replace(",", "");
            dtSalaryGroup.Rows.Add(dr3);
            dgvSalaryGroup.DataSource = null;
            dgvSalaryGroup.DataSource = dtSalaryGroup.DefaultView;
        }
        private void btnAddSalaryGroup_Click(object sender, EventArgs e)
        {
            dgvSalaryGroup.Columns.Clear();
            if (dtSalaryGroup == null)
            {
                DataTable table = CreateSalaryGroup();
            }
            DisplaySalaryGroup();

            AddSalaryGroup();

            dgvSalaryGroup.Columns[0].HeaderText = "کد";
            dgvSalaryGroup.Columns[1].HeaderText = "عنوان";
            dgvSalaryGroup.Columns[2].HeaderText = "مبلغ پیش فرض";
            dgvSalaryGroup.Columns[0].Visible = false;
            dgvSalaryGroup.Columns[1].Width = 160;
            dgvSalaryGroup.Columns[2].Width = 120;


            Int64 Sum = 0;
            for (int i = 0; i < dgvSalaryGroup.RowCount; i++)
            {
                Sum = Sum + (Convert.ToInt64(dgvSalaryGroup.Rows[i].Cells[2].Value));
            }
            txtSumSalary.Text = Sum.ToString();

            if (txtSumSalary.Text == "") txtSumSalary.Text = "0";
            if (txtBaseSalary.Text == "") txtBaseSalary.Text = "0";
            if (txtSumDeduction.Text == "") txtSumDeduction.Text = "0";

            Int64 FinalSalary = (Convert.ToInt64(txtSumSalary.Text.Replace(",", "")) + Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""))) - Convert.ToInt64(txtSumDeduction.Text.Replace(",", ""));
            txtSalaryPrice.Text = FinalSalary.ToString();
        }

        private void btnDelSalaryGroup_Click(object sender, EventArgs e)
        {
            if (dgvSalaryGroup.RowCount == 0)
            {
                return;
            }
            dgvSalaryGroup.Rows.RemoveAt(dgvSalaryGroup.CurrentRow.Index);

            Int64 Sum = 0;
            for (int i = 0; i < dgvSalaryGroup.RowCount; i++)
            {
                Sum = Sum + (Convert.ToInt64(dgvSalaryGroup.Rows[i].Cells[2].Value));
            }
            txtSumSalary.Text = Sum.ToString();

            if (txtSumSalary.Text == "") txtSumSalary.Text = "0";
            if (txtBaseSalary.Text == "") txtBaseSalary.Text = "0";
            if (txtSumDeduction.Text == "") txtSumDeduction.Text = "0";

            Int64 FinalSalary = (Convert.ToInt64(txtSumSalary.Text.Replace(",", "")) + Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""))) - Convert.ToInt64(txtSumDeduction.Text.Replace(",", ""));
            txtSalaryPrice.Text = FinalSalary.ToString();
        }

        public DataTable dtDeduction;
        public DataTable CreateDeduction()
        {
            dtDeduction = new DataTable();

            DataColumn IdDeduction = new DataColumn("IdDeduction", typeof(int));
            dtDeduction.Columns.Add(IdDeduction);

            DataColumn Deduction = new DataColumn("NameDeduction", typeof(string));
            dtDeduction.Columns.Add(Deduction);

            DataColumn BasePrice = new DataColumn("BasePrice", typeof(Int64));
            dtDeduction.Columns.Add(BasePrice);

            return dtDeduction;
        }

        DataTable DisplayDeduction()
        {
            if (dtDeduction == null) { CreateDeduction(); }
            dtDeduction.Rows.Clear();

            var _Deduction = db.tblDeduction.ToList();

            foreach (var item in _Deduction)
            {
                DataRow dr = dtDeduction.NewRow();
                dr["IdDeduction"] = item.IdDeduction;
                dr["NameDeduction"] = item.NameDeduction;
                dr["BasePrice"] = item.BasePrice;
                dtDeduction.Rows.Add(dr);
            }
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;
            return dtDeduction;
        }
        void AddDeduction()
        {
            //کسر کار
            if (txtWorkDeduction.Text == "") txtWorkDeduction.Text = "0";
            if (txtWorkDeductionPrice.Text == "") txtWorkDeductionPrice.Text = "0";
            Int64 SumWorkDeductionPrice = Convert.ToInt64(txtWorkDeductionPrice.Text.Replace(",", "")) * Convert.ToInt64(txtWorkDeduction.Text);

            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr = dtDeduction.NewRow();
            dr["IdDeduction"] = 0;
            dr["NameDeduction"] = "کسر کار";
            dr["BasePrice"] = SumWorkDeductionPrice;
            dtDeduction.Rows.Add(dr);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;

            //تعداد روز غیبت
            if (txtDeductionDay.Text == "") txtDeductionDay.Text = "0";
            if (txtDeductionDayPrice.Text == "") txtDeductionDayPrice.Text = "0";
            Int64 SumtxtDeductionDay = Convert.ToInt64(txtDeductionDayPrice.Text.Replace(",", "")) * Convert.ToInt64(txtDeductionDay.Text);

            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr1 = dtDeduction.NewRow();
            dr1["IdDeduction"] = 0;
            dr1["NameDeduction"] = "کسری بابت غیبت";
            dr1["BasePrice"] = SumtxtDeductionDay;
            dtDeduction.Rows.Add(dr1);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;

            //مساعده
            if (txtHelpPrice.Text == "") txtHelpPrice.Text = "0";
            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr2 = dtDeduction.NewRow();
            dr2["IdDeduction"] = 0;
            dr2["NameDeduction"] = "مساعده";
            dr2["BasePrice"] = txtHelpPrice.Text.Replace(",", "");
            dtDeduction.Rows.Add(dr2);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;

            //قسط وام
            if (txtGestPrice.Text == "") txtGestPrice.Text = "0";
            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr3 = dtDeduction.NewRow();
            dr3["IdDeduction"] = 0;
            dr3["NameDeduction"] = "قسط وام";
            dr3["BasePrice"] = txtGestPrice.Text.Replace(",", "");
            dtDeduction.Rows.Add(dr3);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;

            //سایر کسورات
            if (txtDefDeductoinPrice.Text == "") txtDefDeductoinPrice.Text = "0";
            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr4 = dtDeduction.NewRow();
            dr4["IdDeduction"] = 0;
            dr4["NameDeduction"] = "سایر کسورات";
            dr4["BasePrice"] = txtDefDeductoinPrice.Text.Replace(",", "");
            dtDeduction.Rows.Add(dr4);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;

            //بیمه
            if (txtBemeh.Text == "") txtBemeh.Text = "0";
            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr5 = dtDeduction.NewRow();
            dr5["IdDeduction"] = 0;
            dr5["NameDeduction"] = "بیمه";
            dr5["BasePrice"] = txtBemeh.Text.Replace(",", "");
            dtDeduction.Rows.Add(dr5);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;

            //مالیات
            if (txtTaxPrice.Text == "") txtTaxPrice.Text = "0";
            if (dtDeduction == null) { CreateDeduction(); }
            DataRow dr6 = dtDeduction.NewRow();
            dr6["IdDeduction"] = 0;
            dr6["NameDeduction"] = "مالیات";
            dr6["BasePrice"] = txtTaxPrice.Text.Replace(",", "");
            dtDeduction.Rows.Add(dr6);
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction.DefaultView;
        }

        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            dgvDeduction.Columns.Clear();
            if (dtDeduction == null)
            {
                DataTable table = CreateDeduction();
            }
            DisplayDeduction();

            AddDeduction();

            dgvDeduction.Columns[0].HeaderText = "کد";
            dgvDeduction.Columns[1].HeaderText = "عنوان";
            dgvDeduction.Columns[2].HeaderText = "مبلغ پیش فرض";
            dgvDeduction.Columns[0].Visible = false;
            dgvDeduction.Columns[1].Width = 160;
            dgvDeduction.Columns[2].Width = 120;


            Int64 Sum = 0;
            for (int i = 0; i < dgvDeduction.RowCount; i++)
            {
                Sum = Sum + (Convert.ToInt64(dgvDeduction.Rows[i].Cells[2].Value));
            }
            txtSumDeduction.Text = Sum.ToString();

            if (txtSumSalary.Text == "") txtSumSalary.Text = "0";
            if (txtBaseSalary.Text == "") txtBaseSalary.Text = "0";
            if (txtSumDeduction.Text == "") txtSumDeduction.Text = "0";

            Int64 FinalSalary = (Convert.ToInt64(txtSumSalary.Text.Replace(",", "")) + Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""))) - Convert.ToInt64(txtSumDeduction.Text.Replace(",", ""));
            txtSalaryPrice.Text = FinalSalary.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtSumSalary.Text == "") txtSumSalary.Text = "0";
            if (txtBaseSalary.Text == "") txtBaseSalary.Text = "0";
            if (txtSumDeduction.Text == "") txtSumDeduction.Text = "0";

            if (txtSumSalary.Text == "") txtSumSalary.Text = "0";
            if (txtBaseSalary.Text == "") txtBaseSalary.Text = "0";
            if (txtSumDeduction.Text == "") txtSumDeduction.Text = "0";

            Int64 FinalSalary = (Convert.ToInt64(txtSumSalary.Text.Replace(",", "")) + Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""))) - Convert.ToInt64(txtSumDeduction.Text.Replace(",", ""));
            txtSalaryPrice.Text = FinalSalary.ToString();
        }

        private void btnDelDeduction_Click(object sender, EventArgs e)
        {
            if (dgvDeduction.RowCount == 0)
            {
                return;
            }
            dgvDeduction.Rows.RemoveAt(dgvDeduction.CurrentRow.Index);

            Int64 Sum = 0;
            for (int i = 0; i < dgvDeduction.RowCount; i++)
            {
                Sum = Sum + (Convert.ToInt64(dgvDeduction.Rows[i].Cells[2].Value));
            }
            txtSumDeduction.Text = Sum.ToString();

            Int64 FinalSalary = (Convert.ToInt64(txtSumSalary.Text.Replace(",", "")) + Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""))) - Convert.ToInt64(txtSumDeduction.Text.Replace(",", ""));
            txtSalaryPrice.Text = FinalSalary.ToString();
        }
        void Save()
        {
            if (txtCodeP.Text == string.Empty)
            { errorProvider1.SetError(txtCodeP, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtWorkTime.Text == string.Empty)
            { errorProvider1.SetError(txtWorkTime, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (dgvDeduction.RowCount == 0)
            {
                MessageBox.Show("لیست کسورات خالی می باشد"); return;
            }
            if (dgvSalaryGroup.RowCount == 0)
            {
                MessageBox.Show("لیست حقوق و مزایا خالی می باشد"); return;
            }

            int _CP = Convert.ToInt32(txtCodeP.Text);
            bool _CodeP = db.tblSalary.Where(u => u.CodeP == _CP && u.DateReg == mskDateReg.Text).Any();
            if (_CodeP == true) { MessageBox.Show("این کد پرسنلی قبلا  در این تاریخ حقوق دریافت کرده است"); }

            tblSalary Tbl = new tblSalary();
            Tbl.SalaryId = Convert.ToInt32(txtId.Text);
            Tbl.DateReg = mskDateReg.Text;
            Tbl.Month = txtMonth.Text;
            Tbl.CodeP = Convert.ToInt32(txtCodeP.Text);
            Tbl.OverTime = Convert.ToInt32(txtOverTime.Text);
            Tbl.OverTimePrice = Convert.ToInt64(txtOverTimePrice.Text.Replace(",", ""));
            Tbl.WorkDeduction = Convert.ToInt32(txtWorkDeduction.Text);
            Tbl.WorkDeductionPrice = Convert.ToInt64(txtWorkDeductionPrice.Text.Replace(",", ""));
            Tbl.Mission = Convert.ToInt32(txtMission.Text);
            Tbl.MissionPrice = Convert.ToInt64(txtMissionPrice.Text.Replace(",", ""));
            Tbl.OverDay = Convert.ToInt32(txtOverDay.Text);
            Tbl.OverDayPrice = Convert.ToInt64(txtOverDayPrice.Text.Replace(",", ""));
            Tbl.DeductionDay = Convert.ToInt32(txtDeductionDay.Text);
            Tbl.DeductionDayPrice = Convert.ToInt64(txtDeductionDayPrice.Text.Replace(",", ""));
            Tbl.HelpPrice = Convert.ToInt64(txtHelpPrice.Text.Replace(",", ""));
            Tbl.GestPrice = Convert.ToInt64(txtGestPrice.Text.Replace(",", ""));
            Tbl.DefDeductoinPrice = Convert.ToInt64(txtDefDeductoinPrice.Text.Replace(",", ""));
            Tbl.DefSalaryPrice = Convert.ToInt64(txtDefSalaryPrice.Text.Replace(",", ""));
            Tbl.WorkDay = Convert.ToInt32(txtWorkDay.Text);
            Tbl.WorkTime = Convert.ToInt32(txtWorkTime.Text);
            Tbl.Bemeh = Convert.ToInt64(txtBemeh.Text.Replace(",", ""));
            Tbl.TaxPrice = Convert.ToInt64(txtTaxPrice.Text.Replace(",", ""));
            Tbl.SumSalary = Convert.ToInt64(txtSumSalary.Text.Replace(",", ""));
            Tbl.SumDeduction = Convert.ToInt64(txtSumDeduction.Text.Replace(",", ""));
            Tbl.BaseSalary = Convert.ToInt64(txtBaseSalary.Text.Replace(",", ""));
            Tbl.SalaryPrice = Convert.ToInt64(txtSalaryPrice.Text.Replace(",", ""));
            Tbl.Des = txtDes.Text;
            db.tblSalary.Add(Tbl);
            db.SaveChanges();


            if (Convert.ToInt64(txtGestPrice.Text.Replace(",", "")) > 0 )
            {
                int id = Convert.ToInt32(txtCodeP.Text);
                var loadGest = db.tblVam.Where(u => u.CodeP == id).SingleOrDefault();
                Int64 _Remaining = Convert.ToInt64(loadGest.Remainig);//مانده قبلی وام
                Int64 _RemainingFinal = _Remaining - Convert.ToInt64(txtGestPrice.Text.Replace(",", ""));//مانده جدید وام

                tblVam tbl = new tblVam();
                tbl = db.tblVam.Where(u => u.CodeP == id).SingleOrDefault();
                tbl.Remainig = _RemainingFinal;
                db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            for (int i = 0; i < dgvSalaryGroup.RowCount; i++)
            {
                tblSalary_SalaryGroup _SalaryGroup = new tblSalary_SalaryGroup();
                _SalaryGroup.SalaryId = Convert.ToInt32(txtId.Text);
                _SalaryGroup.IdSalaryGroup = Convert.ToInt32(dgvSalaryGroup.Rows[i].Cells[0].Value);
                _SalaryGroup.SalaryGroup = dgvSalaryGroup.Rows[i].Cells[1].Value.ToString();
                _SalaryGroup.BasePrice = Convert.ToInt64(dgvSalaryGroup.Rows[i].Cells[2].Value);
                db.tblSalary_SalaryGroup.Add(_SalaryGroup);
                db.SaveChanges();
            }
            for (int i = 0; i < dgvDeduction.RowCount; i++)
            {
                tblSalary_Deduction _Deduction = new tblSalary_Deduction();
                _Deduction.SalaryId = Convert.ToInt32(txtId.Text);
                _Deduction.IdDeduction = Convert.ToInt32(dgvDeduction.Rows[i].Cells[0].Value);
                _Deduction.NameDeduction = dgvDeduction.Rows[i].Cells[1].Value.ToString();
                _Deduction.BasePrice = Convert.ToInt64(dgvDeduction.Rows[i].Cells[2].Value);
                db.tblSalary_Deduction.Add(_Deduction);
                db.SaveChanges();
            }
            MessageBox.Show("ثبت انجام شد");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void dgvDeduction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvDeduction.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("N0");
            }
        }

        private void dgvSalaryGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvSalaryGroup.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("N0");
            }
        }
        public DataTable dtSalaryGroup1;
        public DataTable CreateSalaryGroup1()
        {
            dtSalaryGroup1 = new DataTable();

            DataColumn IdSalaryGroup = new DataColumn("IdSalaryGroup", typeof(int));
            dtSalaryGroup1.Columns.Add(IdSalaryGroup);

            DataColumn SalaryGroup = new DataColumn("SalaryGroup", typeof(string));
            dtSalaryGroup1.Columns.Add(SalaryGroup);

            DataColumn BasePrice = new DataColumn("BasePrice", typeof(Int64));
            dtSalaryGroup1.Columns.Add(BasePrice);

            DataColumn id = new DataColumn("id", typeof(int));
            dtSalaryGroup1.Columns.Add(id);

            return dtSalaryGroup1;
        }

        DataTable DisplaySalaryGroup1()
        {
            if (dtSalaryGroup1 == null) { CreateSalaryGroup1(); }
            dtSalaryGroup1.Rows.Clear();
            int _idSalary = Convert.ToInt32(txtId.Text);
            var _SalaryGroup = db.tblSalary_SalaryGroup.Where(u => u.SalaryId == _idSalary).ToList();

            foreach (var item in _SalaryGroup)
            {
                DataRow dr = dtSalaryGroup1.NewRow();
                dr["IdSalaryGroup"] = item.IdSalaryGroup;
                dr["SalaryGroup"] = item.SalaryGroup;
                dr["BasePrice"] = item.BasePrice;
                dr["id"] = item.id;
                dtSalaryGroup1.Rows.Add(dr);
            }
            dgvSalaryGroup.DataSource = null;
            dgvSalaryGroup.DataSource = dtSalaryGroup1.DefaultView;
            return dtSalaryGroup1;
        }
        //----------------------------------
        public DataTable dtDeduction1;
        public DataTable CreateDeduction1()
        {
            dtDeduction1 = new DataTable();

            DataColumn IdDeduction = new DataColumn("IdDeduction", typeof(int));
            dtDeduction1.Columns.Add(IdDeduction);

            DataColumn Deduction = new DataColumn("NameDeduction", typeof(string));
            dtDeduction1.Columns.Add(Deduction);

            DataColumn BasePrice = new DataColumn("BasePrice", typeof(Int64));
            dtDeduction1.Columns.Add(BasePrice);

            DataColumn id = new DataColumn("id", typeof(int));
            dtDeduction1.Columns.Add(id);

            return dtDeduction1;
        }

        DataTable DisplayDeduction1()
        {
            if (dtDeduction1 == null) { CreateDeduction1(); }
            dtDeduction1.Rows.Clear();
            int _idSalary = Convert.ToInt32(txtId.Text);
            var _Deduction = db.tblSalary_Deduction.Where(u => u.SalaryId == _idSalary).ToList();

            foreach (var item in _Deduction)
            {
                DataRow dr = dtDeduction1.NewRow();
                dr["IdDeduction"] = item.IdDeduction;
                dr["NameDeduction"] = item.NameDeduction;
                dr["BasePrice"] = item.BasePrice;
                dr["id"] = item.id;
                dtDeduction1.Rows.Add(dr);
            }
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = dtDeduction1.DefaultView;
            return dtDeduction1;
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (lblFlg.Text != "0")
            {
                Int32 _SalaryId = Convert.ToInt32(txtId.Text);
                var loadSalary = db.View_Salary.Where(u => u.SalaryId == _SalaryId).SingleOrDefault();
                mskDateReg.Text = loadSalary.DateReg;
                txtMonth.Text = loadSalary.Month;
                txtCodeP.Text = Convert.ToString(loadSalary.CodeP);

                Int32 id = Convert.ToInt32(txtCodeP.Text);
                var load = db.tblPerson.Where(u => u.CodeP == id).SingleOrDefault();
                pic.Image = imagebyte(load.Pic);

                int _JobId = Convert.ToInt32(loadSalary.JobsId);
                var loadJob = db.tblJobs.Where(u => u.JobsId == _JobId).SingleOrDefault();
                txtPost.Text = loadJob.JobName;

                txtFLName.Text = loadSalary.FName + " " + loadSalary.LName;
                txtNumChild.Text = Convert.ToString(loadSalary.ChildNum);

                txtOverTime.Text = Convert.ToString(loadSalary.OverTime);
                txtOverTimePrice.Text = Convert.ToString(loadSalary.OverTimePrice);

                txtWorkDeduction.Text = Convert.ToString(loadSalary.WorkDeduction);
                txtWorkDeductionPrice.Text = Convert.ToString(loadSalary.WorkDeductionPrice);

                txtMission.Text = Convert.ToString(loadSalary.Mission);
                txtMissionPrice.Text = Convert.ToString(loadSalary.MissionPrice);

                txtOverDay.Text = Convert.ToString(loadSalary.OverDay);
                txtOverDayPrice.Text = Convert.ToString(loadSalary.OverDayPrice);

                txtDeductionDay.Text = Convert.ToString(loadSalary.DeductionDay);
                txtDeductionDayPrice.Text = Convert.ToString(loadSalary.DeductionDayPrice);

                txtHelpPrice.Text = Convert.ToString(loadSalary.HelpPrice);
                txtGestPrice.Text = Convert.ToString(loadSalary.GestPrice);
                txtDefDeductoinPrice.Text = Convert.ToString(loadSalary.DefDeductoinPrice);
                txtDefSalaryPrice.Text = Convert.ToString(loadSalary.DefSalaryPrice);
                txtWorkDay.Text = Convert.ToString(loadSalary.WorkDay);
                txtWorkTime.Text = Convert.ToString(loadSalary.WorkTime);
                txtBemeh.Text = Convert.ToString(loadSalary.Bemeh);
                txtTaxPrice.Text = Convert.ToString(loadSalary.TaxPrice);
                txtSumSalary.Text = Convert.ToString(loadSalary.SumSalary);
                txtSumDeduction.Text = Convert.ToString(loadSalary.SumDeduction);
                txtBaseSalary.Text = Convert.ToString(loadSalary.BaseSalary);
                txtSalaryPrice.Text = Convert.ToString(loadSalary.SalaryPrice);
                txtDes.Text = loadSalary.Des;
                //-----------------------------------------------
                dgvSalaryGroup.Columns.Clear();
                if (dtSalaryGroup1 == null)
                {
                    DataTable table = CreateSalaryGroup1();
                }
                DisplaySalaryGroup1();

                dgvSalaryGroup.Columns[0].HeaderText = "کد";
                dgvSalaryGroup.Columns[1].HeaderText = "عنوان";
                dgvSalaryGroup.Columns[2].HeaderText = "مبلغ پیش فرض";
                dgvSalaryGroup.Columns[0].Visible = false;
                dgvSalaryGroup.Columns[3].Visible = false;
                dgvSalaryGroup.Columns[1].Width = 160;
                dgvSalaryGroup.Columns[2].Width = 120;

                Int64 Sum = 0;
                for (int i = 0; i < dgvSalaryGroup.RowCount; i++)
                {
                    Sum = Sum + (Convert.ToInt64(dgvSalaryGroup.Rows[i].Cells[2].Value));
                }
                txtSumSalary.Text = Sum.ToString();

                //---------------------------------
                dgvDeduction.Columns.Clear();
                if (dtDeduction == null)
                {
                    DataTable table = CreateDeduction1();
                }
                DisplayDeduction1();

                dgvDeduction.Columns[0].HeaderText = "کد";
                dgvDeduction.Columns[1].HeaderText = "عنوان";
                dgvDeduction.Columns[2].HeaderText = "مبلغ پیش فرض";
                dgvDeduction.Columns[0].Visible = false;
                dgvDeduction.Columns[3].Visible = false;
                dgvDeduction.Columns[1].Width = 160;
                dgvDeduction.Columns[2].Width = 120;


                Int64 Sum1 = 0;
                for (int i = 0; i < dgvDeduction.RowCount; i++)
                {
                    Sum1 = Sum1 + (Convert.ToInt64(dgvDeduction.Rows[i].Cells[2].Value));
                }
                txtSumDeduction.Text = Sum1.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int _SalaryId = Convert.ToInt32(txtId.Text);
            var _CountSalaryGroup = db.tblSalary_SalaryGroup.Where(u => u.SalaryId == _SalaryId).Count();
            for (int i = 0; i < _CountSalaryGroup; i++)
            {
                tblSalary_SalaryGroup Tbl2 = new tblSalary_SalaryGroup();
                Tbl2 = db.tblSalary_SalaryGroup.Where(u => u.SalaryId == _SalaryId).FirstOrDefault();
                db.tblSalary_SalaryGroup.Remove(Tbl2);
                db.SaveChanges();
            }

            var _CountDeduction = db.tblSalary_Deduction.Where(u => u.SalaryId == _SalaryId).Count();
            for (int i = 0; i < _CountDeduction; i++)
            {
                tblSalary_Deduction Tbl3 = new tblSalary_Deduction();
                Tbl3 = db.tblSalary_Deduction.Where(u => u.SalaryId == _SalaryId).FirstOrDefault();
                db.tblSalary_Deduction.Remove(Tbl3);
                db.SaveChanges();
            }
            tblSalary Tbl1 = new tblSalary();
            Tbl1 = db.tblSalary.Where(u => u.SalaryId == _SalaryId).SingleOrDefault();
            db.tblSalary.Remove(Tbl1);
            db.SaveChanges();

            Save();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaxId();
            txtCodeP.Text = txtFLName.Text = txtPost.Text =txtDes.Text= "";
            txtNumChild.Text = txtOverDay.Text = txtOverDayPrice.Text = txtOverTime.Text = txtOverTimePrice.Text = txtMission.Text = txtMissionPrice.Text = txtOverDay.Text = txtOverDayPrice.Text = txtDeductionDay.Text =
                txtDeductionDayPrice.Text = txtHelpPrice.Text = txtGestPrice.Text = txtDefDeductoinPrice.Text = txtDefSalaryPrice.Text = txtWorkTime.Text = txtBemeh.Text = txtTaxPrice.Text = txtSumDeduction.Text =
                txtSumSalary.Text = txtBaseSalary.Text = txtSalaryPrice.Text = "0";
            pic.Image = null;

            dgvDeduction.Rows.Clear();
            dgvSalaryGroup.Rows.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalary_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtId.Text=="") return;
            StiReport report = new StiReport();
            report.Load("Report/rptSalary.mrt");
            report.Compile();
            report["SalaryId"] = Convert.ToInt32(txtId.Text);
            report.ShowWithRibbonGUI();
        }
    }
}
