using DragonBlazeAuto.AndroidCommunity;
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

namespace DragonBlazeAuto
{
    public partial class MainForm : Form
    {
        ACControler AdbInteract = new ACControler();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           AdbInteract.Tap(new Point());

        }

       

    }
}
