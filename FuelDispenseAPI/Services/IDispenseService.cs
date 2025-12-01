using FuelDispenseAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuelDispenseAPI.Services
{
    public interface IDispenseService
    {
        Task<DispenseRecord> CreateRecord(CreateRecordRequest request);
        Task<IEnumerable<DispenseRecord>> GetRecords(
            string dispenserNo, string paymentMode,
            DateTime? start, DateTime? end);

        Task<(byte[] FileBytes, string FileName, string ContentType)> DownloadProof(int id);
    }
}
