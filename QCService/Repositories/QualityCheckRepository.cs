using Microsoft.EntityFrameworkCore;
using QCService.DBContexts;
using QCService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Repositories
{
    public class QualityCheckRepository : IQualityCheckRepository
    {
        QualityCheckDbContext qualityCheckDBContext;
        public QualityCheckRepository(QualityCheckDbContext qualityCheckDBContext)
        {
            this.qualityCheckDBContext = qualityCheckDBContext;
        }
        public void AddQualityCheck(QualityCheck qualityCheck)
        {
            qualityCheckDBContext.QualityCheck.Add(qualityCheck);
        }

        public async Task<IEnumerable<QualityCheck>> GetAllQualityCheckTasks()
        {
            return await qualityCheckDBContext.QualityCheck.OrderBy(x => x.QC_List).ThenBy(x => x.QC_Tag).ToListAsync();
        }

        public async Task<IEnumerable<QualityCheck>> GetQualityCheckTasksByOrder(string orderCode)
        {
            var qualityCheckList = await qualityCheckDBContext.QualityCheck.Where(x => x.QC_List == orderCode).OrderBy(x => x.QC_List).ThenBy(x => x.QC_Tag).ToListAsync();
            return qualityCheckList;
        }

        public async Task<IEnumerable<QualityCheck>> GetQualityCheckTasksByOrderAndTag(string orderCode, string qcTag)
        {
            var qualityCheckList = await qualityCheckDBContext.QualityCheck.Where(x => x.QC_List == orderCode && x.QC_Tag == qcTag).OrderBy(x => x.QC_List).ThenBy(x=> x.QC_Tag).ToListAsync();
            return qualityCheckList;
        }

        public async Task<bool> OrderExistsForQualityCheck(string orderCode, string qcTag)
        {
            if (qcTag == null || qcTag == String.Empty)
                return await qualityCheckDBContext.QualityCheck.Where(x => x.QC_List == orderCode).AnyAsync();
            else
                return await qualityCheckDBContext.QualityCheck.Where(x => x.QC_List == orderCode && x.QC_Tag == qcTag).AnyAsync();

        }

        public async Task<bool> SaveChanges()
        {
            return (await qualityCheckDBContext.SaveChangesAsync() > 0);
        }

        public async Task<QualityCheck> UpdateQualityCheckStatus(string orderCode, string qcTag, QualityCheck qualityCheck)
        {
            try
            {
                var existingQC = await qualityCheckDBContext.QualityCheck.Where(x => x.QC_List == orderCode && x.QC_Tag == qcTag).FirstOrDefaultAsync();
                
                if (existingQC == null)
                {
                    qualityCheck.Active = true;
                    qualityCheck.IsDeleted = false;
                    qualityCheck.Customer_Code = String.IsNullOrEmpty(qualityCheck.Customer_Code) == true ? "ABC" : qualityCheck.Customer_Code;
                    qualityCheck.Customer_Name = String.IsNullOrEmpty(qualityCheck.Customer_Name) == true ? "ABC" : qualityCheck.Customer_Name;
                    qualityCheck.Warehouse_Code = String.IsNullOrEmpty(qualityCheck.Warehouse_Code) == true ? "ABC" : qualityCheck.Warehouse_Code;
                    qualityCheck.Warehouse_Name = String.IsNullOrEmpty(qualityCheck.Warehouse_Name) == true ? "ABC" : qualityCheck.Warehouse_Name;
                    qualityCheck.Company_Code = String.IsNullOrEmpty(qualityCheck.Company_Code) == true ? "ABC" : qualityCheck.Company_Code;
                    qualityCheck.Company_Name = String.IsNullOrEmpty(qualityCheck.Company_Name) == true ? "ABC" : qualityCheck.Company_Name;
                    qualityCheck.CreatedBy = String.IsNullOrEmpty(qualityCheck.CreatedBy) == true ? "Sys" : qualityCheck.CreatedBy;
                    qualityCheck.CreatedDate = String.IsNullOrEmpty(qualityCheck.CreatedDate) == true ? DateTime.Now.Date.ToString("yyyy-MM-dd") : qualityCheck.CreatedDate;
                    qualityCheck.CreatedTime = String.IsNullOrEmpty(qualityCheck.CreatedTime) == true ? DateTime.Now.TimeOfDay.ToString().Substring(0, 8) : qualityCheck.CreatedTime;
                    qualityCheckDBContext.QualityCheck.Add(qualityCheck);
                    return qualityCheck;
                }
                existingQC.Active = true;
                existingQC.IsDeleted = false;
                existingQC.UpdatedBy = "Sys";
                existingQC.UpdatedTime = new DateTime().TimeOfDay.ToString();
                existingQC.UpdatedDate = new DateTime().Date.ToString();
                existingQC.QC_Action = qualityCheck.QC_Action;
                existingQC.QC_By = qualityCheck.QC_By;
                existingQC.QC_Notes = qualityCheck.QC_Notes;
                existingQC.QC_Status = qualityCheck.QC_Status;
                return qualityCheck;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new QualityCheck();
            }
        }
    }
}
