using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust.Models
{
    public abstract class Programme
    {
        public string Category { get; set; }
        public int Cost { get; set; }

        protected Programme(string category, int cost)
        {
            Category = category;
            Cost = cost;
        }
    }

    public class Certification : Programme
    {
        public Certification() : base("CERTIFICATION", 3000) { }
    }

    public class Degree : Programme
    {
        public Degree() : base("DEGREE", 5000) { }
    }

    public class Diploma : Programme
    {
        public Diploma() : base("DIPLOMA", 2500) { }
    }
}
