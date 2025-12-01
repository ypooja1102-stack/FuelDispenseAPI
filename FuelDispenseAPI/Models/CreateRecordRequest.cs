using Microsoft.AspNetCore.Http;

namespace FuelDispenseAPI.Models
{
    public class CreateRecordRequest
    {
        public string DispenserNo { get; set; }
        public decimal QuantityFilled { get; set; }
        public decimal Rate { get; set; }
        public string VehicleNumber { get; set; }
        public string PaymentMode { get; set; }
        public IFormFile PaymentProof { get; set; }
    }
}
