using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODBExe4
{
    public partial class Form1 : Form
    {
        List<Movy> list;
        int posn;
        DafestyEntities context;
        public Form1()
        {
            InitializeComponent();
        }
        public void display()
        {
            textBox1.Text = list[posn].VideoCode.ToString();
            textBox2.Text = list[posn].MovieTitle.ToString();
            textBox3.Text = list[posn].Rating.ToString();
        }

        public void retrieve()
        {
            list[posn].VideoCode = Convert.ToInt16(textBox1.Text);
            list[posn].MovieTitle = textBox2.Text;
            list[posn].Rating = textBox3.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Movy mv;
            mv = list[posn];
            list.Remove(mv);
            context.Movies.Remove(mv);
            int i = context.SaveChanges();
            if (i > 0)
            {
                MessageBox.Show("Successful!");

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//"Load"
        {
            posn = 0;
            context = new DafestyEntities();
            var q = from x in context.Movies select x;
            list = q.ToList();
            display();
        }

        private void button6_Click(object sender, EventArgs e)//">"
        {
            if (posn < list.Count - 1)
            {
                posn++;
                display();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (posn > 0)
            {
                posn--;
                display();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            posn = list.Count - 1;
            display();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            posn = 0;
            display();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int searchCode = Convert.ToInt16(textBox4.Text);
            for (int i = 0; i < list.Count; i++)
            {
                if (searchCode == list[i].VideoCode)
                {
                    posn = i;
                }
            }
            display();
        }

        private void button2_Click(object sender, EventArgs e)//"Update"
        {
            retrieve();
            int i = context.SaveChanges();
            if (i > 0)
            {
                MessageBox.Show("Successful!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button10.Visible = true;
            //context.SaveChanges();
            //var q = from x in context.Movies select x;
            //list = q.ToList();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Movy mv = new Movy();
            mv.VideoCode = Convert.ToInt16(textBox1.Text);
            mv.MovieTitle = textBox2.Text;
            mv.Rating = textBox3.Text;
            context.Movies.Add(mv);
            list.Add(mv);
            int i = context.SaveChanges();
            if (i > 0)
            {
                MessageBox.Show("Successful!");
                posn = list.Count - 1;
            }
            button10.Visible = false;
        }
    }
}
