using CS_20200424.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_20200424
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            fillCmbBox();
        }

        private void btnShowStudents_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            //GET
            var result = client.DownloadString("http://127.0.0.1:3000/students");
            var list = JsonConvert.DeserializeObject<List<Student>>(result);

            grid.DataSource = list;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                Firstname = txtName.Text,
                Lastname = txtSurname.Text,
                Class = txtClass.Text,
                Age = int.Parse(txtAge.Text)
            };

            //serializzo i dati in JSON
            var jsonData = JsonConvert.SerializeObject(student);
            var client = new WebClient();

            //POST
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString("http://localhost:3000/students", "POST", jsonData);
            txtName.Text = "";
            txtSurname.Text = "";
            txtClass.Text = "";
            txtAge.Text = "";
        }

        private void checkText()
        {
            if (txtName.Text != "" && txtSurname.Text != "" && txtClass.Text != "" && txtAge.Text != "")
            {
                btnInsert.Enabled = true;
            }
            else
            {
                btnInsert.Enabled = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }

        private void txtClass_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            checkText();
        }

        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClasses.Text != "")
            {
                btnStudentClass.Enabled = true;
            }
            else
            {
                btnStudentClass.Enabled = false;
            }
        }

        private void btnStudentClass_Click(object sender, EventArgs e)
        {
            String stClass = cmbClasses.Text;
            var client = new WebClient();
            //GET
            var result = client.DownloadString("http://127.0.0.1:3000/students/"+stClass);
            var list = JsonConvert.DeserializeObject<List<Student>>(result);

            grid.DataSource = list;
        }

        private void cmbStudente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudente.Text != "")
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            //GET
            var studentResult = client.DownloadString("http://127.0.0.1:3000/students");
            var studentList = JsonConvert.DeserializeObject<List<Student>>(studentResult);

            var id = studentList[cmbStudente.SelectedIndex].ID;

            //POST
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString("http://localhost:3000/students/delete", "POST", id.ToString());

            fillCmbBox();
        }

        private void fillCmbBox()
        {
            var client = new WebClient();

            //GET
            var result = client.DownloadString("http://127.0.0.1:3000/students/classes");
            var list = JsonConvert.DeserializeObject<List<StudentClass>>(result);

            for (int i = 0; i < list.Count; i++)
            {
                cmbClasses.Items.Add(list[i].Class);
            }

            //GET
            var studentResult = client.DownloadString("http://127.0.0.1:3000/students");
            var studentList = JsonConvert.DeserializeObject<List<Student>>(studentResult);

            foreach (Student s in studentList)
            {
                string studente = s.Firstname + " " + s.Lastname;
                cmbStudente.Items.Add(studente);
            }

            cmbClasses.Text = "";
            cmbStudente.Text = "";
        }
    }
}
