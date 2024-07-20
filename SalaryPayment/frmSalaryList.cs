using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Stimulsoft.Report;
namespace SalaryPayment
{
    public partial class frmSalaryList : Office2007Form
    {
        public frmSalaryList()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void display()
        {
            SalaryDBEntities db = new SalaryDBEntities();
            dataGridViewX1.DataSource = db.View_Salary.ToList();
            Header();
        }

        void Header()
        {
            dataGridViewX1.Columns[0].HeaderText = "شماره فیش";
            dataGridViewX1.Columns[1].HeaderText = "تاریخ";
            dataGridViewX1.Columns[2].HeaderText = "ماه";
            dataGridViewX1.Columns[3].HeaderText = "کد پرسنلی";
            dataGridViewX1.Columns[4].HeaderText = "نام";
            dataGridViewX1.Columns[5].HeaderText = "نام خانوادگی";
            dataGridViewX1.Columns[6].HeaderText = "تعداد فرزند";
            dataGridViewX1.Columns[7].HeaderText = "کد شغل";
            dataGridViewX1.Columns[7].Visible = false;
            dataGridViewX1.Columns[8].HeaderText = "سمت";
            dataGridViewX1.Columns[9].HeaderText = "اضافه کاری";
            dataGridViewX1.Columns[10].HeaderText = "مبلغ هر ساعت";
            dataGridViewX1.Columns[11].HeaderText = "کسر کاری";
            dataGridViewX1.Columns[12].HeaderText = "مبلغ هر ساعت";
            dataGridViewX1.Columns[13].HeaderText = "ماموریت";
            dataGridViewX1.Columns[14].HeaderText = "مبلغ هر روز";
            dataGridViewX1.Columns[15].HeaderText = "اضافه کار روز تعطیل";
            dataGridViewX1.Columns[16].HeaderText = "مبلغ هر روز";
            dataGridViewX1.Columns[17].HeaderText = "روزهای غیبت";
            dataGridViewX1.Columns[18].HeaderText = "مبلغ هر روز";
            dataGridViewX1.Columns[19].HeaderText = "مساعده";
            dataGridViewX1.Columns[20].HeaderText = "قسط وام";
            dataGridViewX1.Columns[21].HeaderText = "سایر کسورات";
            dataGridViewX1.Columns[22].HeaderText = "سایر حقوق و مزایا";
            dataGridViewX1.Columns[23].HeaderText = "تعداد روز کاری";
            dataGridViewX1.Columns[24].HeaderText = "ساعت کاری";
            dataGridViewX1.Columns[25].HeaderText = "بیمه";
            dataGridViewX1.Columns[26].HeaderText = "مالیات";
            dataGridViewX1.Columns[27].HeaderText = "جمع حقوق و مزایا";
            dataGridViewX1.Columns[28].HeaderText = "جمع کسورات";      
            dataGridViewX1.Columns[29].HeaderText = "حقوق پایه";
            dataGridViewX1.Columns[30].HeaderText = "مبلغ قابل پرداخت";
            dataGridViewX1.Columns[31].HeaderText = "توضیحات";
            dataGridViewX1.Columns[31].Width = 300;
            dataGridViewX1.Columns[5].Width = 160;
            dataGridViewX1.Columns[6].Width = 120;
            dataGridViewX1.Columns[10].Width = 120;
            dataGridViewX1.Columns[12].Width = 120;
            dataGridViewX1.Columns[14].Width = 120;
            dataGridViewX1.Columns[15].Width = 150;
            dataGridViewX1.Columns[16].Width = 120;
            dataGridViewX1.Columns[17].Width = 120;
            dataGridViewX1.Columns[18].Width = 120;
            dataGridViewX1.Columns[21].Width = 120;
            dataGridViewX1.Columns[22].Width = 150;
            dataGridViewX1.Columns[23].Width = 140;
            dataGridViewX1.Columns[27].Width = 150;
            dataGridViewX1.Columns[28].Width = 120;
            dataGridViewX1.Columns[29].Width = 120;
            dataGridViewX1.Columns[30].Width = 150;
        }

        private void frmSalaryList_Load(object sender, EventArgs e)
        {
            display();

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskDateReg1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskDateReg2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");


        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Salary.Where(u => u.FName.Contains(txtFName.Text)).ToList();
            Header();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Salary.Where(u => u.LName.Contains(textBoxX1.Text)).ToList();
            Header();
        }

        private void txtPost_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Salary.Where(u => u.JobName.Contains(txtPost.Text)).ToList();
            Header();
        }

        private void txtCodeP_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeP.Text != "")
            {
                Int32 id = Convert.ToInt32(txtCodeP.Text);
                dataGridViewX1.DataSource = db.View_Salary.Where(u => u.CodeP == id).ToList();
                Header();
            }
            if (txtCodeP.Text == "")
            {
                display();
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                Int32 id = Convert.ToInt32(txtId.Text);
                dataGridViewX1.DataSource = db.View_Salary.Where(u => u.SalaryId == id).ToList();
                Header();
            }
            if (txtId.Text == "")
            {
                display();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Salary.Where(u => u.DateReg.CompareTo(mskDateReg1.Text)>=0 && u.DateReg.CompareTo(mskDateReg2.Text) <= 0).ToList();
            Header();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSalary frm = new frmSalary();
            frm.lblFlg.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm.txtId.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
           
            if (frm.ShowDialog() == DialogResult.OK)
                display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;

            if (MessageBox.Show("از حذف اطلاعات مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _SalaryId = Convert.ToInt32(dataGridViewX1.CurrentRow.Cells[0].Value.ToString());
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
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Salary.Where(u => u.DateReg.Contains(mskYear.Text)&& u.Month==txtMonth.Text).ToList();
            Header();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            display();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;
            StiReport report = new StiReport();
            report.Load("Report/rptSalaryList.mrt");
            report.Compile();
            report["Year"] = mskYear.Text;
            report["Month"] = txtMonth.Text;
            report.ShowWithRibbonGUI();
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 12 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 14 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 16 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 18 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 19 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 20 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 21 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 22 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 25 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 26 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 27 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 28 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 29 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 30 && e.RowIndex != this.dataGridViewX1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("N0");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;
            StiReport report = new StiReport();
            report.Load("Report/rptSalary.mrt");
            report.Compile();
            report["SalaryId"] = Convert.ToInt32(dataGridViewX1.CurrentRow.Cells[0].Value);
            report.ShowWithRibbonGUI();
        }
    }
}
