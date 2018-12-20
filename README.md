# ArLib
[![Build status](https://ci.appveyor.com/api/projects/status/1un932sc43b9j4en?svg=true)](https://ci.appveyor.com/project/ArHShRn/arlib)
<br>My personal C# library for simplizing coding experience.<br>
Welcome to dev or modify it because it's under MIT license.<br>

# AR Console
This is a logging helper.<br>
You can record logs like casual Console.WriteLine() but using ARConsole.WriteLine();<br>
## CUI Console Style
![CUI](https://fileshk.arhshrn.cn/github/Ar_Lib/Console/CUI.JPG)<br>
This is the CUI style of the console.<br>
It has 4 kinds of colors indicating your logs.<br>
Default - White - Normal Message<br>
Harmless - Green - Normal Message<br>
Further - Yellow - Further Information<br>
Critical - Red - Critical Message<br>
Redirected - Cyan - For CMD Commands Executing Results<br>
<br>
Below is a sample code that shows you how to use the ARConsole.<br>
![CUI_CODE](https://fileshk.arhshrn.cn/github/Ar_Lib/Console/CUI_CODE.JPG)<br>
```
static void Main(string[] args)
{
    ARConsole.CreateConsole(true, "ARConsole", false);

    ARConsole.CRLF();
    ARConsole.WriteLine("Default Message Color. With Default Param.");
    ARConsole.WriteLine("Default Message Color. With Default Param.", MsgLevel.Default);
    ARConsole.WriteLine("Harmless Message Color. With Default Param.", MsgLevel.Harmless);
    ARConsole.WriteLine("Further Message Color. With Default Param.", MsgLevel.Further);
    ARConsole.WriteLine("Critical Message Color. With Default Param.", MsgLevel.Critical);

    ARConsole.AsyncExecuteCMD("NSLOOKUP -QT=A BLOG.AR-DISTRIBUTED.COM 8.8.8.8");
    ARConsole.ExecuteCMD("TASKLIST | FINDSTR AWCC.Service");

    while(!ARConsole.TasksComplete)
    {
        System.Threading.Thread.Sleep(100);
    }
}
```
## GUI Console Style
![GUI](https://fileshk.arhshrn.cn/github/Ar_Lib/Console/GUI.JPG)<br>
This is the GUI style of the console.<br>
What's different between CUI and GUI style is that CMD commands executing results will be shown in a message box poping.<br>
![GUI_CMD](https://fileshk.arhshrn.cn/github/Ar_Lib/Console/GUI_CMD.JPG)<br>
And to ensure the safety of the current process, a CUI console will be created if the GUI console is disposed by the user.<br>
![GUI_ONDISPOSE](https://fileshk.arhshrn.cn/github/Ar_Lib/Console/GUI_ONDISPOSE.JPG)<br>
<br>
Below is a sample code that shows you how to use the ARConsole.<br>
![GUI_CODE](https://fileshk.arhshrn.cn/github/Ar_Lib/Console/GUI_CODE.JPG)
```
static void Main(string[] args)
{
    ARConsole.CreateConsole(true, "ARConsole", true);

    ARConsole.CRLF();
    ARConsole.WriteLine("Default Message Color. With Default Param.");
    ARConsole.WriteLine("Default Message Color. With Default Param.", MsgLevel.Default);
    ARConsole.WriteLine("Harmless Message Color. With Default Param.", MsgLevel.Harmless);
    ARConsole.WriteLine("Further Message Color. With Default Param.", MsgLevel.Further);
    ARConsole.WriteLine("Critical Message Color. With Default Param.", MsgLevel.Critical);

    ARConsole.AsyncExecuteCMD("NSLOOKUP -QT=A BLOG.AR-DISTRIBUTED.COM 8.8.8.8");
    ARConsole.ExecuteCMD("TASKLIST | FINDSTR AWCC.Service");

    Console.ReadKey();
}