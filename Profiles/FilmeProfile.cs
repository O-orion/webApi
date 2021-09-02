using AutoMapper;
using webApi.Data.Dto;
using webApi.Models;

namespace webApi.Profiles
{
    public class FilmeProfile: Profile
    {
        public FilmeProfile(){
            CreateMap<CreateFilmeDto, filme>();
            CreateMap<UpdateFilmeDto, filme>();
        }
    }
}