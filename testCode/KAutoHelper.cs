// C:\Users\Duy Phuong\Desktop\KAutoHelper.dll
// KAutoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

// Architecture: AnyCPU
// Runtime: .NET 4.0

using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyCompany("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyProduct("KAutoHelper")]
[assembly: AssemblyTitle("KAutoHelper")]
[assembly: AssemblyTrademark("")]
[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: ComVisible(false)]
[assembly: Guid("26c455c5-143c-4e6d-85f4-bbe85cde8a42")]
[assembly: TargetFramework(".NETFramework,Version=v4.5", FrameworkDisplayName = ".NET Framework 4.5")]
namespace KAutoHelper
{
	public class AutoControl
	{
		public delegate bool CallBack(IntPtr hwnd, IntPtr lParam);
		private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);
		[Flags]
		public enum MouseEventFlags : uint
		{
			LEFTDOWN = 2u,
			LEFTUP = 4u,
			MIDDLEDOWN = 32u,
			MIDDLEUP = 64u,
			MOVE = 1u,
			ABSOLUTE = 32768u,
			RIGHTDOWN = 8u,
			RIGHTUP = 16u
		}
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			public static readonly AutoControl.<>c <>9 = new AutoControl.<>c();
			public static Func<Process, bool> <>9__26_0;
			public static Func<Process, bool> <>9__27_0;
			public static AutoControl.EnumWindowProc <>9__31_0;
			internal bool <FindWindowHandlesFromProcesses>b__26_0(Process p)
			{
				return p.MainWindowHandle != IntPtr.Zero;
			}
			internal bool <FindWindowHandleFromProcesses>b__27_0(Process p)
			{
				return p.MainWindowHandle != IntPtr.Zero;
			}
			internal bool <GetChildHandle>b__31_0(IntPtr hWnd, IntPtr lParam)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(lParam);
				if (gCHandle.Target == null)
				{
					return false;
				}
				(gCHandle.Target as List<IntPtr>).Add(hWnd);
				return true;
			}
		}
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("User32.dll")]
		public static extern bool EnumChildWindows(IntPtr hWndParent, AutoControl.CallBack lpEnumFunc, IntPtr lParam);
		[DllImport("User32.dll")]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder s, int nMaxCount);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
		[DllImport("user32.dll")]
		private static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);
		[DllImport("user32.dll")]
		private static extern bool SetDlgItemTextA(IntPtr hWnd, int nIDDlgItem, string gchar);
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
		[DllImport("user32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumChildWindows(IntPtr window, AutoControl.EnumWindowProc callback, IntPtr lParam);
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
		public static IntPtr BringToFront(string className, string windowName = null)
		{
			IntPtr expr_07 = AutoControl.FindWindow(className, windowName);
			AutoControl.SetForegroundWindow(expr_07);
			return expr_07;
		}
		public static IntPtr BringToFront(IntPtr hWnd)
		{
			AutoControl.SetForegroundWindow(hWnd);
			return hWnd;
		}
		public static IntPtr FindWindowHandle(string className, string windowName)
		{
			IntPtr arg_05_0 = IntPtr.Zero;
			return AutoControl.FindWindow(className, windowName);
		}
		public static List<IntPtr> FindWindowHandlesFromProcesses(string className, string windowName, int maxCount = 1)
		{
			IEnumerable<Process> arg_2C_0 = Process.GetProcesses();
			List<IntPtr> list = new List<IntPtr>();
			int num = 0;
			Func<Process, bool> arg_2C_1;
			if ((arg_2C_1 = AutoControl.<>c.<>9__26_0) == null)
			{
				arg_2C_1 = (AutoControl.<>c.<>9__26_0 = new Func<Process, bool>(AutoControl.<>c.<>9.<FindWindowHandlesFromProcesses>b__26_0));
			}
			using (IEnumerator<Process> enumerator = arg_2C_0.Where(arg_2C_1).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IntPtr mainWindowHandle = enumerator.Current.MainWindowHandle;
					string arg_54_0 = AutoControl.GetClassName(mainWindowHandle);
					string text = AutoControl.GetText(mainWindowHandle);
					if (arg_54_0 == className || text == windowName)
					{
						list.Add(mainWindowHandle);
						if (num >= maxCount)
						{
							break;
						}
						num++;
					}
				}
			}
			return list;
		}
		public static IntPtr FindWindowHandleFromProcesses(string className, string windowName)
		{
			IEnumerable<Process> arg_2A_0 = Process.GetProcesses();
			IntPtr result = IntPtr.Zero;
			Func<Process, bool> arg_2A_1;
			if ((arg_2A_1 = AutoControl.<>c.<>9__27_0) == null)
			{
				arg_2A_1 = (AutoControl.<>c.<>9__27_0 = new Func<Process, bool>(AutoControl.<>c.<>9.<FindWindowHandleFromProcesses>b__27_0));
			}
			using (IEnumerator<Process> enumerator = arg_2A_0.Where(arg_2A_1).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IntPtr mainWindowHandle = enumerator.Current.MainWindowHandle;
					string className2 = AutoControl.GetClassName(mainWindowHandle);
					string text = AutoControl.GetText(mainWindowHandle);
					if (className2 == className || text == windowName)
					{
						result = mainWindowHandle;
						break;
					}
				}
			}
			return result;
		}
		public static IntPtr FindWindowExFromParent(IntPtr parentHandle, string text, string className)
		{
			return AutoControl.FindWindowEx(parentHandle, IntPtr.Zero, className, text);
		}
		private static IntPtr FindWindowByIndex(IntPtr hWndParent, int index)
		{
			if (index == 0)
			{
				return hWndParent;
			}
			int num = 0;
			IntPtr intPtr = IntPtr.Zero;
			do
			{
				intPtr = AutoControl.FindWindowEx(hWndParent, intPtr, "Button", null);
				if (intPtr != IntPtr.Zero)
				{
					num++;
				}
			}
			while (num < index && intPtr != IntPtr.Zero);
			return intPtr;
		}
		public static IntPtr GetControlHandleFromControlID(IntPtr parentHandle, int controlId)
		{
			return AutoControl.GetDlgItem(parentHandle, controlId);
		}
		public static List<IntPtr> GetChildHandle(IntPtr parentHandle)
		{
			List<IntPtr> list = new List<IntPtr>();
			GCHandle value = GCHandle.Alloc(list);
			IntPtr lParam = GCHandle.ToIntPtr(value);
			try
			{
				AutoControl.EnumWindowProc arg_33_0;
				if ((arg_33_0 = AutoControl.<>c.<>9__31_0) == null)
				{
					arg_33_0 = (AutoControl.<>c.<>9__31_0 = new AutoControl.EnumWindowProc(AutoControl.<>c.<>9.<GetChildHandle>b__31_0));
				}
				AutoControl.EnumWindowProc callback = arg_33_0;
				AutoControl.EnumChildWindows(parentHandle, callback, lParam);
			}
			finally
			{
				value.Free();
			}
			return list;
		}
		public static IntPtr FindHandleWithText(List<IntPtr> handles, string className, string text)
		{
			return handles.Find(delegate(IntPtr ptr)
			{
				string arg_13_0 = AutoControl.GetClassName(ptr);
				string text2 = AutoControl.GetText(ptr);
				return arg_13_0 == className || text2 == text;
			}
			);
		}
		public static IntPtr FindHandle(IntPtr parentHandle, string className, string text)
		{
			return AutoControl.FindHandleWithText(AutoControl.GetChildHandle(parentHandle), className, text);
		}
		public static bool CallbackChild(IntPtr hWnd, IntPtr lParam)
		{
			string arg_12_0 = AutoControl.GetText(hWnd);
			string className = AutoControl.GetClassName(hWnd);
			if (arg_12_0 == "&Options >>" && className.StartsWith("ToolbarWindow32"))
			{
				AutoControl.SendMessage(hWnd, 0, IntPtr.Zero, IntPtr.Zero);
				return false;
			}
			return true;
		}
		public static void SendClickOnControlById(IntPtr parentHWND, int controlID)
		{
			IntPtr dlgItem = AutoControl.GetDlgItem(parentHWND, controlID);
			int wParam = 0 | (controlID & 65535);
			AutoControl.SendMessage(parentHWND, 273, wParam, dlgItem);
		}
		public static void SendClickOnControlByHandle(IntPtr hWndButton)
		{
			AutoControl.SendMessage(hWndButton, 513, IntPtr.Zero, IntPtr.Zero);
			AutoControl.SendMessage(hWndButton, 514, IntPtr.Zero, IntPtr.Zero);
		}
		public static void SendClickOnPosition(IntPtr controlHandle, int x, int y, EMouseKey mouseButton = EMouseKey.LEFT, int clickTimes = 1)
		{
			int msg = 0;
			int msg2 = 0;
			if (mouseButton == EMouseKey.LEFT)
			{
				msg = 513;
				msg2 = 514;
			}
			if (mouseButton == EMouseKey.RIGHT)
			{
				msg = 516;
				msg2 = 517;
			}
			IntPtr lParam = AutoControl.MakeLParamFromXY(x, y);
			for (int i = 0; i < clickTimes; i++)
			{
				AutoControl.SendMessage(controlHandle, msg, new IntPtr(1), lParam);
				AutoControl.SendMessage(controlHandle, msg2, new IntPtr(1), lParam);
			}
		}
		public static void SendText(IntPtr handle, string text)
		{
			AutoControl.SendMessage(handle, 12, 0, text);
		}
		public static void SendKeyBoardPress(IntPtr handle, VKeys key)
		{
			AutoControl.SendKeyBoardDown(handle, key);
			AutoControl.SendKeyBoardUp(handle, key);
		}
		public static void SendKeyBoardUp(IntPtr handle, VKeys key)
		{
			AutoControl.PostMessage(handle, 257, new IntPtr((int)key), new IntPtr(0));
		}
		public static void SendKeyBoardDown(IntPtr handle, VKeys key)
		{
			AutoControl.PostMessage(handle, 256, new IntPtr((int)key), new IntPtr(0));
		}
		public static void SendTextKeyBoard(IntPtr handle, string text)
		{
			string text2 = text.ToLower();
			for (int i = 0; i < text2.Length; i++)
			{
				char c = text2[i];
				VKeys key = VKeys.VK_SELECT;
				if (c != ' ')
				{
					switch (c)
					{
					case '0':
						key = VKeys.VK_0;
						break;

					case '1':
						key = VKeys.VK_1;
						break;

					case '2':
						key = VKeys.VK_2;
						break;

					case '3':
						key = VKeys.VK_3;
						break;

					case '4':
						key = VKeys.VK_4;
						break;

					case '5':
						key = VKeys.VK_5;
						break;

					case '6':
						key = VKeys.VK_6;
						break;

					case '7':
						key = VKeys.VK_7;
						break;

					case '8':
						key = VKeys.VK_8;
						break;

					case '9':
						key = VKeys.VK_9;
						break;

					default:
						switch (c)
						{
						case 'a':
							key = VKeys.VK_A;
							break;

						case 'b':
							key = VKeys.VK_A;
							break;

						case 'c':
							key = VKeys.VK_C;
							break;

						case 'd':
							key = VKeys.VK_D;
							break;

						case 'e':
							key = VKeys.VK_E;
							break;

						case 'f':
							key = VKeys.VK_F;
							break;

						case 'g':
							key = VKeys.VK_G;
							break;

						case 'h':
							key = VKeys.VK_H;
							break;

						case 'i':
							key = VKeys.VK_I;
							break;

						case 'j':
							key = VKeys.VK_J;
							break;

						case 'k':
							key = VKeys.VK_K;
							break;

						case 'l':
							key = VKeys.VK_L;
							break;

						case 'm':
							key = VKeys.VK_M;
							break;

						case 'n':
							key = VKeys.VK_N;
							break;

						case 'o':
							key = VKeys.VK_O;
							break;

						case 'p':
							key = VKeys.VK_P;
							break;

						case 'q':
							key = VKeys.VK_Q;
							break;

						case 'r':
							key = VKeys.VK_R;
							break;

						case 's':
							key = VKeys.VK_S;
							break;

						case 't':
							key = VKeys.VK_T;
							break;

						case 'u':
							key = VKeys.VK_U;
							break;

						case 'v':
							key = VKeys.VK_V;
							break;

						case 'w':
							key = VKeys.VK_W;
							break;

						case 'x':
							key = VKeys.VK_X;
							break;

						case 'y':
							key = VKeys.VK_Y;
							break;

						case 'z':
							key = VKeys.VK_Z;
							break;
						}
						break;
					}
				}
				else
				{
					key = VKeys.VK_SPACE;
				}
				AutoControl.SendKeyBoardPress(handle, key);
			}
		}
		public static void SendKeyFocus(KeyCode key)
		{
			AutoControl.SendKeyPress(key);
		}
		public static void SendMultiKeysFocus(KeyCode[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				AutoControl.SendKeyDown(keys[i]);
			}
			for (int i = 0; i < keys.Length; i++)
			{
				AutoControl.SendKeyUp(keys[i]);
			}
		}
		public static void SendStringFocus(string message)
		{
			Clipboard.SetText(message);
			AutoControl.SendMultiKeysFocus(new KeyCode[]
			{
				KeyCode.CONTROL,
				KeyCode.KEY_V
			});
		}
		public static void SendKeyPress(KeyCode keyCode)
		{
			INPUT iNPUT = new INPUT
			{
				Type = 1u
			};
			iNPUT.Data.Keyboard = new KEYBDINPUT
			{
				Vk = (ushort)keyCode,
				Scan = 0,
				Flags = 0u,
				Time = 0u,
				ExtraInfo = IntPtr.Zero
			};
			INPUT iNPUT2 = new INPUT
			{
				Type = 1u
			};
			iNPUT2.Data.Keyboard = new KEYBDINPUT
			{
				Vk = (ushort)keyCode,
				Scan = 0,
				Flags = 2u,
				Time = 0u,
				ExtraInfo = IntPtr.Zero
			};
			INPUT[] inputs = new INPUT[]
			{
				iNPUT,
				iNPUT2
			};
			if (AutoControl.SendInput(2u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0u)
			{
				throw new Exception();
			}
		}
		public static void SendKeyDown(KeyCode keyCode)
		{
			INPUT iNPUT = new INPUT
			{
				Type = 1u
			};
			iNPUT.Data.Keyboard = default(KEYBDINPUT);
			iNPUT.Data.Keyboard.Vk = (ushort)keyCode;
			iNPUT.Data.Keyboard.Scan = 0;
			iNPUT.Data.Keyboard.Flags = 0u;
			iNPUT.Data.Keyboard.Time = 0u;
			iNPUT.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[]
			{
				iNPUT
			};
			if (AutoControl.SendInput(1u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0u)
			{
				throw new Exception();
			}
		}
		public static void SendKeyUp(KeyCode keyCode)
		{
			INPUT iNPUT = new INPUT
			{
				Type = 1u
			};
			iNPUT.Data.Keyboard = default(KEYBDINPUT);
			iNPUT.Data.Keyboard.Vk = (ushort)keyCode;
			iNPUT.Data.Keyboard.Scan = 0;
			iNPUT.Data.Keyboard.Flags = 2u;
			iNPUT.Data.Keyboard.Time = 0u;
			iNPUT.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[]
			{
				iNPUT
			};
			if (AutoControl.SendInput(1u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0u)
			{
				throw new Exception();
			}
		}
		public static void MouseClick(int x, int y, EMouseKey mouseKey = EMouseKey.LEFT)
		{
			Cursor.Position = new Point(x, y);
			AutoControl.Click(mouseKey);
		}
		public static void MouseClick(Point point, EMouseKey mouseKey = EMouseKey.LEFT)
		{
			Cursor.Position = point;
			AutoControl.Click(mouseKey);
		}
		public static void Click(EMouseKey mouseKey = EMouseKey.LEFT)
		{
			switch (mouseKey)
			{
			case EMouseKey.LEFT:
				AutoControl.mouse_event(32774u, 0u, 0u, 0u, UIntPtr.Zero);
				return;

			case EMouseKey.RIGHT:
				AutoControl.mouse_event(32792u, 0u, 0u, 0u, UIntPtr.Zero);
				return;

			case EMouseKey.DOUBLE_LEFT:
				AutoControl.mouse_event(32774u, 0u, 0u, 0u, UIntPtr.Zero);
				AutoControl.mouse_event(32774u, 0u, 0u, 0u, UIntPtr.Zero);
				return;

			case EMouseKey.DOUBLE_RIGHT:
				AutoControl.mouse_event(32792u, 0u, 0u, 0u, UIntPtr.Zero);
				AutoControl.mouse_event(32792u, 0u, 0u, 0u, UIntPtr.Zero);
				return;

			default:
				return;
			}
		}
		public static RECT GetWindowRect(IntPtr hWnd)
		{
			RECT result = default(RECT);
			AutoControl.GetWindowRect(hWnd, ref result);
			return result;
		}
		public static Point GetGlobalPoint(IntPtr hWnd, Point? point = null)
		{
			Point result = default(Point);
			RECT windowRect = AutoControl.GetWindowRect(hWnd);
			if (!point.HasValue)
			{
				point = new Point?(default(Point));
			}
			result.X = point.Value.X + windowRect.Left;
			result.Y = point.Value.Y + windowRect.Top;
			return result;
		}
		public static Point GetGlobalPoint(IntPtr hWnd, int x = 0, int y = 0)
		{
			Point result = default(Point);
			RECT windowRect = AutoControl.GetWindowRect(hWnd);
			result.X = x + windowRect.Left;
			result.Y = y + windowRect.Top;
			return result;
		}
		public static string GetText(IntPtr hWnd)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			AutoControl.GetWindowText(hWnd, stringBuilder, 256);
			return stringBuilder.ToString().Trim();
		}
		public static string GetClassName(IntPtr hWnd)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			AutoControl.GetClassName(hWnd, stringBuilder, 256);
			return stringBuilder.ToString().Trim();
		}
		public static IntPtr MakeLParam(int LoWord, int HiWord)
		{
			return (IntPtr)(HiWord << 16 | (LoWord & 65535));
		}
		public static IntPtr MakeLParamFromXY(int x, int y)
		{
			return (IntPtr)(y << 16 | x);
		}
	}
	public class CaptureHelper
	{
		private class GDI32
		{
			public const int SRCCOPY = 13369376;
			[DllImport("gdi32.dll")]
			public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
			[DllImport("gdi32.dll")]
			public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
			[DllImport("gdi32.dll")]
			public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
			[DllImport("gdi32.dll")]
			public static extern bool DeleteDC(IntPtr hDC);
			[DllImport("gdi32.dll")]
			public static extern bool DeleteObject(IntPtr hObject);
			[DllImport("gdi32.dll")]
			public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
		}
		private class User32
		{
			public struct RECT
			{
				public int left;
				public int top;
				public int right;
				public int bottom;
			}
			[DllImport("user32.dll")]
			public static extern IntPtr GetDesktopWindow();
			[DllImport("user32.dll")]
			public static extern IntPtr GetWindowDC(IntPtr hWnd);
			[DllImport("user32.dll")]
			public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
			[DllImport("user32.dll")]
			public static extern IntPtr GetWindowRect(IntPtr hWnd, ref CaptureHelper.User32.RECT rect);
		}
		public static int X;
		public static int Y;
		public static Image CaptureScreen()
		{
			return CaptureHelper.CaptureWindow(CaptureHelper.User32.GetDesktopWindow());
		}
		public static Image CaptureWindow(IntPtr handle)
		{
			IntPtr windowDC = CaptureHelper.User32.GetWindowDC(handle);
			CaptureHelper.User32.RECT rECT = default(CaptureHelper.User32.RECT);
			CaptureHelper.User32.GetWindowRect(handle, ref rECT);
			int nWidth = rECT.right - rECT.left;
			int nHeight = rECT.bottom - rECT.top;
			IntPtr arg_44_0 = CaptureHelper.GDI32.CreateCompatibleDC(windowDC);
			IntPtr intPtr = CaptureHelper.GDI32.CreateCompatibleBitmap(windowDC, nWidth, nHeight);
			IntPtr hObject = CaptureHelper.GDI32.SelectObject(arg_44_0, intPtr);
			CaptureHelper.GDI32.BitBlt(arg_44_0, 0, 0, nWidth, nHeight, windowDC, 0, 0, 13369376);
			CaptureHelper.GDI32.SelectObject(arg_44_0, hObject);
			CaptureHelper.GDI32.DeleteDC(arg_44_0);
			CaptureHelper.User32.ReleaseDC(handle, windowDC);
			Image arg_87_0 = Image.FromHbitmap(intPtr);
			CaptureHelper.GDI32.DeleteObject(intPtr);
			return arg_87_0;
		}
		public static void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
		{
			CaptureHelper.CaptureWindow(handle).Save(filename, format);
		}
		public static void CaptureScreenToFile(string filename, ImageFormat format)
		{
			CaptureHelper.CaptureScreen().Save(filename, format);
		}
		public static Bitmap CaptureImage(Size size, Point position)
		{
			Bitmap result;
			try
			{
				Bitmap expr_18 = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppRgb);
				Graphics.FromImage(expr_18).CopyFromScreen(position.X + CaptureHelper.X, position.Y + CaptureHelper.Y, 0, 0, size, CopyPixelOperation.SourceCopy);
				result = expr_18;
			}
			catch
			{
				result = null;
			}
			return result;
		}
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject([In] IntPtr hObject);
		public static Bitmap CropImage(Image img, Rectangle cropRect)
		{
			Bitmap image = img as Bitmap;
			Bitmap bitmap = new Bitmap(cropRect.Width, cropRect.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), cropRect, GraphicsUnit.Pixel);
			}
			return bitmap;
		}
		public static Bitmap CropImage(Bitmap img, Rectangle cropRect)
		{
			Bitmap bitmap = new Bitmap(cropRect.Width, cropRect.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(img, new Rectangle(0, 0, bitmap.Width, bitmap.Height), cropRect, GraphicsUnit.Pixel);
			}
			return bitmap;
		}
	}
	public enum WMessages
	{
		WM_LBUTTONDOWN = 513,
		WM_LBUTTONUP,
		WM_LBUTTONDBLCLK,
		WM_RBUTTONDOWN,
		WM_RBUTTONUP,
		WM_RBUTTONDBLCLK,
		WM_KEYDOWN = 256,
		WM_KEYUP,
		BN_CLICKED = 0,
		WM_COMMAND = 273,
		WM_SETTEXT = 12,
		WM_CHAR = 258,
		BM_CLICK = 245,
		WM_SYSKEYDOWN = 260,
		WM_SYSKEYUP
	}
	public enum VKeys
	{
		VK_LBUTTON = 1,
		VK_RBUTTON,
		VK_CANCEL,
		VK_MBUTTON,
		VK_BACK = 8,
		VK_TAB,
		VK_CLEAR = 12,
		VK_RETURN,
		VK_SHIFT = 16,
		VK_CONTROL,
		VK_MENU,
		VK_PAUSE,
		VK_CAPITAL,
		VK_ESCAPE = 27,
		VK_SPACE = 32,
		VK_PRIOR,
		VK_NEXT,
		VK_END,
		VK_HOME,
		VK_LEFT,
		VK_UP,
		VK_RIGHT,
		VK_DOWN,
		VK_SELECT,
		VK_PRINT,
		VK_EXECUTE,
		VK_SNAPSHOT,
		VK_INSERT,
		VK_DELETE,
		VK_HELP,
		VK_0,
		VK_1,
		VK_2,
		VK_3,
		VK_4,
		VK_5,
		VK_6,
		VK_7,
		VK_8,
		VK_9,
		VK_A = 65,
		VK_B,
		VK_C,
		VK_D,
		VK_E,
		VK_F,
		VK_G,
		VK_H,
		VK_I,
		VK_J,
		VK_K,
		VK_L,
		VK_M,
		VK_N,
		VK_O,
		VK_P,
		VK_Q,
		VK_R,
		VK_S,
		VK_T,
		VK_U,
		VK_V,
		VK_W,
		VK_X,
		VK_Y,
		VK_Z,
		VK_NUMPAD0 = 96,
		VK_NUMPAD1,
		VK_NUMPAD2,
		VK_NUMPAD3,
		VK_NUMPAD4,
		VK_NUMPAD5,
		VK_NUMPAD6,
		VK_NUMPAD7,
		VK_NUMPAD8,
		VK_NUMPAD9,
		VK_SEPARATOR = 108,
		VK_SUBTRACT,
		VK_DECIMAL,
		VK_DIVIDE,
		VK_F1,
		VK_F2,
		VK_F3,
		VK_F4,
		VK_F5,
		VK_F6,
		VK_F7,
		VK_F8,
		VK_F9,
		VK_F10,
		VK_F11,
		VK_F12,
		VK_SCROLL = 145,
		VK_LSHIFT = 160,
		VK_RSHIFT,
		VK_LCONTROL,
		VK_RCONTROL,
		VK_LMENU,
		VK_RMENU,
		VK_PLAY = 250,
		VK_ZOOM
	}
	public enum EMouseKey
	{
		LEFT,
		RIGHT,
		DOUBLE_LEFT,
		DOUBLE_RIGHT
	}
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
	}
	public struct INPUT
	{
		public uint Type;
		public MOUSEKEYBDHARDWAREINPUT Data;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct MOUSEKEYBDHARDWAREINPUT
	{
		[FieldOffset(0)]
		public HARDWAREINPUT Hardware;
		[FieldOffset(0)]
		public KEYBDINPUT Keyboard;
		[FieldOffset(0)]
		public MOUSEINPUT Mouse;
	}
	public struct HARDWAREINPUT
	{
		public uint Msg;
		public ushort ParamL;
		public ushort ParamH;
	}
	public struct KEYBDINPUT
	{
		public ushort Vk;
		public ushort Scan;
		public uint Flags;
		public uint Time;
		public IntPtr ExtraInfo;
	}
	public struct MOUSEINPUT
	{
		public int X;
		public int Y;
		public uint MouseData;
		public uint Flags;
		public uint Time;
		public IntPtr ExtraInfo;
	}
	public enum KeyCode : ushort
	{
		MEDIA_NEXT_TRACK = 176,
		MEDIA_PLAY_PAUSE = 179,
		MEDIA_PREV_TRACK = 177,
		MEDIA_STOP,
		ADD = 107,
		MULTIPLY = 106,
		DIVIDE = 111,
		SUBTRACT = 109,
		BROWSER_BACK = 166,
		BROWSER_FAVORITES = 171,
		BROWSER_FORWARD = 167,
		BROWSER_HOME = 172,
		BROWSER_REFRESH = 168,
		BROWSER_SEARCH = 170,
		BROWSER_STOP = 169,
		NUMPAD0 = 96,
		NUMPAD1,
		NUMPAD2,
		NUMPAD3,
		NUMPAD4,
		NUMPAD5,
		NUMPAD6,
		NUMPAD7,
		NUMPAD8,
		NUMPAD9,
		F1 = 112,
		F10 = 121,
		F11,
		F12,
		F13,
		F14,
		F15,
		F16,
		F17,
		F18,
		F19,
		F2 = 113,
		F20 = 131,
		F21,
		F22,
		F23,
		F24,
		F3 = 114,
		F4,
		F5,
		F6,
		F7,
		F8,
		F9,
		OEM_1 = 186,
		OEM_102 = 226,
		OEM_2 = 191,
		OEM_3,
		OEM_4 = 219,
		OEM_5,
		OEM_6,
		OEM_7,
		OEM_8,
		OEM_CLEAR = 254,
		OEM_COMMA = 188,
		OEM_MINUS,
		OEM_PERIOD,
		OEM_PLUS = 187,
		KEY_0 = 48,
		KEY_1,
		KEY_2,
		KEY_3,
		KEY_4,
		KEY_5,
		KEY_6,
		KEY_7,
		KEY_8,
		KEY_9,
		KEY_A = 65,
		KEY_B,
		KEY_C,
		KEY_D,
		KEY_E,
		KEY_F,
		KEY_G,
		KEY_H,
		KEY_I,
		KEY_J,
		KEY_K,
		KEY_L,
		KEY_M,
		KEY_N,
		KEY_O,
		KEY_P,
		KEY_Q,
		KEY_R,
		KEY_S,
		KEY_T,
		KEY_U,
		KEY_V,
		KEY_W,
		KEY_X,
		KEY_Y,
		KEY_Z,
		VOLUME_DOWN = 174,
		VOLUME_MUTE = 173,
		VOLUME_UP = 175,
		SNAPSHOT = 44,
		RightClick = 93,
		BACKSPACE = 8,
		CANCEL = 3,
		CAPS_LOCK = 20,
		CONTROL = 17,
		ALT,
		DECIMAL = 110,
		DELETE = 46,
		DOWN = 40,
		END = 35,
		ESC = 27,
		HOME = 36,
		INSERT = 45,
		LAUNCH_APP1 = 182,
		LAUNCH_APP2,
		LAUNCH_MAIL = 180,
		LAUNCH_MEDIA_SELECT,
		LCONTROL = 162,
		LEFT = 37,
		LSHIFT = 160,
		LWIN = 91,
		PAGEDOWN = 34,
		NUMLOCK = 144,
		PAGE_UP = 33,
		RCONTROL = 163,
		ENTER = 13,
		RIGHT = 39,
		RSHIFT = 161,
		RWIN = 92,
		SHIFT = 16,
		SPACE_BAR = 32,
		TAB = 9,
		UP = 38
	}
	public class ImageScanOpenCV
	{
		public static Bitmap GetImage(string path)
		{
			return new Bitmap(path);
		}
		public static Bitmap Find(string main, string sub, double percent = 0.9)
		{
			ImageScanOpenCV.GetImage(main);
			ImageScanOpenCV.GetImage(sub);
			return ImageScanOpenCV.Find(main, sub, percent);
		}
		public static Bitmap Find(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Image<Bgr, byte> arg_0D_0 = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> image = new Image<Bgr, byte>(subBitmap);
			Image<Bgr, byte> image2 = arg_0D_0.Copy();
			using (Image<Gray, float> image3 = arg_0D_0.MatchTemplate(image, 5))
			{
				double[] array;
				double[] array2;
				Point[] array3;
				Point[] array4;
				image3.MinMax(ref array, ref array2, ref array3, ref array4);
				if (array2[0] > percent)
				{
					Rectangle rectangle = new Rectangle(array4[0], image.get_Size());
					image2.Draw(rectangle, new Bgr(Color.Red), 2, 8, 0);
				}
				else
				{
					image2 = null;
				}
			}
			if (image2 != null)
			{
				return image2.ToBitmap();
			}
			return null;
		}
		public static Point? FindOutPoint(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Image<Bgr, byte> arg_17_0 = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> image = new Image<Bgr, byte>(subBitmap);
			Point? result = null;
			using (Image<Gray, float> image2 = arg_17_0.MatchTemplate(image, 5))
			{
				double[] array;
				double[] array2;
				Point[] array3;
				Point[] array4;
				image2.MinMax(ref array, ref array2, ref array3, ref array4);
				if (array2[0] > percent)
				{
					result = new Point?(array4[0]);
				}
			}
			return result;
		}
	}
	internal class ThamKhao
	{
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
		public void SendKeyPress(KeyCode keyCode)
		{
			INPUT iNPUT = new INPUT
			{
				Type = 1u
			};
			iNPUT.Data.Keyboard = new KEYBDINPUT
			{
				Vk = (ushort)keyCode,
				Scan = 0,
				Flags = 0u,
				Time = 0u,
				ExtraInfo = IntPtr.Zero
			};
			INPUT iNPUT2 = new INPUT
			{
				Type = 1u
			};
			iNPUT2.Data.Keyboard = new KEYBDINPUT
			{
				Vk = (ushort)keyCode,
				Scan = 0,
				Flags = 2u,
				Time = 0u,
				ExtraInfo = IntPtr.Zero
			};
			INPUT[] inputs = new INPUT[]
			{
				iNPUT,
				iNPUT2
			};
			if (ThamKhao.SendInput(2u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0u)
			{
				throw new Exception();
			}
		}
		public void SendKeyDown(KeyCode keyCode)
		{
			INPUT iNPUT = new INPUT
			{
				Type = 1u
			};
			iNPUT.Data.Keyboard = default(KEYBDINPUT);
			iNPUT.Data.Keyboard.Vk = (ushort)keyCode;
			iNPUT.Data.Keyboard.Scan = 0;
			iNPUT.Data.Keyboard.Flags = 0u;
			iNPUT.Data.Keyboard.Time = 0u;
			iNPUT.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[]
			{
				iNPUT
			};
			if (ThamKhao.SendInput(1u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0u)
			{
				throw new Exception();
			}
		}
		public void SendKeyUp(KeyCode keyCode)
		{
			INPUT iNPUT = new INPUT
			{
				Type = 1u
			};
			iNPUT.Data.Keyboard = default(KEYBDINPUT);
			iNPUT.Data.Keyboard.Vk = (ushort)keyCode;
			iNPUT.Data.Keyboard.Scan = 0;
			iNPUT.Data.Keyboard.Flags = 2u;
			iNPUT.Data.Keyboard.Time = 0u;
			iNPUT.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[]
			{
				iNPUT
			};
			if (ThamKhao.SendInput(1u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0u)
			{
				throw new Exception();
			}
		}
	}
}
