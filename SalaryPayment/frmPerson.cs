using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SalaryPayment
{
    public partial class frmPerson : Office2007Form
    {
        public frmPerson()
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
        void MaxId()
        {
            var Maxf = db.tblPerson.Select(u => u.CodeP).DefaultIfEmpty(0).Max();
            string id = Convert.ToString(Maxf);
            if (id == "")
                txtCodeP.Text = "1";
            else
            {
                Int64 IdFinal = 1 + Int64.Parse(id);
                txtCodeP.Text = IdFinal.ToString();
            }
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            if (lblFlg.Text == "0")
            {
                btnEdit.Enabled = false;
                MaxId();

                List<tblPersonGroup> list1 = new List<tblPersonGroup>();
                list1.Add(new tblPersonGroup()
                {
                    PersonGroup = ""
                });
                list1.AddRange(db.tblPersonGroup.ToList());
                cmbPersonGroup.DataSource = list1;
                cmbPersonGroup.DisplayMember = "PersonGroup";

                List<tblJobs> list2 = new List<tblJobs>();
                list2.Add(new tblJobs()
                {
                    JobName = ""
                });
                list2.AddRange(db.tblJobs.ToList());
                cmbJobs.DataSource = list2;
                cmbJobs.DisplayMember = "JobName";
            }
            if (lblFlg.Text != "0")
            {
                Int32 id = Convert.ToInt32(txtCodeP.Text);
                var load = db.tblPerson.Where(u=>u.CodeP==id).SingleOrDefault();
                pic.Image = imagebyte(load.Pic);

                btnSave.Enabled = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCodeM.Text == string.Empty)
            { errorProvider1.SetError(txtCodeM, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtFName.Text == string.Empty)
            { errorProvider1.SetError(txtFName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtLName.Text == string.Empty)
            { errorProvider1.SetError(txtLName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtMobile.Text == string.Empty)
            { errorProvider1.SetError(txtMobile, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtChildNum.Text == string.Empty)
            { errorProvider1.SetError(txtChildNum, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtCodeP.Text == string.Empty)
            { errorProvider1.SetError(txtCodeP, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (cmbJobs.Text == string.Empty)
            { errorProvider1.SetError(cmbJobs, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            bool _Person = db.tblPerson.Where(u => u.FName == txtFName.Text && u.LName == txtLName.Text).Any();
            if (_Person == true) { MessageBox.Show("این شخص قبلا ثبت شده است"); return; }

            int _CP = Convert.ToInt32(txtCodeP.Text);
            bool _CodeP = db.tblPerson.Where(u => u.CodeP == _CP).Any();
            if (_CodeP == true) { MessageBox.Show("این کد پرسنلی قبلا ثبت شده است"); return; }


            tblPerson Tbl = new tblPerson();
            Tbl.FName = txtFName.Text;
            Tbl.LName = txtLName.Text;
            Tbl.Father = txtFather.Text;
            Tbl.CodeM = txtCodeM.Text;
            Tbl.ShSh = txtShSh.Text;
            Tbl.BrDate = mskBrDate.Text;
            Tbl.Jensiyat = cmbJensiyat.Text;
            Tbl.Taahol = cmbTaahol.Text;
            Tbl.ChildNum = Convert.ToInt32(txtChildNum.Text);
            Tbl.GroupId = Convert.ToInt32(lblGroupId.Text);
            Tbl.Sarbazi = cmbSarbazi.Text;
            Tbl.Tel = txtTel.Text;
            Tbl.Mobile = txtMobile.Text;
            Tbl.Tahsilat = cmbTahsilat.Text;
            Tbl.Reshteh = txtReshteh.Text;
            Tbl.Address = txtAddress.Text;
            Tbl.CodeP = Convert.ToInt32(txtCodeP.Text);
            Tbl.JobsId = Convert.ToInt32(lblJobsId.Text);
            Tbl.Bemeh = txtBemeh.Text;
            Tbl.DateReg = mskDateReg.Text;
            Tbl.TypeReg = cmbTypeReg.Text;
            Tbl.ShHesab = txtShHesab.Text;
            Tbl.ShCard = txtShCard.Text;
            Tbl.Shaba = txtShaba.Text;
            Tbl.Bank = txtBank.Text;

            Tbl.Pic = ImageToByteArray(pic.Image);
            db.tblPerson.Add(Tbl);
            db.SaveChanges();
            MessageBox.Show("ثبت اطلاعات انجام شد");
        }

        private void cmbPersonGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = db.tblPersonGroup.Where(u => u.PersonGroup == cmbPersonGroup.Text).Select(u => u.GroupId).SingleOrDefault();
            lblGroupId.Text = id.ToString();
        }

        private void cmbJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = db.tblJobs.Where(u => u.JobName == cmbJobs.Text).Select(u => u.JobsId).SingleOrDefault();
            lblJobsId.Text = id.ToString();
        }
       public string _FName;
       public string _LName;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCodeM.Text == string.Empty)
            { errorProvider1.SetError(txtCodeM, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtFName.Text == string.Empty)
            { errorProvider1.SetError(txtFName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtLName.Text == string.Empty)
            { errorProvider1.SetError(txtLName, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtMobile.Text == string.Empty)
            { errorProvider1.SetError(txtMobile, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtChildNum.Text == string.Empty)
            { errorProvider1.SetError(txtChildNum, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (txtCodeP.Text == string.Empty)
            { errorProvider1.SetError(txtCodeP, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (cmbJobs.Text == string.Empty)
            { errorProvider1.SetError(cmbJobs, "نمی تواند خالی باشد"); return; }
            else { errorProvider1.Clear(); }

            if (_FName != txtFName.Text && _LName != txtLName.Text)
            {
                bool _Person = db.tblPerson.Where(u => u.FName == txtFName.Text && u.LName == txtLName.Text).Any();
                if (_Person == true) { MessageBox.Show("این شخص قبلا ثبت شده است"); return; }
            }

            int _CP = Convert.ToInt32(txtCodeP.Text);

            var chk = db.Set<tblPerson>().Local.FirstOrDefault(u => u.CodeP == _CP);
            if (chk != null)
            {
                db.Entry(chk).State = System.Data.Entity.EntityState.Detached;
            }

            tblPerson Tbl = new tblPerson();
            Tbl.FName = txtFName.Text;
            Tbl.LName = txtLName.Text;
            Tbl.Father = txtFather.Text;
            Tbl.CodeM = txtCodeM.Text;
            Tbl.ShSh = txtShSh.Text;
            Tbl.BrDate = mskBrDate.Text;
            Tbl.Jensiyat = cmbJensiyat.Text;
            Tbl.Taahol = cmbTaahol.Text;
            Tbl.ChildNum = Convert.ToInt32(txtChildNum.Text);
            Tbl.GroupId = Convert.ToInt32(lblGroupId.Text);
            Tbl.Sarbazi = cmbSarbazi.Text;
            Tbl.Tel = txtTel.Text;
            Tbl.Mobile = txtMobile.Text;
            Tbl.Tahsilat = cmbTahsilat.Text;
            Tbl.Reshteh = txtReshteh.Text;
            Tbl.Address = txtAddress.Text;
            Tbl.CodeP = Convert.ToInt32(txtCodeP.Text);
            Tbl.JobsId = Convert.ToInt32(lblJobsId.Text);
            Tbl.Bemeh = txtBemeh.Text;
            Tbl.DateReg = mskDateReg.Text;
            Tbl.TypeReg = cmbTypeReg.Text;
            Tbl.ShHesab = txtShHesab.Text;
            Tbl.ShCard = txtShCard.Text;
            Tbl.Shaba = txtShaba.Text;
            Tbl.Bank = txtBank.Text;

            Tbl.Pic = ImageToByteArray(pic.Image);

            db.Entry(Tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("ویرایش اطلاعات انجام شد");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFName.Text = txtLName.Text = txtFName.Text = txtChildNum.Text = txtCodeM.Text = txtShSh.Text = txtTel.Text = txtMobile.Text = txtReshteh.Text = txtAddress.Text = txtBemeh.Text = txtShHesab.Text = txtShCard.Text = txtBank.Text = txtShaba.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cmbPersonGroup_Click(object sender, EventArgs e)
        {
            List<tblPersonGroup> list1 = new List<tblPersonGroup>();
            list1.Add(new tblPersonGroup()
            {
                PersonGroup = ""
            });
            list1.AddRange(db.tblPersonGroup.ToList());
            cmbPersonGroup.DataSource = list1;
            cmbPersonGroup.DisplayMember = "PersonGroup";
        }

        private void cmbJobs_Click(object sender, EventArgs e)
        {
            List<tblJobs> list2 = new List<tblJobs>();
            list2.Add(new tblJobs()
            {
                JobName = ""
            });
            list2.AddRange(db.tblJobs.ToList());
            cmbJobs.DataSource = list2;
            cmbJobs.DisplayMember = "JobName";
        }
    }
}
