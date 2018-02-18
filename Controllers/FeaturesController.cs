using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Core.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public FeaturesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpGet("/api/features")]
        public IEnumerable<KeyValuePairResource> GetFeatures()
        {
            var features = context.Features.ToList();
            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }

    }
}