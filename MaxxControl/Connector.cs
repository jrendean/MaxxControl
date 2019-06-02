using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace MaxxControl
{
    public class Connector
    {
        [DllImport("coredll.dll")]
        static extern IntPtr CreateFile(String lpFileName, UInt32 dwDesiredAccess, UInt32 dwShareMode, IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("coredll.dll")]
        static extern Boolean CloseHandle(IntPtr hObject);

        [DllImport("coredll.dll")]
        static extern int WriteFile(IntPtr fFile, Byte[] lpBuffer, UInt32 nNumberOfBytesToWrite, out UInt32 lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("coredll.dll")]
        static extern int ReadFile(IntPtr fFile, Byte[] lpBuffer, UInt32 nNumberOfBytesToRead, ref Int32 lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("coredll.dll", SetLastError = true)]
        static extern Int32 GetLastError();

        private IntPtr fileHandle;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint GENERIC_READ = 0x80000000;
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint OPEN_EXISTING = 3;


        public Connector()
        {
        }

        public bool Connect(string comPort)
        {
            fileHandle = CreateFile("COM" + comPort + ":", GENERIC_WRITE | GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            //fileHandle = CreateFile("COM" + comPort + ":", GENERIC_WRITE | GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            return fileHandle != new IntPtr(-1);				
        }

        public bool Disconnect()
        {
            return CloseHandle(fileHandle);
        }

        public string Write(string dataToWrite)
        {
            uint written;
			dataToWrite = ("s:" + dataToWrite).PadRight(7, ' ');
			int result = WriteFile(fileHandle, Encoding.ASCII.GetBytes(dataToWrite), (uint)dataToWrite.Length, out written, IntPtr.Zero);

			//if (direction.StartsWith("g:"))
			//{
			//    uint maxBytes = 10;
			//    byte[] inputData = new byte[maxBytes];
			//    int bytesRead = 0;

			//    ReadFile(fileHandle, inputData, maxBytes, ref bytesRead, IntPtr.Zero);
                
			//    if (inputData == null)
			//        return "No data returned";
			//    else
			//        return Encoding.ASCII.GetString(inputData, 0, bytesRead);
			//}
			//else
                return String.Empty;
        }

    }
}
