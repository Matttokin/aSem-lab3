using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aSem_lab1
{
    public partial class Form1 : Form
    {
        private bool authigs = false;
        private string idusrs = "";

        public Form1()
        {
            InitializeComponent();
            db.connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new register().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auth a = new auth();
            a.ShowDialog();
            authigs = a.authVar;
            idusrs = a.idUser;

            if (authigs)
            {
                label.Text = "АВТОРИЗОВАН";
                label.ForeColor = Color.Green;
            }
            else
            {
                label.Text = "НЕ АВТОРИЗОВАН";
                label.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (authigs)
                new LISTTABLES(idusrs).Show();
            else
                MessageBox.Show("Вы не прошли авторизацию");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
