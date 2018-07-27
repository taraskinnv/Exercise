using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading;

namespace On_Off_NetAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // делаем невидимой нашу иконку в трее
            notifyIcon1.Visible = false;
            // добавляем Эвент или событие по 2му клику мышки, 
            //вызывая функцию  notifyIcon1_MouseDoubleClick
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);

            // добавляем событие на изменение окна
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon1.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetNetworkAdapter();
        }

        private void GetNetworkAdapter()        // get all adapter
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject adapter in searchProcedure.Get())
            {
                try
                {
                    comboBox1.Items.Add(adapter["NetConnectionId"].ToString());
                    comboBox2.Items.Add(adapter["NetConnectionId"].ToString());
                }
                catch (Exception)
                {
                    comboBox1.Items.Add("No connections");
                    comboBox2.Items.Add("No connections");
                    comboBox2.Items.Add("No connections");
                }
            }
            try
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 2;
            }
            catch (Exception ex){ }
        }

        private void OnAdapterObj(object NameAdapter)      // On adapter 
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (((string)item["NetConnectionId"]) == (string)NameAdapter)
                {
                    item.InvokeMethod("Enable", null);
                    break;
                }
            }
        }

        private void OffAdapterObj(object NameAdapter)     // Off adapter
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (((string)item["NetConnectionId"]) == (string)NameAdapter)
                {
                    item.InvokeMethod("Disable", null);
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  // direct switching
        {
            ComboboxAndButton(false);
            Thread myThread1 = new Thread(new ParameterizedThreadStart(OffAdapterObj));
            myThread1.Start(comboBox1.SelectedItem.ToString());
            while (myThread1.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            if (myThread1.ThreadState == ThreadState.Stopped)
            {
                Thread myThread2 = new Thread(new ParameterizedThreadStart(OnAdapterObj));
                myThread2.Start(comboBox2.SelectedItem.ToString());
                while (myThread2.ThreadState == ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
            }
            ComboboxAndButton(true);
        }

        private void button2_Click(object sender, EventArgs e)  //reverse switching
        {
            ComboboxAndButton(false);
            Thread myThread1 = new Thread(new ParameterizedThreadStart(OffAdapterObj));
            myThread1.Start(comboBox2.SelectedItem.ToString());
            while (myThread1.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            if (myThread1.ThreadState == ThreadState.Stopped)
            {
                Thread myThread2 = new Thread(new ParameterizedThreadStart(OnAdapterObj));
                myThread2.Start(comboBox1.SelectedItem.ToString());
                while (myThread2.ThreadState == ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                ComboboxAndButton(true);
            }
        }

        private void ComboboxAndButton(bool z)
        {
                comboBox1.Enabled = z;
                comboBox2.Enabled = z;
                button1.Enabled = z;
                button2.Enabled = z;
        }
    }
}