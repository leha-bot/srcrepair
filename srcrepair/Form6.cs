﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace srcrepair
{
    public partial class frmFPGen : Form
    {
        private CFGEdDelegate CETableAdd;

        public frmFPGen(CFGEdDelegate sender)
        {
            InitializeComponent();
            CETableAdd = sender;
        }

        private void GenerateCFG_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
