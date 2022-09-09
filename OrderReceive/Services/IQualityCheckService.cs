using OrderReceive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Services
{
    public interface IQualityCheckService
    {
        public Task<bool> PostQualityCheckData(string orderCode, List<QualityCheck> qcList);
    }
}
