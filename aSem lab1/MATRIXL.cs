using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
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
    public partial class MATRIXL : Form
    {
        ArrayList edl = new ArrayList();

        public MATRIXL(char reads, char write, char delite, char edit)
        {
            InitializeComponent();

            if (reads == '1') read();
            if (edit == '1') button3.Enabled = true;

        }

        private void read()
        {
            OracleDataReader d = send2db.send("SELECT * FROM MATRIXLR");

            if (d.HasRows)
            {
                while (d.Read())
                    dataGridView1.Rows.Add(d.GetInt32(0), d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4), d.GetString(5), d.GetString(6), d.GetString(7), d.GetString(8), d.GetString(9));
            }
            else
            {
                MessageBox.Show(
                "Нет данных для вывода на экран",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!edl.Contains(e.RowIndex))
            {
                edl.Add(e.RowIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < edl.Count; i++)
            {
                OracleDataReader d = send2db.send("UPDATE MATRIXLR SET PUNKTLIST = '" + dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString() + "', TOVARLIST = '" + dataGridView1[2, Convert.ToInt32(edl[i])].Value.ToString() + "', TYPEDOSTAVKALIST = '" + dataGridView1[3, Convert.ToInt32(edl[i])].Value.ToString() + "', TYPETOVARLIST = '" + dataGridView1[4, Convert.ToInt32(edl[i])].Value.ToString() + "', ZAKAZLIST = '" + dataGridView1[5, Convert.ToInt32(edl[i])].Value.ToString() + "', USERLIST = '" + dataGridView1[6, Convert.ToInt32(edl[i])].Value.ToString() + "', MATRIXLR = '" + dataGridView1[7, Convert.ToInt32(edl[i])].Value.ToString() + "', ROLELIST = '" + dataGridView1[8, Convert.ToInt32(edl[i])].Value.ToString() + "', USERROLE = '" + dataGridView1[9, Convert.ToInt32(edl[i])].Value.ToString() + "' WHERE IDROLE = " + dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
