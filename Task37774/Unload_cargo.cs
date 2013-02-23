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
    public partial class Unload_cargo : Form
    {
        int ship = 0;
        OleDbConnection connection = null;
        public Unload_cargo()
        {
            InitializeComponent();
        }
        public Unload_cargo(int s, OleDbConnection c) 
        {
            ship = s;
            connection = c;
            InitializeComponent();
        }
        public void upd() 
        {
            listBox1.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = " + ship + " AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listBox1.Items.Add(str);
            }
            dataReader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string str = null;
                string sql = "SELECT * FROM Goods WHERE GoodTitle = '" + listBox1.SelectedItem.ToString().Substring(listBox1.SelectedItem.ToString().IndexOf(' ')+1, listBox1.SelectedItem.ToString().Length - listBox1.SelectedItem.ToString().IndexOf(' ')-1)+"'";


                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    str = dataReader["ID"].ToString();
                    // listShips.Items.Add(dataReader["ShipName"]);
                    //   listShips.Items.Add(str);
                }
                int ind = int.Parse(str);
                dataReader.Close();
                 sql = "DELETE FROM Loading WHERE GoodID = "+ind+" AND ShipID = "+ship;


                 command = new OleDbCommand(sql, connection);
                command.ExecuteNonQuery();
                       
            }
           // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
    }
}
