using GeekTrust.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust
{
    public class ShoppingCart
    {
        public Dictionary<string, int> _programmes { get; set; }
        private Dictionary<string, float> _categories = new Dictionary<string, float>()
        {
            { "CERTIFICATION", 3000f },
            { "DEGREE", 5000f },
            { "DIPLOMA", 2500f }
        };
        private Dictionary<string, float> _coupons = new Dictionary<string, float>()
        {
            { "DEAL_G20", 0.2f },
            { "B4G1", 0.25f },
            { "DEAL_G5", 0.05f }
        };
        private Dictionary<string, float> _membershipDiscount = new Dictionary<string, float>()
        {
            { "CERTIFICATION", 0.02f },
            { "DEGREE", 0.03f },
            { "DIPLOMA", 0.01f }
        };
        private string appliedCoupon;
        private bool _isProMember = false;
        private float enrollmentFee = 0;
        public void AddProgramme(string category, int quantity)
        {
            if (!_categories.ContainsKey(category))
            {
                Console.WriteLine($"Invalid category: {category}");
                return;
            }

            if (_programmes.ContainsKey(category))
            {
                _programmes[category] += quantity;
            }
            else
            {
                _programmes.Add(category, quantity);
            }
        }

        public void ApplyCoupon(string couponName)
        {
            if (!_coupons.ContainsKey(couponName))
            {
                Console.WriteLine($"Invalid coupon: {couponName}");
                return;
            }
            if (_programmes.Count >= 4)
            {
                appliedCoupon = "B4G1";
            }
            float total = CalculateProgrammeCost();
            if(total >)
        }

        public void AddProMembership()
        {
            _isProMember = true;
        }

        public void AddEnrollmentFee()
        {
            enrollmentFee = 500;
        }
        public bool GetProMembershipStatus()
        {
            return _isProMember;
        }
        public float CalculateProgrammeCost()
        {
            float totalCost = 0;
            foreach (var programme in _programmes)
            {
                float programmeCost = _categories[programme.Key];
                int programmeCount = programme.Value;
                float proMembershipDiscount = (1 - _membershipDiscount[programme.Key]);
                totalCost += programmeCost * programmeCount * (_isProMember ? proMembershipDiscount : 1);
            }
            if (_isProMember)
            {
                totalCost += 200;
            }
            return totalCost;
        }
        public void PrintBill()
        {
            float total = 0f;
            foreach (var programme in _programmes)
            {
                float cost = _categories[programme.Key] * programme.Value;
                if (_isProMember)
                {
                    cost *= 0.9f;
                }
                total += cost;
                Console.WriteLine($"{programme.Value} x {programme.Key}: {cost}");
            }

            Console.WriteLine("Sub Total: {0}", total);
        }
    }
    public class ShoppingCart2
    {
        private List<Programmes> _programmes = new List<Programmes>();
        private Coupon _couponApplied;

        public float SubTotal() { return 45.0f; }
        public 
    }
}
