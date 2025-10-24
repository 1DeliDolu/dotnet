using System;
using System.Windows.Forms;
using LibraryApp.Ansichten;

namespace LibraryApp;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new HauptFenster());
    }
}
