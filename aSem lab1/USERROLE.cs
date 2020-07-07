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
    public partial class USERROLE : Form
    {
        ArrayList edl = new ArrayList();

        public USERROLE(char reads, char write, char delite, char edit)
        {
            InitializeComponent();

            if (reads == '1') read();
            if (edit == '1') button3.Enabled = true;

        }

        private void read()
        {
            OracleDataReader d = send2db.send("SELECT * FROM USERROLE");

            if (d.HasRows)
            {
                while (d.Read())
                    dataGridView1.Rows.Add(d.GetInt32(0), d.GetInt32(1));
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
                OracleDataReader d = send2db.send("UPDATE USERROLE SET IDROLE = '" + dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString() + "' WHERE IDUSER = " + dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
