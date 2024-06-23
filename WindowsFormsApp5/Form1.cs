using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class mouse_player : Form
    {
        private List<(int x, int y, int delay)> recordedActions;
        private bool isRecording;
        public mouse_player()
        {
            InitializeComponent();
            recordedActions = new List<(int, int, int)>();
            isRecording = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            recordedActions.Clear();
            isRecording = true;
            MessageBox.Show("Kayıt başladı. İşlemlerinizi gerçekleştirin.");

            // Mouse hook to record actions
            MouseHook.Start(this);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            isRecording = false;
            MessageBox.Show("Kayıt Durduruldu");

            // Unhook mouse hook after recording
            MouseHook.Stop();
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            if (recordedActions.Count == 0)
            {
                MessageBox.Show("Tekrar oynatılacak kayıtlı eylem yok.");
                return;
            }

            MessageBox.Show("Kayıt Başlatılıyor Lütfen Fareye müdahalede bulunmayın");
            
            // Replay recorded actions
            foreach (var action in recordedActions)
            {
                Thread.Sleep(1000); // Bekleme süresi ekle
                Cursor.Position = new System.Drawing.Point(action.x, action.y);
                InputSimulator.MouseLeftButtonClick(); // Simulate left mouse button click
            }
            this.BringToFront();
            SystemSounds.Beep.Play();
            MessageBox.Show("Kayıt Bitti");

        }
        private void baslat()
        {
            if (recordedActions.Count == 0)
            {
                MessageBox.Show("Tekrar oynatılacak kayıtlı eylem yok.");
                return;
            }

            MessageBox.Show("Kayıt Başlatılıyor Lütfen Fareye müdahalede bulunmayın");

            // Replay recorded actions
            foreach (var action in recordedActions)
            {
                Thread.Sleep(1000); // Bekleme süresi ekle
                Cursor.Position = new System.Drawing.Point(action.x, action.y);
                InputSimulator.MouseLeftButtonClick(); // Simulate left mouse button click
            }
            MessageBox.Show("Kayıt Bitti");
        }
        private static class MouseHook
        {
            private static LowLevelMouseProc _proc;
            private static IntPtr _hookID;
            private static mouse_player _formInstance;

            public static void Start(mouse_player formInstance)
            {
                _formInstance = formInstance;
                _proc = HookCallback;
                _hookID = SetHook(_proc);
            }

            public static void Stop()
            {
                UnhookWindowsHookEx(_hookID);
            }

            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    if (_formInstance != null && _formInstance.isRecording)
                    {
                        _formInstance.recordedActions.Add((hookStruct.pt.x, hookStruct.pt.y, 0)); // Record mouse click
                    }
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            private const int WH_MOUSE_LL = 14;
            private const int WM_LBUTTONDOWN = 0x0201;

            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // F2 tuşuna basıldığında ReplayButton_Click metodunu çağır
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true; // Olayın işlendiğini belirt
                baslat();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }
    }

    // Input simulator class to simulate input events
    public static class InputSimulator
    {
        public static void MouseLeftButtonClick()
        {
            INPUT[] inputs = new INPUT[2];

            inputs[0] = new INPUT();
            inputs[0].type = InputType.MOUSE;
            inputs[0].u.mi.dx = 0;
            inputs[0].u.mi.dy = 0;
            inputs[0].u.mi.mouseData = 0;
            inputs[0].u.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;

            inputs[1] = new INPUT();
            inputs[1].type = InputType.MOUSE;
            inputs[1].u.mi.dx = 0;
            inputs[1].u.mi.dy = 0;
            inputs[1].u.mi.mouseData = 0;
            inputs[1].u.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;

            SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public InputType type;
            public MouseKeybdhardwareInputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct MouseKeybdhardwareInputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
        }

        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public MouseEventFlags dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        public enum InputType : uint
        {
            MOUSE = 0,
            KEYBOARD = 1,
            HARDWARE = 2
        }

        [Flags]
        public enum MouseEventFlags : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_ABSOLUTE = 0x8000
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
    }
}
