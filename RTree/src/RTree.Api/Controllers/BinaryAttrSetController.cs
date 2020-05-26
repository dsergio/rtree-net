using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTree.Business.Dto;
using RTree.Business.Services;

namespace RTree.Api.Controllers
{

    public class BinaryAttrSetController : BaseApiController<BinaryAttrSet, BinaryAttrSetInput>
    {
        public BinaryAttrSetController(IBinaryAttrSetService binaryAttrSetService)
            : base(binaryAttrSetService)
        { }

        [Route("add")]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BinaryAttrSet>> Get([FromQuery] int attr1, [FromQuery] int attr2)
        {
            BinaryAttrSet entity1 = await Service.FetchByIdAsync(attr1);
            BinaryAttrSet entity2 = await Service.FetchByIdAsync(attr2);
            if (entity1 is null || entity2 is null)
            {
                return NotFound();
            }
            var retEnt = entity1;
            retEnt.Label += "," + entity2.Label;
            foreach (var i in entity2.Attributes)
            {
                retEnt.Attributes.Add(i);
            }

            return Ok(retEnt);
        }

        [Route("dissimilarity")]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BinaryAttrSet>> GetDissimilarity([FromQuery] int attr1, [FromQuery] int attr2)
        {
            BinaryAttrSet entity1 = await Service.FetchByIdAsync(attr1);
            BinaryAttrSet entity2 = await Service.FetchByIdAsync(attr2);
            if (entity1 is null || entity2 is null)
            {
                return NotFound();
            }
            var retEnt = entity1;
            retEnt.Label += "," + entity2.Label;
            foreach (var i in entity2.Attributes)
            {
                retEnt.Attributes.Add(i);
            }

            return Ok(retEnt);
        }
    }
}