using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Data
{
	public class LocationItem : FingerPrintEntityBase
	{
		private int X { get; set; }
		private int Y { get; set; }
		public string Type { get => _Type; set => _Type = value ?? throw new ArgumentNullException(nameof(Type)); }
		private string _Type = string.Empty;

		public LocationItem(int x, int y, string type)
		{
			X = x;
			Y = y;
			Type = type;
		}
	}
}
