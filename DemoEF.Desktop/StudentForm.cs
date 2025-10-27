using Demo.BAL.Interfaces;
using Demo.DAL.Constants;
using Demo.DAL.Dto;
using Demo.DAL.Implementations;
using Demo.DAL.Models;
using DemoEF.BAL.Dto;
using DemoEF.BAL.Enums;
using DemoEF.DAL.Dto;
using DemoEF.Desktop.Utilities;
using System.Data;


namespace Demo.Desktop
{
    public partial class StudentForm : Form
    {
        private readonly IStudentReadServices _studentReadServices;
        private readonly IStudentWriteServices _studentWriteServices;
        private int _studentId;
        private string _uploadedFile; //This is to store the uploaded file path (declared)
        private string _existingProfile; //declared to store existing profile path from db

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
                Name = Path.GetFileName(nameof(StudentReadDto.Profile)),
                HeaderText = "Profile",
                DataPropertyName = Path.GetFileName(nameof(StudentReadDto.Profile)),
                CellTemplate = new DataGridViewTextBoxCell()
            });
            dgvStudents.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(StudentReadDto.DOB),
                HeaderText = "Date Of Birth",
                DataPropertyName = nameof(StudentReadDto.DOB),
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
            var result = await _studentReadServices.GetAllStudentsAsync();
            if (result.Status == Status.Success)
            {
                _students = result.Data;
                dgvStudents.DataSource = _students;
                UpdateSerialNumber();
            }

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
            var result = await _studentReadServices.GetAllHobbiesAsync();
            var table = result.Data;
            clbHobby.DataSource = table;
            clbHobby.DisplayMember = nameof(DropdownDto.Name);
            clbHobby.ValueMember = nameof(DropdownDto.Id);
        }
        private async Task LoadCourseAsync()
        {
            var result = await _studentReadServices.GetAllCoursesAsync();
            var courses = result.Data;
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
        private async Task UpsertSync(bool save = true)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string fee = txtFee.Text;
            bool gender = rbMale.Checked;
            bool agree = chkAgree.Checked;
            int course = (int)cmbCourse.SelectedValue;
            DateOnly dob = DateOnly.FromDateTime(dtpDOB.Value);
            var hobbyIds = clbHobby
                           .CheckedItems
                           .Cast<DropdownDto>()
                           .Select(h => h.Id)
                           .ToList();

            if (save)
            {
                var student = new StudentCreateDto
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Fee = fee,
                    Gender = gender,
                    CourseId = course,
                    DOB = dob,
                    Agree = agree,
                    HobbyIds = hobbyIds
                };

                bool isSuccess = StudentFormValidationCheck(student);

                if (!isSuccess)
                {
                    //ClearTextField();
                    return;
                }

                string profile = SaveImage($"{student.FirstName}_{student.LastName}");
                student.Profile = profile;

                var result = await _studentWriteServices.SaveDataAsync(student);
                await OnSuccessAsync(result);
                ResetImage();


            }
            else
            {
                string profileImage = pbProfile.ImageLocation;
                var student = new StudentUpdateDto
                {
                    Id = _studentId,
                    FirstName = firstName,
                    LastName = lastName,
                    Fee = fee,
                    Profile = profileImage,
                    Gender = gender,
                    CourseId = course,
                    DOB = dob,
                    Agree = agree,
                    HobbyIds = hobbyIds
                };

                bool isSuccess = StudentFormValidationCheck(student);

                if (!isSuccess)
                {
                    //ClearTextField();
                    return;
                }
                if (!String.IsNullOrWhiteSpace(_uploadedFile))
                {
                    _studentWriteServices.RemoveImage(_existingProfile);
                    string profile = SaveImage($"{student.FirstName}_{student.LastName}");
                    student.Profile = profile;
                }

                var result = await _studentWriteServices.UpdateDataAsync(student);
                await OnSuccessAsync(result);
                ResetImage();

            }
        }

        private string SaveImage(string name)
        {
            StudentImageRequest request = new()
            {
                Name = name,
                Source = _uploadedFile,
            };
            var imageRequest = _studentWriteServices.SaveImage(request);
            string profile = imageRequest.Status == Status.Success ? imageRequest
                                                                        .Data
                                                                        .Select(x => x.FileName)
                                                                        .SingleOrDefault()
                                                                        :
                                                                        null;
            return profile;
        }

        private async Task OnSuccessAsync(OutputDto result)
        {
            if (result.Status == Status.Success)
            {

                ClearTextField();
                await LoadStudentsAsync();
                DialogMessage.SuccessAlert(result);
            }
            else
            {
                DialogMessage.FailedAlert(result);
            }

        }

        private async Task FormSubmit()
        {
            await UpsertSync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_studentId > 0)
            {
                await UpsertSync(false);
                return;
            }
            DialogMessage.FailedAlert("Please select a Id before Updating");
            //btnSubmit.Enabled = false;

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_studentId > 0)
            {
                var result = await _studentWriteServices.DeleteDataAsync(_studentId);
                await OnSuccessAsync(result);
                return;
            }
            DialogMessage.FailedAlert("Please select a Id before Deleting");
            //btnSubmit.Enabled = false;

        }

        private async void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _studentId = (int)dgvStudents.CurrentRow.Cells[nameof(StudentReadDto.Id)].Value;

            if (_studentId > 0)
            {
                btnSubmit.Enabled = false;
                var result = await _studentReadServices.GetStudentByIdAsync(_studentId);
                if (result.Status == Status.Success)
                {
                    var students = result.Data.SingleOrDefault();

                    txtFirstName.Text = students.FirstName;
                    txtLastName.Text = students.LastName;
                    txtFee.Text = students.Fee;
                    if (students.Gender == true)
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }
                    cmbCourse.Text = students.Course;
                    ResetHobbies();

                    var hobbies = clbHobby.Items.Cast<DropdownDto>().ToList();
                    foreach (int hobbyId in students.HobbyIds)
                    {
                        var hobby = hobbies.FirstOrDefault(x => x.Id == hobbyId);
                        int index = clbHobby.Items.IndexOf(hobby);
                        clbHobby.SetItemChecked(index, true);
                    }
                    dtpDOB.CustomFormat = ApplicationConstant.DateFormat;
                    dtpDOB.Value = students.DOB.ToDateTime(TimeOnly.MinValue);
                    chkAgree.Checked = students.Agree;
                    ResetImage();

                    if (!String.IsNullOrEmpty(students.Profile))
                    {
                        _existingProfile=students.Profile;  
                        txtProfileName.Text = Path.GetFileName(students.Profile);
                        pbProfile.Load(students.Profile);
                    }

                }
                else
                {
                    DialogMessage.FailedAlert(result);
                }

            }
            else
            {
                DialogMessage.FailedAlert($"Please select a {_studentId}");

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
            ResetImage();
            btnSubmit.Enabled = true;
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
                _uploadedFile = imageUploadDialog.FileName;
                pbProfile.Load(_uploadedFile);
                txtProfileName.Text = imageUploadDialog.SafeFileName;
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await _studentWriteServices.RemoveImageAsync(_studentId,_existingProfile);
            ResetImage();
        }

        private void ResetImage()
        {
            pbProfile.Image = null;
            txtProfileName.Clear();
            _uploadedFile = null;
            _existingProfile= null;
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
            var result = await _studentReadServices.GetAllStudentsAsync();
            _students = result.Data;

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
    }
}
