using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Data
{
	public class Item : FingerPrintEntityBase
	{
		public IList<IAttr> Attrs { get; } = new List<IAttr>();
		public string Type { get => _Type; set => _Type = value ?? throw new ArgumentNullException(nameof(Type)); }
		private string _Type = string.Empty;

		public Item(string type)
		{
			Type = type ?? throw new ArgumentNullException(nameof(type));
		}
	}
}
