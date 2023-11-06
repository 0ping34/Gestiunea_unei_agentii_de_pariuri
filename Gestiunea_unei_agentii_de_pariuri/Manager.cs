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
using MySql.Data.MySqlClient;
using Gestiunea_unei_agentii_de_pariuri.Data;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities.Collections;
using System.Collections;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestiunea_unei_agentii_de_pariuri
{

    public partial class Manager : Form
    {
        static string server = "127.0.0.1;";
        static string database = "casa_de_pariuri;";
        static string Uid = "admin;";
        static string password = "1234;";
        public MySqlConnection conn = new MySqlConnection($"server={server} database={database} Uid={Uid} password={password}");
        public float Castiguri=0;
        public float Profit=0;
        public Manager()
        {
            InitializeComponent();
            LoadData();
            LoadData2();
            LoadData3();
            LoadData4();
            LoadData5();
            LoadData6();
        }

        //LoadData() incarca datele din baza de date in DataGridView in timp real
        private void LoadData()
        {
            var database = new Logare();
            if (database.bool_connOpen())
            {
                string query = "SELECT * FROM casa_de_pariuri";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bS = new BindingSource();
                bS.DataSource = dt;

                dataGridView1.DataSource = bS;
                database.connClose();
            }
            else
            {
                MessageBox.Show("Nu sa incarcat");
            }
        }

        private void LoadData2()
        {
            var database = new Logare();
            if (database.bool_connOpen())
            {
                string query = "SELECT * FROM angajat";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bS = new BindingSource();
                bS.DataSource = dt;

                dataGridView2.DataSource = bS;
                database.connClose();
            }
            else
            {
                MessageBox.Show("Nu sa incarcat");
            }
        }

        private void LoadData3()
        {
            var database = new Logare();
            if (database.bool_connOpen())
            {
                string query = "SELECT * FROM aparat";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bS = new BindingSource();
                bS.DataSource = dt;

                dataGridView3.DataSource = bS;
                database.connClose();
            }
            else
            {
                MessageBox.Show("Nu sa incarcat");
            }
        }

        private void LoadData4()
        {
            var database = new Logare();
            if (database.bool_connOpen())
            {
                string query = "SELECT * FROM pariu";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bS = new BindingSource();
                bS.DataSource = dt;

                dataGridView4.DataSource = bS;
                database.connClose();
            }
            else
            {
                MessageBox.Show("Nu sa incarcat");
            }
        }

        private void LoadData5()
        {
            var database = new Logare();
            if (database.bool_connOpen())
            {
                string query = "SELECT * FROM cota";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bS = new BindingSource();
                bS.DataSource = dt;

                dataGridView5.DataSource = bS;
                database.connClose();
            }
            else
            {
                MessageBox.Show("Nu sa incarcat");
            }
        }

        private void LoadData6()
        {
            var database = new Logare();
            if (database.bool_connOpen())
            {
                string query = "SELECT * FROM client";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bS = new BindingSource();
                bS.DataSource = dt;

                dataGridView6.DataSource = bS;
                database.connClose();
            }
            else
            {
                MessageBox.Show("Nu sa incarcat");
            }
        }
        private void Manager_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData2();
            LoadData3();
            LoadData4();
            LoadData5();
            LoadData6();

        }

        //adaugare
        private void Adaugare_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "INSERT INTO casa_de_pariuri (CODP, Nume, Locatie,Contact) VALUES (@value1, @value2, @value3,@value4)";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODP.Text);
            cmd.Parameters.AddWithValue("@value2", Nume.Text);
            cmd.Parameters.AddWithValue("@value3", Locatie.Text);
            cmd.Parameters.AddWithValue("@value4", Contact.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData();

        }



        //modificare
        private void Modificare_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "UPDATE casa_de_pariuri set Nume=@value2, Locatie=@value3,Contact=@value4 where CODP=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODP.Text);
            cmd.Parameters.AddWithValue("@value2", Nume.Text);
            cmd.Parameters.AddWithValue("@value3", Locatie.Text);
            cmd.Parameters.AddWithValue("@value4", Contact.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData();
        }

        //stergere
        private void Stergere_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "Delete FROM casa_de_pariuri WHERE CODP=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODP.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData();
        }

        //inserare in casutele de text a datelor din DataGridView
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CODP.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nume.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Locatie.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Contact.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        //Reset
        private void Reset_Click(object sender, EventArgs e)
        {
            CODP.Text = "";
            Nume.Text = "";
            Locatie.Text = "";
            Contact.Text = "";
            LoadData();
        }


        //Cautare
        private void Cautare_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from casa_de_pariuri WHERE CODP LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Search.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            conn.Close();
            MessageBox.Show("Succes");

        }

        //Filtrare
        private void Filtru_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from casa_de_pariuri WHERE CODP LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Filtru.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            conn.Close();

        }

        //Export PDF
        private void Printat_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            // If the user chooses a printer, print the table
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        //Printarea Datelor
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the row height and column width
            int rowHeight = dataGridView1.RowTemplate.Height;
            int columnWidth = 80;

            // Set the starting x and y coordinates
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            // Draw the column headers
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                x += columnWidth;

                // Draw a line after each column except for the last column
                if (i != dataGridView1.Columns.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
            }

            // Draw a line below the column headers
            y += rowHeight;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(Pens.Black, x, y, x + (dataGridView1.Columns.Count * columnWidth), y);

            // Draw the data
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                x = e.MarginBounds.Left;
                y += rowHeight;

                // Draw the row data
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].FormattedValue.ToString(), new Font("Arial", 12), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                    x += columnWidth;

                    // Draw a line after each column except for the last column
                    if (j != dataGridView1.Columns.Count - 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                    }
                }

                // Draw a line below the row
                e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (dataGridView1.Columns.Count * columnWidth), y);
            }
        }
        
        //Import Excel(csv)
        private void button1_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to get the path of the .csv file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The path of the .csv file
                string filePath = ofd.FileName;

                // Create a new DataTable
                DataTable dt = new DataTable();

                // Read the contents of the .csv file into the DataTable
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // Assign the DataTable as the DataSource for the DataGridView
                dataGridView1.DataSource = dt;
            }

        }

        //Grapic de tip Line
        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new instance of Graph
            Graph Graph = new Graph();

            // Ensure that chart1 has a Series to add data to
            if (Graph.chart1.Series.Count == 0)
            {
                Graph.chart1.Series.Add("Series1");
            }

            // Set the chart type to Bar
            Graph.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            Graph.chart1.ChartAreas[0].AxisX.Title = "Nume";
            Graph.chart1.ChartAreas[0].AxisY.Title = "Frequency";
            MySqlDataAdapter adapter;
            string query = "Select Nume,Locatie from casa_de_pariuri ";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            Dictionary<string, int> frequency = new Dictionary<string, int>();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nume = reader[0].ToString();
                    if (frequency.ContainsKey(nume))
                    {
                        frequency[nume]++;
                    }
                    else
                    {
                        frequency[nume] = 1;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }

            conn.Close();

            foreach (var item in frequency)
            {
                Graph.chart1.Series["Series1"].Points.AddXY(item.Key, item.Value);
            }

            Graph.Show();
        }

        //Practic repet operatiunile de m-ai de sus de 6 ori cu mingi diferente de structura


        private void Adaugare2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "INSERT INTO angajat (CODA, Nume, Prenume,Varsta,CODP) VALUES (@value1, @value2, @value3,@value4,@value5)";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODA.Text);
            cmd.Parameters.AddWithValue("@value2", Nume2.Text);
            cmd.Parameters.AddWithValue("@value3", Prenume.Text);
            cmd.Parameters.AddWithValue("@value4", Varsta.Text);
            cmd.Parameters.AddWithValue("@value5", CODP2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData2();
        }

        private void Modificare2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "UPDATE angajat set Nume=@value2, Prenume=@value3,Varsta=@value4,CODP=@value5 where CODA=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODA.Text);
            cmd.Parameters.AddWithValue("@value2", Nume2.Text);
            cmd.Parameters.AddWithValue("@value3", Prenume.Text);
            cmd.Parameters.AddWithValue("@value4", Varsta.Text);
            cmd.Parameters.AddWithValue("@value5", CODP2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData2();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CODA.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nume2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            Prenume.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            Varsta.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            CODP2.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void Stergere2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "Delete FROM angajat WHERE CODA=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODA.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData2();
        }

        private void Reset2_Click(object sender, EventArgs e)
        {

            CODA.Text = "";
            Nume2.Text = "";
            Prenume.Text = "";
            Varsta.Text = "";
            CODP2.Text = "";
            LoadData2();
        }

        private void Cautare2_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from angajat WHERE CODA LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Search2.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            conn.Close();
            MessageBox.Show("Succes");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from angajat WHERE CODA LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Filtru2.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument2;

            // If the user chooses a printer, print the table
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the row height and column width
            int rowHeight = dataGridView2.RowTemplate.Height;
            int columnWidth = 80;

            // Set the starting x and y coordinates
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            // Draw the column headers
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView2.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                x += columnWidth;

                // Draw a line after each column except for the last column
                if (i != dataGridView2.Columns.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
            }

            // Draw a line below the column headers
            y += rowHeight;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(Pens.Black, x, y, x + (dataGridView2.Columns.Count * columnWidth), y);

            // Draw the data
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                x = e.MarginBounds.Left;
                y += rowHeight;

                // Draw the row data
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].FormattedValue.ToString(), new Font("Arial", 12), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                    x += columnWidth;

                    // Draw a line after each column except for the last column
                    if (j != dataGridView2.Columns.Count - 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                    }
                }

                // Draw a line below the row
                e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (dataGridView1.Columns.Count * columnWidth), y);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to get the path of the .csv file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The path of the .csv file
                string filePath = ofd.FileName;

                // Create a new DataTable
                DataTable dt = new DataTable();

                // Read the contents of the .csv file into the DataTable
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // Assign the DataTable as the DataSource for the DataGridView
                dataGridView2.DataSource = dt;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {// Create a new instance of Graph
            Graph Graph = new Graph();

            // Ensure that chart1 has a Series to add data to
            if (Graph.chart1.Series.Count == 0)
            {
                Graph.chart1.Series.Add("Series1");
            }

            // Set the chart type to Bar
            Graph.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            Graph.chart1.ChartAreas[0].AxisX.Title = "Nume";
            Graph.chart1.ChartAreas[0].AxisY.Title = "Varsta";
            MySqlDataAdapter adapter;
            string query = "Select Nume,Varsta from angajat ";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string xLabel = reader[0].ToString();
                    double yValue;

                    if (Double.TryParse(reader[1].ToString(), out yValue))
                    {
                        Graph.chart1.Series["Series1"].Points.AddXY(xLabel, yValue);
                    }
                    else
                    {
                        MessageBox.Show("Cannot convert Varsta to a numeric value.");
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }

            conn.Close();
            Graph.Show();

        }

        private void Adaugare3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "INSERT INTO aparat (CODAP, Nume, Producator,Vechime,Cost,CODP) VALUES (@value1, @value2, @value3,@value4,@value5,@value6)";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODAP.Text);
            cmd.Parameters.AddWithValue("@value2", Nume3.Text);
            cmd.Parameters.AddWithValue("@value3", Producator.Text);
            cmd.Parameters.AddWithValue("@value4", Vechime.Text);
            cmd.Parameters.AddWithValue("@value5", Cost.Text);
            cmd.Parameters.AddWithValue("@value6", CODP3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData3();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CODAP.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nume3.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            Producator.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            Vechime.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            Cost.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            CODP3.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void Modificare3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "UPDATE aparat set Nume=@value2, Producator=@value3,Vechime=@value4,Cost=@value5,CODP=@value6 where CODAP=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODAP.Text);
            cmd.Parameters.AddWithValue("@value2", Nume3.Text);
            cmd.Parameters.AddWithValue("@value3", Producator.Text);
            cmd.Parameters.AddWithValue("@value4", Vechime.Text);
            cmd.Parameters.AddWithValue("@value5", Cost.Text);
            cmd.Parameters.AddWithValue("@value6", CODP3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData3();
        }

        private void Stergere3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "Delete FROM aparat WHERE CODAP=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODAP.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData3();
        }

        private void Reset3_Click(object sender, EventArgs e)
        {
            CODAP.Text = "";
            Nume3.Text = "";
            Producator.Text = "";
            Vechime.Text = "";
            Cost.Text = "";
            CODP3.Text = "";
            LoadData3();
        }

        private void Cautare3_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from aparat WHERE CODAP LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Search3.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView3.DataSource = table;
            conn.Close();
            MessageBox.Show("Succes");
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from aparat WHERE CODAP LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Filtru3.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView3.DataSource = table;
            conn.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument3;

            // If the user chooses a printer, print the table
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument3.Print();
            }
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the row height and column width
            int rowHeight = dataGridView3.RowTemplate.Height;
            int columnWidth = 80;

            // Set the starting x and y coordinates
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            // Draw the column headers
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView3.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                x += columnWidth;

                // Draw a line after each column except for the last column
                if (i != dataGridView3.Columns.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
            }

            // Draw a line below the column headers
            y += rowHeight;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(Pens.Black, x, y, x + (dataGridView3.Columns.Count * columnWidth), y);

            // Draw the data
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                x = e.MarginBounds.Left;
                y += rowHeight;

                // Draw the row data
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    e.Graphics.DrawString(dataGridView3.Rows[i].Cells[j].FormattedValue.ToString(), new Font("Arial", 12), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                    x += columnWidth;

                    // Draw a line after each column except for the last column
                    if (j != dataGridView3.Columns.Count - 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                    }
                }

                // Draw a line below the row
                e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (dataGridView1.Columns.Count * columnWidth), y);
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to get the path of the .csv file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The path of the .csv file
                string filePath = ofd.FileName;

                // Create a new DataTable
                DataTable dt = new DataTable();

                // Read the contents of the .csv file into the DataTable
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // Assign the DataTable as the DataSource for the DataGridView
                dataGridView3.DataSource = dt;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Create a new instance of Graph
            Graph Graph = new Graph();

            // Ensure that chart1 has a Series to add data to
            if (Graph.chart1.Series.Count == 0)
            {
                Graph.chart1.Series.Add("Series1");
            }

            // Set the chart type to Bar
            Graph.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            Graph.chart1.ChartAreas[0].AxisX.Title = "Producator";
            Graph.chart1.ChartAreas[0].AxisY.Title = "Cost";
            MySqlDataAdapter adapter;
            string query = "Select Producator,Cost from aparat ";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string xLabel = reader[0].ToString();
                    double yValue;

                    if (Double.TryParse(reader[1].ToString(), out yValue))
                    {
                        Graph.chart1.Series["Series1"].Points.AddXY(xLabel, yValue);
                    }
                    else
                    {
                        MessageBox.Show("Cannot convert Cost to a numeric value.");
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }

            conn.Close();
            Graph.Show();


        }

        private void Adaugare4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "INSERT INTO pariu (CODPA, Tip,Sport, Data_Incheieri,Data_Realizari,CODAP) VALUES (@value1, @value2, @value3,@value4,@value5,@value6)";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODPA.Text);
            cmd.Parameters.AddWithValue("@value2", Tip.Text);
            cmd.Parameters.AddWithValue("@value3", Sport.Text);
            cmd.Parameters.AddWithValue("@value4", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@value5", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@value6", CODAP2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData4();
        }

        private void Modificare4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "UPDATE pariu set Tip=@value2, Sport=@value3,Data_Incheieri=@value4,Data_Realizari=@value5,CODAP=@value6 where CODPA=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODPA.Text);
            cmd.Parameters.AddWithValue("@value2", Tip.Text);
            cmd.Parameters.AddWithValue("@value3", Sport.Text);
            cmd.Parameters.AddWithValue("@value4", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@value5", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@value6", CODAP2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData4();
        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            CODPA.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            Tip.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
            Sport.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView4.Rows[e.RowIndex].Cells[3].Value;
            dateTimePicker2.Value = (DateTime)dataGridView4.Rows[e.RowIndex].Cells[4].Value;
            CODAP2.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void Stergere4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "Delete FROM pariu WHERE CODPA=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODPA.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData4();
        }

        private void Reset4_Click(object sender, EventArgs e)
        {

            CODPA.Text = "";
            Tip.Text = "";
            Sport.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            CODAP2.Text =  "";
            LoadData4();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from pariu WHERE CODPA LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Search4.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            conn.Close();
            MessageBox.Show("Succes");
        }

        private void Filtru4_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from pariu WHERE CODPA LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Filtru4.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument4;

            // If the user chooses a printer, print the table
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument4.Print();
            }
        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the row height and column width
            int rowHeight = dataGridView4.RowTemplate.Height;
            int columnWidth = 80;

            // Set the starting x and y coordinates
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            // Draw the column headers
            for (int i = 0; i < dataGridView4.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView4.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                x += columnWidth;

                // Draw a line after each column except for the last column
                if (i != dataGridView4.Columns.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
            }

            // Draw a line below the column headers
            y += rowHeight;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(Pens.Black, x, y, x + (dataGridView4.Columns.Count * columnWidth), y);

            // Draw the data
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                x = e.MarginBounds.Left;
                y += rowHeight;

                // Draw the row data
                for (int j = 0; j < dataGridView4.Columns.Count; j++)
                {
                    e.Graphics.DrawString(dataGridView4.Rows[i].Cells[j].FormattedValue.ToString(), new Font("Arial", 12), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                    x += columnWidth;

                    // Draw a line after each column except for the last column
                    if (j != dataGridView4.Columns.Count - 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                    }
                }

                // Draw a line below the row
                e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (dataGridView1.Columns.Count * columnWidth), y);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to get the path of the .csv file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The path of the .csv file
                string filePath = ofd.FileName;

                // Create a new DataTable
                DataTable dt = new DataTable();

                // Read the contents of the .csv file into the DataTable
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // Assign the DataTable as the DataSource for the DataGridView
                dataGridView4.DataSource = dt;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create a new instance of Graph
            Graph Graph = new Graph();

            // Ensure that chart1 has a Series to add data to
            if (Graph.chart1.Series.Count == 0)
            {
                Graph.chart1.Series.Add("Series1");
            }

            // Set the chart type to Bar
            Graph.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            Graph.chart1.ChartAreas[0].AxisX.Title = "Tip";
            Graph.chart1.ChartAreas[0].AxisY.Title = "Count";

            string query = "Select Tip, Sport from pariu";

            Dictionary<string, int> counts = new Dictionary<string, int>();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tipSportPair = reader[0].ToString() + "/" + reader[1].ToString();

                    if (counts.ContainsKey(tipSportPair))
                    {
                        counts[tipSportPair]++;
                    }
                    else
                    {
                        counts[tipSportPair] = 1;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            foreach (var pair in counts)
            {
                int index = Graph.chart1.Series["Series1"].Points.AddY(pair.Value);
                Graph.chart1.Series["Series1"].Points[index].AxisLabel = pair.Key;
            }

            Graph.Show();
        }

        private void Adaugare5_Click(object sender, EventArgs e)
        {
            Castiguri = float.Parse(Miza.Text) * float.Parse(Sansa.Text);
            Profit =Castiguri- float.Parse(Miza.Text);
            MySqlCommand cmd;
            string query = "INSERT INTO cota (CODC,Miza,Castiguri,Profit,Sansa,CODPA) VALUES (@value1, @value2, @value3,@value4,@value5,@value6)";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODC.Text);
            cmd.Parameters.AddWithValue("@value2", Miza.Text);
            cmd.Parameters.AddWithValue("@value3", Castiguri);
            cmd.Parameters.AddWithValue("@value4", Profit);
            cmd.Parameters.AddWithValue("@value5", Sansa.Text);
            cmd.Parameters.AddWithValue("@value6", CODPA2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData5();

        }

        private void Modificare5_Click(object sender, EventArgs e)
        {
            Castiguri = float.Parse(Miza.Text) * float.Parse(Sansa.Text);
            Profit = Castiguri - float.Parse(Miza.Text);
            MySqlCommand cmd;
            string query = "UPDATE cota set Miza=@value2, Castiguri=@value3,Profit=@value4,Sansa=@value5,CODPA=@value6 where CODC=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODC.Text);
            cmd.Parameters.AddWithValue("@value2", Miza.Text);
            cmd.Parameters.AddWithValue("@value3", Castiguri);
            cmd.Parameters.AddWithValue("@value4", Profit);
            cmd.Parameters.AddWithValue("@value5", Sansa.Text);
            cmd.Parameters.AddWithValue("@value6", CODPA2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData5();
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CODC.Text = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
            Miza.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            Sansa.Text = dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString();
            CODPA2.Text = dataGridView5.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void Stergere5_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "Delete FROM cota WHERE CODC=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", CODC.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData5();
        }

        private void Reset5_Click(object sender, EventArgs e)
        {
            CODC.Text = "";
            Miza.Text = "";
            Sansa.Text = "";
            CODPA2.Text = "";
            LoadData5();
        }

        private void Cautare5_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from cota WHERE CODC LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Search5.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView5.DataSource = table;
            conn.Close();
            MessageBox.Show("Succes");
        }

        private void Filtru5_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from cota WHERE CODC LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Filtru5.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView5.DataSource = table;
            conn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument5;

            // If the user chooses a printer, print the table
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument5.Print();
            }
        }

        private void printDocument5_PrintPage(object sender, PrintPageEventArgs e)
        {

            // Set the row height and column width
            int rowHeight = dataGridView2.RowTemplate.Height;
            int columnWidth = 80;

            // Set the starting x and y coordinates
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            // Draw the column headers
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView2.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                x += columnWidth;

                // Draw a line after each column except for the last column
                if (i != dataGridView2.Columns.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
            }

            // Draw a line below the column headers
            y += rowHeight;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(Pens.Black, x, y, x + (dataGridView5.Columns.Count * columnWidth), y);

            // Draw the data
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                x = e.MarginBounds.Left;
                y += rowHeight;

                // Draw the row data
                for (int j = 0; j < dataGridView5.Columns.Count; j++)
                {
                    e.Graphics.DrawString(dataGridView5.Rows[i].Cells[j].FormattedValue.ToString(), new Font("Arial", 12), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                    x += columnWidth;

                    // Draw a line after each column except for the last column
                    if (j != dataGridView5.Columns.Count - 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                    }
                }

                // Draw a line below the row
                e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (dataGridView1.Columns.Count * columnWidth), y);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to get the path of the .csv file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The path of the .csv file
                string filePath = ofd.FileName;

                // Create a new DataTable
                DataTable dt = new DataTable();

                // Read the contents of the .csv file into the DataTable
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // Assign the DataTable as the DataSource for the DataGridView
                dataGridView5.DataSource = dt;
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create a new instance of Graph
            Graph Graph = new Graph();

            // Ensure that chart1 has a Series to add data to
            if (Graph.chart1.Series.Count == 0)
            {
                Graph.chart1.Series.Add("Series1");
            }

            // Set the chart type to Bar
            Graph.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            Graph.chart1.ChartAreas[0].AxisX.Title = "Miza";
            Graph.chart1.ChartAreas[0].AxisY.Title = "Castiguri";

            string query = "Select Miza, Castiguri from cota ";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    double miza = Convert.ToDouble(reader[0]);
                    double castiguri = Convert.ToDouble(reader[1]);

                    // Create a new data point
                    DataPoint dp = new DataPoint(miza, castiguri);

                    // Add the data point to the series
                    Graph.chart1.Series["Series1"].Points.Add(dp);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            Graph.Show();

        }

        private void Adaugare6_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "INSERT INTO client (CNP, Nume, Prenume,Adresa,Varsta,CODPA) VALUES (@value1, @value2, @value3,@value4,@value5,@value6)";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", Cnp.Text);
            cmd.Parameters.AddWithValue("@value2", Nume4.Text);
            cmd.Parameters.AddWithValue("@value3", Prenume2.Text);
            cmd.Parameters.AddWithValue("@value4", Adresa.Text);
            cmd.Parameters.AddWithValue("@value5", Varsta2.Text);
            cmd.Parameters.AddWithValue("@value6", CODPA3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData6();
        }

        private void Modificare6_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "UPDATE client set Nume=@value2, Prenume=@value3,Adresa=@value4,Varsta=@value5,CODPA=@value6 where CNP=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", Cnp.Text);
            cmd.Parameters.AddWithValue("@value2", Nume4.Text);
            cmd.Parameters.AddWithValue("@value3", Prenume2.Text);
            cmd.Parameters.AddWithValue("@value4", Adresa.Text);
            cmd.Parameters.AddWithValue("@value5", Varsta2.Text);
            cmd.Parameters.AddWithValue("@value6", CODPA3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData6();
        }

        private void dataGridView6_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cnp.Text = dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nume4.Text = dataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();
            Prenume2.Text = dataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
            Adresa.Text = dataGridView6.Rows[e.RowIndex].Cells[3].Value.ToString();
            Varsta2.Text = dataGridView6.Rows[e.RowIndex].Cells[4].Value.ToString();
            CODPA3.Text = dataGridView6.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void Stergere6_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            string query = "Delete FROM client WHERE CNP=@value1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value1", Cnp.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succes");
            LoadData6();
        }

        private void Reset6_Click(object sender, EventArgs e)
        {
            Cnp.Text = "";
            Nume4.Text = "";
            Prenume2.Text = "";
            Adresa.Text = "";
            Varsta2.Text = "";
            CODPA3.Text = "";
            LoadData6();
        }

        private void Cautare6_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from client WHERE CNP LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Search6.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView6.DataSource = table;
            conn.Close();
            MessageBox.Show("Succes");

        }

        private void Filtru6_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            string query = "Select * from client WHERE CNP LIKE @searchTerm";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + Filtru6.Text + "%");
            adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView6.DataSource = table;
            conn.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument6;

            // If the user chooses a printer, print the table
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument6.Print();
            }
        }

        private void printDocument6_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the row height and column width
            int rowHeight = dataGridView6.RowTemplate.Height;
            int columnWidth = 80;

            // Set the starting x and y coordinates
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            // Draw the column headers
            for (int i = 0; i < dataGridView6.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView6.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                x += columnWidth;

                // Draw a line after each column except for the last column
                if (i != dataGridView6.Columns.Count - 1)
                {
                    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
            }

            // Draw a line below the column headers
            y += rowHeight;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(Pens.Black, x, y, x + (dataGridView2.Columns.Count * columnWidth), y);

            // Draw the data
            for (int i = 0; i < dataGridView6.Rows.Count; i++)
            {
                x = e.MarginBounds.Left;
                y += rowHeight;

                // Draw the row data
                for (int j = 0; j < dataGridView6.Columns.Count; j++)
                {
                    e.Graphics.DrawString(dataGridView6.Rows[i].Cells[j].FormattedValue.ToString(), new Font("Arial", 12), Brushes.Black, new RectangleF(x, y, columnWidth, rowHeight));
                    x += columnWidth;

                    // Draw a line after each column except for the last column
                    if (j != dataGridView6.Columns.Count - 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                    }
                }

                // Draw a line below the row
                e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, y, e.MarginBounds.Left + (dataGridView1.Columns.Count * columnWidth), y);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to get the path of the .csv file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // The path of the .csv file
                string filePath = ofd.FileName;

                // Create a new DataTable
                DataTable dt = new DataTable();

                // Read the contents of the .csv file into the DataTable
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                // Assign the DataTable as the DataSource for the DataGridView
                dataGridView6.DataSource = dt;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {   // Create a new instance of Graph
            Graph Graph = new Graph();

            // Ensure that chart1 has a Series to add data to
            if (Graph.chart1.Series.Count == 0)
            {
                Graph.chart1.Series.Add("Series1");
            }

            // Set the chart type to Bar
            Graph.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            Graph.chart1.ChartAreas[0].AxisX.Title = "Nume";
            Graph.chart1.ChartAreas[0].AxisY.Title = "Frequency";

            string query = "SELECT Nume, Adresa FROM client";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            Dictionary<string, Dictionary<string, int>> frequencyDict = new Dictionary<string, Dictionary<string, int>>();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nume = reader[0].ToString();
                    string adresa = reader[1].ToString();

                    if (frequencyDict.ContainsKey(adresa))
                    {
                        if (frequencyDict[adresa].ContainsKey(nume))
                        {
                            frequencyDict[adresa][nume]++;
                        }
                        else
                        {
                            frequencyDict[adresa].Add(nume, 1);
                        }
                    }
                    else
                    {
                        frequencyDict.Add(adresa, new Dictionary<string, int>() { { nume, 1 } });
                    }
                }

                reader.Close();

                int index = 0;
                foreach (var adresa in frequencyDict.Keys)
                {
                    foreach (var nume in frequencyDict[adresa].Keys)
                    {
                        Graph.chart1.Series["Series1"].Points.AddXY(nume + " (" + adresa + ")", frequencyDict[adresa][nume]);
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }

            conn.Close();
            Graph.Show();

        }

      
    }
}
    

