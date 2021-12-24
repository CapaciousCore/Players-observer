using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Players_observer
{
    class ProcessMemoryReader
    {
        private Process ReadProcess { get; set; }
        private readonly IntPtr ProcessHandle;
        public int BaseAddress { get; private set; }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 DesiredAccess, Int32 InheritHandle, UInt32 ProcessID);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr ProcessHandle);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr ProcessHandle, IntPtr BaseAddress, [In, Out] byte[] Buffer, UInt32 Size, out IntPtr NumberOfBytesRead);

        public ProcessMemoryReader(string ProcessName)
        {
            try
            {
                Process ReadProcess = Process.GetProcessesByName(ProcessName)[0];

                if (ReadProcess != null)
                {                    
                    ProcessHandle = OpenProcess(0x10, 1, (uint)ReadProcess.Id);
                    BaseAddress = ReadProcess.MainModule.BaseAddress.ToInt32();
                }
            }
            catch (IndexOutOfRangeException e)
            {
                ReadProcess = null;
            }
        }

        ~ProcessMemoryReader()
        {
            if (ProcessHandle != IntPtr.Zero)
            {
                CloseHandle(ProcessHandle);
            }
        }

        private int ReadMemory(int MemoryAddress, uint BytesToRead, out byte[] Buffer)
        {
            if (ProcessHandle == IntPtr.Zero)
            {
                Buffer = new byte[0];

                return 0;
            }
            else
            {
                Buffer = new byte[BytesToRead];
                IntPtr BytesReaded;
                ReadProcessMemory(ProcessHandle, (IntPtr)MemoryAddress, Buffer, BytesToRead, out BytesReaded);

                return BytesReaded.ToInt32();
            }
        }

        public byte ReadByte(int MemoryAddress)
        {
            byte[] Buffer;
            int BytesReaded = ReadMemory(MemoryAddress, 1, out Buffer);

            if (BytesReaded == 0)
            {
                return new byte();
            }
            else
            {
                return Buffer[0];
            }
        }

        public byte[] ReadBytes(int MemoryAddress, uint Length)
        {
            byte[] Buffer;
            int BytesReaded = ReadMemory(MemoryAddress, Length, out Buffer);

            if (BytesReaded == 0)
            {
                return new byte[Length];
            }
            else
            {
                return Buffer;
            }
        }

        public int ReadInt(int MemoryAddress)
        {
            byte[] Buffer;
            int BytesReaded = ReadMemory(MemoryAddress, 4, out Buffer);

            if (BytesReaded == 0)
            {
                return 0;
            }
            else
            {
                return BitConverter.ToInt32(Buffer, 0);
            }
        }

        public float ReadFloat(int MemoryAddress)
        {
            byte[] Buffer;
            int BytesReaded = ReadMemory(MemoryAddress, 4, out Buffer);

            if (BytesReaded == 0)
            {
                return 0;
            }
            else
            {
                return BitConverter.ToSingle(Buffer, 0);
            }
        }
    }
}