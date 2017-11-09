using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TXT
{
	public partial class Form2 : Form
	{
		public RichTextBox richtextbox;
		public int start = 0;
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			richtextbox.SelectionColor = Color.Blue;
			string str;
			str = textBox1.Text;
			if (checkBox1.Checked)
			{
				if (radioButton2.Checked)
				{
					checkUp(str);
				}
				else
				{
					checkDown(str);
				}
			}
			else
			{
				if (radioButton2.Checked)
				{
					uncheckUp(str);
				}
				else
				{
					uncheckDown(str);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void checkDown(string ss)
		{
			int c = 0;
			int b = 0;
			try
			{
				c = richtextbox.SelectionStart;
				b = richtextbox.Text.IndexOf(ss, c + ss.Length, StringComparison.CurrentCulture);
				richtextbox.SelectionStart = b;
				richtextbox.SelectionLength = ss.Length;
				richtextbox.SelectionColor = Color.Red;
			}
			catch
			{
				MessageBox.Show("已查找到文档的结尾", "查找结束对话框",
					MessageBoxButtons.OK);
				richtextbox.SelectionStart = c;
				richtextbox.SelectionLength = ss.Length;
			}
		}
		public void checkUp(string ss)
		{
			int c = 0;
			int b = 0;
			try
			{
				c = richtextbox.SelectionStart;
				b = richtextbox.Text.LastIndexOf(ss, c - ss.Length, StringComparison.InvariantCulture);
				richtextbox.SelectionStart = b;
				richtextbox.SelectionLength = ss.Length;
				richtextbox.SelectionColor = Color.Red;
			}
			catch
			{
				MessageBox.Show("已查找到文档的开始","查找结束对话框",
					MessageBoxButtons.OK);
				textBox1.SelectionStart = c;
				textBox1.SelectionLength = ss.Length;
			}
		}

		public void uncheckDown(string ss)
		{
			int c = 0;
			int b = 0;
			try
			{
				c = richtextbox.SelectionStart;
				b = richtextbox.Text.IndexOf("ss", c + ss.Length, StringComparison.CurrentCultureIgnoreCase);
				richtextbox.SelectionStart = b;
				richtextbox.SelectionLength = ss.Length;
				richtextbox.SelectionColor = Color.Red;
			}
			catch
			{
				MessageBox.Show("已查找到文档的结尾", "查找结束对话框", MessageBoxButtons.OK);
				textBox1.SelectionStart = c;
				textBox1.SelectionLength = ss.Length;
			}
		}

		public void uncheckUp(string ss)
		{
			int c = 0;
			int b = 0;
			try
			{
				c = richtextbox.SelectionStart;
				b = richtextbox.Text.LastIndexOf(ss, c - ss.Length, StringComparison.InvariantCultureIgnoreCase);
				richtextbox.SelectionStart = b;
				richtextbox.SelectionLength = ss.Length;
				richtextbox.SelectionColor = Color.Red;
			}
			catch
			{
				MessageBox.Show("已经查找到文档的开头", "查找结束对话框", MessageBoxButtons.OK);
				textBox1.SelectionStart = c;
				textBox1.SelectionLength = ss.Length;
			}
		}
	}
}
