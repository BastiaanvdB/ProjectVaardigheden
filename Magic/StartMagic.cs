using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    public class StartMagic
    {
        public void Start()
        {
            StartVideo();
            StartConsole();
        }

        private void StartVideo()
        {
            Magic magic = new Magic();
            magic.Show();
        }



        private void StartConsole()
        {
            MagicConsole magicConsole = new MagicConsole();
            magicConsole.Show();
        }



    }
}
