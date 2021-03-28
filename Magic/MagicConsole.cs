using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic
{
    public partial class MagicConsole : Form
    {
        public MagicConsole()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            FillConsole();
        }


        private void FillConsole()
        {
            magiclist.Items.Add(new ListViewItem(new string[] { $"" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"> access Someren security grid" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"access: PERMISSION DENIED. " }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"> access Someren security grid" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"access: PERMISSION DENIED. " }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"> access Someren security grid" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"acces: PERMISSION DENIED...and....." }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
            magiclist.Items.Add(new ListViewItem(new string[] { $"YOU DIDN't SAY THE MAGIC WORD!" }));
        }



    }
}
