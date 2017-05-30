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
    public partial class Form1 : Form
    {
        List<Button> listBtn = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            listBtn.Add(button1);
            listBtn.Add(button2);
            listBtn.Add(button3);
            listBtn.Add(button4);
            listBtn.Add(button5);
            listBtn.Add(button6);
            listBtn.Add(button7);
            listBtn.Add(button8);
            listBtn.Add(button9);
        }
        //login log = new login();
        
        Player playerOne = new Player(FirstPlayers.firstPlayer.ToString(), "X");
        Player playerTwo = new Player(FirstPlayers.secondPlayer.ToString(), "O");
        private bool btnClicked = false;
        private int a = 0;
        private int k = 0;
        private int scoreOne = 0;
        private int scoreTwo = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn;
            btn = sender as Button;
            if (btnClicked == false && btn.Text != playerOne.symb && btn.Text != playerTwo.symb)
            {
                btn.Text = playerOne.symb;
                label2.Text = playerTwo.name;
                btnClicked = true;
            }
            else if (btnClicked == true && btn.Text != playerOne.symb && btn.Text != playerTwo.symb)
            {
                btn.Text = playerTwo.symb;
                label2.Text = playerOne.name;
                btnClicked = false;
            }
            CheckWinners();
            DisableBtn();
            showWinner();
            Score();
        }
        private void CheckWinners()
        {
            Button[,] btnArr = new Button[3, 3] { { button1, button2, button3 }, { button4, button5, button6 }, { button7, button8, button9 } };
                        
            for (int j = 0; j < 3; j++)
            {
                //horrizontal
                if (btnArr[j, a].Text == playerOne.symb && btnArr[j, a+1].Text == playerOne.symb && btnArr[j, a+2].Text == playerOne.symb
                    || (btnArr[j, a].Text == playerTwo.symb && btnArr[j, a + 1].Text == playerTwo.symb && btnArr[j, a + 2].Text == playerTwo.symb))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        btnArr[j, i].BackColor = Color.Green;
                    }
                }
                //vertical
                if (btnArr[a,j].Text == playerOne.symb && btnArr[a + 1,j].Text == playerOne.symb && btnArr[a + 2,j].Text == playerOne.symb
                    || (btnArr[a, j].Text == playerTwo.symb && btnArr[a + 1, j].Text == playerTwo.symb && btnArr[a + 2, j].Text == playerTwo.symb))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        btnArr[i, j].BackColor = Color.Green;
                    }
                }
                //Cross
                if (btnArr[a, a].Text == playerOne.symb && btnArr[a + 1, a + 1].Text == playerOne.symb && btnArr[a + 2, a + 2].Text == playerOne.symb
                    || (btnArr[a, a].Text == playerTwo.symb && btnArr[a + 1, a + 1].Text == playerTwo.symb && btnArr[a + 2, a + 2].Text == playerTwo.symb))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        btnArr[i, i].BackColor = Color.Green;
                        
                    }
                }
                //cross reverse
                if (btnArr[a+2, a].Text == playerOne.symb && btnArr[a + 1, a + 1].Text == playerOne.symb && btnArr[a, a + 2].Text == playerOne.symb
                    ||(btnArr[a + 2, a].Text == playerTwo.symb && btnArr[a + 1, a + 1].Text == playerTwo.symb && btnArr[a, a + 2].Text == playerTwo.symb))
                {
                    
                    for (int i = 2; i >= 0; i--)
                    {
                        if (k == 3)
                        {
                            break;
                        }
                        else
                        {
                            btnArr[i, k].BackColor = Color.Green;
                            k++;
                        }
                    }
                }
               
            }
        }
        private void DisableBtn()
        {
            
            foreach (Button btn in listBtn)
            {
                if (btn.BackColor == Color.Green)
                {
                    foreach (Button b in listBtn)
                    {
                        b.Enabled = false;
                    }
                }
            }
        }
        private void showWinner()
        {
            foreach(Button btn in listBtn)
            {
                if (btn.BackColor == Color.Green)
                {
                    
                    if (btn.Text == playerOne.symb)
                    {
                        this.label3.Text = playerOne.name + " WIN!";
                    }
                    else if(btn.Text == playerTwo.symb)
                    {
                        this.label3.Text = playerTwo.name + " WIN!";
                    }
                }
            }
            
        }
        private void Score()
        {
            foreach (Button btn in listBtn)
            {
                if (btn.BackColor == Color.Green)
                {
                    if (label3.Text == playerOne.name + " WIN!")
                    {
                        scoreOne++;
                        this.label4.Text = (scoreOne/3).ToString();
                    }
                    if (label3.Text == playerTwo.name + " WIN!")
                    {
                        scoreTwo++;
                        this.label5.Text = (scoreTwo/3).ToString();
                    }
                }
            }
        }
        private void ClearAll()
        {
            foreach (Button btn in listBtn)
            {
                btn.Text="";
                btn.BackColor = SystemColors.Control;
                btn.Enabled = true;
                label3.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
