using GeekTrust.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekTrust
{
    public class ShoppingCart
    {
        public List<Programme> programmes = new List<Programme>();
        public List<Coupon> appliedCoupons = new List<Coupon>();
        public bool IsProMember=false;
        private decimal SubTotal;
        private decimal TotalProDiscount;
        private decimal EnrollmentFee;
        private decimal Total;
        private Bill bill;
        public void SetSubTotal(decimal amount)
        {
            this.SubTotal = amount;
        }
        public string AddProgrammes(string programmeCategory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Programme programme = programmeCategory switch
                {
                    "CERTIFICATION" => new Certification(),
                    "DIPLOMA" => new Diploma(),
                    "DEGREE" => new Degree(),
                    _ => throw new ArgumentException("Invalid programme category."),
                };
                programmes.Add(programme);
            }
            return $"{count} programmes added to {programmeCategory} category.";
        }
        
        public static decimal GetCostOfCheapestProgramme(List<Programme> p)
        {
            return p.OrderBy(o => o.Cost).First().Cost;
        }
        public string AddCoupon(string couponType)
        {
            Coupon appliedCoupon = couponType switch
            {
                "DEAL_G20" => new DealG20(),
                "DEAL_G5" => new DealG5(),
                "B4G1" => new B41G(),
                _ => throw new ArgumentException("invalid coupon category.")
            };
            appliedCoupons.Add(appliedCoupon);
            return "Coupon Applied";
        }
        public string AddProMembership()
        {
            IsProMember = true;
            return "empty";
            //throw new NotImplementedException();
        }
        
        public string printBill(ShoppingCart cart)
        {
            Bill bill = new Bill(cart);

            return bill.generateBill();
        }

        internal decimal ProMemberShipFees()
        {
            if (IsProMember) return 200;
            return 0;
            throw new NotImplementedException();
        }

        internal decimal GetSubtotal()
        {
            return SubTotal;
            throw new NotImplementedException();
        }
    }
}
//public string AddProgrammes(string programmeCategory, int count)
//{
//    ProgrammeFactory factory;

//    switch (programmeCategory)
//    {
//        case "CERTIFICATION":
//            factory = new CertificationFactory();
//            break;
//        case "DIPLOMA":
//            factory = new DiplomaFactory();
//            break;
//        case "DEGREE":
//            factory = new DegreeFactory();
//            break;
//        default:
//            throw new ArgumentException("Invalid programme category.");
//    }

//    for (int i = 0; i < count; i++)
//    {
//        Programme programme = factory.CreateProgramme();
//        programmes.Add(programme);
//    }

//    return $"{count} programmes added to {programmeCategory} category.";
//}

//public abstract class ProgrammeFactory
//{
//    public abstract Programme CreateProgramme();
//}

//public class CertificationFactory : ProgrammeFactory
//{
//    public override Programme CreateProgramme()
//    {
//        return new Certification();
//    }
//}