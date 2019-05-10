using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformtest
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }
       public student s = new student();
        DB.IDB i = new DB.DBByAutoClose();
        private void update_Load(object sender, EventArgs e)
        {
            
            string sql = "select * from student where id="+s.id+"" ;
            List<student> ls = i.ExecuteToList<student>(sql);
            foreach (student s in ls)
            {
                this.textBox1.Text = s.id.ToString();
                this.textBox3.Text = s.name;
                this.textBox2.Text = s.sex = s.sex == "nan" ? "男" : "女";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (this.textBox1.Text.Equals(string.Empty))
                {
                    string sql="insert into student(name,sex) values('"+this.textBox3.Text+"','"+this.textBox2.Text+"')";
                    i.ExecuteScalar(sql);
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    string sql = "update student set name='" + this.textBox3.Text + "',sex='" + this.textBox2.Text + "' where id=" + s.id + "";
                    MessageBox.Show("修改成功！");
                    i.ExecuteScalar(sql);
                    this.Close();
                }
            }
            catch(Exception) { throw; }
        }
    }
}
