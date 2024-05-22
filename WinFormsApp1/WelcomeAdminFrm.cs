using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class WelcomeAdminFrm : Form
    {

        public WelcomeAdminFrm()
        {
            InitializeComponent();
        }
        public List<User> Users = new List<User>();
        public WelcomeAdminFrm(string username)
        {
            Username=username;
            InitializeComponent();
            dataGridView1.DataSource = Users;
           
        }

        public string Username { get; }

        private void WelcomeAdminFrm_Load(object sender, EventArgs e)
        {
            label2.Text = Username;

            string path = "E:\\mosa.txt";
            // Open the file to read from.
            string readText = File.ReadAllText(path);
            Users = JsonConvert.DeserializeObject<List<User>>(readText);

            dataGridView1.DataSource = Users;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var role = comboBox1?.SelectedItem?.ToString() ?? "Test";

         

            User user = new(textBox1.Text, role);
           
            Users.Add(user);

            dataGridView1.DataSource = Users.ToList();
            string content = JsonConvert.SerializeObject(Users);
            
            string path = "E:\\mosa.txt";
            File.WriteAllText(path, content);

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
