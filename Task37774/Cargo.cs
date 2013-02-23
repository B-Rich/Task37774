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
    public partial class Cargo : Form
    {
        int maxWeight = 0;
     //   string good = "";
        int ship = 0;
        OleDbConnection connection;
        public Cargo()
        {
            InitializeComponent();
        }
        public Cargo(int w, int s, OleDbConnection c) {
            maxWeight = w;
            ship = s;
            connection = c;
            InitializeComponent();
        }
        private void Cargo_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int w = 0;
            int i = 0;
            string dest = null;
            string orig = null;
            bool ori = false;
            bool des = false;
            int o = 0;
            int d = 0;
            System.Collections.Generic.List<string> str2 = new System.Collections.Generic.List<string>();
            if (listBox1.SelectedItem != null)
            {
                i = listBox1.SelectedIndex + 1;
                if (textBox1.Text != null)
                {
                    try
                    {
                        w = int.Parse(textBox1.Text);
                    }
                    catch (Exception ex)
                    {

                    }
                    if (w > 0)
                    {
                        string str = null;
                        string sql = "SELECT * FROM Loading WHERE ShipID = " + ship;
                        int l = 0;
                        OleDbCommand command = new OleDbCommand(sql, connection);
                        OleDbDataReader dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            str = dataReader["Quantity"].ToString();
                            l = l + int.Parse(str);
                            str2.Add(str);
                            str = dataReader["OriginID"].ToString();
                            str2.Add(str);
                            str = dataReader["DestinationID"].ToString();
                            str2.Add(str);
                            str = null;
                        }
                        dataReader.Close();

                        if (w <= (maxWeight - l))
                        {
                            l = l + w;
                            if (textBox2.Text != null && textBox3.Text != null)
                            {
                                try
                                {
                                    orig = textBox2.Text;
                                }
                                catch (Exception ex)
                                {

                                }
                                try
                                {
                                    dest = textBox3.Text;
                                }
                                catch (Exception ex)
                                {

                                }
                                if (l > maxWeight * 0.8 && l < maxWeight * 0.9)
                                {
                                    sql = "SELECT * FROM Places WHERE City = '" + textBox2.Text + "'";
                                    command = new OleDbCommand(sql, connection);
                                    OleDbDataReader dataReader2 = command.ExecuteReader();
                                    dataReader2.Read();
                                    str = dataReader2["ID"].ToString();
                                    o = int.Parse(str);
                                    dataReader2.Close();
                                    for (int j = str2.Count / 3; j < 2 * str2.Count; j++)
                                    {

                                        if (str.Equals(str2[j]))
                                            ori = true;
                                        else
                                        {
                                            ori = false;
                                            break;
                                        }
                                    }
                                    sql = "SELECT * FROM Places WHERE City = '" + textBox3.Text + "'";
                                    command = new OleDbCommand(sql, connection);
                                    OleDbDataReader dataReader3 = command.ExecuteReader();
                                    dataReader3.Read();
                                    str = dataReader3["ID"].ToString();
                                    d = int.Parse(str);
                                    dataReader3.Close();
                                    for (int j = 2 * str2.Count / 3; j < str2.Count; j++)
                                    {

                                        if (str.Equals(str2[j]))
                                            des = true;
                                        else
                                        {
                                            des = false;
                                            break;
                                        }
                                    }


                                    if (ori || des)
                                    {
                                        sql = "INSERT INTO Loading (ShipID, GoodID, Quantity, OriginID, DestinationID) VALUES ('" + ship + "', '" + i + "', '" + w + "', '" + o + "', '" + d + "')";
                                        command = new OleDbCommand(sql, connection);
                                        command.ExecuteNonQuery();
                                    }
                                }
                                else if (l > maxWeight * 0.9)
                                {
                                    sql = "SELECT * FROM Places WHERE City = '" + textBox2.Text + "'";
                                    command = new OleDbCommand(sql, connection);
                                    OleDbDataReader dataReader2 = command.ExecuteReader();
                                    dataReader2.Read();
                                    str = dataReader2["ID"].ToString();
                                    o = int.Parse(str);
                                    dataReader2.Close();
                                    for (int j = str2.Count / 3; j < 2 * str2.Count; j++)
                                    {

                                        if (str.Equals(str2[j]))
                                            ori = true;
                                        else
                                        {
                                            ori = false;
                                            break;
                                        }
                                    }
                                    sql = "SELECT * FROM Places WHERE City = '" + textBox3.Text + "'";
                                    command = new OleDbCommand(sql, connection);
                                    OleDbDataReader dataReader3 = command.ExecuteReader();
                                    dataReader3.Read();
                                    str = dataReader3["ID"].ToString();
                                    d = int.Parse(str);
                                    dataReader3.Close();
                                    for (int j = 2 * str2.Count / 3; j < str2.Count; j++)
                                    {

                                        if (str.Equals(str2[j]))

                                            des = true;
                                        else
                                        {
                                            des = false;
                                            break;
                                        }
                                    }


                                    if (ori && des)
                                    {
                                        sql = "INSERT INTO Loading (ShipID, GoodID, Quantity, OriginID, DestinationID) VALUES ('" + ship + "', '" + i + "', '" + w + "', '" + o + "', '" + d + "')";
                                        command = new OleDbCommand(sql, connection);
                                        command.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    sql = "SELECT * FROM Places WHERE City = '" + textBox2.Text.ToString() + "'";
                                    command = new OleDbCommand(sql, connection);
                                    OleDbDataReader dataReader2 = command.ExecuteReader();
                                    dataReader2.Read();
                                    str = dataReader2["ID"].ToString();
                                    o = int.Parse(str);
                                    dataReader2.Close();
                                    sql = "SELECT * FROM Places WHERE City = '" + textBox3.Text.ToString() + "'";
                                    command = new OleDbCommand(sql, connection);
                                    OleDbDataReader dataReader3 = command.ExecuteReader();
                                    dataReader3.Read();
                                    str = dataReader3["ID"].ToString();
                                    d = int.Parse(str);
                                    dataReader3.Close();
                                    sql = "INSERT INTO Loading (ShipID, GoodID, Quantity, OriginID, DestinationID) VALUES ('" + ship + "', '" + i + "', '" + w + "', '" + o + "', '" + d + "')";
                                    command = new OleDbCommand(sql, connection);
                                    command.ExecuteNonQuery();
                                }

                            }
                        }else
                            errorProvider1.SetError(button1, "Cargo can't be loaded");

                    }
                    else
                        errorProvider1.SetError(button1, "Cargo can't be loaded");

                }
            }
            // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
    }
}
