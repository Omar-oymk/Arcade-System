﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectt
{
    public partial class RealLife : Form
    {
        public RealLife()
        {
            InitializeComponent();
            this.FormClosed += (s, args) => Application.Exit();     // add that if this form is closed then close the whole app
        }
    }
}
