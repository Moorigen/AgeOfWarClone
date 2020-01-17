using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfWarClone {
    static class Program {

        public static Random random = new Random();
        public static string resourcePath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(Path.DirectorySeparatorChar)).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(Path.DirectorySeparatorChar)).LastIndexOf(Path.DirectorySeparatorChar)) + Path.DirectorySeparatorChar + "Resources" + Path.DirectorySeparatorChar;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainHandler());
        }
        
    }
}
