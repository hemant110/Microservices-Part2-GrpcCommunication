using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Profiles
{
    public class QualityCheckProfile :Profile
    {
        public QualityCheckProfile()
        {
            CreateMap<Entities.QualityCheck, Models.QualityCheck>().ReverseMap();
            CreateMap<Models.QualityCheck, Entities.QualityCheck>().ReverseMap();
            CreateMap<Warehouse_Backend.Grpc.QualityCheckForCreation, Entities.QualityCheck>().ReverseMap();
            CreateMap<Warehouse_Backend.Grpc.QualityCheck, Entities.QualityCheck>().ReverseMap();
        }
    }
}
