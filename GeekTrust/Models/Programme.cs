using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust.Models
{
    public abstract class Programme
    {
        public string Category { get; set; }
        public decimal Cost { get; set; }
        protected const int CERTIFICATION_COST = 3000;
        protected const int DEGREE_COST = 5000;
        protected const int DIPLOMA_COST = 2500;
        protected Programme(string category, int cost)
        {
            Category = category;
            Cost = cost;
        }
        public abstract decimal ProMemberShipDiscount { get; }
    }

    public class Certification : Programme
    {
        private decimal proMembershipDiscout = 0.02m;
        public Certification() : base("CERTIFICATION", CERTIFICATION_COST) { }
        public override decimal ProMemberShipDiscount { get => proMembershipDiscout; }
    }

    public class Degree : Programme
    {
        private decimal proMembershipDiscount = 0.03m;
        public Degree() : base("DEGREE", DEGREE_COST) { }
        public override decimal ProMemberShipDiscount { get => proMembershipDiscount; }
    }

    public class Diploma : Programme
    {
        private decimal proMembershipDiscount = 0.01m;
        public Diploma() : base("DIPLOMA", DIPLOMA_COST) { }
        public override decimal ProMemberShipDiscount { get => proMembershipDiscount; }
    }
}
