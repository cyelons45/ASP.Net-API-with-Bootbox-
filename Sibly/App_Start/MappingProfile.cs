using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Sibly.Dtos;
using Sibly.Models;

namespace Sibly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap().ForMember(c => c.CustomerId, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Movie, MoviesDto>().ReverseMap().ForMember(m => m.MovieId, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MoviesDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            
            
        }
    }
}