﻿using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Krisiun_Project.Janelas
{
    public partial class KouguForm : Form
    {
        private DataTable dataTable;

        public KouguForm()
        {
            InitializeComponent();
            LoadCsvToDataGridView("kougu.csv");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
        }

        private void KouguForm_Load(object sender, EventArgs e)
        {
         }

        private void LoadCsvToDataGridView(string filePath)
        {
            dataTable = new DataTable();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            using (StreamReader sr = new StreamReader(Path.Combine(dir, filePath)))
            {
                string[] headers = sr.ReadLine().Split(',');

                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dataTable.Rows.Add(dr);
                }
            }
        }

        private void SaveCsvFromDataGridView(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string[] columnNames = new string[dataTable.Columns.Count];
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                columnNames[i] = dataTable.Columns[i].ColumnName;
            }
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dataTable.Rows)
            {
                string[] fields = new string[dataTable.Columns.Count];
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    fields[i] = row[i].ToString();
                }
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(Path.Combine(dir, filePath), sb.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCsvFromDataGridView("testekougu.csv");
        }
    }
}
