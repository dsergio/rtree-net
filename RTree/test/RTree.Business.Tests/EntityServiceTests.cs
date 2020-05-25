﻿using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RTree.Business.Services;
using RTree.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTree.Business.Tests
{
    [TestClass]
    public abstract class EntityServiceTests<TDto, TInputDto, TEntity> : TestBase
        where TEntity : EntityBase
        where TDto : class, TInputDto, Dto.IEntity
        where TInputDto : class
    {
        protected abstract IEntityService<TDto, TInputDto> GetService(ApplicationDbContext dbContext, IMapper mapper);

        protected abstract TEntity CreateEntity();
        protected abstract TInputDto CreateInputDto();

        [TestMethod]
        public async Task DeleteAsync_WithExistingItem_RemovesIt()
        {
            // Arrange
            using var setupContext = new ApplicationDbContext(Options);
            TEntity entity = CreateEntity();
            setupContext.Set<TEntity>().Add(entity);
            await setupContext.SaveChangesAsync();

            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            // Act
            bool wasRemoved = await service.DeleteAsync(entity.Id);

            // Assert
            Assert.IsTrue(wasRemoved);
            using var assertContext = new ApplicationDbContext(Options);
            Assert.IsNull(assertContext.Set<TEntity>().Find(entity.Id));
        }

        [TestMethod]
        public async Task DeleteAsync_NoExistingItem_RemovesIt()
        {
            // Arrange
            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            // Act
            bool wasRemoved = await service.DeleteAsync(1);

            // Assert
            Assert.IsFalse(wasRemoved);
        }

        [TestMethod]
        public async Task FetchAllAsync_ReturnsAllItems()
        {
            // Arrange
            TEntity item1 = CreateEntity();
            TEntity item2 = CreateEntity();
            TEntity item3 = CreateEntity();
            using var setupContext = new ApplicationDbContext(Options);
            setupContext.Add(item1);
            setupContext.Add(item2);
            setupContext.Add(item3);
            setupContext.SaveChanges();

            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            // Act
            List<TDto> items = await service.FetchAllAsync();

            // Assert
            CollectionAssert.AreEquivalent(new[]
            {
                item1.Id,
                item2.Id,
                item3.Id
            },
            items.Select(x => x.Id).ToArray());
        }

        [TestMethod]
        public async Task FetchByIdAsync_WithExitingItem_RemovesIt()
        {
            // Arrange
            using var setupContext = new ApplicationDbContext(Options);
            TEntity entity = CreateEntity();
            setupContext.Set<TEntity>().Add(entity);
            await setupContext.SaveChangesAsync();

            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            // Act
            TDto found = await service.FetchByIdAsync(entity.Id);

            // Assert
            Assert.AreEqual(entity.Id, found.Id);
        }

        [TestMethod]
        public async Task FetchByIdAsync_NoItem_RemovesIt()
        {
            // Arrange
            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            // Act
            TDto found = await service.FetchByIdAsync(1);

            // Assert
            Assert.IsNull(found);
        }

        [TestMethod]
        public async Task InsertAsync_WithItem_AddsItem()
        {
            // Arrange
            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);
            TInputDto inputDto = CreateInputDto();

            // Act
            TDto inserted = await service.InsertAsync(inputDto);

            // Assert
            using var assertContext = new ApplicationDbContext(Options);
            Assert.IsNotNull(assertContext.Set<TEntity>().Find(inserted.Id));
        }

        [TestMethod]
        public async Task UpdateAsync_WithExistingItem_UpdatesItem()
        {
            // Arrange
            using var setupContext = new ApplicationDbContext(Options);
            TEntity entity = CreateEntity();
            setupContext.Set<TEntity>().Add(entity);
            await setupContext.SaveChangesAsync();

            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            TInputDto newEntity = CreateInputDto();

            // Act
            TDto? updated = await service.UpdateAsync(entity.Id, newEntity);

            // Assert
            Assert.IsNotNull(updated);
        }

        [TestMethod]
        public async Task UpdateAsync_WithNoItem_ItReturnsNull()
        {
            // Arrange
            using var dbContext = new ApplicationDbContext(Options);
            IEntityService<TDto, TInputDto> service = GetService(dbContext, Mapper);

            TInputDto newEntity = CreateInputDto();

            // Act
            TDto? updated = await service.UpdateAsync(1, newEntity);

            // Assert
            Assert.IsNull(updated);
        }
    }
}
