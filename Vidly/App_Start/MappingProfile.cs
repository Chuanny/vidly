using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Dto to Domain
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<MembershipTypeDTO, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<GenreDTO, Genre>().ForMember(m => m.Id, opt => opt.Ignore()); ;

            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
        }
    }
}