﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NextTask
{
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            base.OnFormClosed(e);
        }

        private void addProject_Click(object sender, EventArgs e)
        {

        }
    }
}
