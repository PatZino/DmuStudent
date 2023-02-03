using AutoMapper;
using DmuStudent.DTO;
using DmuStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmuStudent.Common
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Student, StudentViewModel>().ReverseMap();
		}

	}
}
