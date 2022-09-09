using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Profiles
{
    public class QualityCheckCreationProfile :Profile
    {
        public QualityCheckCreationProfile()
        {
            CreateMap<Models.QualityCheckForCreation, Entities.QualityCheck>().ReverseMap();
            CreateMap<Models.QualityCheckForUpdate, Entities.QualityCheck>().ReverseMap();
        }
    }
}
