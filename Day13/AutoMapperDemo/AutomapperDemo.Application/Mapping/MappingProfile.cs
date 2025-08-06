using AutomapperDemo.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomapperDemo.Core.Entities;
using AutomapperDemo.Core.DTOs;
using AutoMapper;

namespace AutomapperDemo.Application.Mapping
{
    public class MappingProfile : Profile
    {

        //bugreqDTO , bugresDTO

        //mapping for bug request and response:
        //bugreq -> bug -> create / update
        //bug -> bugres -> read
        public MappingProfile()
        {
            CreateMap<Bug, BugRequestDTO>().ReverseMap();    // bugrequest is mapped to bug . but upcasting la big first small second kudukanum. so reverse map
            CreateMap<Bug, BugResponseDTO>();
        }
        
    }
}
