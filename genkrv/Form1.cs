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
        public Form1()
        {
            InitializeComponent();
        }
        public string makeGen(byte length, byte rule)
        {
            Checker checker = new Checker();
            Generator generator = new Generator();
            if (length > generator.getAphabetLength())
            {
                length = generator.getAphabetLength();
            }
            while (true)
            {
                string password = generator.generatePassword(length);
                if (checker.check(rule, password))
                {
                    return password;
                }
            }
        }

        public bool makeCheck(string password, byte rule)
        {
            Checker checker = new Checker();
            return checker.check(rule, password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Todo Создать мехнизм забора данных с чекбоксов и отправки их в генератор

            byte rule = 0;
            if (checkBox1.Checked) rule += 1;
            if (checkBox2.Checked) rule += 2;
            if (checkBox3.Checked) rule += 4;
            if (checkBox4.Checked) rule += 8;
            if (checkBox5.Checked) rule += 16;
            if (checkBox6.Checked) rule += 32;
            if (checkBox7.Checked) rule += 64;
            byte length = Convert.ToByte(textBox1.Text);
            textBox3.Text = makeGen(length, rule);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Todo Создать механизм проверки введенного пароля и обработки правил
            byte rule = 0;
            if (checkBox1.Checked) rule += 1;
            if (checkBox2.Checked) rule += 2;
            if (checkBox3.Checked) rule += 4;
            if (checkBox4.Checked) rule += 8;
            if (checkBox5.Checked) rule += 16;
            if (checkBox6.Checked) rule += 32;
            if (checkBox7.Checked) rule += 64;

            if (makeCheck(textBox2.Text, rule))
            {
                label4.Text = "Пароль соответствует критериям";
            }
            else label4.Text = "Пароль не соответствует критериям";
        }
    }
}
