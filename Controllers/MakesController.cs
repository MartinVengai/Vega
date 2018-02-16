using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vega.Models;
using vega.Persistence;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using vega.Controllers.Resources;

namespace vega.Controllers
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
    }
}