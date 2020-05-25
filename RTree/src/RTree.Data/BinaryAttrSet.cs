using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTree.Data
{
	public class BinaryAttrSet : FingerPrintEntityBase, IAttributeSet
	{
		private string _Label = string.Empty;

		public string Label { get => _Label; set => _Label = value; }
		public IList<BinaryAttr> Attributes { get; } = new List<BinaryAttr>();


		public void AddAttribute(BinaryAttr attr)
		{
			Attributes.Add(attr);
		}

		public double Dissimilarity(IList<IAttr> attr1, IList<IAttr> attr2)
		{
			throw new NotImplementedException();
		}

		public BinaryAttr GetAttr(string name)
		{
			BinaryAttr val = Attributes.FirstOrDefault(i => i.Name == name);
			return val;
		}
	}
}
