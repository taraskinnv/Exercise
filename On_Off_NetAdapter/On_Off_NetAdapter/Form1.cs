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

namespace On_Off_NetAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetNetworkAdapter();
        }


        private void GetNetworkAdapter()
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
                        //comboBox1.Items.Add("Нет подключений");
                    }
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (((string)item["NetConnectionId"]) == "Подключение по локальной сети")
                {
                    item.InvokeMethod("Disable", null);
                }
                if (((string)item["NetConnectionId"]) == "Подключение по локальной сети 3")
                {
                    item.InvokeMethod("Enable", null);
                }
            }

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (((string)item["NetConnectionId"]) == "Подключение по локальной сети")
                {
                    item.InvokeMethod("Enable", null);
                }
                if (((string)item["NetConnectionId"]) == "Подключение по локальной сети 3")
                {
                    item.InvokeMethod("Disable", null);
                }
            }
        }
    }
}