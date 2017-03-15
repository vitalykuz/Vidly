/*
 *As part of this exercise, you’ll get this exception when updating a movie:
    Property ‘Id’ is part of object’s key information and cannot be modified.
    This exception happens at the following line:
    Mapper.Map(movieDto,	movie);	
    The exception is thrown when AutoMapper attempts to set the Id of movie:
    customer.Id	=	customerDto.Id;	
    Id is the key property for the Movie class, and a key property should not be changed.
    That’s why we get this exception. To resolve this, you need to tell AutoMapper to ignore
    Id during mapping of a MovieDto to Movie.
    In MappingProfile:
    CreateMap<Movie,	MovieDto>()
				    .ForMember(m	=>	m.Id,	opt	=>	opt.Ignore());	
    The same configuration should be applied to mapping of customers:
    CreateMap<Customer,	CustomerDto>()
				.ForMember(c	=>	c.Id,	opt	=>	opt.Ignore());
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            // after this we need to load it when the app starts. Go to Global.aspx
        }
    }
}