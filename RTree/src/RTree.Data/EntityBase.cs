using System;
using System.ComponentModel.DataAnnotations;

namespace RTree
{
	public class EntityBase
	{
		[Required]
		public int Id { get; protected set; }
	}
}
