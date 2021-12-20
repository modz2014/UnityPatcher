using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace UnityPatcher
{
	public class Patcher : IDisposable
	{
		public class PatcherState
		{
			public readonly uint Fail;

			public readonly bool FileHasChanged;

			public readonly uint Good;

			public readonly string StringState;

			public PatcherState(bool fileHasChanged, uint good, uint fail, string stringState = "")
			{
				FileHasChanged = fileHasChanged;
				Good = good;
				Fail = fail;
				StringState = stringState;
			}
		}

		public struct MainPattern
		{
			public readonly Pattern Ptrn;

			public readonly long[] StreamPosition;

			public int SuccessfullyFound
			{
				get
				{
					if (StreamPosition == null)
					{
						return 0;
					}
					return StreamPosition.Length;
				}
			}

			public bool Success
			{
				get
				{
					if (StreamPosition == null)
					{
						return false;
					}
					if (Ptrn.BrakAfter < 1 && StreamPosition.Length != 0)
					{
						return true;
					}
					return Ptrn.BrakAfter - Ptrn.ReplaceAfter == StreamPosition.Length;
				}
			}

			public MainPattern(Pattern ptrn, long[] streamPosition)
			{
				if (ptrn == null)
				{
					throw new ArgumentNullException("Pattern.");
				}
				Ptrn = ptrn;
				StreamPosition = streamPosition;
			}
		}

		public class Pattern
		{
			public struct UniversalByte
			{
				public enum Action
				{
					Skip,
					Normal
				}

				public Action Act;

				public byte B;
			}

			public readonly UniversalByte[] ReplaceBytes;

			public readonly UniversalByte[] SearchBytes;

			private readonly bool _valid;

			public uint BrakAfter;

			public uint ReplaceAfter;

			public bool ValidPattern
			{
				get
				{
					if (BrakAfter != 0 && BrakAfter - ReplaceAfter < 1)
					{
						return false;
					}
					return _valid;
				}
			}

			public bool ReplaceImmediately { get; }

			public Pattern(string se, string rep, uint brakAfter = 1u, uint replaceAfter = 0u)
			{
				if (string.IsNullOrEmpty(se))
				{
					throw new ArgumentException("Input string null or empty.");
				}
				BrakAfter = brakAfter;
				ReplaceAfter = replaceAfter;
				if (rep == null)
				{
					SearchBytes = TryParse(se);
					ReplaceImmediately = false;
					_valid = true;
				}
				else
				{
					SearchBytes = TryParse(se);
					ReplaceBytes = TryParse(rep);
					ReplaceImmediately = true;
					_valid = true;
				}
			}

			private UniversalByte[] TryParse(string st)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (char c in st)
				{
					if (c > ' ' && c < '\u007f')
					{
						stringBuilder.Append(c);
					}
				}
				string text = stringBuilder.ToString().ToUpper();
				if (text.Length % 2 != 0)
				{
					throw new Exception("String of byte must be power of two.");
				}
				bool flag = false;
				UniversalByte[] array = new UniversalByte[text.Length / 2];
				int num = 0;
				for (int j = 0; j < text.Length; j += 2)
				{
					string text2 = text.Substring(j, 2);
					if (text2 == "??")
					{
						array[num].Act = UniversalByte.Action.Skip;
					}
					else
					{
						array[num].Act = UniversalByte.Action.Normal;
						array[num].B = byte.Parse(text2, NumberStyles.HexNumber);
						flag = true;
					}
					num++;
				}
				if (!flag)
				{
					throw new ArgumentNullException("Can't add the string of byte (Does not make sense).");
				}
				return array;
			}
		}

		private int _bufferSize = 2048;

		public string FileName;

		private FileStream _fs;

		private bool _isDisposed;

		private string[] _succesMessages = new string[5] { "Pattern not found!!", "Patched!!", "Patched but result is other!!", "Found!!", "Found but result is other!!" };

		public PatcherState CurrentState { get; private set; }

		public string[] SuccesMessages
		{
			get
			{
				return _succesMessages;
			}
			set
			{
				if (value != null && value.Length == 5)
				{
					_succesMessages = value;
				}
			}
		}

		public int BufferSize
		{
			get
			{
				return _bufferSize;
			}
			set
			{
				_bufferSize = ((value < 16) ? 16 : value);
			}
		}

		public List<Pattern> Patterns { get; }

		public Patcher()
		{
			Patterns = new List<Pattern>();
		}

		public Patcher(string filename)
		{
			Patterns = new List<Pattern>();
			FileName = filename;
		}

		public Patcher(string filename, List<Pattern> patterns)
		{
			if (Patterns == null)
			{
				throw new ArgumentNullException("patterns.");
			}
			if (Patterns.Count == 0)
			{
				throw new ArgumentOutOfRangeException("Collection is empty: patterns.");
			}
			Patterns = patterns;
			FileName = filename;
		}

		public bool AddString(string se, string rep, uint brakAfter = 1u, uint replaceAfter = 0u)
		{
			try
			{
				Patterns.Add(new Pattern(se, rep, brakAfter, replaceAfter));
			}
			catch (Exception ex)
			{
				NLogger.Warn($"AddString: {ex.GetType()}: {ex.Message}");
				return false;
			}
			return true;
		}

		public bool Patch()
		{
			if (Patterns == null)
			{
				NLogger.Error("ArgumentNullException: patterns.");
				return false;
			}
			Patterns.RemoveAll((Pattern item) => item == null);
			if (Patterns.Count == 0)
			{
				NLogger.Error("Collection is empty: patterns.");
				return false;
			}
			uint num = 0u;
			uint num2 = 0u;
			bool flag = false;
			try
			{
				_fs = CreateStream(FileName);
				foreach (Pattern pattern in Patterns)
				{
					MainPattern pt = FindAllPatterns(pattern);
					if (pt.SuccessfullyFound > 0)
					{
						if (ReplaceAllPatterns(pt))
						{
							flag = true;
						}
						if (pt.Success)
						{
							num2++;
							continue;
						}
						num2++;
						num++;
					}
					else
					{
						num++;
					}
				}
			}
			catch (Exception ex)
			{
				if (_fs != null)
				{
					_fs.Dispose();
					_fs = null;
				}
				NLogger.Error($"{ex.GetType()}: {ex.Message}");
				return false;
			}
			if (_fs != null)
			{
				_fs.Close();
				_fs = null;
			}
			if (flag)
			{
				if (num != 0 && num2 != 0)
				{
					NLogger.Debug(_succesMessages[2]);
					CurrentState = new PatcherState(flag, num2, num, _succesMessages[2]);
					return true;
				}
				if (num == 0 && num2 != 0)
				{
					NLogger.Debug(_succesMessages[1]);
					CurrentState = new PatcherState(flag, num2, num, _succesMessages[1]);
					return true;
				}
				CurrentState = new PatcherState(flag, num2, num, _succesMessages[0]);
				NLogger.Debug(_succesMessages[0]);
			}
			else
			{
				if (num != 0 && num2 != 0)
				{
					CurrentState = new PatcherState(flag, num2, num, _succesMessages[4]);
					NLogger.Debug(_succesMessages[4]);
					return true;
				}
				if (num == 0 && num2 != 0)
				{
					CurrentState = new PatcherState(flag, num2, num, _succesMessages[3]);
					NLogger.Debug(_succesMessages[3]);
					return true;
				}
				CurrentState = new PatcherState(flag, num2, num, _succesMessages[0]);
				NLogger.Debug(_succesMessages[0]);
			}
			return false;
		}

		private MainPattern FindAllPatterns(Pattern pt)
		{
			if (_isDisposed)
			{
				throw new ObjectDisposedException("Object was disposed.");
			}
			if (pt == null)
			{
				throw new ArgumentNullException("Pattern");
			}
			if (!pt.ValidPattern)
			{
				return new MainPattern(pt, null);
			}
			long num = 0L;
			int num2 = 0;
			int num3 = 0;
			uint num4 = 0u;
			uint num5 = 0u;
			byte[] array = new byte[_bufferSize];
			int num6 = _bufferSize;
			Pattern.UniversalByte[] searchBytes = pt.SearchBytes;
			List<long> list = new List<long>();
			if (_isDisposed)
			{
				throw new ObjectDisposedException("Object was disposed.");
			}
			_fs.Position = 0L;
			while (num6 > 0)
			{
				if (_isDisposed)
				{
					throw new ObjectDisposedException("Object was disposed.");
				}
				long position = _fs.Position;
				num6 = _fs.Read(array, 0, array.Length);
				for (int i = 0; i < num6; i++)
				{
					if (searchBytes[num3].Act == Pattern.UniversalByte.Action.Skip || array[i] == searchBytes[num3].B)
					{
						if (num3 == 0)
						{
							num = position;
							num2 = i;
						}
						if (searchBytes.Length - 1 == num3)
						{
							num3 = 0;
							if (num4 == pt.ReplaceAfter)
							{
								num5++;
								list.Add(num + num2);
								if (pt.BrakAfter != 0 && num5 == pt.BrakAfter)
								{
									return new MainPattern(pt, list.ToArray());
								}
							}
							else
							{
								num4++;
							}
						}
						else
						{
							num3++;
						}
					}
					else if (num3 > 0)
					{
						num3 = 0;
						i = num2;
						if (num != position)
						{
							_fs.Position = num;
							num6 = _fs.Read(array, 0, array.Length);
						}
					}
				}
			}
			if (num5 == 0)
			{
				return new MainPattern(pt, null);
			}
			return new MainPattern(pt, list.ToArray());
		}

		private bool ReplaceAllPatterns(MainPattern pt)
		{
			if (!pt.Ptrn.ReplaceImmediately || _isDisposed)
			{
				return false;
			}
			int num = 0;
			long[] streamPosition = pt.StreamPosition;
			Pattern.UniversalByte[] replaceBytes = pt.Ptrn.ReplaceBytes;
			byte[] array = new byte[pt.Ptrn.SearchBytes.Length];
			long[] array2 = streamPosition;
			foreach (long position in array2)
			{
				if (_isDisposed)
				{
					return false;
				}
				bool flag = false;
				_fs.Position = position;
				_fs.Read(array, 0, array.Length);
				for (int j = 0; j < array.Length; j++)
				{
					if (replaceBytes[j].Act > Pattern.UniversalByte.Action.Skip && array[j] != replaceBytes[j].B)
					{
						array[j] = replaceBytes[j].B;
						flag = true;
					}
				}
				if (flag)
				{
					_fs.Position = position;
					_fs.Write(array, 0, array.Length);
					num++;
				}
			}
			return true;
		}

		private FileStream CreateStream(string fileName)
		{
			FileAttributes attributes = File.GetAttributes(fileName);
			attributes = FileAttributes.Normal;
			File.SetAttributes(fileName, attributes);
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
			if (fileStream.Length < 16)
			{
				fileStream.Close();
				fileStream = null;
				throw new IOException("File is too short! (posible damaged).");
			}
			return fileStream;
		}

		~Patcher()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing && _fs != null)
				{
					_fs.Dispose();
				}
				_fs = null;
				_isDisposed = true;
			}
		}
	}
}
