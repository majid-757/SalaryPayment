﻿using System;
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
    public partial class frmDeductionList : Office2007Form
    {
        public frmDeductionList()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void display()
        {
            SalaryDBEntities db = new SalaryDBEntities();
            dataGridViewX1.DataSource = db.tblDeduction.ToList();
            Header();
        }

        void Header()
        {
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[1].HeaderText = "عنوان کسورات";
            dataGridViewX1.Columns[2].HeaderText = "مبلغ پیش فرض";
            dataGridViewX1.Columns[1].Width = 300;
            dataGridViewX1.Columns[2].Width = 150;
        }
        private void frmDeductionList_Load(object sender, EventArgs e)
        {
            display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = db.tblDeduction.Where(u => u.NameDeduction.Contains(txtName.Text)).ToList();
            Header();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;
            frmDeduction frm = new frmDeduction();
            frm.txtId.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm.lblFlg.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frm.txtName.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            frm.txtBasePrice.Text = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
                display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;

            if (MessageBox.Show("از حذف اطلاعات مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblDeduction Tbl = new tblDeduction();
                Tbl = db.tblDeduction.Find(Convert.ToInt64(dataGridViewX1.CurrentRow.Cells[0].Value));
                db.tblDeduction.Remove(Tbl);
                db.SaveChanges();
                display();
                MessageBox.Show("حذف اطلاعات انجام شد");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dataGridViewX1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("N0");
            }
        }
    }
}