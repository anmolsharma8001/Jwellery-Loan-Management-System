using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JWELLER_APP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if((textBox1.Text!=string.Empty) && (textBox2.Text!=string.Empty) && (textBox3.Text != string.Empty))
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
                conn.Open();
                string loginQuery = "select * from ADMIN_DATA where PASSWORD='" + (textBox1.Text).ToString() + "' and USER_ID='" + 1 + "'";
                SqlCommand cmd = new SqlCommand(loginQuery, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    conn.Close();
                    if (textBox2.Text == textBox3.Text)
                    {
                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand("update ADMIN_DATA SET PASSWORD='" + textBox2.Text + "'WHERE USER_ID='" + 1 + "'", conn);
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Password changed");
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        label5.Text = "Check new password...";
                        label5.Visible = true;
                    }

                }
                else
                {
                    label5.Text = "invalid old Password";
                    label5.Visible = true;
                }

            }
            else
            {
                label5.Text = "Fill Required feiled";
                label5.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Visible=false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
