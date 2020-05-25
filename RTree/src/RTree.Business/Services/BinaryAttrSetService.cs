using AutoMapper;
using RTree.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Business.Services
{
	
    public class BinaryAttrSetService : EntityService<Dto.BinaryAttrSet, Dto.BinaryAttrSetInput, Data.BinaryAttrSet>, IBinaryAttrSetService
    {
        public BinaryAttrSetService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }
    }
}
