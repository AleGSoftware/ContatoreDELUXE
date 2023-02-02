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
                this.BackgroundImage = Properties.Resources.contatoredeluxe;
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
    }
}