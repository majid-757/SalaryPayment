using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;
namespace SalaryPayment
{
    public partial class frmInfo : Office2007Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        SalaryDBEntities db = new SalaryDBEntities();

        Image imagebyte(byte[] bytes)
        {
            MemoryStream m = new System.IO.MemoryStream(bytes);
            return Image.FromStream(m);
        }
        public byte[] ImageToByteArray(Image imagein)
        {
            using (var ms = new MemoryStream())
            {
                imagein.Save(ms, ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            var a = db.tblInfo.Count();
            if (a != 0)
            {
                var load = db.tblInfo.SingleOrDefault();
                txtId.Text = Convert.ToString(load.Id);
                txtName.Text = load.Name;
                txtTel1.Text = load.Tel1;
                txtTel2.Text = load.Tel2;
                txtFax.Text = load.Fax;
                txtAddress.Text = load.Address;
                pic.Image = imagebyte(load.Pic);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                var op = openFileDialog1;

                op.Filter = ("Image Files |*.png; *.jpg; *.jpeg;");
                op.FilterIndex = 2;
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "لطفا یک تصویر انتخاب کنید";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch { }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pic.Image = null;
        }
        void Save()
        {
            if (txtId.Text==string.Empty)
            {errorProvider1.SetError(txtId, "نمی تواند خالی باشد"); return; }
            else {errorProvider1.Clear();}

            if (txtName.Text == string.Empty)
            { errorProvider1.SetError(txtName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtTel1.Text == string.Empty)
            { errorProvider1.SetError(txtTel1, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            tblInfo Tbl = new tblInfo();
            Tbl.Id = Convert.ToInt64(txtId.Text);
            Tbl.Name = txtName.Text;
            Tbl.Tel1 = txtTel1.Text;
            Tbl.Tel2 = txtTel2.Text;
            Tbl.Fax = txtFax.Text;
            Tbl.Address = txtAddress.Text;
            Tbl.Pic = ImageToByteArray(pic.Image);
            db.tblInfo.Add(Tbl);
            db.SaveChanges();
            MessageBox.Show("ثبت اطلاعات انجام شد");

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var a = db.tblInfo.Count();
            if (a != 0)
            {
                tblInfo Tbl = new tblInfo();
                Tbl = db.tblInfo.Find(Convert.ToInt64(txtId.Text));
                db.tblInfo.Remove(Tbl);
                db.SaveChanges();

                Save();
            }
            if (a==0)
            {
                Save();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
