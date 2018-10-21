using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_test
{
    public partial class Form1 : Form
    {
        Form2 form2;
        Form2 f2;
        List<Document> doc;
        public Form1()
        {
            InitializeComponent();
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
            doc = new List<Document>();
            DateTimePicker datatimepic = new DateTimePicker();
            doc.Add(new Document("1 Дизель л 100", "10.06.2018", "31.10.2018", "1", "19.10.2018", "Иванов Иван Иванович", "Passport", "АА", "123456", "19.10.2000", "РВ УМВС", "Албатрос", "as123", 100));
            doc.Add(new Document("2 Дизель1 л 50", "10.10.2018", "30.11.2018", "2", "19.10.2018", "Иванов Иван Иванович", "Passport", "АB", "321654", "01.01.1978", "РВ УМВС", "Албатрос", "as123", 50));
            doc.Add(new Document("3 Дизель2 л 1000", "10.10.2018", "31.10.2018", "3", "19.10.2018", "Иванов Иван Иванович", "Passport", "АH", "000001", "07.07.1963", "РВ УМВС", "Албатрос", "as123", 1000));
            UpdateDateG();

            string str;
            foreach (var item in doc)
            {
                DateTime date = DateTime.ParseExact(item.Valid_until, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                //date = date.AddDays(1);
                TimeSpan timeSpan = DateTime.Now - date;

                str = timeSpan.Days.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;
            f2 = new Form2(doc, a, false);
            f2.ShowDialog();
            UpdateDateG();


        }

        private void UpdateDateG()
        {
            while (dataGridView1.RowCount != 1)     //очистка dataGridView1
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            foreach (Document item in doc)
            {
                dataGridView1.Rows.Add(item.TMV, item.Amount, item.Document_Number, item.Date_of_issue, item.Valid_until);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.RowCount;
            f2 = new Form2(doc, a, true);
            f2.ShowDialog();
            UpdateDateG();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doc.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            UpdateDateG();
        }
    }
}
