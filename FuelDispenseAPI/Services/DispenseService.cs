using FuelDispenseAPI.Models;
using FuelDispenseAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FuelDispenseAPI.Services
{
    public class DispenseService : IDispenseService
    {
        private readonly IDispenseRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public DispenseService(
            IDispenseRepository repo,
            IWebHostEnvironment env,
            IConfiguration config)
        {
            _repo = repo;
            _env = env;
            _config = config;
        }

        public async Task<DispenseRecord> CreateRecord(CreateRecordRequest req)
        {
            if (req.PaymentProof == null)
                throw new Exception("Payment proof required.");

            string ext = Path.GetExtension(req.PaymentProof.FileName).ToLower();
            string[] allowed = { ".jpg", ".jpeg", ".png", ".pdf" };
            if (!Array.Exists(allowed, x => x == ext))
                throw new Exception("Invalid file type.");

            string folder = _config["FileStorage:Path"];
            string path = Path.Combine(_env.ContentRootPath, folder);
            Directory.CreateDirectory(path);

            string fileName = Guid.NewGuid().ToString() + ext;
            string fullPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
                await req.PaymentProof.CopyToAsync(stream);

            return await _repo.AddRecordSP(
                req.DispenserNo,
                req.QuantityFilled,
                req.Rate,
                req.VehicleNumber,
                req.PaymentMode,
                fileName
            );
        }

        public async Task<IEnumerable<DispenseRecord>> GetRecords(
            string dispenserNo, string paymentMode,
            DateTime? start, DateTime? end)
        {
            return await _repo.GetRecordsSP(dispenserNo, paymentMode, start, end);
        }

        // In your service class
        public async Task<(byte[] FileBytes, string FileName, string ContentType)> DownloadProof(int id)
        {
            var record = await _repo.GetByIdSP(id);
            if (record == null)
                throw new Exception("Record not found.");

            string folder = _config["FileStorage:Path"];
            string fileName = record.PaymentProofFileName; 
            string fullPath = Path.Combine(_env.ContentRootPath, folder, fileName);

            if (!File.Exists(fullPath))
                throw new Exception("File not found.");

            string contentType = GetMimeType(fileName); 

            byte[] fileBytes = await File.ReadAllBytesAsync(fullPath);

            return (fileBytes, fileName, contentType);
        }
        private string GetMimeType(string file)
        {
            string ext = Path.GetExtension(file).ToLower();
            return ext switch
            {
                ".pdf" => "application/pdf",
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                _ => "application/octet-stream"
            };
        }
    }
}
