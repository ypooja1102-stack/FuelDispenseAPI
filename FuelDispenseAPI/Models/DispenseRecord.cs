using System;
using System.ComponentModel.DataAnnotations;

namespace FuelDispenseAPI.Models
{
    public class DispenseRecord
    {
        [Key]
        public int DispenseId { get; set; }

        [Required]
        public string DispenserNo { get; set; }
        public DateTime DispenseDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal QuantityFilled { get; set; }
       
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public string PaymentMode { get; set; }    

        public string PaymentProofFileName { get; set; } 

    }
}
