if not exist out (md out)

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /out:out\Runner.exe /win32icon:favicon.ico code\runner.cs
REM c:\WINDOWS\Microsoft.NET\Framework\v3.5\csc /target:winexe /out:out\Runner.exe /win32icon:icon.ico code\Runner.cs
pause
