using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JWELLER_APP
{
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            string dt = System.DateTime.Now.ToString();
            DateTime date1 = Convert.ToDateTime(dt);
            DateTime date2 = Convert.ToDateTime("11/01/2023");
            double result = (date2 - date1).TotalDays;
            string days = Math.Round(result).ToString();
            
            if (int.Parse(days)<=0)
            {
                MessageBox.Show(days+ " Your software has been expired contact to Software administratore","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                //MessageBox.Show(days.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    Form1 form1 = new Form1();
                    SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
                    conn.Open();
                    string loginQuery = "select * from ADMIN_DATA where USERNAME='" + (textBox1.Text).ToString() + "' and PASSWORD='" + (textBox2.Text).ToString() + "'";
                    SqlCommand cmd = new SqlCommand(loginQuery, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        this.Hide();
                        form1.ShowDialog();
                        //LoginInfo.UserID = sdr["ADMIN_NAME"].ToString();
                        this.Close();
                    }
                    else
                    {
                        label3.Visible = true;
                        label3.Text = "Invalid User..!";
                        //MessageBox.Show("Not matched");
                    }
                    conn.Close();
                }
                else
                {
                    label3.Visible = true;
                    label3.Text = "USERNAME AND PASSWORD CAN NOT BE EMPTY..!";
                }

            }
            catch (Exception ex)
            {
                label3.Visible= true;
                label3.Text = "Database conection is not stablished";
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Visible=false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public static class LoginInfo
    {
        public static string UserID;
    }
}
