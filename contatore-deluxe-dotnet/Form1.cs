using Markdig;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using WkHtmlToPdfDotNet;

namespace contatore_deluxe_dotnet
{
    public partial class Form1 : Form
    {
        string programVersion = "1.0";
        string buildType = "Release Candidate";
        string[] devBuilds = new string[] {"Developement", "Release Candidate", "Beta", "Master", "Alpha"};
        public Form1(string[] args)
        {
            InitializeComponent();
            if (!((IList<string>)devBuilds).Contains(buildType))
            {
                debugToolStripMenuItem.Visible = false;
                label1.Visible = false;
            } else
            {
                debugToolStripMenuItem.Visible = true;
                label1.Visible = true;
                label1.Text = buildType;
                try
                {
                    //MessageBox.Show(Convert.ToString(args[0]));
                }
                catch
                {

                }
            }
            if (args.Length > 0)
            {
                loadFile(args[0]);
            }
        }
        int player1Count;
        int player2Count;
        int player3Count;
        int player4Count;
        int winnerThreshold = 20;
        string Winner = "";
        string actionHistory = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        void showWinScreen(int player)
        {
            switch (player)
            {
                case 1:
                    Winner = player1TextBox.Text;
                    break;
                case 2:
                    Winner = player2TextBox.Text;
                    break;
                case 3:
                    Winner = player3TextBox.Text;
                    break;
                case 4:
                    Winner = player4TextBox.Text;
                    break;

            }
            var messageBoxResult = MessageBox.Show($"Il vincitore della partita è {Winner} (Giocatore {player.ToString()})\nVuoi azzerare la partita?", "Vincitore della partita", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (messageBoxResult == DialogResult.Yes)
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
            actionHistory += "P" + player.ToString() + "W.";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (player1Count + 1 <= 999)
            {
                player1Count++;
                count1.Text = player1Count.ToString("000");
                actionHistory += "P1A.";
            }
            if (player1Count >= winnerThreshold)
            {
                showWinScreen(1);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (player1Count - 1 != -1){
                player1Count--;
                count1.Text = player1Count.ToString("000");
                actionHistory += "P1R.";

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
                actionHistory += "P3A.";

            }
            if (player3Count >= winnerThreshold)
            {
                showWinScreen(3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (player3Count - 1 != -1)
            {
                player3Count--;
                count3.Text = player3Count.ToString("000");
                actionHistory += "P3R.";

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (player2Count + 1 <= 999)
            {
                player2Count++;
                count2.Text = player2Count.ToString("000");
                actionHistory += "P2A.";

            }
            if (player1Count >= winnerThreshold)
            {
                showWinScreen(2);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (player2Count - 1 != -1)
            {
                player2Count--;
                count2.Text = player2Count.ToString("000");
                actionHistory += "P2R.";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (player4Count + 1 <= 999)
            {
                player4Count++;
                count4.Text = player4Count.ToString("000");
                actionHistory += "P4A.";


            }
            if (player1Count >= winnerThreshold)
            {
                showWinScreen(4);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (player4Count - 1 != -1)
            {
                player4Count--;
                count4.Text = player4Count.ToString("000");
                actionHistory += "P4R.";

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
            actionHistory = "";
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
                    schermoInteroToolStripMenuItem.Checked = false;
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    if (this.MinimumSize == new Size(1080, 346))
                    {
                        this.Size = new Size(1080, 346);
                    }
                    else
                    {
                        this.Size = new Size(1080, 716);
                    }
                    count3.Visible = true;
                    player3Down.Visible = true;
                    player3Up.Visible = true;
                    player3TextBox.Visible = true;
                    count4.Visible = false;
                    player4Down.Visible = false;
                    player4Up.Visible = false;
                    player4TextBox.Visible = false;

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

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                try
                {
                    winnerThreshold = Convert.ToInt32(toolStripTextBox1.Text);
                }
                catch
                {
                    toolStripTextBox1.Text = winnerThreshold.ToString();
                }
            }
            
            
        }

        private void informazioniSulProgrammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm(programVersion, buildType);
            about.Show();
        }

        private void caricaPartitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                loadFile(openFileDialog1.FileName);


            }
            catch
            {

            }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                saveFile(saveFileDialog1.FileName);


            }
            catch
            {

            }
        }
        void saveFile(string filePath)
        {
            TextWriter fileSaver = new StreamWriter(filePath);


            fileSaver.WriteLine("copyrightalegsoftware");
            fileSaver.WriteLine("ctdlxe_file");
            fileSaver.WriteLine(programVersion);
            fileSaver.WriteLine(buildType);
            fileSaver.WriteLine(temaColoratoToolStripMenuItem.Checked);
            fileSaver.WriteLine(mostraLogoToolStripMenuItem.Checked);
            fileSaver.WriteLine(giocatoriToolStripMenuItem.Checked);
            fileSaver.WriteLine(giocatoriToolStripMenuItem1.Checked);
            fileSaver.WriteLine(giocatoriToolStripMenuItem2.Checked);
            fileSaver.WriteLine(winnerThreshold);
            fileSaver.WriteLine(player1Count);
            fileSaver.WriteLine(player2Count);
            fileSaver.WriteLine(player3Count);
            fileSaver.WriteLine(player4Count);
            fileSaver.WriteLine(player1TextBox.Text);
            fileSaver.WriteLine(player2TextBox.Text);
            fileSaver.WriteLine(player3TextBox.Text);
            fileSaver.WriteLine(player4TextBox.Text);
            fileSaver.WriteLine(actionHistory);
            fileSaver.WriteLine("copyrightalegsoftware");
            fileSaver.WriteLine("endoffile-endoffile");
            fileSaver.Close();
        }
        void loadFile(string filePath)
        {
            TextReader fileLoader = new StreamReader(filePath);
            try
            {
                string copyrightFile = fileLoader.ReadLine();
                string fileType = fileLoader.ReadLine();

                if (copyrightFile == "copyrightalegsoftware" && fileType == "ctdlxe_file")
                {
                    string originalVersion = fileLoader.ReadLine();
                    string originalBuildType = fileLoader.ReadLine();
                    bool temaColorato = Convert.ToBoolean(fileLoader.ReadLine());
                    bool mostraLogo = Convert.ToBoolean(fileLoader.ReadLine());
                    bool players_2 = Convert.ToBoolean(fileLoader.ReadLine());
                    bool players_3 = Convert.ToBoolean(fileLoader.ReadLine());
                    bool players_4 = Convert.ToBoolean(fileLoader.ReadLine());
                    int winnerThresholdFile = Convert.ToInt32(fileLoader.ReadLine());
                    int player1CountFile = Convert.ToInt32(fileLoader.ReadLine());
                    int player2CountFile = Convert.ToInt32(fileLoader.ReadLine());
                    int player3CountFile = Convert.ToInt32(fileLoader.ReadLine());
                    int player4CountFile = Convert.ToInt32(fileLoader.ReadLine());
                    string player1NameFile = fileLoader.ReadLine();
                    string player2NameFile = fileLoader.ReadLine();
                    string player3NameFile = fileLoader.ReadLine();
                    string player4NameFile = fileLoader.ReadLine();
                    string actionHistoryFile = fileLoader.ReadLine();
                    string copyrightFileEnd = fileLoader.ReadLine();
                    string endOfFile = fileLoader.ReadLine();
                    fileLoader.Close();
                    if (copyrightFile == copyrightFileEnd && endOfFile == "endoffile-endoffile")
                    {
                        int playerCountFile = 0;
                        if (players_2)
                        {
                            playerCountFile = 2;
                        }
                        else if (players_3)
                        {
                            playerCountFile = 3;
                        }
                        else if (players_4)
                        {
                            playerCountFile = 4;
                        }

                        var result = MessageBox.Show($"Caricato file: {filePath}\n" +
                            $"Versione ContatoreDELUXE: {originalBuildType} {originalVersion}\n" +
                            $"Tema colorato abilitato: {temaColorato.ToString()}\n" +
                            $"Mostra logo ContatoreDELUXE: {mostraLogo.ToString()}\n" +
                            $"Numero giocatori: {playerCountFile.ToString()}\n" +
                            $"Si vince a: {winnerThresholdFile.ToString()}\n" +
                            $"Giocatore 1: {player1NameFile} con {player1CountFile.ToString()}\n" +
                            $"Giocatore 2: {player2NameFile} con {player2CountFile.ToString()}\n" +
                            $"Giocatore 3: {player3NameFile} con {player3CountFile.ToString()}\n" +
                            $"Giocatore 4: {player4NameFile} con {player4CountFile.ToString()}\n" +
                            $"Si vuole caricare il file e sovrascrivere la partita in corso?", "Caricamento file riuscito.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            player1Count = player1CountFile;
                            count1.Text = player1CountFile.ToString("000");
                            player1TextBox.Text = player1NameFile;
                            player2Count = player2CountFile;
                            count2.Text = player2CountFile.ToString("000");
                            player2TextBox.Text = player2NameFile;
                            player3Count = player3CountFile;
                            count3.Text = player3CountFile.ToString("000");
                            player3TextBox.Text = player3NameFile;
                            player4Count = player4CountFile;
                            count4.Text = player4CountFile.ToString("000");
                            player4TextBox.Text = player4NameFile;
                            temaColoratoToolStripMenuItem.Checked = temaColorato;
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
                            changePlayerCount(playerCountFile);
                            mostraLogoToolStripMenuItem.Checked = mostraLogo;
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
                            actionHistory = actionHistoryFile;
                            toolStripTextBox1.Text = winnerThresholdFile.ToString(); ;
                            winnerThreshold = winnerThresholdFile;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Impossibile caricare il file {filePath}.\nMotivo: Formato file non conforme alle specifiche", "Errore F002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    fileLoader.Close();
                    MessageBox.Show($"Impossibile caricare il file {filePath}.\nMotivo: File non compatibile", "Errore F001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show($"Impossibile caricare il file {filePath}.\nMotivo: Errore generico", "Errore F000", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void stampaActionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(actionHistory);
        }

        private void nuovaPartitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePlayerCount(4);
            this.BackgroundImage = Properties.Resources.contatoredeluxe;
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
            azzeraToolStripMenuItem_Click(sender, e);
            player1TextBox.Text = "Giocatore 1";
            player2TextBox.Text = "Giocatore 2";
            player3TextBox.Text = "Giocatore 3";
            player4TextBox.Text = "Giocatore 4";
            winnerThreshold = 20;
            toolStripTextBox1.Text = 20.ToString();
            giocatoriToolStripMenuItem.Checked = false;
            giocatoriToolStripMenuItem1.Checked = false;
            giocatoriToolStripMenuItem2.Checked = true;
            temaColoratoToolStripMenuItem.Checked = true;
            mostraLogoToolStripMenuItem.Checked = true;
        }
        string convertactionStringtoRTF(string actionString)
        {
            string RTFString = " ";
            char[] delimiterChars = {'.'};

            

            string[] instructions = actionString.Split(delimiterChars);

            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case "P1A":
                        RTFString += @"
Aggiunto un punto a Giocatore 1
";
                        break;
                    case "P1R":
                        RTFString += @"
Rimosso un punto a Giocatore
";
                        break;
                    case "P1W":
                        RTFString += @"
Il giocatore 1 vince la partita
";
                        break;
                    case "P2A":
                        RTFString += @"
Aggiunto un punto a Giocatore 2
";
                        break;
                    case "P2R":
                        RTFString += @"
Rimosso un punto a Giocatore 2
";
                        break;
                    case "P2W":
                        RTFString += @"
Il giocatore 2 vince la partita
";
                        break;
                    case "P3A":
                        RTFString += @"
Aggiunto un punto a Giocatore 3
";
                        break;
                    case "P3R":
                        RTFString += @"
Rimosso un punto a Giocatore 3
";
                        break;
                    case "P3W":
                        RTFString += @"
Il giocatore 3 vince la partita
";
                        break;
                    case "P4A":
                        RTFString += @"
Aggiunto un punto a Giocatore 4
";
                        break;
                    case "P4R":
                        RTFString += @"
Rimosso un punto a Giocatore 4
";
                        break;
                    case "P5W":
                        RTFString += @"
Il giocatore 4 vince la partita
";
                        break;

                }
            }
            return RTFString;
        }

        private void stampaConversioneAHTORTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(convertactionStringtoRTF(actionHistory));
            System.Diagnostics.Debug.WriteLine(convertactionStringtoRTF(actionHistory));
        }
        string boolToStringNice(bool boolean)
        {
            if (boolean)
            {
                return "Abilitato";
            }
            else
            {
                return "Disabilitato";
            }
        }
        private void esportaPartitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var datetime = DateTime.Now;
            string date = datetime.ToString();


            try
            {
                saveFileDialog2.ShowDialog();
                string RTFString = convertactionStringtoRTF(actionHistory);
                string markdownTemplate = @$"## ContatoreDELUXE 
### RESOCONTO DELLA PARTITA
#### Impostazioni di gioco
Data partita: {date}

Versione di ContatoreDELUXE: {buildType} {programVersion}

Tema colorato: {boolToStringNice(temaColoratoToolStripMenuItem.Checked)}

Mostra logo: {boolToStringNice(mostraLogoToolStripMenuItem.Checked)}

Vincita a: {winnerThreshold}

Giocatore 1: {player1TextBox.Text} con {player1Count} punti

Giocatore 2: {player2TextBox.Text} con {player2Count} punti

Giocatore 3: {player3TextBox.Text} con {player3Count} punti

Giocatore 4: {player4TextBox.Text} con {player4Count} punti

#### Cronologia gioco
Inizio partita
{RTFString}

© AleGSoftware 2023
";

                if (saveFileDialog2.FileName != "")
                {
                    if (saveFileDialog2.FilterIndex == 1)
                    {
                        string html = Markdown.ToHtml(markdownTemplate);
                        File.WriteAllText(saveFileDialog2.FileName, "<style>h2, h3, h4, p {font-family: Arial}</style>\n" + html);
                        var converter = new BasicConverter(new PdfTools());
                        var doc = new HtmlToPdfDocument()
                        {
                            GlobalSettings = {
                                ColorMode = ColorMode.Color,
                                Orientation = WkHtmlToPdfDotNet.Orientation.Portrait,
                                PaperSize = PaperKind.A4Plus,
                               },
                            Objects = {
                            new ObjectSettings() {
                                PagesCount = true,
                                HtmlContent = html,
                                WebSettings = { DefaultEncoding = "utf-8" },
                                HeaderSettings = { FontSize = 13, Right = "Pagina [page] di [toPage]", Line = false, Spacing = 2.812 }
                            }
                            }
                        };
                        byte[] pdf = converter.Convert(doc);
                        using var stream = File.Create(saveFileDialog2.FileName);
                        stream.Write(pdf, 0, pdf.Length);

                    }
                    else if (saveFileDialog2.FilterIndex == 2)
                    {
                        File.WriteAllText(saveFileDialog2.FileName, markdownTemplate);
                    }
                    else if (saveFileDialog2.FilterIndex == 3)
                    {
                        string html = Markdown.ToHtml(markdownTemplate);
                        File.WriteAllText(saveFileDialog2.FileName, "<style>h2, h3, h4, p {font-family: Segoe UI}</style>\n" + html);
                    }

                }
            }
            catch
            {

            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            loadFile(fileList[0]);

            if (fileList.Length == 1)
            {
                if (fileList[0].EndsWith(".ctdlxe")){
                }
            }
        }
    }
}