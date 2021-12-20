using System.Collections.Generic;
using System.Linq;

public class LicHeader
{
	public class LicSettings
	{
		public int Android;

		public int Blackberry;

		public bool Educt;

		public int Flash;

		public int IPhone;

		public bool Nin = true;

		public bool NRelease;

		public bool PlayStation = true;

		public int SamsungTv;

		public bool Team = true;

		public int Tizen;

		public int Type = 1;

		public bool Wii = true;

		public int WinStore;

		public bool Xbox = true;
	}

	public static LicSettings PropLicSettings { get; set; } = new LicSettings();


	public static int[] ReadAll()
	{
		List<int> list = new List<int>();
		switch (PropLicSettings.Type)
		{
		case 0:
			list.Add(0);
			list.Add(1);
			list.Add(16);
			break;
		case 1:
			list.Add(0);
			list.Add(1);
			break;
		case 2:
			list.Add(62);
			break;
		}
		if (PropLicSettings.Team)
		{
			list.Add(2);
		}
		switch (PropLicSettings.IPhone)
		{
		case 0:
			list.Add(3);
			list.Add(4);
			list.Add(9);
			break;
		case 1:
			list.Add(3);
			list.Add(9);
			break;
		}
		if (PropLicSettings.Xbox)
		{
			list.Add(5);
			list.Add(33);
			list.Add(11);
		}
		if (PropLicSettings.PlayStation)
		{
			list.Add(6);
			list.Add(10);
			list.Add(30);
			list.Add(31);
			list.Add(32);
		}
		if (PropLicSettings.Wii)
		{
			list.Add(23);
			list.Add(36);
		}
		if (PropLicSettings.Nin)
		{
			list.Add(39);
			list.Add(35);
		}
		if (PropLicSettings.NRelease)
		{
			list.Add(61);
		}
		if (PropLicSettings.Educt)
		{
			list.Add(63);
		}
		switch (PropLicSettings.Android)
		{
		case 0:
			list.Add(12);
			list.Add(13);
			break;
		case 1:
			list.Add(12);
			break;
		}
		switch (PropLicSettings.Flash)
		{
		case 0:
			list.Add(14);
			list.Add(15);
			break;
		case 1:
			list.Add(14);
			break;
		}
		switch (PropLicSettings.WinStore)
		{
		case 0:
			list.Add(19);
			list.Add(20);
			list.Add(21);
			list.Add(26);
			break;
		case 1:
			list.Add(19);
			break;
		}
		switch (PropLicSettings.SamsungTv)
		{
		case 0:
			list.Add(24);
			list.Add(25);
			list.Add(34);
			break;
		case 1:
			list.Add(24);
			list.Add(34);
			break;
		}
		switch (PropLicSettings.Blackberry)
		{
		case 0:
			list.Add(17);
			list.Add(18);
			list.Add(28);
			break;
		case 1:
			list.Add(17);
			list.Add(28);
			break;
		}
		switch (PropLicSettings.Tizen)
		{
		case 0:
			list.Add(33);
			list.Add(34);
			list.Add(29);
			break;
		case 1:
			list.Add(33);
			list.Add(29);
			break;
		}
		list.Sort();
		return list.Distinct().ToArray();
	}
}
