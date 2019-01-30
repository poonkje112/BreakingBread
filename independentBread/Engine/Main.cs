using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace GameEngine
{
    public class EntryPoint
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main(string[] args)
        {
#if DEBUG
            ShowWindow(GetConsoleWindow(), SW_SHOW);
#else
            ShowWindow(GetConsoleWindow(), SW_HIDE);
#endif
            GameEngine instance = GameEngine.GetInstance();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(onExit);

            if (instance == null)
                return;

            new breakingBread(); //breakingBread implements AbstractGame and subscribes himself to the game engine

            instance.Run();

            //Clean up unmanaged resources
            instance.Dispose();
        }

#if DEBUG
        static string assetPath = "../../Assets/";
#else
        static string assetPath = "./Assets/";
#endif

        static void onExit(object sender, EventArgs e)
        {
            foreach(string file in Directory.GetFiles(assetPath))
            {
                if(file.Contains("Hover_"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }
        }
    }
}
