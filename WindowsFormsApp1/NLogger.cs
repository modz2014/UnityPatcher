using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public class NLogger
	{
		private class Message
		{
			public enum State
			{
				Debug,
				Information,
				Exclamation,
				Error
			}

			public readonly string message;

			public readonly State state;

			public int Level => (int)state;

			public Message(string ms, short st = 0)
			{
				message = ms;
				state = (State)st;
			}
		}

		private static List<Message> _msgs;

		private static short _errorState;

		public static short MaxMessages;

		public static void Clear()
		{
			_msgs.Clear();
			_errorState = 0;
		}

		static NLogger()
		{
			_msgs = new List<Message>();
			MaxMessages = 8;
			_errorState = 0;
		}

		public static void LastXMessages()
		{
			if (_msgs.Count < 1)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int count = _msgs.Count;
			if (count > MaxMessages)
			{
				for (int i = count - MaxMessages; i < count; i++)
				{
					stringBuilder.Append(_msgs[i].message).AppendLine();
				}
			}
			else
			{
				foreach (Message msg in _msgs)
				{
					stringBuilder.Append(msg.message).AppendLine();
				}
			}
			Publish(new Message(stringBuilder.ToString(), _errorState));
		}

		public static void LastMessage()
		{
			if (_msgs.Count >= 1)
			{
				Publish(_msgs[_msgs.Count - 1]);
			}
		}

		public static void WriteLogToFile(string filename)
		{
			if (_msgs.Count >= 1)
			{
				try
				{
					File.WriteAllText(filename, GetFullLog(header: true));
				}
				catch (Exception ex)
				{
					MessageBox.Show("IOException: Can't write log to file: " + ex.Message, "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				}
			}
		}

		public static string GetFullLog(bool header = false)
		{
			if (_msgs.Count < 1)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (header)
			{
				stringBuilder.Append("Patcher log file.").AppendLine();
				stringBuilder.Append("File format: {ErrorLevel} {Message},").AppendLine();
				stringBuilder.Append("0 = Ok,").AppendLine();
				stringBuilder.Append("1 = Information,").AppendLine();
				stringBuilder.Append("2 = Exclamation,").AppendLine();
				stringBuilder.Append("3 = Error").AppendLine();
			}
			foreach (Message msg in _msgs)
			{
				stringBuilder.Append(string.Format("{{0}} {{1}},", msg.Level, msg.message));
			}
			return stringBuilder.ToString();
		}

		private static void Publish(Message md)
		{
			if (md != null)
			{
				switch (md.state)
				{
				case Message.State.Debug:
					MessageBox.Show(md.message, "Patcher");
					break;
				case Message.State.Information:
					MessageBox.Show(md.message, "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
					break;
				case Message.State.Exclamation:
					MessageBox.Show(md.message, "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					break;
				case Message.State.Error:
					MessageBox.Show(md.message, "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
					break;
				}
			}
		}

		internal static void Debug(string ms)
		{
			_msgs.Add(new Message(ms, 0));
		}

		internal static void Inf(string ms)
		{
			_msgs.Add(new Message(ms, 1));
			if (_errorState < 1)
			{
				_errorState = 1;
			}
		}

		internal static void Warn(string ms)
		{
			_msgs.Add(new Message(ms, 2));
			if (_errorState < 2)
			{
				_errorState = 2;
			}
		}

		internal static void Error(string ms)
		{
			_msgs.Add(new Message(ms, 3));
			if (_errorState < 3)
			{
				_errorState = 3;
			}
		}
	}
}
