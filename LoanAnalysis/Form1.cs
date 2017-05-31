using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Item item = new Item();

            item.Name = "Item 1";
            item.subItems = new List<SubItem>() { new SubItem("SubItem1.1"), new SubItem("SubItem1.2") };

            TreeNode parent = new TreeNode("Parent");
            TreeNode child1 = new TreeNode("Child1");
            
            TreeNode child1_1 = new TreeNode("Child1_1");
            TreeNode child2 = new TreeNode("Child2");
            
            TreeNode child3 = new TreeNode("Child3");

            child1.Nodes.Add(child1_1);
            child1.ContextMenuStrip = contextMenuStrip1;

            parent.Nodes.Add(child1);
            parent.Nodes.Add(child2);
            parent.Nodes.Add(child3);

            treeView1.Nodes.Add(parent);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if(e.Clicks == 1 && e.Button == MouseButtons.Right)
            //{
            //    Point p = new Point(e.X, e.Y);
            //    contextMenuStrip1.Show(this,p);
            //}
        }
    }

    class Item
    {
        public Item() { }

        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<SubItem> subItems { get; set; }
    }

    class SubItem
    {
        public string Name { get; set; }
        public SubItem(string name)
        {
            Name = name;
        }
        public SubItem() { }
    }
}
