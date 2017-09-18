﻿using System;
using System.Runtime.InteropServices;

namespace Anapher.Wpf.Swan.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct CWPRETSTRUCT
    {
        public IntPtr lResult;
        public IntPtr lParam;
        public IntPtr wParam;
        public uint message;
        public IntPtr hwnd;
    }
}