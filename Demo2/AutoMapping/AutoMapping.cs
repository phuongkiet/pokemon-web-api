using AutoMapper;
using Demo2.Entity;
using Demo2.Models.RequestModel;
using Demo2.Models.ResponseModel;

namespace Demo2.AutoMapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapPokemon();
        }

        private void MapPokemon()
        {
            CreateMap<Pokemon, PokemonResponse>().
                ReverseMap();
            CreateMap<Pokemon, PokemonCreateRequest>(). 
                ReverseMap();
            CreateMap<Category, CategoryResponse>().
                ReverseMap();
            CreateMap<Category, CategoryCreateRequest>().
                ReverseMap();
            CreateMap<Category, CategoryUpdateRequest>().
                ReverseMap();
            CreateMap<Region, RegionResponse>().
                ReverseMap();
            CreateMap<Owner, OwnerResponse>().
                ReverseMap();

        }
    }
}