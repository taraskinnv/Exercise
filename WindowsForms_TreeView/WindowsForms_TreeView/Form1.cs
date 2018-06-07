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

namespace WindowsForms_TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillDriveNodes();
        }

        private void FillDriveNodes()
        {
            treeView1.Nodes.Clear();
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    FillTreeNode(driveNode, drive.Name);
                    treeView1.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex) { }
        }

        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception ex) { }
        }


        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    var dirs = Directory.GetDirectories(e.Node.FullPath);
                    var files = Directory.GetFiles(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        foreach (var v in dirs)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(v).Name);
                            FillTreeNode(dirNode, v);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                    if (files.Length != 0)
                    {
                        foreach (var v in files)
                        {
                            TreeNode fileNode = new TreeNode(new DirectoryInfo(v).Name);
                            FillTreeNode(fileNode, v);
                            e.Node.Nodes.Add(fileNode);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {

            Process.Start(treeView1.SelectedNode.FullPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(treeView1.SelectedNode.FullPath);
            if (file.Attributes == FileAttributes.Directory)
            {
                file.MoveTo(treeView1.SelectedNode.FullPath.Remove(treeView1.SelectedNode.FullPath.LastIndexOf("\\") + 1) + textBox1.Text);
            }
            else if (treeView1.SelectedNode.Text.IndexOf(file.Extension) == -1)
            {
                file.MoveTo(treeView1.SelectedNode.FullPath.Remove(treeView1.SelectedNode.FullPath.LastIndexOf("\\") + 1) + textBox1.Text + file.Extension);
            }
            else
            {
                file.MoveTo(treeView1.SelectedNode.FullPath.Remove(treeView1.SelectedNode.FullPath.LastIndexOf("\\") + 1) + textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            if (dir.Attributes == FileAttributes.Directory)
            {
                Directory.Delete(treeView1.SelectedNode.FullPath, true);
            }
            else
            {
                FileInfo file = new FileInfo(treeView1.SelectedNode.FullPath);
                file.Delete();
            }
        }



    }
}

        