using Demo.BAL.Interfaces;
using Demo.DAL.Constants;
using Demo.DAL.Dto;
using Demo.DAL.Implementations;
using Demo.DAL.Models;
using System.Data;


namespace Demo.Desktop
{
    public partial class StudentForm : Form
    {
        private readonly IStudentReadServices _studentReadServices;
        private readonly IStudentWriteServices _studentWriteServices;
        private int _studentId;

        private List<StudentReadDto> _students;

        public StudentForm(IStudentReadServices studentReadServices, IStudentWriteServices studentWriteServices)
        {
            InitializeComponent();
            _studentReadServices = studentReadServices;
            _studentWriteServices = studentWriteServices;
            InitalizeFormComponents();


        }
        private async Task LoadStudentGridAsync()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = ApplicationConstant.SN,
                HeaderText = "S.N",
                CellTemplate = new DataGridViewTextBoxCell()

            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Id),
                HeaderText = "Id",
                DataPropertyName = nameof(StudentReadDto.Id),
                CellTemplate = new DataGridViewTextBoxCell()

            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.FirstName),
                HeaderText = "First Name",
                DataPropertyName = nameof(StudentReadDto.FirstName),
                CellTemplate = new DataGridViewTextBoxCell()

            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.LastName),
                HeaderText = "Last Name",
                DataPropertyName = nameof(StudentReadDto.LastName),
                CellTemplate = new DataGridViewTextBoxCell()
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Fee),
                HeaderText = "Fee",
                DataPropertyName = nameof(StudentReadDto.Fee),
                CellTemplate = new DataGridViewTextBoxCell()
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Gender),
                HeaderText = "Gender",
                DataPropertyName = nameof(StudentReadDto.Gender),
                CellTemplate = new DataGridViewTextBoxCell()

            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Course),
                HeaderText = "Course Selected",
                DataPropertyName = nameof(StudentReadDto.Course),
                CellTemplate = new DataGridViewTextBoxCell()

            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Hobbies),
                HeaderText = "Hobbies",
                DataPropertyName = nameof(StudentReadDto.Hobbies),
                CellTemplate = new DataGridViewTextBoxCell()

            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Agree),
                HeaderText = "Agree or Not",
                DataPropertyName = nameof(StudentReadDto.Agree),
                CellTemplate = new DataGridViewTextBoxCell()
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.Profile),
                HeaderText = "Profile",
                DataPropertyName = nameof(StudentReadDto.Profile),
                CellTemplate = new DataGridViewTextBoxCell()
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.CreatedDate),
                HeaderText = "Created Date",
                DataPropertyName = nameof(StudentReadDto.CreatedDate),
                CellTemplate = new DataGridViewTextBoxCell()

            });
            await LoadStudentsAsync();
        }

        private async Task LoadStudentsAsync()
        {
            _students = await _studentReadServices.GetAllStudentsAsync();
            dgvStudents.DataSource = _students;

            UpdateSerialNumber();

        }

        private void UpdateSerialNumber()
        {
            for (int i = 0; i < dgvStudents.Rows.Count; i++)
            {
                dgvStudents.Rows[i].Cells[ApplicationConstant.SN].Value = (i + 1).ToString();
            }
        }

        private void InitalizeFormComponents()
        {
            txtFirstName.Focus();
            txtFirstName.TabIndex = 0;
            txtLastName.TabIndex = 1;
            dtpDOB.TabIndex = 2;
            lblHobby.TabIndex = 3;
            btnSubmit.TabIndex = 4;
            btnCancel.TabIndex = 5;
            txtFullName.ReadOnly = true;
            txtFee.ReadOnly = true;
            txtFee.Text = StudentRepository._fee;
            txtProfileName.ReadOnly = true;
            pbProfile.BorderStyle = BorderStyle.Fixed3D;
            pbProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            imageUploadDialog.Filter = "Image Files (*.jpg;.jpeg;*.png;*.gif;)|*.jpg;*.jpeg;*.png;";
            lblFirstNameError.Visible = false;
            lblLastNameError.Visible = false;
            lblChkAgreeError.Visible = false;
            rbMale.Checked = true;
            lblcmbCourseError.Visible = false;
            lblDOBError.Visible = false;
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = " ";
            lblHobbyError.Visible = false;
        }
        private async Task LoadHobbiesAsync()
        {
            var table = await _studentReadServices.GetAllHobbiesAsync();
            clbHobby.DataSource = table;
            clbHobby.DisplayMember = nameof(DropdownDto.Name);
            clbHobby.ValueMember = nameof(DropdownDto.Id);
        }
        private async Task LoadCourseAsync()
        {

            var courses = await _studentReadServices.GetAllCoursesAsync();
            courses.Insert(0, new DropdownDto { Id = 0, Name = "Please Select a Course" });
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = nameof(DropdownDto.Name);
            cmbCourse.ValueMember = nameof(DropdownDto.Id);
            cmbCourse.SelectedIndex = 0;
        }

        private void WorkingComponents()
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            txtFullName.Text = String.Concat(firstName, " ", lastName);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCourseAsync();
            await LoadHobbiesAsync();
            await LoadStudentGridAsync();

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            WorkingComponents();
            string firstName = txtFirstName.Text;
            if (!String.IsNullOrWhiteSpace(firstName))
            {
                lblFirstNameError.Visible = false;
            }

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            WorkingComponents();
            string lastName = txtLastName.Text;
            if (!String.IsNullOrWhiteSpace(lastName))
            {
                lblLastNameError.Visible = false;
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFee_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            await FormSubmit();

        }

        private async Task FormSubmit()
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string fee = txtFee.Text;
            bool gender = rbMale.Checked;
            bool agree = chkAgree.Checked;
            string profile = txtProfileName.Text;
            int course = (int)cmbCourse.SelectedValue;
            DateOnly dob = DateOnly.FromDateTime(dtpDOB.Value);
            var hobbyIds = clbHobby
                           .CheckedItems
                           .Cast<DropdownDto>()
                           .Select(h => h.Id)
                           .ToList();
            var student = new StudentCreateDto
            {
                FirstName = firstName,
                LastName = lastName,
                Fee = fee,
                Gender = gender,
                CourseId = course,
                DOB = dob,
                Agree = agree,
                Profile = profile,
                HobbyIds = hobbyIds
            };

            bool isSuccess = StudentFormValidationCheck(student);

            if (!isSuccess)
            {
                return;
            }
            if (isSuccess)
            {
                await _studentWriteServices.SaveDataAsync(student);
                await LoadStudentsAsync();

                ClearTextField();
                MessageBox.Show("Saved Success", "Success", MessageBoxButtons.OK);
            }

        }


        private bool StudentFormValidationCheck(StudentCreateDto student)
        {
            if (String.IsNullOrWhiteSpace(student.FirstName))
            {
                lblFirstNameError.Visible = true;
            }
            else
            {
                lblFirstNameError.Visible = false;

            }
            if (String.IsNullOrWhiteSpace(student.LastName))
            {
                lblLastNameError.Visible = true;
            }
            else
            {
                lblLastNameError.Visible = false;

            }
            if (!student.Agree)
            {
                lblChkAgreeError.Visible = true;
            }
            else
            {
                lblChkAgreeError.Visible = false;
            }
            if (cmbCourse.SelectedIndex == 0)
            {
                lblcmbCourseError.Visible = true;
            }
            else
            {
                lblcmbCourseError.Visible = false;
            }
            if (dtpDOB.CustomFormat == " ")
            {
                lblDOBError.Visible = true;
            }
            else
            {
                lblDOBError.Visible = false;
            }
            if (student.HobbyIds.Count == 0)
            {
                lblHobbyError.Visible = true;
            }
            else
            {
                lblHobbyError.Visible = false;
            }

            bool result = !String.IsNullOrWhiteSpace(student.FirstName) && !String.IsNullOrWhiteSpace(student.LastName) && cmbCourse.SelectedIndex > 0 && student.Agree && dtpDOB.CustomFormat != " " && student.HobbyIds.Count > 0;
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearTextField();
        }

        private void ClearTextField()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            cmbCourse.SelectedIndex = 0;
            rbMale.Checked = true;
            chkAgree.Checked = false;
            pbProfile.Image = null;
            cmbCourse.SelectedIndex = 0;
            txtFirstName.Focus();
            dtpDOB.CustomFormat = " ";
            ResetHobbies();

        }

        private void ResetHobbies()
        {
            for (int i = 0; i < clbHobby.Items.Count; i++)
            {
                clbHobby.SetItemChecked(i, false);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (imageUploadDialog.ShowDialog() == DialogResult.OK)
            {
                pbProfile.Load(imageUploadDialog.FileName);
                txtProfileName.Text = imageUploadDialog.SafeFileName;

            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            pbProfile.Image = null;
            txtProfileName.Clear();
        }

        private void imageUploadDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void pbProfile_Click(object sender, EventArgs e)
        {

        }

        private void txtProfileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbAgree_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            bool isAgree = chkAgree.Checked;
            if (isAgree)
            {
                lblChkAgreeError.Visible = false;
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblChkAgreeError_Click(object sender, EventArgs e)
        {

        }

        private void lblCourse_Click(object sender, EventArgs e)
        {

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedIndex > 0)
            {
                lblcmbCourseError.Visible = false;
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            _students = await _studentReadServices.GetAllStudentsAsync();

            if (String.IsNullOrWhiteSpace(search))
            {
                dgvStudents.DataSource = _students;
            }
            else
            {

                var filtered = _students
                    .Where(s => s.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || s.LastName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || s.Gender != null && s.Gender.StartsWith(search, StringComparison.OrdinalIgnoreCase)
                    || s.Course != null && s.Course.StartsWith(search, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();

                dgvStudents.DataSource = filtered;
            }
            UpdateSerialNumber();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            dtpDOB.CustomFormat = ApplicationConstant.DateFormat;
            lblDOBError.Visible = false;
        }
        private void clbHobby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbHobby.SelectedItems.Count > 0)
            {
                lblHobbyError.Visible = false;
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_studentId > 0)
            {
                //update
            }

            MessageBox.Show("Plz select a Id before Updating", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_studentId > 0)
            {
                //delete
            }
            MessageBox.Show("Plz select a Id before Deleting", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _studentId = (int)dgvStudents.CurrentRow.Cells[nameof(StudentReadDto.Id)].Value;

            if (_studentId > 0)
            {
                var students=await _studentReadServices.GetStudentByIdAsync(_studentId);
                if (students is not null)
                {
                    txtFirstName.Text = students.FirstName;
                    txtLastName.Text = students.LastName;
                    txtFee.Text = students.Fee;
                    if (students.Gender == true)
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = false;
                    }
                    cmbCourse.Text=students.Course;
                    ResetHobbies();

                    var hobbies = clbHobby.Items.Cast<DropdownDto>().ToList();
                    foreach (int hobbyId in students.HobbyIds)
                    {
                        var hobby = hobbies.FirstOrDefault(x => x.Id == hobbyId);
                        int index = clbHobby.Items.IndexOf(hobby);
                        clbHobby.SetItemChecked(index,true);
                    }

                    dtpDOB.Value = students.DOB.ToDateTime(TimeOnly.MinValue);
                    chkAgree.Checked = students.Agree;

                    if (!String.IsNullOrEmpty(students.Profile))
                    {
                        txtProfileName.Text = students.Profile;
                        pbProfile.Load(students.Profile);
                    }

                }

            }
            else
            {
                MessageBox.Show("Please select a Id","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
    }
}
