﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_КП_3сем
{
        static class Program
        {
            /// <summary>
            /// Главная точка входа для приложения.
            /// </summary>
            [STAThread]
            static void Main()
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AutorisationForm());
            }
        }
}
