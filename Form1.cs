using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NumberGuessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = false;
        }

        Random rnd = new Random();
        int guess, number, right;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // to stop the beep
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            right = 10;
            number = rnd.Next(100);
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            guess = Convert.ToInt32(textBox1.Text);
            textBox1.Clear();
            if (guess == number)
            {
                label2.Text = "*"+ number + "*" + " You Guessed it in " + (10 - right) + " Guesses.";
                textBox1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                right--;
                label2.Text = "You Have " + right + " Right.";
                if (guess < number) { label3.Text = "That's too Low."; }
                else { label3.Text = "That's too High."; }
                if (right == 0) 
                {
                    label2.Text = "The Number was: "+ number + " - Try Again.";
                    textBox1 .Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
        }

    }
}
