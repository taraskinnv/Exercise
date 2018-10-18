using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_test
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            //form2 = new Form2(this);
            //form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("ТМЦ", "ТМЦ");
            dataGridView1.Columns.Add("Кол-во", "Кол-во");
            dataGridView1.Columns.Add("№ довер", "№ довер");
            dataGridView1.Columns.Add("Дата выдачи", "Дата выдачи");
            dataGridView1.Columns.Add("Действительна до", "Действительна до");
            dataGridView1.Columns[0].Width = 300;
            
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ReadOnly = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)            ////disable sort in DataGridView1
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            List<Document> doc = new List<Document>();
            doc.Add(new Document());
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
