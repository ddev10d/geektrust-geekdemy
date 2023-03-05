using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust.Models
{
    public abstract class Programme
    {
        public string Category { get; set; }
        public decimal Cost { get; set; }
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
        public Certification() : base("CERTIFICATION", 3000) { }
        public override decimal ProMemberShipDiscount { get => proMembershipDiscout; }
    }

    public class Degree : Programme
    {
        private decimal proMembershipDiscount = 0.03m;
        public Degree() : base("DEGREE", 5000) { }
        public override decimal ProMemberShipDiscount { get => proMembershipDiscount; }
    }

    public class Diploma : Programme
    {
        private decimal proMembershipDiscount = 0.01m;
        public Diploma() : base("DIPLOMA", 2500) { }
        public override decimal ProMemberShipDiscount { get => proMembershipDiscount; }
    }
}
