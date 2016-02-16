﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.WindowsForm
{
    public partial class F空窗口 : FormK
    {
        public bool 允许最大化
        {
            get { return this.u窗体头1.显示最大化按钮; }
            set { this.u窗体头1.显示最大化按钮 = value; }
        }

        public bool 允许最小化
        {
            get { return this.u窗体头1.显示最小化按钮; }
            set { this.u窗体头1.显示最小化按钮 = value; }
        }

        public bool 允许缩放
        {
            get { return this.u窗体脚1.Visible; }
            set { this.u窗体脚1.Visible = value; }
        }

        public bool 允许设置
        {
            get { return this.u窗体头1.显示设置按钮; }
            set { this.u窗体头1.显示设置按钮 = value; }
        }

        public F空窗口(Control __控件, string __标题)
        {
            InitializeComponent();
            this.Width = __控件.Width + 25;
            this.Height = __控件.Height + 66;
            __控件.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(__控件);

            this.u窗体头1.标题 = __标题;
            this.Text = __标题;

            this.u窗体头1.点击设置 += On点击设置;
        }

        public event Action 点击设置;

        protected virtual void On点击设置()
        {
            var handler = 点击设置;
            if (handler != null) handler();
        }
    }
}
