using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Business.Dto
{
	public class BinaryAttrSet : BinaryAttrSetInput, IEntity
	{
		public int Id { get; set; }
		public List<BinaryAttr> BinaryAttrs { get; } = new List<BinaryAttr>();
	}
}
