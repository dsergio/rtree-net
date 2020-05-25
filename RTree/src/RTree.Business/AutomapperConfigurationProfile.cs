using AutoMapper;
using RTree.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RTree.Business
{
    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<Dto.BinaryAttrInput, BinaryAttr>();
            CreateMap<BinaryAttr, Dto.BinaryAttr>();

            CreateMap<Dto.BinaryAttrSetInput, BinaryAttrSet>();
            CreateMap<BinaryAttrSet, Dto.BinaryAttrSet>();

            
        }

        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
