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
	public partial class Form3 : Form
	{
		public int start = 0;
		private RichTextBox richText;
		public Form3(RichTextBox rtb)
		{
			InitializeComponent();
			richText = rtb;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string str1;
			str1 = textBox1.Text.Trim();
			richText.SelectionColor = Color.Blue;
			start = richText.Find(str1, start, RichTextBoxFinds.MatchCase);
			if(start == -1)
			{
				MessageBox.Show("已查找到文档的结尾", "查找结束对话框",
					MessageBoxButtons.OK);
				start = 0;
			}
			else
			{
				start += str1.Length;
			}
			richText.SelectionColor = Color.Red;
			richText.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string str1, str2;
			str1 = textBox1.Text;
			str2 = textBox2.Text;
			richText.SelectionColor = Color.Blue;
			start = richText.Find(str1, start, RichTextBoxFinds.MatchCase);
			if(start == -1)
			{
				MessageBox.Show("已替换到文档的结尾", "替换结束对话框", MessageBoxButtons.OK);
				start = 0;
			}
			else
			{
				richText.SelectedText = str2;
				start += str2.Length;
			}
			richText.SelectionColor = Color.Red;
			richText.Focus();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string str1, str2;
			str1 = textBox1.Text;
			str2 = textBox2.Text;
			start = 0;
			start = richText.Find(str1, start, RichTextBoxFinds.MatchCase);
			while(start != -1)
			{
				richText.SelectedText = str2;
				start += str2.Length;
				start = richText.Find(str1, start, RichTextBoxFinds.MatchCase);
			}
			MessageBox.Show("已替换到文档的结尾", "替换结束对话框", MessageBoxButtons.OK);
			start = 0;
			richText.Focus();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
