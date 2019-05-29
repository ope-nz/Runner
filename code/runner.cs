using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace B4JRunner
{
    class Program
    {
        static void Main(string[] args)
        {
			string ExeName = System.AppDomain.CurrentDomain.FriendlyName;					

			string JarName = ExeName.Replace(".exe",".jar");
			
			string ThisLocation = Directory.GetCurrentDirectory();
			
			string JavaFolder = "";
			
			if(Directory.Exists(".\\runtime"))
			{
				JavaFolder = ".\\runtime\\java";
			}
			
			if(Directory.Exists("..\\runtime"))
			{
				JavaFolder = "..\\runtime\\java";
			}	

			if (JavaFolder == "")
			{
				MessageBox.Show("Cant find runtime folder, exiting!");
				Environment.Exit(-1);
			}
				
            Process p = new Process();
            p.StartInfo.FileName = JavaFolder + "\\bin\\javaw.exe";
            p.StartInfo.WorkingDirectory = ThisLocation;
            p.StartInfo.Arguments = "--module-path " + JavaFolder +  "\\javafx\\lib --add-modules javafx.controls,javafx.fxml -jar " + JarName;
            p.Start();
        }
    }
}