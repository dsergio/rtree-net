using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTree.Business.Dto;
using RTree.Business.Services;

namespace RTree.Api.Controllers
{

    public class BinaryAttrController : BaseApiController<BinaryAttr, BinaryAttrInput>
    {
        public BinaryAttrController(IBinaryAttrService binaryAttrService)
            : base(binaryAttrService)
        { }
    }
}