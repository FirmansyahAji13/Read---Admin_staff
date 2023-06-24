using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace JT_APPS__Final_Setting_
{
    public partial class staff : Form
    {
        private const string connectionString = "Server=localhost; Port=5432; Database=JT-Apps; User Id=postgres; Password=timotius";
        public staff()
        {
            InitializeComponent();
            LoadDataToDataGridView();
        }
        private void LoadDataToDataGridView()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand comm = new NpgsqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT * FROM staff";
                    NpgsqlDataReader dataReader = comm.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dataReader);
                        dataGridView1.DataSource = dt;
                    }

                    dataReader.Close();
                }
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGanti_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apakah anda yakin ingin mengganti sandi?", "Ubah Sandi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
