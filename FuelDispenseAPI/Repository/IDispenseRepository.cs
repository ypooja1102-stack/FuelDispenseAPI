using FuelDispenseAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuelDispenseAPI.Repository
{
    public interface IDispenseRepository
    {
        Task<Models.DispenseRecord> AddRecordSP(
            string dispenserNo,
            decimal quantity,
            decimal rate,
            string vehicleNumber,
            string paymentMode,
            string proofFileName);

        Task<IEnumerable<DispenseRecord>> GetRecordsSP(
            string dispenserNo,
            string paymentMode,
            DateTime? startDate,
            DateTime? endDate);

        Task<DispenseRecord> GetByIdSP(int id);
    }
}
