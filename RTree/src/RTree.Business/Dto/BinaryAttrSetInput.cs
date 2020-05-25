using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTree.Business.Dto
{
	public class BinaryAttrSetInput
	{
		[Required]
		public string? Label { get; set; }
	}
}
