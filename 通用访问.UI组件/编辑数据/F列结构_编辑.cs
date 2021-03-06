﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using 通用访问.DTO;

namespace 通用访问.UI组件.编辑数据
{
    public partial class F列结构_编辑 : Form
    {
        private M元数据 _元数据;

        public string _值;

        public F列结构_编辑(M元数据 __元数据, string __值, string __标题 = "")
        {
            _元数据 = __元数据;
            _值 = __值;
            InitializeComponent();
            this.out标题.Text = __标题;
            this.Text = __标题;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_元数据 != null)
            {
                this.out范围.Text = _元数据.范围;
                this.out类型.Text = _元数据.类型;
                this.out描述.Text = _元数据.描述;
                this.out默认值.Text = _元数据.默认值;
            }
            else
            {
                this.splitContainer1.Panel2Collapsed = true;
            }

            try
            {
                if (!string.IsNullOrEmpty(_值))
                {
                    JArray arr = JArray.Parse(_值);
                    foreach (JValue __值 in arr)
                    {
                        this.out值.Rows.Add(__值.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("值格式错误");
            }
            this.do确定.Click += do确定_Click;
        }

        void do确定_Click(object sender, EventArgs e)
        {
            var __sw = new StringWriter();
            JsonWriter __writer = new JsonTextWriter(__sw);
            __writer.WriteStartArray();
            foreach (DataGridViewRow __行 in this.out值.Rows)
            {
                if (!__行.IsNewRow)
                {
                    var __value = __行.Cells[0].Value == null ? "" : __行.Cells[0].Value.ToString();
                    if (_元数据 != null)
                    {
                        switch (_元数据.类型)
                        {
                            case "string":
                            case "字符串":
                                __writer.WriteValue(__value);
                                break;
                            default:
                                __writer.WriteRawValue(__value);
                                break;
                        }
                    }
                    else
                    {
                        __writer.WriteRawValue(__value);
                    }
                }
            }
            __writer.WriteEndArray();
            __writer.Flush();
            _值 = __sw.GetStringBuilder().ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
