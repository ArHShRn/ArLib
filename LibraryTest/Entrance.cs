using System;
using ArLib.Console;

namespace LibraryTest
{
    class Entrance
    {
        static void Main(string[] args)
        {
            ARConsole.CreateConsole(true, "HuQi Says:", false, "Prof.Hu's logger");

            ARConsole.CRLF();
            ARConsole.WriteLine("Default Message Color. With Default Param.");
            ARConsole.WriteLine("Default Message Color. With Default Param.", MsgLevel.Default);
            ARConsole.WriteLine("Harmless Message Color. With Default Param.", MsgLevel.Harmless);
            ARConsole.WriteLine("Further Message Color. With Default Param.", MsgLevel.Further);
            ARConsole.WriteLine("Critical Message Color. With Default Param.", MsgLevel.Critical);

            ARConsole.AsyncExecuteCMD("NSLOOKUP -QT=A AREIY.LOVE 8.8.8.8");
            ARConsole.AsyncExecuteCMD("TASKLIST | FINDSTR AWCC.Service");
            Console.ReadKey();
        }
    }
}
