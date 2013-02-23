using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Task37774
{
    public partial class Form2 : Form
    {
        OleDbConnection con = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Ships SET Ships.[InPort] = True WHERE (([Ships].[ID]="+(listBox1.SelectedIndex + 1)+"))";

            OleDbCommand command = new OleDbCommand(sql, con);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            int w = 0;
            int l = 0;
            string s = null;
            string sql = "SELECT * FROM Ships WHERE ID = "+(listBox1.SelectedIndex+1);

            OleDbCommand command = new OleDbCommand(sql, con);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                s = dataReader["Weight"].ToString();
            }
            dataReader.Close();
            w = int.Parse(s);
            sql = "SELECT * FROM Loading WHERE ShipID = " + (listBox1.SelectedIndex + 1);

            command = new OleDbCommand(sql, con);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                s = dataReader["Quantity"].ToString();
                l = l+int.Parse(s);
            }
            dataReader.Close();
            if (l >= w * 0.35)
            {
                sql = "UPDATE Ships SET Ships.[InPort] = False WHERE (([Ships].[ID]=" + (listBox1.SelectedIndex + 1) + "))";

                command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();
            } else
                errorProvider1.SetError(button2, "Ship should be loaded at least on 70%");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void move(OleDbConnection c)
        {
            string str = "";
            con = c;
            string sql = "SELECT * FROM Ships";

            OleDbCommand command = new OleDbCommand(sql, c);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["ShipName"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listBox1.Items.Add(str);
            }
            dataReader.Close();
        }
    }
}
