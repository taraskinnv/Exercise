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
                comboBox2.SelectedIndex = 1;
            }
            catch (Exception ex){ }
        }

        private void OnAdapter(string NameAdapter)      // On adapter
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (((string)item["NetConnectionId"]) == NameAdapter)
                {
                    item.InvokeMethod("Enable", null);
                    break;
                }
            }
        }

        private void OffAdapter(string NameAdapter)     // Off adapter
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (((string)item["NetConnectionId"]) == NameAdapter)
                {
                    item.InvokeMethod("Disable", null);
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  // direct switching
        {
            OffAdapter(comboBox1.SelectedItem.ToString());
            OnAdapter(comboBox2.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)  //reverse switching
        {
            OffAdapter(comboBox2.SelectedItem.ToString());
            OnAdapter(comboBox1.SelectedItem.ToString());
        }
    }
}