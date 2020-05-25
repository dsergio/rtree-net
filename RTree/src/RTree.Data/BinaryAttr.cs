using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Data
{
	public class BinaryAttr : FingerPrintEntityBase, IAttr
	{
		public string Name { get; set; }
		public bool Value { get; set; }

		public BinaryAttr(string name, bool value)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Value = value;
		}
	}
}
