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
    public partial class frmPersonList : Office2007Form
    {
        public frmPersonList()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void display()
        {
            SalaryDBEntities db = new SalaryDBEntities();
            dataGridViewX1.DataSource = db.View_Person.ToList();
            Header();
        }

        void Header()
        {
            dataGridViewX1.Columns[0].HeaderText = "نام";
            dataGridViewX1.Columns[1].HeaderText = "نام خانوداگی";
            dataGridViewX1.Columns[1].Width = 150;
            dataGridViewX1.Columns[2].HeaderText = "نام پدر";
            dataGridViewX1.Columns[3].HeaderText = "کد ملی";
            dataGridViewX1.Columns[4].HeaderText = "ش شناسنامه";
            dataGridViewX1.Columns[4].Width = 120;
            dataGridViewX1.Columns[5].HeaderText = "تاریخ تولد";
            dataGridViewX1.Columns[6].HeaderText = "جنسیت";
            dataGridViewX1.Columns[7].HeaderText = "وضعیت تاهل";
            dataGridViewX1.Columns[8].HeaderText = "تعداد فرزند";
            dataGridViewX1.Columns[9].HeaderText = "کد گروه";
            dataGridViewX1.Columns[9].Visible = false;
            dataGridViewX1.Columns[10].HeaderText = "گروه بندی";
            dataGridViewX1.Columns[11].HeaderText = "سربازی";
            dataGridViewX1.Columns[12].HeaderText = "تلفن";
            dataGridViewX1.Columns[13].HeaderText = "موبایل";
            dataGridViewX1.Columns[14].HeaderText = "تحصیلات";
            dataGridViewX1.Columns[15].HeaderText = "رشته تحصیلی";
            dataGridViewX1.Columns[15].Width = 150;
            dataGridViewX1.Columns[16].HeaderText = "آدرس";
            dataGridViewX1.Columns[16].Width = 300;
            dataGridViewX1.Columns[17].HeaderText = "کد پرسنلی";
            dataGridViewX1.Columns[18].HeaderText = "کد شغل";
            dataGridViewX1.Columns[18].Visible = false;
            dataGridViewX1.Columns[19].HeaderText = "سمت";
            dataGridViewX1.Columns[19].Width = 150;
            dataGridViewX1.Columns[20].HeaderText = "بیمه";
            dataGridViewX1.Columns[21].HeaderText = "تاریخ استخدام";
            dataGridViewX1.Columns[21].Width = 120;
            dataGridViewX1.Columns[22].HeaderText = "نوع استخدام";
            dataGridViewX1.Columns[22].Width = 120;
            dataGridViewX1.Columns[23].HeaderText = "شماره حساب";
            dataGridViewX1.Columns[23].Width = 150;
            dataGridViewX1.Columns[24].HeaderText = "شماره کارت";
            dataGridViewX1.Columns[24].Width = 150;
            dataGridViewX1.Columns[25].HeaderText = "شماره شبا";
            dataGridViewX1.Columns[25].Width = 300;
            dataGridViewX1.Columns[26].HeaderText = "نام بانک";
           
        }

        private void frmPersonList_Load(object sender, EventArgs e)
        {
            display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Person.Where(u => u.JobName.Contains(txtName.Text)).ToList();
            Header();
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Person.Where(u => u.FName.Contains(txtFName.Text)).ToList();
            Header();
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.View_Person.Where(u => u.LName.Contains(txtLName.Text)).ToList();
            Header();
        }

        private void txtCodeP_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeP.Text !="")
            {
                Int32 id = Convert.ToInt32(txtCodeP.Text);
                dataGridViewX1.DataSource = db.View_Person.Where(u => u.CodeP == id).ToList();
                Header();
            }
            if (txtCodeP.Text == "")
            {
                display();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;
            frmPerson frm = new frmPerson();
            frm.txtFName.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm._FName = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm.txtLName.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            frm._LName = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            frm.txtFather.Text = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
            frm.txtCodeM.Text = dataGridViewX1.CurrentRow.Cells[3].Value.ToString();
            frm.txtShSh.Text = dataGridViewX1.CurrentRow.Cells[4].Value.ToString();
            frm.mskBrDate.Text = dataGridViewX1.CurrentRow.Cells[5].Value.ToString();
            frm.cmbJensiyat.Text = dataGridViewX1.CurrentRow.Cells[6].Value.ToString();
            frm.cmbTaahol.Text = dataGridViewX1.CurrentRow.Cells[7].Value.ToString();
            frm.txtChildNum.Text = dataGridViewX1.CurrentRow.Cells[8].Value.ToString();
            frm.lblGroupId.Text = dataGridViewX1.CurrentRow.Cells[9].Value.ToString();
            frm.cmbPersonGroup.Text = dataGridViewX1.CurrentRow.Cells[10].Value.ToString();
            frm.cmbSarbazi.Text = dataGridViewX1.CurrentRow.Cells[11].Value.ToString();
            frm.txtTel.Text = dataGridViewX1.CurrentRow.Cells[12].Value.ToString();
            frm.txtMobile.Text = dataGridViewX1.CurrentRow.Cells[13].Value.ToString();
            frm.cmbTahsilat.Text = dataGridViewX1.CurrentRow.Cells[14].Value.ToString();
            frm.txtReshteh.Text = dataGridViewX1.CurrentRow.Cells[15].Value.ToString();
            frm.txtAddress.Text = dataGridViewX1.CurrentRow.Cells[16].Value.ToString();
            frm.txtCodeP.Text = dataGridViewX1.CurrentRow.Cells[17].Value.ToString();
            frm.lblFlg.Text = dataGridViewX1.CurrentRow.Cells[17].Value.ToString();
            frm.lblJobsId.Text = dataGridViewX1.CurrentRow.Cells[18].Value.ToString();
            frm.cmbJobs.Text = dataGridViewX1.CurrentRow.Cells[19].Value.ToString();
            frm.txtBemeh.Text = dataGridViewX1.CurrentRow.Cells[20].Value.ToString();
            frm.mskDateReg.Text = dataGridViewX1.CurrentRow.Cells[21].Value.ToString();
            frm.cmbTypeReg.Text = dataGridViewX1.CurrentRow.Cells[22].Value.ToString();
            frm.txtShHesab.Text = dataGridViewX1.CurrentRow.Cells[23].Value.ToString();
            frm.txtShCard.Text = dataGridViewX1.CurrentRow.Cells[24].Value.ToString();
            frm.txtShaba.Text = dataGridViewX1.CurrentRow.Cells[25].Value.ToString();
            frm.txtBank.Text = dataGridViewX1.CurrentRow.Cells[26].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
                display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;

            if (MessageBox.Show("از حذف اطلاعات مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblPerson Tbl = new tblPerson();
                Tbl = db.tblPerson.Find(Convert.ToInt64(dataGridViewX1.CurrentRow.Cells[17].Value));
                db.tblPerson.Remove(Tbl);
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
            report.Load("Report/rptPerson.mrt");
            report.Compile();
            report.ShowWithRibbonGUI();
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            if (lblFlg.Text=="vam")
            {
                frmVam frm = (frmVam)Application.OpenForms["FrmVam"];
                frm.GetPerson(dataGridViewX1.CurrentRow.Cells[17].Value.ToString(), dataGridViewX1.CurrentRow.Cells[0].Value.ToString(), dataGridViewX1.CurrentRow.Cells[1].Value.ToString());
                this.Close();
            }
            if (lblFlg.Text == "Salary")
            {
                frmSalary frm = (frmSalary)Application.OpenForms["frmSalary"];
                frm.GetPerson(dataGridViewX1.CurrentRow.Cells[17].Value.ToString(), dataGridViewX1.CurrentRow.Cells[0].Value.ToString(), dataGridViewX1.CurrentRow.Cells[1].Value.ToString(), dataGridViewX1.CurrentRow.Cells[8].Value.ToString(), dataGridViewX1.CurrentRow.Cells[19].Value.ToString());
                this.Close();
            }
        }
    }
}
