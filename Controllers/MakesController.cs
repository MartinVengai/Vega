using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vega.Persistence;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Core.Models;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/makes")]
        public IEnumerable<MakeResource> GetMakes()
        {
            var makes = context.Makes.Include(m => m.Models).ToList();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

        [HttpGet("/api/models")]
        public IEnumerable<KeyValuePairResource> GetModels()
        {
            var models = context.Models.ToList();
            return mapper.Map<List<Model>, List<KeyValuePairResource>>(models);
        }
    }
}