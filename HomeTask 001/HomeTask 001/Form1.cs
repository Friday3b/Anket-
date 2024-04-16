using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace HomeTask_001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public object JsonSerializer { get;set; }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            User user = new User()
            {
                Name = textBox1Name.Text,
                Surname = textBox2Surname.Text,
                FatherName = textBox3FatherName.Text,
                Country = textBox4Country.Text,
                City = textBox5City.Text,
                PhoneNumber = textBox6PhoneNumber.Text,
                Gender = comboBox1.Text,
                Birthday = dateTimePicker1.Text,
            };
            //options: new JsonSerializerOptions() { WriteIndented = true }

            var settings = new JsonSerializerSettings //seliqeli json ucun
            {
                Formatting = Formatting.Indented,
            };


            var json =JsonConvert.SerializeObject(user , settings); 
            File.AppendAllText(textBox1Name.Text , json + Environment.NewLine);//seliqeli json yazmag
            MessageBox.Show("User saved ! ");
            textBox1Name.Text = string.Empty;
            textBox2Surname.Text = string.Empty;
            textBox3FatherName.Text = string.Empty;
            textBox4Country.Text = string.Empty;
            textBox5City.Text = string.Empty;
            textBox6PhoneNumber.Text = string.Empty;
            comboBox1.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;


        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameLoadtxtbox.Text))
            {
                label8.Visible = true;
                return;
            }
            label8.Visible = false;
            try
            {

                string filePath = Path.Combine(Application.StartupPath, $"{NameLoadtxtbox.Text}.json");

            
                var json = File.ReadAllText(filePath);
                var user = JsonConvert.DeserializeObject<User>(json);

                textBox1Name.Text = user.Name;
                textBox2Surname.Text = user.Surname;
                textBox3FatherName.Text = user.FatherName;
                textBox4Country.Text = user.Country;
                textBox5City.Text = user.City;
                textBox6PhoneNumber.Text = user.PhoneNumber;
                comboBox1.Text = user.Gender;
                dateTimePicker1.Text = user.Birthday;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found !");
            }

        }
    }
}
