using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectToMySQL11D
{
    public partial class Form1 : Form
    {
        string connstr = "server=192.168.1.235;"
            + "port=3306;" + "user=REMOTE;" + "password=Aa123456@;" + "database=minions";
        MySqlConnection connect;
        MySqlCommand query;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect = new MySqlConnection(connstr);
            if (connect.State == 0)
            {
                connect.Open();
            }
            MessageBox.Show("Connection NOW oppened");
            string sql = "SELECT minions_id, minions_Name, minions_Age" + "FROM minions";
            query = new MySqlCommand(sql, connect);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add($"{reader[0]} --> {reader[1]} Age: {reader["Age"]}");
            }

            reader.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
