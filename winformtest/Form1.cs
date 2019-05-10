using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace winformtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(null,null);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 删除_Click(object sender, EventArgs e)
        {
            update u = new update();
            u.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.listView1.Items.Clear();
                DB.IDB i = new DB.DBByAutoClose();
                string sql = NewMethod();
                List<student> ls = i.ExecuteToList<student>(sql);
                foreach (student s in ls)
                {
                    ListViewItem ltem = new ListViewItem((s.id).ToString());
                    ltem.SubItems.Add(s.name);
                    ltem.SubItems.Add(s.sex = s.sex == "nan" ? "男" : "女");
                    this.listView1.Items.Add(ltem);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string NewMethod()
        {
            return "select * from student where name like '%" + this.textBox2.Text.Trim() +"%' ";
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("确定要删除信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK) { 
                    DB.IDB i = new DB.DBByAutoClose();
                string id = this.listView1.SelectedItems[0].Text;
                string sql = "delete from student where id=" + id + "";
                i.ExecuteScalar(sql);
                button1_Click(null, null);
                MessageBox.Show("删除成功", "提示");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update u = new update();
            u.s.id = Convert.ToInt32(this.listView1.SelectedItems[0].Text);
            u.Show();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}