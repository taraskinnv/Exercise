using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translate
{
    public partial class Form1 : Form
    {
        
        DataClasses1DataContext context;
        Ping pin = new Ping();
        public Form1()
        {
            InitializeComponent();

            //--------------------------------------------------------------------------
            // Проверка наличия интернета
            IPStatus status = IPStatus.Unknown;
            PingReply pingReply = null;
            try
            {
                pingReply = pin.Send("www.google.com");
                textBox2.Text = pingReply.Address.ToString();
                status = pingReply.Status;
            }
            catch (Exception) { }

            if (status != IPStatus.Success)
            {
                MessageBox.Show("Please connect internet");
                this.Close();
            }
            //----------------------------------------------------------------------------
            //наличие ID proc в базе
            context = new DataClasses1DataContext();

            string str_proc = null;
            var get_proc = context.Search_id_processor(GetID());
            foreach (var i in get_proc)
            {
                str_proc = i.id_processor;
            }

            if (str_proc != GetID())
            {
                //оплата
                MessageBox.Show("aaaaaaaaaaaaaaaaaaaaaa");
                //this.Close();
                context.Add_id_processor(GetID(), "qwerty");

            }
            //--------------------------------------------------------------------------------
            //textBox2.Text = GetID();
            if (Status() == 1)
            {
                //textBox1.Text = ReadOnlyAttribute.
                //textBox1.ReadOnly = ReadOnlyAttribute.Yes;
                //textBox3.ReadOnly = true;
            }
        }

        int number = 0;

        



        private static string GetID()  //получение ID proc
        {
            string str = "";
            ManagementClass mng = new ManagementClass("win32_processor");
            ManagementObjectCollection collect = mng.GetInstances();
            foreach (ManagementObject obj in collect)
            {
                str = obj.Properties["processorID"].Value.ToString();
            }
                return str;
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            //context.Add_id_processor(GetID(),"qwerty"); //для проверки своего ПК
            dataGridView1.Columns.Add("word", "word");
            dataGridView1.Columns.Add("translate", "translate");
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ReadOnly = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)            ////disable sort in DataGridView1
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var loc = context.Locate_language;
            foreach (var i in loc)
            {
                comboBox1.Items.Add(i.languag);
                comboBox2.Items.Add(i.languag);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }


        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        List<string> list3 = new List<string>();
        OpenFileDialog open;
        string str_finish;
        public string TranslateText(string input, string text, string output) //перевод google
        {
            string url = String.Format("http://www.google.com/translate_t?hl={0}&ie=UTF8&text={1}&langpair={2}", input, text, output);
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString(url);
            result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
            result = result.Substring(result.IndexOf(">") + 1);
            result = result.Substring(0, result.IndexOf("</span>"));
            return result.Trim();
        }

        private void button1_Click(object sender, EventArgs e) // Open file
        {

            list2.Clear();
            open = new OpenFileDialog();
            while (dataGridView1.RowCount != 1)     //очистка dataGridView1
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader fs = new StreamReader(open.FileName);
                StreamReader fs1 = new StreamReader(open.FileName);
                str_finish = fs1.ReadToEnd();
                string str;
                do
                {
                    str = fs.ReadLine();
                    if (str == null)
                        break;
                    if (str.IndexOf("msgid \"") != -1 && str.Length > 8)
                    {
                        str = str.Substring(str.IndexOf("msgid \"") + ("msgid \"").Length);
                        str = str.Substring(0, str.Length - 1);
                        if (str != null)
                        {
                            list2.Add(str);
                        }
                    }
                    if (str.IndexOf("msgctxt \"") != -1 && str.Length > 10)
                    {
                        str = str.Substring(str.IndexOf("msgctxt \"") + "msgctxt \"".Length);
                        str = str.Substring(0, str.Length - 1);
                        if (str != null)
                        {
                            list2.Add(str);
                        }
                    }
                } while (str != null);

                IEnumerable<string> lll = list2.Distinct(); //убираю повторяющиеся слова
                foreach (var i in lll)
                {
                    dataGridView1.Rows.Add(i, "");
                }
                list2.Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // событие на изменение datagrid
        {
            if (e.ColumnIndex == 0)
            {
                context = new DataClasses1DataContext();

                var id = context.Word_search_id(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                int i1 = -1;
                foreach (var i in id)
                {
                    i1 = i.id;
                }
                if (i1 != -1)
                {
                    var mas = context.Word_tr(i1, comboBox1.Text);
                    foreach (var i in mas)
                    {
                        list.Add(i.word_slovo);
                    }
                }

                list.Add(TranslateText(comboBox1.Text, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), comboBox2.Text));


                IEnumerable<string> list_b = list.Distinct();  //убираю повторяющиеся слова
                foreach (var i in list_b)
                {
                    list3.Add(i);
                }


                listBox1.DataSource = null;
                listBox1.DataSource = list3;
                listBox1.DisplayMember = "list3";
                list3.Clear();
                list.Clear();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else
            {
                list.Clear();
                list3.Clear();
                listBox1.DataSource = null;
                listBox1.DataSource = list3;
                listBox1.DisplayMember = "list3";
            }
        }

        private void listBox1_Click(object sender, EventArgs e) //отобоажение для своего варианта
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)    //добовление своего варианта  в dataGridView1
        {
            try
            {
                if (number<1 && Status() == 1)
                {
                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                    dataGridView1.Rows[rowindex].Cells[columnindex + 1].Value = textBox1.Text;
                    number++;
                }
                else
                {
                    MessageBox.Show("Trial");
                }
            }
            catch (Exception) { }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)   //добовление c listBox1 в dataGridView1
        {
            try
            {
                if (number < 1 && Status() == 1)
                {
                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                    dataGridView1.Rows[rowindex].Cells[columnindex + 1].Value = listBox1.SelectedItem.ToString();
                    number++;
                }
                else
                {
                    MessageBox.Show("Trial");
                }
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)                  // Save file
        {

            if (Status() == 1)
            {
                MessageBox.Show("Trial");
                return;
            }

            textBox2.Text = dataGridView1.RowCount.ToString();


            //for (int i = 1; i < dataGridView1.RowCount; i++)        //проверка что все поля заполнены
            //{
            //    try
            //    {
            //        if (dataGridView1[1, i].Value.ToString() == "")
            //        {
            //            MessageBox.Show("Жопа");
            //            return;
            //        }
            //    }
            //    catch (Exception ex) { }
            //}


            for (int i = 0; i < 1/*dataGridView1.RowCount*/; i++)
            {
                str_finish = str_finish.Replace(dataGridView1[0, i].Value.ToString(), dataGridView1[1, i].Value.ToString());
            }
            SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //-----------------------------------------------------------------------------------------------
                    for (int i = 0; i < 1; i++) // проверка или добавление word в базу
                    {
                        Add_word_base(0, i, comboBox2.Text);
                        Add_word_base(1, i, comboBox1.Text);
                    }


                    // поиск Translate.id
                    int id_w1 = -1;
                    var id_word1 = context.Word_search_id(dataGridView1[0, 0].Value.ToString());
                    foreach (var i in id_word1)
                    {
                        id_w1 = i.id;
                    }

                    int id_w2 = -1;
                    var id_translate1 = context.Word_search_id(dataGridView1[1, 0].Value.ToString());
                    foreach (var i in id_translate1)
                    {
                        id_w2 = i.id;
                    }

                    var id_t = context.search_trans_id(comboBox1.Text, id_w1, id_w2);
                    int id_trans = -1;
                    foreach (var i in id_t)
                    {
                        id_trans = i.id;
                    }

                    if (id_trans == -1)
                    {
                        var loc1 = context.language_id(comboBox1.Text); //определение language_id
                        int loc = -1;
                        foreach (var l in loc1)
                        {
                            loc = l.id;
                        }
                        context.Add_transl(loc, id_w1, id_w2);    //добавление translate_word в базу
                    }
                    else
                    {
                        context.Add_count_trans(id_trans);
                    }

                    FileStream fs_write = new FileStream(save.FileName + ".pot", FileMode.Create);
                    StreamWriter streamWriter = new StreamWriter(fs_write);
                    streamWriter.Write(str_finish);
                    streamWriter.Close();
                

            }
        }

        private void Add_word_base(int col, int row, string combobox)        //добавление слов в word
        {
            int id = -1;
            var id_word = context.Word_search_id(dataGridView1[col, row].Value.ToString());
            foreach (var i in id_word)
            {
                id = i.id;
            }

            if (id == -1)
            {
                var loc1 = context.language_id(combobox); //определение language_id
                int loc = -1;
                foreach (var l in loc1)
                {
                    loc = l.id;
                }
                context.Add_word(dataGridView1[col, row].Value.ToString(), loc);    //добавление слова в базу
            }
        }

        private int Status()
        {
            int status = 0;
            var get_proc = context.Search_status(GetID());
            foreach (var i in get_proc)
            {
                status = i.status_id;
            }
            return status;


        }
    }
}
