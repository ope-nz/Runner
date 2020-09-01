using System;
using System.Diagnostics;
//using System.Windows.Forms;
using System.IO;
using System.Reflection;

// A few assembly level attributes.
[assembly:AssemblyVersion("2.0.0.0")]
[assembly:AssemblyProductAttribute("Runner")]
[assembly:AssemblyCopyrightAttribute("ope ltd")]
[assembly:AssemblyTitle("JAR Launcher")]

// NOTE: console output only shows if you run with | more option at cmd. eg runner.exe | more
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
			
			Console.WriteLine(ThisLocation);
			
			// Updated the logic below, if there is a "private" runtime folder found then this will be the prefered one over the one in the C:\Java folder
			// This is so that the runtime bundled with the app is used before looking for others

			if(JavaFolder == "" && Directory.Exists(".\\runtime"))
			{
				JavaFolder = ".\\runtime\\java";
			}
			
			if(JavaFolder == "" && Directory.Exists("..\\runtime"))
			{
				JavaFolder = "..\\runtime\\java";
			}
			
			if(JavaFolder == "" && Directory.Exists(@"C:\Java"))
			{
				string [] subDirectories = System.IO.Directory.GetDirectories(@"C:\Java","*jdk*");
				if (subDirectories.Length > 0)
				{	
					string firstSubDir = subDirectories[0];
					JavaFolder = firstSubDir;
				}				
			}
			
			Console.WriteLine(JavaFolder);

			if (JavaFolder == "")
			{
				//MessageBox.Show("Cant find runtime folder, exiting!");
				Console.WriteLine("Cant find runtime folder, exiting!");
				Environment.Exit(-1);
			}			
			
			//string Arguments = "--module-path " + JavaFolder +  "\\javafx\\lib --add-modules javafx.controls,javafx.fxml -jar " + JarName;
			string Arguments = "--module-path " + JavaFolder +  "\\javafx\\lib --add-modules ALL-MODULE-PATH -jar " + JarName;
			
			Console.WriteLine(Arguments);
			
				
            Process p = new Process();
            p.StartInfo.FileName = JavaFolder + "\\bin\\javaw.exe";
            p.StartInfo.WorkingDirectory = ThisLocation;
            p.StartInfo.Arguments = Arguments;
			p.StartInfo.UseShellExecute = false;		
            p.Start();
			p.WaitForExit();
        }
    }
}