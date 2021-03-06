﻿//=============================================================================
// ArLIB Console : Windows CUI Console Class
// Introduction :
//  Using Windows API, Eusth did this all. I just modified
//   it into my LIB class.
//  This class allocates current running thread a console,
//   and handles everything that needs to control the allocated console.
// 
// Code And Concept By Eusth
// https://github.com/Eusth
// Modified By ArHShRn
// https://github.com/ArHShRn
// Microsoft Docs
// https://docs.microsoft.com/en-us/windows/console/console-functions
//
//=============================================================================
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ArLib.Console
{
    /// <summary>
    /// A helper class to create a console.
    /// </summary>
    class CuiConsole
    {
        private static bool hasConsole = false;

        private static IntPtr conOut;
        private static IntPtr oldOut;

        /// <summary>
        /// [WINDOWS API] ALLOCATE A CONSOLE
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        /// <summary>
        /// [WINDOWS API] RELEASE CREATED CONSOLE
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = false)]
        private static extern bool FreeConsole();

        [DllImport("kernel32.dll", SetLastError = false)]
        private static extern bool SetConsoleTitle(string lpConsoleTitle);

        /// <summary>
        /// [WINDOWS API] GET A HANDLE FROM A STANDARD DEVICE
        /// (INPUT, OUTPUT, ERROR STREAM)
        /// </summary>
        /// <param name="nStdHandle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        /// <summary>
        /// [WINDOWS API] SET A HANDLE TO A STANDARD DEVICE
        /// (OUTPUT STREAM)
        /// </summary>
        /// <param name="nStdHandle"></param>
        /// <param name="hConsoleOutput"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetStdHandle(int nStdHandle, IntPtr hConsoleOutput);

        /// <summary>
        /// [WINDOWS API] CREATE OR OPEN A FILE OR A DEVICE.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="desiredAccess"></param>
        /// <param name="shareMode"></param>
        /// <param name="securityAttributes"></param>
        /// <param name="creationDisposition"></param>
        /// <param name="flagsAndAttributes"></param>
        /// <param name="templateFile"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFile(
                string fileName,
                int desiredAccess,
                int shareMode,
                IntPtr securityAttributes,
                int creationDisposition,
                int flagsAndAttributes,
                IntPtr templateFile);

        /// <summary>
        /// [WINDOWS API] CLOSE A HANDLE
        /// (FILES, FILE MAPPINGS, THREADS ETC.)
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// Create current thread a console window.
        /// </summary>
        public static void CreateConsole(string title = @"ArHShRn CUI Logger")
        {
            if (hasConsole)
                return;

            if (oldOut == IntPtr.Zero)
                oldOut = GetStdHandle(-11);

            if (!AllocConsole())
                throw new Exception("AllocConsole() Failed. The current process may have a console.");

            conOut = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, 3, 0, IntPtr.Zero);

            if (!SetStdHandle(-11, conOut))
                throw new Exception("SetStdHandle() Failed.");

            if (!SetConsoleTitle(title))
                throw new Exception("SetConsoleTitle Failed.");

            StreamToConsole();

            hasConsole = true;
        }

        /// <summary>
        /// Release the console created before.
        /// </summary>
        public static void ReleaseConsole()
        {
            if (!hasConsole)
                return;

            if (!CloseHandle(conOut))
                throw new Exception("Failed to close cureent console handle.");

            conOut = IntPtr.Zero;
            if (!FreeConsole())
                throw new Exception("Failed to free current console.");

            if (!SetStdHandle(-11, oldOut))
                throw new Exception("Failed to set standard handle.");

            StreamToConsole();

            hasConsole = false;
        }

        /// <summary>
        /// Redirect the stream to console created before.
        /// </summary>
        private static void StreamToConsole()
        {
            Stream cstm = System.Console.OpenStandardOutput();
            StreamWriter cstw = new StreamWriter(cstm, Encoding.Default)
            {
                AutoFlush = true
            };

            System.Console.SetOut(cstw);
            System.Console.SetError(cstw);
        }
    }
}
