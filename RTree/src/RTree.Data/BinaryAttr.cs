using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Data
{
	public class BinaryAttr : FingerPrintEntityBase, IAttr
	{
		public string Name { get; set; }
		public bool Value { get; set; }

#nullable disable
		public BinaryAttrSet BinaryAttrSet { get; set; }
#nullable enable
		public int BinaryAttrSetId { get; set; }

		public BinaryAttr()
			: this("", false, 0)
		{ }

		public BinaryAttr(int id)
			: this("", false, id)
		{ }

		
		public BinaryAttr(string name, bool value, BinaryAttrSet binaryAttrSet) : this(name, value,
			// Justification: There is no way to check for nullability with constructor chaining.
#pragma warning disable CA1062 // Validate arguments of public methods          
			binaryAttrSet.Id)
#pragma warning restore CA1062 // Validate arguments of public methods
		{
			BinaryAttrSet = binaryAttrSet;
		}

		private BinaryAttr(string name, bool value, int binaryAttrSetId)
		{
			Name = name;
			Value = value;
			BinaryAttrSetId = binaryAttrSetId;
		}
	}
}
