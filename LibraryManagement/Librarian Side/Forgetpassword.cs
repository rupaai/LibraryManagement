﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryManagement.DBConnect;
using System.Data.SqlClient;
namespace LibraryManagement
{
    public partial class Forgetpassword : Form
    {
        public Forgetpassword()
        {
            InitializeComponent();
        }
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J2E5UDC\SQLEXPRESS;Initial Catalog=lms;Integrated Security=True");
        DBConnect db = new DBConnect();
        string id, security, name, time_id, pass;
        private void button3_Click(object sender, EventArgs e)
        {
            LibrarianLogin ob = new LibrarianLogin();
            this.Hide();
            ob.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String username, name, security, password, answer;

                username = txtusername.Text;
                name = txtlibname.Text;
                security = txtsecurity.Text;
                password = txtpassword.Text;
                answer = txtanswer.Text;
                //con.Open();
                string[] col = new[] { "id", "name", "security", "time_id" };
                String query1 = "SELECT id, name, security, time_id FROM Librarian WHERE username='" + username + "';";
                //SqlCommand cmd1 = new SqlCommand(query1, con);
                List<List<string>> result = new List<List<string>>();
                result = db.selectSearch(query1, col);
                for(int i = 0; i<col.Length; i++)
                    {
                        col[i] = result[0][i];
                    }
                id = col[0];
                name = col[1];
                security = col[2];
                time_id = col[3];
                txtlibname.Text = name;
                txtsecurity.Text = security;
                //SqlDataReader dr1 = cmd1.ExecuteReader();
                //if (dr1.Read())
                //{
                //    txtlibname.Text = (dr1["libname"].ToString());

                //    txtsecurity.Text = (dr1["securityquestion"].ToString());




                //}

                //dr1.Close();
                //con.Close();


            } catch (Exception ex)
            { }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                String query2 = "SELECT password FROM Librarian WHERE answer = '" + txtanswer.Text + "' AND id='" + id + "' AND time_id='" + time_id + "';";
                string[] col = new[] { "password" };
                List<List<string>> result = new List<List<string>>();
                result = db.selectSearch(query2, col);
                
                pass = result[0][0];
                txtpassword.Text = pass;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
