using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Zadanie_test
{
    public partial class Form2 : Form
    {
        List<Document> doc2;
        int number;
        bool q;
        public Form2(List<Document> l, int number, bool q)
        {
            InitializeComponent();
            doc2 = l;
            this.number = number;
            this.q = q;
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;// доделать с нормальной формой и нормальмым заполнением
            if (q== false)
            {
                textBox11.Text = doc2[number].TMV;
                textBox6.Text = doc2[number].Document_Number;
                textBox4.Text = doc2[number].Issued_to;
                textBox9.Text = doc2[number].Organization;
                textBox10.Text = doc2[number].Contract;
                textBox5.Text = doc2[number].Doc_series;
                textBox7.Text = doc2[number].Doc_Number;
                textBox8.Text = doc2[number].Issued_by;
                textBox12.Text = doc2[number].Amount.ToString();


                string format ="dd.MM.yyyy";
                dateTimePicker1.CustomFormat = format;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.Value = DateTime.ParseExact(doc2[number].Date_of_issue, format, CultureInfo.InvariantCulture);
                dateTimePicker2.CustomFormat = format;
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.Value = DateTime.ParseExact(doc2[number].Valid_until, format, CultureInfo.InvariantCulture);
                dateTimePicker3.CustomFormat = format;
                dateTimePicker3.Format = DateTimePickerFormat.Custom;
                dateTimePicker3.Value = DateTime.ParseExact(doc2[number].Document_Date, format, CultureInfo.InvariantCulture);
                dateTimePicker4.CustomFormat = format;
                dateTimePicker4.Format = DateTimePickerFormat.Custom;
                dateTimePicker4.Value = DateTime.ParseExact(doc2[number].Date_his_issue, format, CultureInfo.InvariantCulture);

                comboBox1.Items.Add(doc2[number].Type_of_identity_Doc);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (q != false)
            {
                doc2.Add(new Document(textBox11.Text, dateTimePicker1.Value.ToShortDateString(),
                    dateTimePicker2.Value.ToShortDateString(), textBox6.Text, dateTimePicker3.Value.ToShortDateString(),
                    textBox4.Text, comboBox1.Text, textBox5.Text, textBox7.Text, dateTimePicker1.Value.ToShortDateString(),
                    textBox8.Text, textBox9.Text, textBox10.Text,Int32.Parse(textBox12.Text)));
            }
            else
            {
                doc2[number].TMV = textBox11.Text;
                doc2[number].Document_Number  = textBox6.Text;
                doc2[number].Issued_to = textBox4.Text;
                doc2[number].Organization = textBox9.Text;
                doc2[number].Contract = textBox10.Text;
                doc2[number].Doc_series = textBox5.Text;
                doc2[number].Doc_Number = textBox7.Text;
                doc2[number].Issued_by = textBox8.Text;

                doc2[number].Date_of_issue = dateTimePicker1.Value.ToShortDateString();
                doc2[number].Valid_until = dateTimePicker2.Value.ToShortDateString();
                doc2[number].Document_Date = dateTimePicker3.Value.ToShortDateString();
                doc2[number].Date_his_issue = dateTimePicker4.Value.ToShortDateString();

                doc2[number].Type_of_identity_Doc = comboBox1.Text;
            }
            this.Close();
        }
    }
}
