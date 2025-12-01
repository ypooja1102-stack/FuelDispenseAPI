
using FuelDispenseAPI.Models;
using FuelDispenseAPI.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FuelDispenseAPI.Repository
{
    public class DispenseRepository : IDispenseRepository
    {
        private readonly AppDbContext _db;

        public DispenseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<DispenseRecord> AddRecordSP(
            string dispenserNo, decimal qty, decimal rate, string vehicleNo,
            string mode, string fileName)
        {
            var idParam = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            try
            {
                await _db.Database.ExecuteSqlRawAsync(
                    "EXEC sp_AddFuelDispense @DispenserNo, @Quantity, @Rate, @VehicleNumber, @PaymentMode, @PaymentProofFileName, @Id OUT",
                    new SqlParameter("@DispenserNo", dispenserNo),
                    new SqlParameter("@Quantity", qty),
                    new SqlParameter("@Rate", rate),
                    new SqlParameter("@VehicleNumber", vehicleNo),
                    new SqlParameter("@PaymentMode", mode),
                    new SqlParameter("@PaymentProofFileName", fileName),
                    idParam
                );


                int createdId = (int)idParam.Value;


            return await _db.DispenseRecords.FindAsync(createdId); }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<DispenseRecord>> GetRecordsSP(
            string dispenserNo, string mode,
            DateTime? start, DateTime? end)
        {
            return await _db.DispenseRecords
                .FromSqlRaw(
                    "EXEC sp_GetFuelDispense @DispenserNo, @PaymentMode, @StartDate, @EndDate",
                    new SqlParameter("@DispenserNo", dispenserNo ?? (object)DBNull.Value),
                    new SqlParameter("@PaymentMode", mode ?? (object)DBNull.Value),
                    new SqlParameter("@StartDate", start ?? (object)DBNull.Value),
                    new SqlParameter("@EndDate", end ?? (object)DBNull.Value)
                )
                .ToListAsync();
        }

        public async Task<DispenseRecord> GetByIdSP(int id)
        {
            var result = await _db.DispenseRecords
                .FromSqlRaw("EXEC sp_GetRecordById @Id",
                new SqlParameter("@Id", id))
                .ToListAsync();

            return result.Count > 0 ? result[0] : null;
        }
    }
}
