﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Utility.WindowsForm;
using Utility.存储;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 通用访问.UI组件
{
    public partial class F对象列表窗口 : FormK
    {

        public F对象列表窗口(IPEndPoint __地址, string __名称 = "")
        {
            InitializeComponent();

            __名称 = string.IsNullOrEmpty(__名称) ? __地址.ToString() : __名称;
            this.out标题.Text = __名称;
            this.Text = __名称;
            this.f对象列表1.地址 = __地址;
            this.f对象列表1.名称 = __名称;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}
