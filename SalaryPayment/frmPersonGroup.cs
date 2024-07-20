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
    public partial class frmPersonGroup : Office2007Form
    {
        public frmPersonGroup()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        void display()
        {
            SalaryDBEntities db = new SalaryDBEntities();
            dataGridViewX1.DataSource = db.tblPersonGroup.ToList();
            dataGridViewX1.Columns[0].HeaderText = "کد گروه";
            dataGridViewX1.Columns[1].HeaderText = "عنوان گروه";
            dataGridViewX1.Columns[1].Width = 200;
            dataGridViewX1.Columns[2].Visible = false;
        }
        void MaxId()
        {
            var Maxf = db.tblPersonGroup.Select(u => u.GroupId).DefaultIfEmpty(0).Max();
            string id = Convert.ToString(Maxf);
            if (id == "")
                txtId.Text = "1";
            else
            {
                Int64 IdFinal = 1 + Int64.Parse(id);
                txtId.Text = IdFinal.ToString();
            }
        }
        private void frmPersonGroup_Load(object sender, EventArgs e)
        {
            display();
            MaxId();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            bool _PersonGroup = db.tblPersonGroup.Where(u => u.PersonGroup == txtName.Text).Any();
            if (_PersonGroup == true) { MessageBox.Show("این گروه بندی قبلا ثبت شده است"); return; }

            tblPersonGroup tbl = new tblPersonGroup();
            tbl.GroupId = Convert.ToInt32(txtId.Text);
            tbl.PersonGroup = txtName.Text;
            db.tblPersonGroup.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("ثبت اطلاعات انجام شد");
            display();
            txtName.Text = "";
            MaxId();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (dataGridViewX1.CurrentRow.Cells[1].Value.ToString() != txtName.Text)
            {
                bool _PersonGroup = db.tblPersonGroup.Where(u => u.PersonGroup == txtName.Text).Any();
                if (_PersonGroup == true) { MessageBox.Show("این گروه بندی قبلا ثبت شده است"); return; }
            }

            var chk = db.Set<tblPersonGroup>().Local.FirstOrDefault(u => u.GroupId == Convert.ToInt32(txtId.Text));
            if (chk != null)
            {
                db.Entry(chk).State = System.Data.Entity.EntityState.Detached;
            }

            tblPersonGroup tbl = new tblPersonGroup();
            tbl.GroupId = Convert.ToInt32(txtId.Text);
            tbl.PersonGroup = txtName.Text;
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
            display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount == 0) return;

            if (MessageBox.Show("از حذف اطلاعات مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblPersonGroup Tbl = new tblPersonGroup();
                Tbl = db.tblPersonGroup.Find(Convert.ToInt32(txtId.Text));
                db.tblPersonGroup.Remove(Tbl);
                db.SaveChanges();
                display();
                txtName.Text = "";
                MaxId();
                MessageBox.Show("حذف اطلاعات انجام شد");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            MaxId();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridViewX1_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
