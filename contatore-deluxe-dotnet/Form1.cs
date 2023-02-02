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
    }
}