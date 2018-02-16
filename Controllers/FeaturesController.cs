using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
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
        public IEnumerable<FeatureResource> GetFeatures()
        {
            var features = context.Features.ToList();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }

    }
}