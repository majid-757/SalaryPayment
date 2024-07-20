
namespace SalaryPayment
{
    partial class frmVam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnNew = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnBack = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.lblFlg = new System.Windows.Forms.Label();
            this.txtLName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumAgsat = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPriceAgsat = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.mskStartDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.mskDateReg = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPersonId = new System.Windows.Forms.Label();
            this.btnCal = new DevComponents.DotNetBar.ButtonX();
            this.txtRemainig = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.White;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnNew);
            this.groupPanel3.Controls.Add(this.btnEdit);
            this.groupPanel3.Controls.Add(this.btnBack);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 274);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(330, 43);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 9;
            // 
            // btnNew
            // 
            this.btnNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.Location = new System.Drawing.Point(99, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 37);
            this.btnNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNew.Symbol = "";
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "جدید";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(174, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 37);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.Symbol = "";
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBack
            // 
            this.btnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 37);
            this.btnBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBack.Symbol = "";
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "بازگشت";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(249, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.Symbol = "";
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFlg
            // 
            this.lblFlg.AutoSize = true;
            this.lblFlg.Location = new System.Drawing.Point(43, 135);
            this.lblFlg.Name = "lblFlg";
            this.lblFlg.Size = new System.Drawing.Size(15, 16);
            this.lblFlg.TabIndex = 1;
            this.lblFlg.Text = "0";
            this.lblFlg.Visible = false;
            // 
            // txtLName
            // 
            this.txtLName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLName.Border.Class = "TextBoxBorder";
            this.txtLName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLName.DisabledBackColor = System.Drawing.Color.White;
            this.txtLName.Enabled = false;
            this.txtLName.FocusHighlightEnabled = true;
            this.txtLName.ForeColor = System.Drawing.Color.Black;
            this.txtLName.Location = new System.Drawing.Point(16, 69);
            this.txtLName.Name = "txtLName";
            this.txtLName.PreventEnterBeep = true;
            this.txtLName.Size = new System.Drawing.Size(192, 23);
            this.txtLName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "نام خانوادگی";
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFName.Border.Class = "TextBoxBorder";
            this.txtFName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFName.Enabled = false;
            this.txtFName.FocusHighlightEnabled = true;
            this.txtFName.ForeColor = System.Drawing.Color.Black;
            this.txtFName.Location = new System.Drawing.Point(43, 40);
            this.txtFName.Name = "txtFName";
            this.txtFName.PreventEnterBeep = true;
            this.txtFName.Size = new System.Drawing.Size(165, 23);
            this.txtFName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "نام شخص";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtId.Border.Class = "TextBoxBorder";
            this.txtId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtId.DisabledBackColor = System.Drawing.Color.White;
            this.txtId.Enabled = false;
            this.txtId.FocusHighlightEnabled = true;
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Location = new System.Drawing.Point(43, 12);
            this.txtId.Name = "txtId";
            this.txtId.PreventEnterBeep = true;
            this.txtId.Size = new System.Drawing.Size(164, 23);
            this.txtId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "کد وام";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "تاریخ شروع اقساط";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "تعداد اقساط";
            // 
            // txtNumAgsat
            // 
            this.txtNumAgsat.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNumAgsat.Border.Class = "TextBoxBorder";
            this.txtNumAgsat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumAgsat.DisabledBackColor = System.Drawing.Color.White;
            this.txtNumAgsat.FocusHighlightEnabled = true;
            this.txtNumAgsat.ForeColor = System.Drawing.Color.Black;
            this.txtNumAgsat.Location = new System.Drawing.Point(18, 158);
            this.txtNumAgsat.Name = "txtNumAgsat";
            this.txtNumAgsat.PreventEnterBeep = true;
            this.txtNumAgsat.Size = new System.Drawing.Size(192, 23);
            this.txtNumAgsat.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "مبلغ وام";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPrice.Border.Class = "TextBoxBorder";
            this.txtPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrice.DisabledBackColor = System.Drawing.Color.White;
            this.txtPrice.FocusHighlightEnabled = true;
            this.txtPrice.ForeColor = System.Drawing.Color.Black;
            this.txtPrice.Location = new System.Drawing.Point(18, 187);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PreventEnterBeep = true;
            this.txtPrice.Size = new System.Drawing.Size(192, 23);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtPriceAgsat
            // 
            this.txtPriceAgsat.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPriceAgsat.Border.Class = "TextBoxBorder";
            this.txtPriceAgsat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPriceAgsat.DisabledBackColor = System.Drawing.Color.White;
            this.txtPriceAgsat.Enabled = false;
            this.txtPriceAgsat.FocusHighlightEnabled = true;
            this.txtPriceAgsat.ForeColor = System.Drawing.Color.Black;
            this.txtPriceAgsat.Location = new System.Drawing.Point(64, 216);
            this.txtPriceAgsat.Name = "txtPriceAgsat";
            this.txtPriceAgsat.PreventEnterBeep = true;
            this.txtPriceAgsat.Size = new System.Drawing.Size(145, 23);
            this.txtPriceAgsat.TabIndex = 8;
            this.txtPriceAgsat.TextChanged += new System.EventHandler(this.txtPriceAgsat_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "مبلغ اقساط";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX1.Location = new System.Drawing.Point(17, 40);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(24, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "57390";
            this.buttonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // mskStartDate
            // 
            // 
            // 
            // 
            this.mskStartDate.BackgroundStyle.Class = "TextBoxBorder";
            this.mskStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mskStartDate.ButtonClear.Visible = true;
            this.mskStartDate.Location = new System.Drawing.Point(99, 129);
            this.mskStartDate.Mask = "####/##/##";
            this.mskStartDate.Name = "mskStartDate";
            this.mskStartDate.Size = new System.Drawing.Size(111, 22);
            this.mskStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.mskStartDate.TabIndex = 5;
            this.mskStartDate.Text = "";
            // 
            // mskDateReg
            // 
            // 
            // 
            // 
            this.mskDateReg.BackgroundStyle.Class = "TextBoxBorder";
            this.mskDateReg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mskDateReg.ButtonClear.Visible = true;
            this.mskDateReg.Location = new System.Drawing.Point(97, 98);
            this.mskDateReg.Mask = "####/##/##";
            this.mskDateReg.Name = "mskDateReg";
            this.mskDateReg.Size = new System.Drawing.Size(111, 22);
            this.mskDateReg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.mskDateReg.TabIndex = 4;
            this.mskDateReg.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "تاریخ پرداخت وام";
            // 
            // lblPersonId
            // 
            this.lblPersonId.AutoSize = true;
            this.lblPersonId.Location = new System.Drawing.Point(43, 102);
            this.lblPersonId.Name = "lblPersonId";
            this.lblPersonId.Size = new System.Drawing.Size(15, 16);
            this.lblPersonId.TabIndex = 44;
            this.lblPersonId.Text = "0";
            this.lblPersonId.Visible = false;
            // 
            // btnCal
            // 
            this.btnCal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCal.Location = new System.Drawing.Point(12, 216);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(46, 23);
            this.btnCal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCal.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnCal.TabIndex = 45;
            this.btnCal.Text = "محاسبه";
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // txtRemainig
            // 
            this.txtRemainig.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemainig.Border.Class = "TextBoxBorder";
            this.txtRemainig.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemainig.DisabledBackColor = System.Drawing.Color.White;
            this.txtRemainig.Enabled = false;
            this.txtRemainig.FocusHighlightEnabled = true;
            this.txtRemainig.ForeColor = System.Drawing.Color.Black;
            this.txtRemainig.Location = new System.Drawing.Point(65, 245);
            this.txtRemainig.Name = "txtRemainig";
            this.txtRemainig.PreventEnterBeep = true;
            this.txtRemainig.Size = new System.Drawing.Size(145, 23);
            this.txtRemainig.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 47;
            this.label9.Text = "مانده وام";
            // 
            // frmVam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 317);
            this.Controls.Add(this.txtRemainig);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.lblPersonId);
            this.Controls.Add(this.mskDateReg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mskStartDate);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.lblFlg);
            this.Controls.Add(this.txtPriceAgsat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumAgsat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmVam";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت وام";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVam_FormClosed);
            this.Load += new System.EventHandler(this.frmVam_Load);
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnNew;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnBack;
        private DevComponents.DotNetBar.ButtonX btnSave;
        public DevComponents.DotNetBar.Controls.TextBoxX txtLName;
        private System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.Controls.TextBoxX txtFName;
        private System.Windows.Forms.Label label2;
        public DevComponents.DotNetBar.Controls.TextBoxX txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Label lblFlg;
        public DevComponents.DotNetBar.Controls.TextBoxX txtPrice;
        private System.Windows.Forms.Label label6;
        public DevComponents.DotNetBar.Controls.TextBoxX txtNumAgsat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public DevComponents.DotNetBar.Controls.TextBoxX txtPriceAgsat;
        private System.Windows.Forms.Label label7;
        public DevComponents.DotNetBar.Controls.MaskedTextBoxAdv mskStartDate;
        public DevComponents.DotNetBar.Controls.MaskedTextBoxAdv mskDateReg;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblPersonId;
        private DevComponents.DotNetBar.ButtonX btnCal;
        public DevComponents.DotNetBar.Controls.TextBoxX txtRemainig;
        private System.Windows.Forms.Label label9;
    }
}