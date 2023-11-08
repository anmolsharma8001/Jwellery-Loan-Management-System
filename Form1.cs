using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static JWELLER_APP.Form2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JWELLER_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(LoginInfo.UserID);
            //label23.Text = LoginInfo.UserID;
            /*SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
            conn.Open();
            string insertQuery= "INSERT INTO CUSTOMER_MAIN_DATA(C_NAME,C_ADDRESS,C_ADHAR,MOBILE,ITEM_NAME,ITEM_TYPE,WEIGHT,P_AMMOUNT,INTEREST_P,LOAN_DATE) VALUES(@NAME,@ADDRESS,@ADHAR,@MOBILE,@ITEMNAME,@ITEMTYPE,@WEIGHT,@AMMOUNT,@L_DATE)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@C_NAME", TextBox1.Text);
            cmd.Parameters.AddWithValue("@C_ADDRESS", TextBox2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("SAVED");*/
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = true;
            label22.Visible = false;
            textBox20.Visible = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            checkBox1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView1.DataSource = "";
            textBox18.Text = string.Empty;
            textBox19.Text = string.Empty;
            reset();



        }
        int i = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            i = i + 1;
            if (i == 1)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                groupBox3.Visible = true;
                label22.Visible = true;
                textBox20.Visible = true;
                textBox20.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                checkBox1.Visible = false;
                dataGridView1.Visible = true;
                reset();
            }
            else
            {
                i = 0;
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
                conn.Open();
                string findquery = "SELECT * FROM CUSTOMER_MAIN_DATA";
                SqlCommand cmd = new SqlCommand(findquery, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                SqlDataReader reader1 = cmd.ExecuteReader();
                DataTable dtable1 = new DataTable();
                dtable1.Load(reader1);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        isgridenable = false;
                        dataGridView1.DataSource = dtable1;
                        label24.Visible = false;

                        // textBox12.Text = calinterest(int.Parse(textBox9.Text),Int64.Parse(textBox8.Text),Int64.Parse(textBox15.Text)).ToString();
                    }
                    else
                    {
                        label24.Visible = true;
                        label24.Text = "No Data here";

                    }

                }
                conn.Close();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox9.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (checkBox1.Checked == false))
            {
                MessageBox.Show("Please fill all the required filled or check the checkbox!"/*, MessageBoxButtons.OK, MessageBoxIcon.Exclamation*/);
            }
            else
            {
                try
                {
                    int n;
                    float m;
                    bool isamtNumeric = int.TryParse("123", out n), isintNumeric = int.TryParse(textBox9.Text, out n), isweightNumeric = float.TryParse(textBox6.Text, out m);
                    if (isamtNumeric == true && isintNumeric == true && isweightNumeric == true)
                    {
                        String cr_dt = System.DateTime.Now.ToString();
                        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
                        conn.Open();
                        string insertQuery = "INSERT INTO CUSTOMER_MAIN_DATA(C_NAME,C_ADDRESS,C_ADHAR,MOBILE,ITEM_NAME,ITEM_TYPE,WEIGHT,P_AMMOUNT,INTEREST_P,LOAN_DATE,TOTAL_PAY_AMT,LAST_PAY_AMT,IS_DUE,CLOSING_AMOUNT) VALUES(@NAME,@ADDRESS,@ADHAR,@MOBILE,@ITEMNAME,@ITEMTYPE,@WEIGHT,@AMMOUNT,@INTEREST,@L_DATE,@T_PAY,@L_PAY,@ISDUE,@CLOSING_AMT)";
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                        cmd.Parameters.AddWithValue("@ADDRESS", textBox2.Text);
                        cmd.Parameters.AddWithValue("@ADHAR", textBox3.Text);
                        cmd.Parameters.AddWithValue("@MOBILE", textBox4.Text);
                        cmd.Parameters.AddWithValue("@ITEMNAME", textBox5.Text);
                        cmd.Parameters.AddWithValue("@WEIGHT", textBox6.Text);
                        cmd.Parameters.AddWithValue("@ITEMTYPE", textBox7.Text);
                        cmd.Parameters.AddWithValue("@AMMOUNT", textBox8.Text);
                        cmd.Parameters.AddWithValue("@INTEREST", textBox9.Text);
                        cmd.Parameters.AddWithValue("@L_DATE", cr_dt);
                        cmd.Parameters.AddWithValue("@T_PAY", 0);
                        cmd.Parameters.AddWithValue("@L_PAY", 0);
                        cmd.Parameters.AddWithValue("@ISDUE", 0);
                        cmd.Parameters.AddWithValue("@CLOSING_AMT", 0);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        reset();
                        MessageBox.Show("DATA HAS SAVED SUCCESSFULLY...");
                    }
                    else
                    {
                        MessageBox.Show("Loan amount,interest & Weight can't be Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            /* bool isNumericadhar = int.TryParse(textBox3.Text, out _);
             if(isNumericadhar==false)
             {
                 textBox3.Text = null;
                 MessageBox.Show("only numeric");

             }*/
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            /*int n;
            bool isNumericmobile = int.TryParse(textBox4.Text, out n);
            if (isNumericmobile == false)
            {
                MessageBox.Show("only numeric");
                textBox4.Text = "";
            }*/
        }
        int is_due;
        float total_paid_amt;
        private void button6_Click(object sender, EventArgs e)
        {


            string findquery;
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
            conn.Open();
            if (textBox18.Text != "")
            {
                findquery = "SELECT * FROM CUSTOMER_MAIN_DATA WHERE C_NAME='" + textBox18.Text + "'";
                SqlCommand cmd = new SqlCommand(findquery, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dtable = new DataTable();
                dtable.Load(reader);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        textBox20.Text = sdr["id"].ToString();
                        textBox1.Text = sdr["C_NAME"].ToString();
                        textBox2.Text = sdr["C_ADDRESS"].ToString();
                        textBox3.Text = sdr["C_ADHAR"].ToString();
                        textBox4.Text = sdr["MOBILE"].ToString();
                        textBox5.Text = sdr["ITEM_NAME"].ToString();
                        textBox6.Text = sdr["WEIGHT"].ToString();
                        textBox7.Text = sdr["ITEM_TYPE"].ToString();
                        textBox8.Text = sdr["P_AMMOUNT"].ToString();
                        textBox9.Text = sdr["INTEREST_P"].ToString();
                        textBox10.Text = textBox8.Text;
                        textBox13.Text = sdr["LOAN_DATE"].ToString();
                        textBox16.Text = sdr["TOTAL_PAY_AMT"].ToString();
                        is_due = int.Parse(sdr["IS_DUE"].ToString());
                        total_paid_amt = float.Parse(sdr["CLOSING_AMOUNT"].ToString());
                        datesubstract();
                        dataGridView1.DataSource = dtable;
                        textBox17.Enabled = true;
                        groupBox5.Visible = true;
                        calinterest();

                    }
                    else
                    {
                        label21.Text = "Not Available data";
                        label21.Visible = true;

                    }
                }
            }
            else if (textBox19.Text != "")
            {
                findquery = "SELECT * FROM CUSTOMER_MAIN_DATA WHERE MOBILE='" + textBox19.Text + "'";
                SqlCommand cmd = new SqlCommand(findquery, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dtable = new DataTable();
                dtable.Load(reader);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        textBox20.Text = sdr["id"].ToString();
                        textBox1.Text = sdr["C_NAME"].ToString();
                        textBox2.Text = sdr["C_ADDRESS"].ToString();
                        textBox3.Text = sdr["C_ADHAR"].ToString();
                        textBox4.Text = sdr["MOBILE"].ToString();
                        textBox5.Text = sdr["ITEM_NAME"].ToString();
                        textBox6.Text = sdr["ITEM_TYPE"].ToString();
                        textBox7.Text = sdr["WEIGHT"].ToString();
                        textBox8.Text = sdr["P_AMMOUNT"].ToString();
                        textBox9.Text = sdr["INTEREST_P"].ToString();
                        textBox10.Text = textBox8.Text;
                        textBox13.Text = sdr["LOAN_DATE"].ToString();
                        textBox16.Text = sdr["TOTAL_PAY_AMT"].ToString();
                        is_due = int.Parse(sdr["IS_DUE"].ToString());
                        total_paid_amt = float.Parse(sdr["CLOSING_AMOUNT"].ToString());
                        datesubstract();
                        dataGridView1.DataSource = dtable;
                        textBox17.Enabled = true;
                        groupBox5.Visible = true;
                        calinterest();

                        // textBox12.Text = calinterest(int.Parse(textBox9.Text),Int64.Parse(textBox8.Text),Int64.Parse(textBox15.Text)).ToString();




                    }
                    else
                    {
                        label21.Text = "Not Available data";
                        label21.Visible = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill any one field for search!........");
            }
            conn.Close();



        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            textBox18.Text = "";
            label21.Visible = false;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            textBox19.Text = "";
            label21.Visible = false;
        }
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox20.Text = string.Empty;
        }
        public void datesubstract()
        {
            try
            {
                isgridenable = true;
                textBox14.Text = System.DateTime.Now.ToString();
                DateTime date1 = Convert.ToDateTime(textBox13.Text);
                DateTime date2 = Convert.ToDateTime(textBox14.Text);
                double result = (date2 - date1).TotalDays;
                textBox15.Text = Math.Round(result).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool isgridenable;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isgridenable == true)
                {
                    textBox20.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox13.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textBox16.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    is_due = int.Parse(dataGridView1.CurrentRow.Cells[14].Value.ToString());
                    total_paid_amt = float.Parse(dataGridView1.CurrentRow.Cells[15].Value.ToString());

                    calinterest();
                }
            }
            catch
            {

            }

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {
                datesubstract();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        float t_due;

        public void calinterest()
        {

            try
            {
                if (is_due == 0)
                {
                    float p, i, d, iamt, t_pay = float.Parse(textBox16.Text);
                    i = int.Parse(textBox9.Text);
                    p = int.Parse(textBox8.Text);
                    d = int.Parse(textBox15.Text);

                    i = i / 30;//monthly interest divide by 30 days to calculate once day
                    iamt = ((p * i) / 100);//per day rs interest
                    iamt = iamt * d;
                    textBox11.Text = iamt.ToString();
                    textBox12.Text = (int.Parse(textBox8.Text) + iamt).ToString();
                    t_due = int.Parse(textBox8.Text) + iamt;
                    textBox16.Text = (t_due - t_pay).ToString();
                }
                else
                {
                    float t_pay = float.Parse(textBox16.Text);
                    textBox16.Text = (total_paid_amt - t_pay).ToString();
                    //MessageBox.Show(total_paid_amt.ToString());

                    textBox11.Text = "No interest"; textBox12.Text = "closed";

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you confirmto log out your application...?", "Logout or Not", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                this.Close();
            }
            else
            {
                // Do Nothing
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox17.Text != string.Empty)
            {
                string total_paid;

                float T_PAID, P_AMT;
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select TOTAL_PAY_AMT,P_AMMOUNT FROM CUSTOMER_MAIN_DATA WHERE ID='" + textBox20.Text + "'", conn);
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();


                if (sdr.Read())
                {
                    total_paid = sdr["TOTAL_PAY_AMT"].ToString();
                    T_PAID = float.Parse(total_paid);
                    //P_AMT = float.Parse(sdr["P_AMMOUNT"].ToString());
                    P_AMT = t_due;
                    conn.Close();

                    //ADD TOTAL PAID AND LAST PAID
                    float d_amt = float.Parse(textBox17.Text);

                    total_paid = (T_PAID + d_amt).ToString();
                    conn.Open();
                    string query;

                    if ((float.Parse(textBox16.Text) <= float.Parse(textBox17.Text)) && is_due != 1)
                    {

                        query = "update CUSTOMER_MAIN_DATA set LAST_PAY_AMT='" + textBox17.Text.ToString() + "',TOTAL_PAY_AMT='" + total_paid + "',LAST_PAY_DATE='" + System.DateTime.Now.ToString() + "',IS_DUE='" + 1 + "',CLOSING_AMOUNT='" + textBox12.Text.ToString() + "' WHERE id='" + textBox20.Text.ToString() + "'";
                        SqlCommand cmd3 = new SqlCommand(query, conn);
                        cmd3.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        query = "update CUSTOMER_MAIN_DATA set LAST_PAY_AMT = '" + textBox17.Text.ToString() + "', TOTAL_PAY_AMT = '" + total_paid + "', LAST_PAY_DATE = '" + System.DateTime.Now.ToString() + "' WHERE id = '" + textBox20.Text.ToString() + "' ";
                        SqlCommand cmd1 = new SqlCommand(query, conn);
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                    }

                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into CUSTOMER_TRAN_DATA(ID,CUSTOMER_NAME,ADDRESS,AMOUNT_PAID,PAID_DATE) VALUES(@ID,@NAME,@ADDRESS,@AMOUNT,@DATE)", conn);
                    cmd2.Parameters.AddWithValue("@ID", textBox20.Text);
                    cmd2.Parameters.AddWithValue("@NAME", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@ADDRESS", textBox2.Text);
                    cmd2.Parameters.AddWithValue("@AMOUNT", textBox17.Text);
                    cmd2.Parameters.AddWithValue("@DATE", System.DateTime.Now.ToString());

                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    textBox17.Text = string.Empty;
                    MessageBox.Show("AMOUNT DEPOSITED", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterdeposit();
                    //button6_Click(sender, new EventArgs());

                    /*else
                    {
                        MessageBox.Show("No dues is Remaining in this account","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        textBox17.Text = string.Empty;
                    }*/



                    /*
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update CUSTOMER_MAIN_DATA set LAST_PAY_AMT='"+textBox17.Text.ToString()+"',TOTAL_PAY_AMT="'");
                    cmd.ExecuteNonQuery();
                    conn.Close();*/
                }
            }
            else
            {
                MessageBox.Show("Please enter deposit Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string connections = "Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True";
                if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty) && (textBox3.Text != string.Empty) && (textBox4.Text != string.Empty))
                {
                    SqlConnection conn = new SqlConnection(connections);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update CUSTOMER_MAIN_DATA SET C_NAME='" + textBox1.Text + "',C_ADDRESS='" + textBox2.Text + "',C_ADHAR='" + textBox3.Text + "',MOBILE='" + textBox4.Text + "' WHERE ID='" + textBox20.Text + "' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated personel detail..");
                    radioButton1.Checked = false;
                    radioButton3.Checked = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;

                }

            }
            if (radioButton3.Checked == true)
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
                conn.Open();
                string findquery = "SELECT TRAN_ID,CUSTOMER_NAME,ADDRESS,AMOUNT_PAID,PAID_DATE FROM CUSTOMER_TRAN_DATA WHERE ID='" + textBox20.Text + "'";
                SqlCommand cmd = new SqlCommand(findquery, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                SqlDataReader reader1 = cmd.ExecuteReader();
                DataTable dtable1 = new DataTable();
                dtable1.Load(reader1);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        isgridenable = false;
                        dataGridView1.DataSource = dtable1;
                        label24.Visible = false;

                        // textBox12.Text = calinterest(int.Parse(textBox9.Text),Int64.Parse(textBox8.Text),Int64.Parse(textBox15.Text)).ToString();
                    }
                    else
                    {
                        label24.Visible = true;
                        label24.Text = "Not Found";

                    }

                }
                conn.Close();

            }

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                Form3 frm3 = new Form3();
                frm3.ShowDialog();
                radioButton2.Checked = false;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        void afterdeposit()
        {
            string findquery;
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=E:\\CUSTOMER_DATA.MDF;Integrated Security=True");
            conn.Open();
            
                findquery = "SELECT * FROM CUSTOMER_MAIN_DATA WHERE id='"+textBox20.Text+"'";
                SqlCommand cmd = new SqlCommand(findquery, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dtable = new DataTable();
                dtable.Load(reader);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        textBox20.Text = sdr["id"].ToString();
                        textBox1.Text = sdr["C_NAME"].ToString();
                        textBox2.Text = sdr["C_ADDRESS"].ToString();
                        textBox3.Text = sdr["C_ADHAR"].ToString();
                        textBox4.Text = sdr["MOBILE"].ToString();
                        textBox5.Text = sdr["ITEM_NAME"].ToString();
                        textBox6.Text = sdr["WEIGHT"].ToString();
                        textBox7.Text = sdr["ITEM_TYPE"].ToString();
                        textBox8.Text = sdr["P_AMMOUNT"].ToString();
                        textBox9.Text = sdr["INTEREST_P"].ToString();
                        textBox10.Text = textBox8.Text;
                        textBox13.Text = sdr["LOAN_DATE"].ToString();
                        textBox16.Text = sdr["TOTAL_PAY_AMT"].ToString();
                        is_due = int.Parse(sdr["IS_DUE"].ToString());
                        total_paid_amt = float.Parse(sdr["CLOSING_AMOUNT"].ToString());
                        datesubstract();
                        dataGridView1.DataSource = dtable;
                        textBox17.Enabled = true;
                        groupBox5.Visible = true;
                        calinterest();

                    }

                }
            
        }
    }
}
