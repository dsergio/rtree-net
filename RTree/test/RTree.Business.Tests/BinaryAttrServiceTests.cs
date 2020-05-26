using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RTree.Business.Dto;
using RTree.Business.Services;
using RTree.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTree.Business.Tests
{
    [TestClass]
    public class BinaryAttrServiceTests : EntityServiceTests<Dto.BinaryAttr, Dto.BinaryAttrInput, Data.BinaryAttr>
	{
        [TestInitialize]
        public void TestSetup()
        {
            
        }

        protected override Data.BinaryAttr CreateEntity()
            => new Data.BinaryAttr(
                Guid.NewGuid().ToString(),
                false,
                new Data.BinaryAttrSet()
                );

        protected override BinaryAttrInput CreateInputDto()
        {
            return new BinaryAttrInput
            {
                Name = Guid.NewGuid().ToString(),
                Value = false
            };
        }

        protected override IEntityService<Dto.BinaryAttr, Dto.BinaryAttrInput> GetService(ApplicationDbContext dbContext, IMapper mapper)
            => new BinaryAttrService(dbContext, mapper);
    }
}
