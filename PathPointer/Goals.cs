﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathPointer
{
    public partial class Goals : Form
    {
        public Goals()
        {
            InitializeComponent();
        }

        private void Goals_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuManagement.HideForm(this, e);
        }

        private void Goals_Load(object sender, EventArgs e)
        {
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = MainMenu.CreateInstance(this);
        }
    }
}
