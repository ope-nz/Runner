using System;
using System.Diagnostics;
//using System.Windows.Forms;
using System.IO;

// NOTE: console output only shows if you run with | more option at cmd. eg runner.exe | more
namespace B4JRunner
{
    class Program
    {
        static void Main(string[] args)
        {
			string ExeName = System.AppDomain.CurrentDomain.FriendlyName;					

			string JarName = ExeName.Replace(&quot;.exe&quot;,&quot;.jar&quot;);
			
			string ThisLocation = Directory.GetCurrentDirectory();
			
			string JavaFolder = &quot;&quot;;
			
			Console.WriteLine(ThisLocation);
			
			// Updated the logic below, if there is a &quot;private&quot; runtime folder found then this will be the prefered one over the one in the C:\Java folder
			// This is so that the runtime bundled with the app is used before looking for others

			if(JavaFolder == &quot;&quot; &amp;&amp; Directory.Exists(&quot;.\\runtime&quot;))
			{
				JavaFolder = &quot;.\\runtime\\java&quot;;
			}
			
			if(JavaFolder == &quot;&quot; &amp;&amp; Directory.Exists(&quot;..\\runtime&quot;))
			{
				JavaFolder = &quot;..\\runtime\\java&quot;;
			}
			
			if(JavaFolder == &quot;&quot; &amp;&amp; Directory.Exists(@&quot;C:\Java&quot;))
			{
				string [] subDirectories = System.IO.Directory.GetDirectories(@&quot;C:\Java&quot;,&quot;*jdk*&quot;);
				if (subDirectories.Length &gt; 0)
				{	
					string firstSubDir = subDirectories[0];
					JavaFolder = firstSubDir;
				}				
			}
			
			Console.WriteLine(JavaFolder);

			if (JavaFolder == &quot;&quot;)
			{
				//MessageBox.Show(&quot;Cant find runtime folder, exiting!&quot;);
				Console.WriteLine(&quot;Cant find runtime folder, exiting!&quot;);
				Environment.Exit(-1);
			}			
			
			//string Arguments = &quot;--module-path &quot; + JavaFolder +  &quot;\\javafx\\lib --add-modules javafx.controls,javafx.fxml -jar &quot; + JarName;
			string Arguments = &quot;--module-path &quot; + JavaFolder +  &quot;\\javafx\\lib --add-modules ALL-MODULE-PATH -jar &quot; + JarName;
			
			Console.WriteLine(Arguments);
				
            Process p = new Process();
            p.StartInfo.FileName = JavaFolder + &quot;\\bin\\javaw.exe&quot;;
            p.StartInfo.WorkingDirectory = ThisLocation;
            p.StartInfo.Arguments = Arguments;
			p.StartInfo.UseShellExecute = false;		
            p.Start();
			p.WaitForExit();
        }
    }
}