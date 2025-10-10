namespace Demo.Desktop
{
    partial class StudentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblFee = new Label();
            txtFee = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            imageUploadDialog = new OpenFileDialog();
            pbProfile = new PictureBox();
            btnUpload = new Button();
            btnRemove = new Button();
            txtProfileName = new TextBox();
            chkAgree = new CheckBox();
            lblGender = new Label();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            dgvStudents = new DataGridView();
            lblFirstNameError = new Label();
            lblLastNameError = new Label();
            lblChkAgreeError = new Label();
            settingToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            settingToolStripMenuItem1 = new ToolStripMenuItem();
            logoutToolStripMenuItem1 = new ToolStripMenuItem();
            cmbCourse = new ComboBox();
            lblCourse = new Label();
            button1 = new Button();
            lblcmbCourseError = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblDOB = new Label();
            dtpDOB = new DateTimePicker();
            lblDOBError = new Label();
            lblHobby = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            lblHobbyError = new Label();
            clbHobby = new CheckedListBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(25, 40);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(61, 15);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "FirstName";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(104, 37);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(165, 23);
            txtFirstName.TabIndex = 1;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(25, 81);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(60, 15);
            lblLastName.TabIndex = 0;
            lblLastName.Text = "LastName";
            lblLastName.Click += lblLastName_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(104, 78);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(165, 23);
            txtLastName.TabIndex = 2;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(25, 123);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(58, 15);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "FullName";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(104, 120);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(165, 23);
            txtFullName.TabIndex = 7;
            txtFullName.TextChanged += txtFullName_TextChanged;
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.Location = new Point(26, 165);
            lblFee.Name = "lblFee";
            lblFee.Size = new Size(31, 15);
            lblFee.TabIndex = 6;
            lblFee.Text = "Fee: ";
            // 
            // txtFee
            // 
            txtFee.Location = new Point(105, 162);
            txtFee.Name = "txtFee";
            txtFee.Size = new Size(164, 23);
            txtFee.TabIndex = 5;
            txtFee.TextChanged += txtFee_TextChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(29, 464);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(106, 32);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(432, 463);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 32);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // imageUploadDialog
            // 
            imageUploadDialog.FileName = "openFileDialog1";
            imageUploadDialog.FileOk += imageUploadDialog_FileOk;
            // 
            // pbProfile
            // 
            pbProfile.Location = new Point(522, 46);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(178, 110);
            pbProfile.TabIndex = 8;
            pbProfile.TabStop = false;
            pbProfile.Click += pbProfile_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(526, 226);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(76, 32);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(608, 226);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(83, 32);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // txtProfileName
            // 
            txtProfileName.Location = new Point(522, 176);
            txtProfileName.Name = "txtProfileName";
            txtProfileName.Size = new Size(178, 23);
            txtProfileName.TabIndex = 1;
            txtProfileName.TextChanged += txtProfileName_TextChanged;
            // 
            // chkAgree
            // 
            chkAgree.AutoSize = true;
            chkAgree.Location = new Point(30, 424);
            chkAgree.Name = "chkAgree";
            chkAgree.Size = new Size(205, 19);
            chkAgree.TabIndex = 9;
            chkAgree.Text = "Plz agree the terms and Condition";
            chkAgree.UseVisualStyleBackColor = true;
            chkAgree.CheckedChanged += chkAgree_CheckedChanged;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(25, 205);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(45, 15);
            lblGender.TabIndex = 6;
            lblGender.Text = "Gender";
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(105, 203);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(51, 19);
            rbMale.TabIndex = 10;
            rbMale.TabStop = true;
            rbMale.Text = "male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(208, 203);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(61, 19);
            rbFemale.TabIndex = 10;
            rbFemale.TabStop = true;
            rbFemale.Text = "female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(107, 523);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.Size = new Size(777, 211);
            dgvStudents.TabIndex = 11;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick;
            dgvStudents.RowPostPaint += dgvStudents_RowPostPaint;
            // 
            // lblFirstNameError
            // 
            lblFirstNameError.AutoSize = true;
            lblFirstNameError.ForeColor = Color.Red;
            lblFirstNameError.Location = new Point(292, 41);
            lblFirstNameError.Name = "lblFirstNameError";
            lblFirstNameError.Size = new Size(115, 15);
            lblFirstNameError.TabIndex = 12;
            lblFirstNameError.Text = "firstname is required";
            // 
            // lblLastNameError
            // 
            lblLastNameError.AutoSize = true;
            lblLastNameError.ForeColor = Color.Red;
            lblLastNameError.Location = new Point(292, 81);
            lblLastNameError.Name = "lblLastNameError";
            lblLastNameError.Size = new Size(113, 15);
            lblLastNameError.TabIndex = 12;
            lblLastNameError.Text = "lastname is required";
            // 
            // lblChkAgreeError
            // 
            lblChkAgreeError.AutoSize = true;
            lblChkAgreeError.ForeColor = Color.Red;
            lblChkAgreeError.Location = new Point(296, 424);
            lblChkAgreeError.Name = "lblChkAgreeError";
            lblChkAgreeError.Size = new Size(219, 15);
            lblChkAgreeError.TabIndex = 12;
            lblChkAgreeError.Text = "you must agree the terms and condition";
            lblChkAgreeError.Click += lblChkAgreeError_Click;
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(32, 19);
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(32, 19);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(947, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem1
            // 
            settingToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem1 });
            settingToolStripMenuItem1.Name = "settingToolStripMenuItem1";
            settingToolStripMenuItem1.Size = new Size(55, 20);
            settingToolStripMenuItem1.Text = "setting";
            // 
            // logoutToolStripMenuItem1
            // 
            logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            logoutToolStripMenuItem1.Size = new Size(109, 22);
            logoutToolStripMenuItem1.Text = "logout";
            logoutToolStripMenuItem1.Click += logoutToolStripMenuItem1_Click;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(104, 242);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(165, 23);
            cmbCourse.TabIndex = 16;
            cmbCourse.SelectedIndexChanged += cmbCourse_SelectedIndexChanged;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(26, 247);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 15;
            lblCourse.Text = "Course:";
            lblCourse.Click += lblCourse_Click;
            // 
            // button1
            // 
            button1.Location = new Point(156, 552);
            button1.Name = "button1";
            button1.Size = new Size(115, 32);
            button1.TabIndex = 4;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCancel_Click;
            // 
            // lblcmbCourseError
            // 
            lblcmbCourseError.AutoSize = true;
            lblcmbCourseError.ForeColor = Color.Red;
            lblcmbCourseError.Location = new Point(292, 249);
            lblcmbCourseError.Name = "lblcmbCourseError";
            lblcmbCourseError.Size = new Size(123, 15);
            lblcmbCourseError.TabIndex = 12;
            lblcmbCourseError.Text = "Please select a course ";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(658, 486);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(719, 476);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(165, 33);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(28, 294);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(31, 15);
            lblDOB.TabIndex = 15;
            lblDOB.Text = "DOB";
            lblDOB.Click += lblCourse_Click;
            // 
            // dtpDOB
            // 
            dtpDOB.Location = new Point(104, 286);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(165, 23);
            dtpDOB.TabIndex = 17;
            dtpDOB.ValueChanged += dtpDOB_ValueChanged;
            // 
            // lblDOBError
            // 
            lblDOBError.AutoSize = true;
            lblDOBError.ForeColor = Color.Red;
            lblDOBError.Location = new Point(292, 289);
            lblDOBError.Name = "lblDOBError";
            lblDOBError.Size = new Size(92, 15);
            lblDOBError.TabIndex = 12;
            lblDOBError.Text = "DOB is Required";
            // 
            // lblHobby
            // 
            lblHobby.AutoSize = true;
            lblHobby.Location = new Point(25, 340);
            lblHobby.Name = "lblHobby";
            lblHobby.Size = new Size(49, 15);
            lblHobby.TabIndex = 15;
            lblHobby.Text = "Hobby :";
            lblHobby.Click += lblCourse_Click;
            // 
            // lblHobbyError
            // 
            lblHobbyError.AutoSize = true;
            lblHobbyError.ForeColor = Color.Red;
            lblHobbyError.Location = new Point(292, 359);
            lblHobbyError.Name = "lblHobbyError";
            lblHobbyError.Size = new Size(104, 15);
            lblHobbyError.TabIndex = 12;
            lblHobbyError.Text = "Hobby is Required";
            // 
            // clbHobby
            // 
            clbHobby.FormattingEnabled = true;
            clbHobby.Location = new Point(105, 324);
            clbHobby.Name = "clbHobby";
            clbHobby.Size = new Size(120, 94);
            clbHobby.TabIndex = 19;
            clbHobby.SelectedIndexChanged += clbHobby_SelectedIndexChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(163, 464);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(106, 32);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(296, 464);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 32);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 595);
            Controls.Add(clbHobby);
            Controls.Add(dtpDOB);
            Controls.Add(cmbCourse);
            Controls.Add(lblHobby);
            Controls.Add(lblDOB);
            Controls.Add(lblCourse);
            Controls.Add(lblChkAgreeError);
            Controls.Add(lblHobbyError);
            Controls.Add(lblDOBError);
            Controls.Add(lblcmbCourseError);
            Controls.Add(lblLastNameError);
            Controls.Add(lblFirstNameError);
            Controls.Add(dgvStudents);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(chkAgree);
            Controls.Add(pbProfile);
            Controls.Add(btnRemove);
            Controls.Add(btnUpload);
            Controls.Add(button1);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSubmit);
            Controls.Add(txtFee);
            Controls.Add(lblGender);
            Controls.Add(lblFee);
            Controls.Add(txtFullName);
            Controls.Add(txtLastName);
            Controls.Add(txtProfileName);
            Controls.Add(txtSearch);
            Controls.Add(txtFirstName);
            Controls.Add(lblFullName);
            Controls.Add(lblLastName);
            Controls.Add(lblSearch);
            Controls.Add(lblFirstName);
            Controls.Add(menuStrip1);
            Name = "StudentForm";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblFee;
        private TextBox txtFee;
        private Button btnSubmit;
        private Button btnCancel;
        private OpenFileDialog imageUploadDialog;
        private PictureBox pbProfile;
        private Button btnUpload;
        private Button btnRemove;
        private TextBox txtProfileName;
        private CheckBox chkAgree;
        private Label lblGender;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private DataGridView dgvStudents;
        private Label lblFirstNameError;
        private Label lblLastNameError;
        private Label label3;
        private Label lblChkAgreeError;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingToolStripMenuItem1;
        private ToolStripMenuItem logoutToolStripMenuItem1;
        private ComboBox cmbCourse;
        private Label lblCourse;
        private Button button1;
        private Label lblcmbCourseError;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblDOB;
        private DateTimePicker dtpDOB;
        private Label lblDOBError;
        private Label lblHobby;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblHobbyError;
        private CheckedListBox clbHobby;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
