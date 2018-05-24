using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //comboBox1.Items.IsReadOnly;
        }

        private void FillDriveNodes()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                comboBox1.Items.Add(drive.Name);
            }
            comboBox1.SelectedIndex = 0;
            listView1.View = View.Details;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Size");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Izm");
            //Show(comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ComboBox comboBox2 = sender as ComboBox;
            Show(comboBox2.Text);
        }

        private void Show(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            // перебор полученных файлов
            foreach (string dir in dirs)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                if ((directoryInfo.Attributes == FileAttributes.Directory))
                {
                    string[] str = { directoryInfo.Name, "", "dir" };
                    //ListViewItem lvi = new ListViewItem();
                    //lvi.Text = dir;
                    // добавляем элемент в ListView
                    //listView1.Items.Add(lvi);
                    //lvi.SubItems.Add(lvi.ToString());
                    listView1.Items.Add(new ListViewItem(str));
                }
            }

            string[] files = Directory.GetFiles(path);
            // перебор полученных файлов
            foreach (string file in files)
            {
                FileInfo f = new FileInfo(file);
                string[] str = { f.Name, (f.Length).ToString() };
                // добавляем элемент в ListView
                //listView1.Items.Add(lvi);
                listView1.Items.Add(new ListViewItem(str));
            }
            //listView1.Columns.Add(lvi);
        }
    }
}
