using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genkrv
{
    public partial class Form1 : Form
    {
        public static string makeGen(short rule, int length)
        {
            Checker checker = new Checker();
            Generator generator = new Generator();
            while (true)
            {
                string pass = generator.generatePassword((short)length, (byte)rule);
                if (checker.check((byte)rule, pass))
                {
                    return pass;
                }
            }
        }
        public static bool makeCheck(short rule, string password)
        {
            Checker checker = new Checker();
            return checker.check((byte)rule, password);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short rule = 0;
            if (checkBox1.Checked) rule += 1;
            if (checkBox2.Checked) rule += 2;
            if (checkBox3.Checked) rule += 4;
            if (checkBox4.Checked) rule += 8;
            if (checkBox5.Checked) rule += 16;
            if (checkBox6.Checked) rule += 32;
            if (checkBox7.Checked) rule += 64;

            int length = Convert.ToInt32(textBox1.Text);
            textBox3.Text = makeGen(rule, length);
            label4.Text = "Пароль сгенерирован";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            short rule = 0;
            if (checkBox1.Checked) rule += 1;
            if (checkBox2.Checked) rule += 2;
            if (checkBox3.Checked) rule += 4;
            if (checkBox4.Checked) rule += 8;
            if (checkBox5.Checked) rule += 16;
            if (checkBox6.Checked) rule += 32;
            if (checkBox7.Checked) rule += 64;

            if (makeCheck(rule, textBox2.Text))
            {
                label4.Text = "Пароль соответствует правилам";
            }
            else label4.Text = "Пароль не соответствует правилам";
        }
    }
}
