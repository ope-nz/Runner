# Runner
Small C# executable to run a Java JAR file using Open JDK

Runner is a smallC# executable which starts the JAR using Open JDK but the executable uses its name to execute the jar in the same directory.

For example;

1) If you start Runner.exe it will launch Runner.jar in the same directory
2) If you rename Runner.exe to bob.exe it will launch bob.jar (assuming bob.jar exists)

This way you can have one executable that you can rename to target multiple JAR files.

The arguments passed are;

RuntimeFolder\bin\javaw.exe --module-path RuntimeFolder\javafx\lib --add-modules javafx.controls,javafx.fxml -jar JarName

Where;
- RuntimeFolder is the runtime folder in the same directory as the executable.
- JarName is the executable file name with .exe rplaced with .jar

A pre-compiled exe is in the "out" folder.

If you want to build your own Runner or change the icon there is a Windows batch file to build the C# code for you (download the project).

IMPORTANT: One thing to note is that by default Open JDK isn't in the OS path so Runner looks for a folder called "runtime" in the same folder as Runner.exe and the JDK should be in the runtime folder. You can adjust this in the C# code if you want. The code looks for the runtime folder in the same folder, one folder up and also looks for a JDK in C:\Java.
