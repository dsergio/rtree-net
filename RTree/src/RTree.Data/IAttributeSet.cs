using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Data
{
	public interface IAttributeSet
	{
		public double Dissimilarity(IList<IAttr> attr1, IList<IAttr> attr2);

	}
}
