using AutoMapper;
using RTree.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Business.Services
{
	
    public class BinaryAttrService : EntityService<Dto.BinaryAttr, Dto.BinaryAttrInput, Data.BinaryAttr>, IBinaryAttrService
    {
        public BinaryAttrService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }
    }
}
