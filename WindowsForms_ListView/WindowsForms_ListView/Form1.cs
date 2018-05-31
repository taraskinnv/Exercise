using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            listView1.Columns.Add("Data");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ComboBox comboBox2 = sender as ComboBox;
            Show(comboBox2.Text);
        }

        private void Show(string path)
        {
            listView1.Items.Clear();
            string[] dirs = Directory.GetDirectories(path);
            // перебор полученных файлов
            foreach (string dir in dirs)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                if ((directoryInfo.Attributes == FileAttributes.Directory))
                {
                    string[] str = { directoryInfo.Name, "", "dir", directoryInfo.LastWriteTime.ToShortDateString() + " " + directoryInfo.LastWriteTime.ToShortTimeString() };
                    ListViewItem lvi = new ListViewItem(str);
                    lvi.Tag = directoryInfo.FullName;
                    listView1.Items.Add(lvi);
                }
            }

            string[] files = Directory.GetFiles(path);
            // перебор полученных файлов
            foreach (string file in files)
            {
                FileInfo f = new FileInfo(file);
                string[] str = { f.Name, (f.Length).ToString(), f.Extension, f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString() };
                ListViewItem lvi = new ListViewItem(str);
                lvi.Tag = f.FullName;
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListView v = (ListView)sender;
            DirectoryInfo directory = new DirectoryInfo(v.SelectedItems[0].Tag.ToString());
            if (directory.Attributes == FileAttributes.Directory)
            {
                Show(v.SelectedItems[0].Tag.ToString());
            }
            else
            {
                Process.Start(v.SelectedItems[0].Tag.ToString());
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            //ListView v = new ListView();
            //v = (ListView)sender;
            //DirectoryInfo directory = new DirectoryInfo(v.SelectedItems[0].Tag.ToString());
            //if (directory.Attributes == FileAttributes.Directory)
            //{
            //    Show(v.SelectedItems[0].Tag.ToString());
            //}
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            ListView v = new ListView();
            v = (ListView)sender;
            var str = v.SelectedItems[0].Tag;
            
            if (e.KeyCode == Keys.Delete)
            {
                DirectoryInfo directory = new DirectoryInfo(v.SelectedItems[0].Tag.ToString());
                var v1 = directory.Parent;
                if (directory.Attributes == FileAttributes.Directory)
                {
                    Directory.Delete(v.SelectedItems[0].Tag.ToString(), true);
                }
                else
                {
                    File.Delete(v.SelectedItems[0].Tag.ToString());
                }
                Show(v1.FullName);
            }
            else if (e.KeyCode == Keys.Back)
            {
                DirectoryInfo directory = new DirectoryInfo(str.ToString());
                var v1 = directory.Parent.Parent;
                Show(v1.FullName);
            }
        }
    }
}
