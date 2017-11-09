using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TXT
{
	public partial class Form1 : Form
	{
		private static string openfilepath = "";                               //保存所打开文件的路径
		public Form1()
		{
			InitializeComponent();
		}

		private void 模式DToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			place();
		}

		private void 自动换行WToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(richTextBox1.WordWrap == true)
			{
				richTextBox1.WordWrap = false;
				自动换行WToolStripMenuItem.Checked = false;
				richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
			}
			else
			{
				richTextBox1.WordWrap = true;
				自动换行WToolStripMenuItem.Checked = true;
				richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.Modified)
			{
				DialogResult dResult = MessageBox.Show("文件" + this.Text + "的内容已改变，需要保存吗？", "保存文件", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (dResult)
				{
					case DialogResult.Yes:
						另存为LToolStripMenuItem_Click(null, null);
						richTextBox1.Clear();
						this.Text = "无标题—记事本";
						break;
					case DialogResult.No:
						richTextBox1.Clear();
						this.Text = "无标题—记事本";
						break;
					case DialogResult.Cancel:
						break;
				}
			}
			else
			{
				richTextBox1.Clear();
				this.Text = "无标题—记事本";
				richTextBox1.Modified = false;
			}
		}

		private void 文件FToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";       //设置文件类型
			openFileDialog1.FilterIndex = 1;                                                     //设置默认文件类型的显示顺序
			openFileDialog1.RestoreDirectory = true;                                       //打开对话框是否记忆上次打开的目录
			StreamReader sr = null;																 //定义 StreamReader 对象
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					openfilepath = openFileDialog1.FileName;
					string name = openfilepath.Substring(openfilepath.LastIndexOf("\\") + 1);
					this.Text = name;
					sr = new StreamReader(openfilepath, Encoding.Default);
					richTextBox1.Text = sr.ReadToEnd();
				}
				catch
				{
					MessageBox.Show("打开文件时出错。", "错误",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning);
					return;
				}
				finally
				{
					if(sr != null)
					{
						sr.Close();
						sr.Dispose();
					}
				}
			}
		}

		private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StreamWriter sw = null;
			if(openfilepath == "")
			{
				另存为LToolStripMenuItem_Click(null, null);
				return;
			}
			try
			{
				sw = new StreamWriter(openfilepath, false, Encoding.Default);
				sw.Write(richTextBox1.Text);
				toolStripStatusLabel1.Text = "保存成功";
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
				return;
			}
			finally
			{
				if(sw != null)
				{
					sw.Close();
					sw.Dispose();
				}
			}
		}

		private void 另存为LToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";      
			saveFileDialog1.FilterIndex = 2;                                                    
			saveFileDialog1.RestoreDirectory = true;
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				openfilepath = saveFileDialog1.FileName.ToString();
				FileStream fs;
				try
				{
					fs = File.Create(openfilepath);
				}
				catch
				{
					MessageBox.Show("建立文件时出错。", "错误",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning);
					return;
				}
				byte[] content = Encoding.Default.GetBytes(richTextBox1.Text);
				try
				{
					fs.Write(content, 0, content.Length);
					fs.Flush();
					toolStripStatusLabel1.Text = "保存成功";
				}
				catch
				{
					MessageBox.Show("写入文件时出错。", "错误",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning);
				}
				finally
				{
					fs.Close();
					fs.Dispose();
				}
			}
		}

		private void 打印PToolStripMenuItem_Click(object sender, EventArgs e)
		{
			printDialog1.ShowDialog();
		}

		private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void 撤销UToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Undo();
		}

		private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Cut();
		}

		private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Copy();
		}

		private void 粘贴PToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Paste();
		}

		private void 删除LToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectedText = "";
		}

		private void 查找FToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 ff = new Form2();
			ff.richtextbox = richTextBox1;
			ff.ShowDialog();
		}

		private void 替换RToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form3 fc = new Form3(richTextBox1);
			fc.ShowDialog();
		}

		private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectAll();
		}

		private void 时间日期DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionLength > 0)
			{
				richTextBox1.SelectedText = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " " + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
			}
			else
			{
				richTextBox1.SelectedText +=  DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " " + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
			}
		}

		private void 字体FToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(fontDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.SelectionFont = fontDialog1.Font;
			}
		}

		private void 状态栏SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(statusStrip1.Visible == true)
			{
				statusStrip1.Visible = false;
				状态栏SToolStripMenuItem.Checked = false;
				richTextBox1.Height += 22;
			}
			else
			{
				statusStrip1.Visible = true;
				状态栏SToolStripMenuItem.Checked = true;
				richTextBox1.Height -= 22;
			}
		}

		private void 关于记事本GToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("此记事本的版本为V1.0！");
		}

		private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
		{
			place();
		}

		private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
		{
			place();
		}

		private void place()
		{
			string str = this.richTextBox1.Text;
			int m = this.richTextBox1.SelectionStart;
			int Ln = 0;
			int Col = 0;
			for(int i = m - 1; i >= 0; i--)
			{
				if(str[i] == '\n')
				{
					Ln++;
					if (Ln < 1)
					{
						Col++;
					}
					Ln += 1;
					Col += 1;
					toolStripStatusLabel1.Text = "行： " + Ln.ToString() + ", 列： " + Col.ToString();
				}
			}
		}

		private void toolStripButton10_Click(object sender, EventArgs e)
		{
			richTextBox1.Redo();
		}
	}
}
