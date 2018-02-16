using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<MakeResource, Make>();
            CreateMap<Model, ModelResource>();
            CreateMap<ModelResource, Model>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<FeatureResource, Feature>();
        }
    }
}