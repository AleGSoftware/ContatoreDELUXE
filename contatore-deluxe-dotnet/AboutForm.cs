using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using contatore_deluxe_dotnet.Properties;

namespace contatore_deluxe_dotnet
{
    public partial class AboutForm : Form
    {
        public AboutForm(string programVersion, string buildType)
        {
            InitializeComponent();
            label3.Text = buildType + " " + programVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete(Path.GetTempPath() + @"\gpl-3.0.rtf");
            File.WriteAllText(Path.GetTempPath() + @"\gpl-3.0.rtf", Resources.gpl_3_0);
            Process.Start("write.exe", Path.GetTempPath() + @"\gpl-3.0.rtf");
        }
    }
}
