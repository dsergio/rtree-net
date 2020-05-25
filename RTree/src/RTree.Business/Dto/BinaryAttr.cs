using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Business.Dto
{
	public class BinaryAttr : BinaryAttrInput, IEntity
	{
		public int Id { get; set; }
	}
}
