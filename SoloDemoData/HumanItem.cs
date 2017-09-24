using SoloDemoDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDemoData
{
    public class HumanItem
    {
        public int IDemp { get; set; }
        public string Name { get; set; } //agregated
        public int IDdpm { get; set; }
        public string NameDpm { get; set; }
        public List<SoloSalary> ListSalaries { get; set; }

        //public int IDsal { get; set; }
        //public double Amount { get; set; }
        //public DateTime validFrom { get; set; }
        //public DateTime validUntil { get; set; }

        public HumanItem()
        {

        }

        public HumanItem(int IDemp, string Name, int IDdpm, string NameDpm, List<SoloSalary> salalist /*int IDsal, double Amount, DateTime validFrom, DateTime validUntil*/)
        {
            this.IDemp = IDemp;
            this.Name = Name;
            this.IDdpm = IDdpm;
            this.NameDpm = NameDpm;
            this.ListSalaries = salalist;

            /*
            this.IDsal = IDsal;
            this.Amount = Amount;
            this.validFrom = validFrom;
            this.validUntil = validUntil;
            */
        }

        public static List<HumanItem> MakeHumans(List<SoloEmployer> employees, List<SoloDepartment> departments, List<SoloSalary> salaries) //call like MakeHumans(empRepo.GetAll().ToList(), dpmRepo.GetAll().ToList(), salRepo.GetAll().ToList())
        {
            List<HumanItem> people = new List<HumanItem>(); //builds object-oriented object contains people in linked format, so it can be easily listed in reporting

            foreach (SoloEmployer se in employees)
            {
                HumanItem hi = new HumanItem();
                hi.ListSalaries = new List<SoloSalary>();

                hi.IDemp = se.ID;
                hi.Name = String.Format("{0} {1} {2}", se.Name1, se.Name2, se.Name3);

                foreach (SoloDepartment sd in departments)
                {
                    if (se.IDdmp == sd.IDdpm)
                    {
                        hi.IDdpm = sd.IDdpm;
                        hi.NameDpm = sd.Name;
                        break; //only one department per employee possible
                    }
                }

                foreach (SoloSalary ss in salaries)
                {
                    if (se.ID == ss.IDemp)
                    {
                        hi.ListSalaries.Add(new SoloSalary(ss.IDsal, ss.Amount, ss.validFrom, ss.validUntil, se.ID));
                        //add all of salaries founded
                    }
                }

                people.Add(hi);
            }
            return people;

        }
    }
}
