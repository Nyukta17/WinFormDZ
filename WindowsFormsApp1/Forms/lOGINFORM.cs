using MySql.Data.MySqlClient;
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
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    public partial class lOGINFORM : Form
    {
        public lOGINFORM()
        {
            InitializeComponent();
            this.Login_fild.AutoSize = false;
            this.Login_fild.Size = new Size(this.Pass_fild.Size.Width, 29);
            this.Pass_fild.Size = new Size(this.Login_fild.Size.Width, 20);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        Point lastPoint;
        private void lOGINFORM_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void lOGINFORM_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = Login_fild.Text;
            var pass = Pass_fild.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string comm = $"SELECT Log, Pass from Table_Users  WHERE Log = '{login}' and Pass = '{pass}'";
            SqlCommand command = new SqlCommand(comm,db.get_connection());
           
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0 ) 
            {
                MessageBox.Show("Yes, you are inside");
                Users form = new Users();
                form.ShowDialog();
            }
            else 
            {
                MessageBox.Show("No, you are't inside");
            }
        }
    }
}
