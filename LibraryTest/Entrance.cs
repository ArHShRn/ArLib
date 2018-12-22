using System;
using ArLib.Console;

namespace LibraryTest
{
    class Entrance
    {
        static void Main(string[] args)
        {
            ARConsole.CreateConsole(false, "ARConsole", false);

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
    }
}
