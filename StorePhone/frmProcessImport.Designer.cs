namespace StorePhone
{
    partial class frmProcessImport
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.progressBar = new JCS.Components.NeroBar();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabtrangthai = new System.Windows.Forms.TabPage();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.tabError = new System.Windows.Forms.TabPage();
            this.btn_xuat = new System.Windows.Forms.Button();
            this.gridview_error = new System.Windows.Forms.DataGridView();
            this.vitri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabtrangthai.SuspendLayout();
            this.tabError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview_error)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::StorePhone.Properties.Resources.title_mess;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 28);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoEllipsis = true;
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Title.Image = global::StorePhone.Properties.Resources.title_mess;
            this.lbl_Title.Location = new System.Drawing.Point(-2, -1);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(100, 28);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "Đang sao chép";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.progressBar.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Location = new System.Drawing.Point(12, 43);
            this.progressBar.Name = "progressBar";
            this.progressBar.PercentageBasedOn = JCS.Components.NeroBar.NeroBarPercentageCalculationModes.WholeControl;
            this.progressBar.PercentageShow = true;
            this.progressBar.Segment2StartThreshold = 1D;
            this.progressBar.Size = new System.Drawing.Size(307, 15);
            this.progressBar.TabIndex = 3;
            this.progressBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(335, 33);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(57, 27);
            this.btn_Stop.TabIndex = 5;
            this.btn_Stop.Text = "Dừng";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabtrangthai);
            this.tabControl.Controls.Add(this.tabError);
            this.tabControl.Location = new System.Drawing.Point(12, 66);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(380, 184);
            this.tabControl.TabIndex = 7;
            // 
            // tabtrangthai
            // 
            this.tabtrangthai.Controls.Add(this.richTextBox);
            this.tabtrangthai.Location = new System.Drawing.Point(4, 22);
            this.tabtrangthai.Name = "tabtrangthai";
            this.tabtrangthai.Padding = new System.Windows.Forms.Padding(3);
            this.tabtrangthai.Size = new System.Drawing.Size(372, 158);
            this.tabtrangthai.TabIndex = 0;
            this.tabtrangthai.Text = "Status";
            this.tabtrangthai.UseVisualStyleBackColor = true;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(3, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(366, 152);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.btn_xuat);
            this.tabError.Controls.Add(this.gridview_error);
            this.tabError.Location = new System.Drawing.Point(4, 22);
            this.tabError.Name = "tabError";
            this.tabError.Padding = new System.Windows.Forms.Padding(3);
            this.tabError.Size = new System.Drawing.Size(372, 158);
            this.tabError.TabIndex = 1;
            this.tabError.Text = "Error";
            this.tabError.UseVisualStyleBackColor = true;
            // 
            // btn_xuat
            // 
            this.btn_xuat.Enabled = false;
            this.btn_xuat.Location = new System.Drawing.Point(294, 132);
            this.btn_xuat.Name = "btn_xuat";
            this.btn_xuat.Size = new System.Drawing.Size(75, 23);
            this.btn_xuat.TabIndex = 1;
            this.btn_xuat.Text = "Xuất File";
            this.btn_xuat.UseVisualStyleBackColor = true;
            this.btn_xuat.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridview_error
            // 
            this.gridview_error.AllowUserToAddRows = false;
            this.gridview_error.AllowUserToDeleteRows = false;
            this.gridview_error.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview_error.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vitri,
            this.sodienthoai,
            this.status});
            this.gridview_error.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridview_error.Location = new System.Drawing.Point(3, 3);
            this.gridview_error.Name = "gridview_error";
            this.gridview_error.Size = new System.Drawing.Size(366, 125);
            this.gridview_error.TabIndex = 0;
            // 
            // vitri
            // 
            this.vitri.DataPropertyName = "vitri";
            this.vitri.HeaderText = "Vị Trí";
            this.vitri.Name = "vitri";
            this.vitri.Width = 70;
            // 
            // sodienthoai
            // 
            this.sodienthoai.DataPropertyName = "sodienthoai";
            this.sodienthoai.HeaderText = "Số Điện Thoại";
            this.sodienthoai.Name = "sodienthoai";
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Trạng Thái";
            this.status.Name = "status";
            this.status.Width = 150;
            // 
            // pictureBox_title
            // 
            this.pictureBox_title.AutoEllipsis = true;
            this.pictureBox_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBox_title.ForeColor = System.Drawing.Color.White;
            this.pictureBox_title.Image = global::StorePhone.Properties.Resources.title_mess;
            this.pictureBox_title.Location = new System.Drawing.Point(93, -1);
            this.pictureBox_title.Name = "pictureBox_title";
            this.pictureBox_title.Size = new System.Drawing.Size(33, 28);
            this.pictureBox_title.TabIndex = 8;
            this.pictureBox_title.Text = ".";
            // 
            // frmProcessImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 253);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_title);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessImport";
            this.Opacity = 0.99D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmProcessImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabtrangthai.ResumeLayout(false);
            this.tabError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview_error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Title;
        private JCS.Components.NeroBar progressBar;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabtrangthai;
        private System.Windows.Forms.TabPage tabError;
        private System.Windows.Forms.DataGridView gridview_error;
        private System.Windows.Forms.Label pictureBox_title;
        private System.Windows.Forms.Button btn_xuat;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn vitri;
        private System.Windows.Forms.DataGridViewTextBoxColumn sodienthoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}