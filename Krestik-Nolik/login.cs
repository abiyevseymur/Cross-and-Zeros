using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krestik_Nolik
{
    
    
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            FirstPlayers.firstPlayer = textBox1.Text;
            FirstPlayers.secondPlayer = textBox2.Text;
            if(textBox1.Text != "" && textBox2.Text != "" && textBox1.Text != textBox2.Text)
            {
                Form1 game = new Form1();
                game.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Please fill the correct players name!");
            }
        }
        

    }
    public static class FirstPlayers
    {
        public static string firstPlayer { get; set; }
        public static string secondPlayer { get; set; }
    }
}
