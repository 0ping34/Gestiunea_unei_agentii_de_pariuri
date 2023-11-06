using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace Gestiunea_unei_agentii_de_pariuri
{
    public partial class Login : Form
    {
        Data.Logare con =new Data.Logare();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(User.Text=="admin" && Pass.Text=="1234")
            {
                try 
                {
                    Data.Logare.dataSource();
                    con.connOpen();
                    Debug.WriteLine("Logare");
                    con.connClose();
                    this.Hide();
                    Manager m=new Manager();
                    m.ShowDialog();
                    this.Close();
                }
                catch(Exception ex) 
                {
                    Debug.WriteLine("Esec");
                    con.connClose();
                }
            }
            else 
            {
                MessageBox.Show("Te rog sa reintroduci utilizatorul si parola");
            }
        }
    }
}
