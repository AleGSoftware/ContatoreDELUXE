using System.Diagnostics.Contracts;

namespace contatore_deluxe_dotnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int player1Count;
        int player2Count;
        int player3Count;
        int player4Count;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player1Count + 1 <= 999)
            {
                player1Count++;
                count1.Text = player1Count.ToString("000");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (player1Count - 1 != -1){
                player1Count--;
                count1.Text = player1Count.ToString("000");
            }
        }

        private void mostraLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostraLogoToolStripMenuItem.Checked = !mostraLogoToolStripMenuItem.Checked;
            if (mostraLogoToolStripMenuItem.Checked)
            {
                if (giocatoriToolStripMenuItem.Checked)
                {
                    this.BackgroundImage = Properties.Resources.contatoredeluxe_small;
                }
                else if (giocatoriToolStripMenuItem1.Checked || giocatoriToolStripMenuItem2.Checked)
                {
                    this.BackgroundImage = Properties.Resources.contatoredeluxe;
                }
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (player3Count + 1 <= 999)
            {
                player3Count++;
                count3.Text = player3Count.ToString("000");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (player3Count - 1 != -1)
            {
                player3Count--;
                count3.Text = player3Count.ToString("000");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (player2Count + 1 <= 999)
            {
                player2Count++;
                count2.Text = player2Count.ToString("000");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (player2Count - 1 != -1)
            {
                player2Count--;
                count2.Text = player2Count.ToString("000");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (player4Count + 1 <= 999)
            {
                player4Count++;
                count4.Text = player4Count.ToString("000");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (player4Count - 1 != -1)
            {
                player4Count--;
                count4.Text = player4Count.ToString("000");
            }
        }

        private void g1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void g1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void g2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void g2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void g3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void g3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void g4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void g4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void azzeraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1Count = 0;
            player2Count = 0;
            player3Count = 0;
            player4Count = 0;
            count1.Text = player1Count.ToString("000");
            count2.Text = player2Count.ToString("000");
            count3.Text = player3Count.ToString("000");
            count4.Text = player4Count.ToString("000");
        }

        private void temaColoratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temaColoratoToolStripMenuItem.Checked = !temaColoratoToolStripMenuItem.Checked;
            if (temaColoratoToolStripMenuItem.Checked)
            {
                count1.ForeColor = Color.Blue;
                count2.ForeColor = Color.Red;
                count3.ForeColor = Color.LimeGreen;
                count4.ForeColor = Color.DarkViolet;
                player1TextBox.ForeColor = Color.Blue;
                player2TextBox.ForeColor = Color.Red;
                player3TextBox.ForeColor = Color.LimeGreen;
                player4TextBox.ForeColor = Color.DarkViolet;
                player1Up.ForeColor = Color.Blue;
                player1Down.ForeColor = Color.Blue;
                player2Up.ForeColor = Color.Red;
                player2Down.ForeColor = Color.Red;
                player3Up.ForeColor = Color.LimeGreen;
                player3Down.ForeColor = Color.LimeGreen;
                player4Up.ForeColor = Color.DarkViolet;
                player4Down.ForeColor = Color.DarkViolet;
            }
            else
            {
                count1.ForeColor = Color.Black;
                count2.ForeColor = Color.Black;
                count3.ForeColor = Color.Black;
                count4.ForeColor = Color.Black;
                player1TextBox.ForeColor = Color.Black;
                player2TextBox.ForeColor = Color.Black;
                player3TextBox.ForeColor = Color.Black;
                player4TextBox.ForeColor = Color.Black;
                player1Up.ForeColor = Color.Black;
                player1Down.ForeColor = Color.Black;
                player2Up.ForeColor = Color.Black;
                player2Down.ForeColor = Color.Black;
                player3Up.ForeColor = Color.Black;
                player3Down.ForeColor = Color.Black;
                player4Up.ForeColor = Color.Black;
                player4Down.ForeColor = Color.Black;
            }
            
        }
        void changePlayerCount(int players)
        {
            switch (players)
            {
                case 2:
                    schermoInteroToolStripMenuItem.Checked = false;
                    this.Size = new Size(1080, 716);
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    count3.Visible = false;
                    player3Down.Visible = false;
                    player3Up.Visible = false;
                    player3TextBox.Visible = false;
                    count4.Visible = false;
                    player4Down.Visible = false;
                    player4Up.Visible = false;
                    player4TextBox.Visible = false;
                    this.MinimumSize = new Size(1080, 346);
                    this.Size = new Size(1080, 346);
                    count1.Anchor = AnchorStyles.Left;
                    count2.Anchor = AnchorStyles.Right;
                    player1TextBox.Anchor = AnchorStyles.Left;
                    player2TextBox.Anchor = AnchorStyles.Right;
                    player1Up.Anchor = AnchorStyles.Left;
                    player1Down.Anchor = AnchorStyles.Left;
                    player2Up.Anchor = AnchorStyles.Right;
                    player2Down.Anchor = AnchorStyles.Right;
                    if (mostraLogoToolStripMenuItem.Checked)
                    {
                        this.BackgroundImage = Properties.Resources.contatoredeluxe_small;
                    }
                    break;
                case 3:
                    break;
                case 4:
                    schermoInteroToolStripMenuItem.Checked = false;
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    if (this.MinimumSize == new Size(1080, 346))
                    {
                        this.Size = new Size(1080, 346);       
                    } else
                    {
                        this.Size = new Size(1080, 716);
                    }
                    count3.Visible = true;
                    player3Down.Visible = true;
                    player3Up.Visible = true;
                    player3TextBox.Visible = true;
                    count4.Visible = true;
                    player4Down.Visible = true;
                    player4Up.Visible = true;
                    player4TextBox.Visible = true;
                    
                    count1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    count2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    player1TextBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    player2TextBox.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    player1Up.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    player1Down.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    player2Up.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    player2Down.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    if (mostraLogoToolStripMenuItem.Checked)
                    {
                        this.BackgroundImage = Properties.Resources.contatoredeluxe;
                    }
                    this.MinimumSize = new Size(1080, 716);
                    this.Size = new Size(1080, 716);
                    break;
            }
        }

        private void giocatoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giocatoriToolStripMenuItem.Checked = true;
            giocatoriToolStripMenuItem2.Checked = false;
            giocatoriToolStripMenuItem1.Checked = false;
            changePlayerCount(2);
            
        }

        private void giocatoriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            giocatoriToolStripMenuItem.Checked = false;
            giocatoriToolStripMenuItem2.Checked = false;
            giocatoriToolStripMenuItem1.Checked = true;
            changePlayerCount(3);
        }

        private void giocatoriToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            giocatoriToolStripMenuItem.Checked = false;
            giocatoriToolStripMenuItem2.Checked = true;
            giocatoriToolStripMenuItem1.Checked = false;
            changePlayerCount(4);
        }

        private void schermoInteroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schermoInteroToolStripMenuItem.Checked = !schermoInteroToolStripMenuItem.Checked;
            if (schermoInteroToolStripMenuItem.Checked)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}