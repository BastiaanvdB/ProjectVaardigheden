using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class MagicWord : Form
    {
        public MagicWord()
        {
            InitializeComponent();
            string locationfile = @"Resources\theKing.mp4";
            axWindowsMediaPlayer1.URL = locationfile;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.settings.volume = 100;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
