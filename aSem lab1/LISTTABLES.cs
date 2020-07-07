using Oracle.ManagedDataAccess.Client;
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
    public partial class LISTTABLES : Form
    {
        string[] mt;
        public LISTTABLES(string id)
        {
            InitializeComponent();

            mt = request.getMatrixr(id);
                if (mt[1].ToString().Length == 4) button1.Enabled = true;
                if (mt[2].ToString().Length == 4) button2.Enabled = true;
                if (mt[3].ToString().Length == 4) button3.Enabled = true;
                if (mt[4].ToString().Length == 4) button4.Enabled = true;
                if (mt[5].ToString().Length == 4) button5.Enabled = true;
                if (mt[6].ToString().Length == 4) button6.Enabled = true;
                if (mt[7].ToString().Length == 4) button7.Enabled = true;
                if (mt[8].ToString().Length == 4) button8.Enabled = true;
                if (mt[9].ToString().Length == 4) button9.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PUNKTLIST(mt[1].ToString()[0], mt[1].ToString()[1], mt[1].ToString()[2], mt[1].ToString()[3]).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new TOVARLIST(mt[2].ToString()[0], mt[2].ToString()[1], mt[2].ToString()[2], mt[2].ToString()[3]).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new TYPEDOSTAVKALIST(mt[3].ToString()[0], mt[3].ToString()[1], mt[3].ToString()[2], mt[3].ToString()[3]).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new TYPETOVARLIST(mt[4].ToString()[0], mt[4].ToString()[1], mt[4].ToString()[2], mt[4].ToString()[3]).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new USERLIST(mt[5].ToString()[0], mt[5].ToString()[1], mt[5].ToString()[2], mt[5].ToString()[3]).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ZAKAZLIST(mt[6].ToString()[0], mt[6].ToString()[1], mt[6].ToString()[2], mt[6].ToString()[3]).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new MATRIXL(mt[7].ToString()[0], mt[7].ToString()[1], mt[7].ToString()[2], mt[7].ToString()[3]).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new ROLELIST(mt[8].ToString()[0], mt[8].ToString()[1], mt[8].ToString()[2], mt[8].ToString()[3]).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new USERROLE(mt[9].ToString()[0], mt[9].ToString()[1], mt[9].ToString()[2], mt[9].ToString()[3]).Show();
        }
    }
}
