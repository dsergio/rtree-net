using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTree.Business.Dto
{
	public class BinaryAttrInput
	{
        [Required]
        public string? Name { get; set; }
        [Required]
        public bool? Value { get; set; }
        
    }
}
