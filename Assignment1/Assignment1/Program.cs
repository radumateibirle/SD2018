using Assignment1.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            testAll();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static void testAll()
        {
            testHash();
        }
        static void testHash()
        {
            Assignment1.ServicesLayer.Models.UserModel userTest = new Assignment1.ServicesLayer.Models.UserModel();
            string hash = "lQ6KUm7bwo1ii3/35dY8nLWH90+DmjeFEYCalRucb0M=";
            string hashed = userTest.hash("OParolacu4cifre127");
            if (!hashed.Equals(hash))
            {
                throw new Exception();
            }
        }
    }
}
