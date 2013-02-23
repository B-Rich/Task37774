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
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //    string sql = "SELECT * FROM Ships WHERE InPort = TRUE";
            string connectionString;
            connectionString = "Provider=Microsoft.Ace.OLEDB.12.0;" +
        @"Data Source= ../../../Sailing.accdb";
            connection = new OleDbConnection(connectionString);
            connection.Open();

        }

        private void inPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Ships WHERE InPort = TRUE";
            
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string s = dataReader["InPort"].ToString();
                string str = dataReader["ShipName"].ToString() + " "+dataReader["Weight"].ToString();
               // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);

                
            }
            dataReader.Close();
            
        }

        private void arkRoyalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 1";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
             //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 1";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }
            
            Cargo c = new Cargo(weight, 1, connection);
            c.Show();
            c.Activate();
        }

        private void goldToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goldToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void teaToolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }
        private void teaToolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }
        private void teaToolStripMenuItem10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void atSeaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Ships WHERE InPort = FALSE";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string s = dataReader["InPort"].ToString();
                string str = dataReader["ShipName"].ToString() + " " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);


            }
            dataReader.Close();
        }

        private void arkRoyalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods, Places WHERE ShipID = 1 AND ShipID=Ships.ID AND GoodID=Goods.ID AND OriginID=Places.ID AND DestinationID=Places.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void bountyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 3 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString()+dataReader["Quantity"].ToString()+" "+dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void bataviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 2 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void cuttySarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 4 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void endeavourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 5 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void enterpriseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 6 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void goldenHindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 7 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void marlboroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 8 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void maryCelesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 9 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void mayflowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 10 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void queenCharlotteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 11 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void santaMariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 12 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void victoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listShips.Items.Clear();
            string sql = "SELECT * FROM Loading, Ships, Goods WHERE ShipID = 13 AND ShipID=Ships.ID AND GoodID=Goods.ID";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = dataReader["ShipName"].ToString() + dataReader["Quantity"].ToString() + " " + dataReader["GoodTitle"].ToString();// +" " + dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                listShips.Items.Add(str);
            }
            dataReader.Close();
        }

        private void bataviaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 2";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            

            Cargo c = new Cargo(weight, 2, connection);
            c.Show();
            c.Activate();
        }

        private void bountyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 3";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 3";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 3, connection);
            c.Show();
            c.Activate();
        }

        private void cuttySarkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 4";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 4";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 4, connection);
            c.Show();
            c.Activate();
        }

        private void endeavourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 5";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 5";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 5, connection);
            c.Show();
            c.Activate();
        }

        private void enterpriseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 6";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 6";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 6, connection);
            c.Show();
            c.Activate();
        }

        private void goldenHindToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 7";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 7";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 7, connection);
            c.Show();
            c.Activate();
        }

        private void marlboroughToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 8";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 8";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 8, connection);
            c.Show();
            c.Activate();
        }

        private void maryCelesteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 9";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 9";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 9, connection);
            c.Show();
            c.Activate();
        }

        private void mayflowerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 10";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 10";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 10, connection);
            c.Show();
            c.Activate();
        }

        private void queenCharlotteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 11";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 11";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 11, connection);
            c.Show();
            c.Activate();
        }

        private void santaMariaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 12";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 12";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 12, connection);
            c.Show();
            c.Activate();
        }

        private void victoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int weight = 0;
            string str = "";
            string sql = "SELECT * FROM Ships WHERE ID = 13";

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Weight"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            weight = int.Parse(str) / 2;
            dataReader.Close();
            str = null;
            sql = "SELECT * FROM Loading WHERE ShipID = 13";
            command = new OleDbCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                str = dataReader["Quantity"].ToString();
                // listShips.Items.Add(dataReader["ShipName"]);
                //   listShips.Items.Add(str);
            }
            dataReader.Close();
            if (str != null)
            {
                weight = weight - int.Parse(str);
            }

            Cargo c = new Cargo(weight, 13, connection);
            c.Show();
            c.Activate();
        }

        private void arkRoyalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c =new Unload_cargo(1, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void bataviaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(2, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void bountyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(3, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void cuttySarkToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(4, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void endeavourToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(5, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void enterpriseToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(6, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void goldenHindToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(7, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void marlboroughToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(8, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void maryCelesteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(9, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void mayflowerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(10, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void queenCharlotteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(11, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void santaMariaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(12, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void victoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Unload_cargo c = new Unload_cargo(13, connection);
            c.Show();
            c.Activate();
            c.upd();
        }

        private void setSailEnterPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            f.Activate();
            f.move(connection);
        }

        

        
    }
}
