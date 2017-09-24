using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloDemoDomain
{
    public class SoloSalary
    {
        [Key]
        public int IDsal { get; set; }
        public double Amount { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validUntil { get; set; }        

        [ForeignKey("Employer")]
        public int IDemp { get; set; }
        public virtual SoloEmployer Employer { get; set; }

        public SoloSalary()
        {
            //check validity of solution with empty constructor
        }

        public SoloSalary(int IDsal, double amount, DateTime validFrom, DateTime validUntil, int IDemp)
        {
            this.IDsal = IDsal;
            this.Amount = amount;
            this.validFrom = validFrom;
            this.validUntil = validUntil;
            this.IDemp = IDemp;
        }
    }
}
