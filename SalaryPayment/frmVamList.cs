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
    public partial class frmVamList : Office2007Form
    {
        public frmVamList()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void display()
        {
            SalaryDBEntities db = new SalaryDBEntities();
            dataGridViewX1.DataSource = db.View_Vam.ToList();
            Header();
        }

        void Header()
        {
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "کد پرسنلی";
            dataGridViewX1.Columns[2].HeaderText = "نام";
            dataGridViewX1.Columns[3].HeaderText = "نام خانوداگی";
            dataGridViewX1.Columns[3].Width = 150;
            dataGridViewX1.Columns[4].HeaderText = "تاریخ ثبت";
            dataGridViewX1.Columns[5].HeaderText = "شروع اقساط";
            dataGridViewX1.Columns[6].HeaderText = "تعداداقساط";
            dataGridViewX1.Columns[7].HeaderText = "مبلغ وام";
            dataGridViewX1.Columns[8].HeaderText = "مبلغ اقساط";
            dataGridViewX1.Columns[9].HeaderText = "باقیمانده";
            dataGridViewX1.Columns[3].Width = 120;
            dataGridViewX1.Columns[5].Width = 120;
            dataGridViewX1.Columns[7].Width = 120;
            dataGridViewX1.Columns[8].Width = 120;
            dataGridViewX1.Columns[9].Width = 120;
        }

        private void frmVamList_Load(object sender, EventArgs e)
        {
            display();

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskDateReg1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskDateReg2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Vam.Where(u => u.FName.Contains(txtFName.Text)).ToList();
            Header();
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Vam.Where(u => u.LName.Contains(txtLName.Text)).ToList();
            Header();
        }

        private void txtCodeP_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeP.Text != "")
            {
                Int32 id = Convert.ToInt32(txtCodeP.Text);
                dataGridViewX1.DataSource = db.View_Vam.Where(u => u.CodeP == id).ToList();
                Header();
            }
            if (txtCodeP.Text == "")
            {
                display();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Vam.Where(u => u.DateReg.CompareTo(mskDateReg1.Text)>=0 && u.DateReg.CompareTo(mskDateReg2.Text) <= 0).ToList();
            Header();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;
            frmVam frm = new frmVam();
            frm.txtId.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm.lblFlg.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm.lblPersonId.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            frm.txtFName.Text = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
            frm.txtLName.Text = dataGridViewX1.CurrentRow.Cells[3].Value.ToString();
            frm.mskDateReg.Text = dataGridViewX1.CurrentRow.Cells[4].Value.ToString();
            frm.mskStartDate.Text = dataGridViewX1.CurrentRow.Cells[5].Value.ToString();
            frm.txtNumAgsat.Text = dataGridViewX1.CurrentRow.Cells[6].Value.ToString();
            frm.txtPrice.Text = dataGridViewX1.CurrentRow.Cells[7].Value.ToString();
            frm.txtPriceAgsat.Text = dataGridViewX1.CurrentRow.Cells[8].Value.ToString();
            frm.txtRemainig.Text = dataGridViewX1.CurrentRow.Cells[9].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
                display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;

            if (MessageBox.Show("از حذف اطلاعات مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblVam Tbl = new tblVam();
                Tbl = db.tblVam.Find(Convert.ToInt64(dataGridViewX1.CurrentRow.Cells[0].Value));
                db.tblVam.Remove(Tbl);
                db.SaveChanges();
                display();
                MessageBox.Show("حذف اطلاعات انجام شد");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            report.Load("Report/rptVam.mrt");
            report.Compile();
            report["DateReg1"] = mskDateReg1.Text;
            report["DateReg2"] = mskDateReg2.Text;
            report.ShowWithRibbonGUI();
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 8 && e.RowIndex != this.dataGridViewX1.NewRowIndex || e.ColumnIndex == 9 && e.RowIndex != this.dataGridViewX1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("N0");
            }
        }
    }
}
