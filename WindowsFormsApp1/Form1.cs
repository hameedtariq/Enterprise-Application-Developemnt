using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<String> subjects;
        public Form1()
        {
            InitializeComponent();
            this.subjects = new List<String>();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = this.textBox1.Text;
            string lastname = this.textBox2.Text;
            bool check = this.checkBox1.Checked;
            if(string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                this.label4.Text = "All fields are required";
                this.label4.ForeColor = Color.Red;
                return;
            }
            if(this.subjects.Count == 0)
            {
                this.label4.Text = "Please add atleast one subject.";
                this.label4.ForeColor = Color.Red;
                return;
            }
            if(check)
            {
                this.label4.Text = $"First Name: {firstname}, Last Name: {lastname}\n" +
                    $"Subjects Enrolled: ";
                foreach(var subject in this.subjects)
                {
                    this.label4.Text += subject;
                }
                this.label4.ForeColor = Color.Green;
            }
            else
            {
                this.label4.Text = "Only students with pre-requisites clear are allowed to enroll in a subject";
                this.label4.ForeColor = Color.Red;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string subject = this.comboBox1.SelectedItem != null ? this.comboBox1.SelectedItem.ToString() : "";
            if(subject == "")
            {
                this.label4.Text = "Please select a subject to add";
                this.label4.ForeColor = Color.Red;
                return;
            }
            if(subjects.Contains(subject))
            {
                this.label4.Text = $"{subject} has already been added";
                this.label4.ForeColor = Color.Red;
                return;
            }

            subjects.Add(subject);
            this.label4.Text = $"{subject} has been added";
            this.label4.ForeColor = Color.Green;
            listBox1.Items.Add(subject);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string subject = this.comboBox1.SelectedItem != null ? this.comboBox1.SelectedItem.ToString() : "";
            if (subject == "")
            {
                this.label4.Text = "Please select a subject to add";
                this.label4.ForeColor = Color.Red;
                return;
            }

            if (!subjects.Contains(subject))
            {
                this.label4.Text = $"{subject} has not been added yet";
                this.label4.ForeColor = Color.Red;
                return;
            }

            subjects.Remove(subject);
            this.label4.Text = $"{subject} has been removed";
            this.label4.ForeColor = Color.Green;
            listBox1.Items.Remove(subject);
        }
    }
}
