using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RTree.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTree.Business.Services
{
	
    public class BinaryAttrSetService : EntityService<Dto.BinaryAttrSet, Dto.BinaryAttrSetInput, Data.BinaryAttrSet>, IBinaryAttrSetService
    {
        public BinaryAttrSetService(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }

        public async Task<List<Dto.BinaryAttrSet>> FetchAllAsync()
        {
            List<Dto.BinaryAttrSet> i = Mapper.Map<List<Data.BinaryAttrSet>, List<Dto.BinaryAttrSet>>(await Query.Include(p => p.Attributes).ToListAsync());
            return i;
        }

        public async Task<Dto.BinaryAttrSet> FetchByIdAsync(int id)
        {
            return Mapper.Map<Data.BinaryAttrSet, Dto.BinaryAttrSet>(await Query.Include(p => p.Attributes).FirstOrDefaultAsync(x => x.Id == id));
        }

        
    }
}
