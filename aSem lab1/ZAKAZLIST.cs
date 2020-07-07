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
    public partial class ZAKAZLIST : Form
    {
        ArrayList edl = new ArrayList();

        public ZAKAZLIST(char reads, char write, char delite, char edit)
        {
            InitializeComponent();

            if (reads == '1') read();
            if (write == '1') button1.Enabled = true;
            if (delite == '1') button2.Enabled = true;
            if (edit == '1') button3.Enabled = true;

        }

        private void read()
        {
            OracleDataReader d = send2db.send("SELECT * FROM ZAKAZLIST");

            if (d.HasRows)
            {
                while (d.Read())
                    dataGridView1.Rows.Add(d.GetInt32(0), d.GetInt32(1), d.GetInt32(2), d.GetDateTime(3).ToShortDateString(), d.GetInt32(4), d.GetInt32(5), d.GetInt32(6));
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDataReader d = send2db.send("INSERT INTO ZAKAZLIST(IDUSER, IDTOVAR, DATA_ZAKAZ, IDPUNKTNAZNACH, IDTYPEDOSTAVKA, STOIMOST) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "' )");
                dataGridView1.Rows.Add(Convert.ToInt32(dataGridView1[0, dataGridView1.Rows.Count - 1].Value) + 1, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
            catch
            {
                MessageBox.Show("Невозможно занести данные. Проверьте правильность введеных велечин");
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
                try
                {
                    OracleDataReader d = send2db.send("UPDATE ZAKAZLIST SET IDUSER = '" + dataGridView1[1, Convert.ToInt32(edl[i])].Value.ToString() + "', IDTOVAR = '" + dataGridView1[2, Convert.ToInt32(edl[i])].Value.ToString() + "', DATA_ZAKAZ = '" + dataGridView1[3, Convert.ToInt32(edl[i])].Value.ToString() + "', IDPUNKTNAZNACH = '" + dataGridView1[4, Convert.ToInt32(edl[i])].Value.ToString() + "', IDTYPEDOSTAVKA = '" + dataGridView1[5, Convert.ToInt32(edl[i])].Value.ToString() + "', STOIMOST = '" + dataGridView1[6, Convert.ToInt32(edl[i])].Value.ToString() + "' WHERE IDZAKAZ = " + dataGridView1[0, Convert.ToInt32(edl[i])].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления данных. Проверьте правильность введеных велечин");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDataReader d = send2db.send("DELETE FROM ZAKAZLIST WHERE IDZAKAZ = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch
            {
                MessageBox.Show(
                "Нельзя удалить запись",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
