using System.Collections.Generic;
using System;

public class Invoice
{
    public decimal SubTotal { get; set; }
    public decimal CouponDiscount { get; set; }
    public decimal TotalProductDiscount { get; set; }
    public decimal ProfessionalMembershipFee { get; set; }
    public decimal EnrollmentFee { get; set; }

    public decimal Total
    {
        get
        {
            return SubTotal - CouponDiscount - TotalProductDiscount + ProfessionalMembershipFee + EnrollmentFee;
        }
    }

    public Invoice(decimal subTotal, decimal couponDiscount, decimal totalProductDiscount, decimal professionalMembershipFee, decimal enrollmentFee)
    {

        SubTotal = subTotal;
        CouponDiscount = couponDiscount;
        TotalProductDiscount = totalProductDiscount;
        ProfessionalMembershipFee = professionalMembershipFee;
        EnrollmentFee = enrollmentFee;

    }

}

// create an invoice

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

public abstract class Coupon
{
    public string Code { get; set; }
    public int DiscountPercentage { get; set; }

    protected Coupon(string code, int discountPercentage)
    {
        Code = code;
        DiscountPercentage = discountPercentage;
    }
}

public class DealG20 : Coupon
{
    public DealG20() : base("DEAL_G20", 20) { }
}

public class ShoppingCart
{
    public List<Programme> Programmes { get; set; }
    public Coupon Coupon { get; set; }

    public ShoppingCart()
    {
        Programmes = new List<Programme>();
    }

    public void AddProgramme(Programme programme)
    {
        Programmes.Add(programme);
    }

    public void ApplyCoupon(Coupon coupon)
    {
        Coupon = coupon;
    }

    public decimal GetDiscountedTotal()
    {
        // decimal total = Programmes.Sum(p => p.Cost);
        // if (Coupon != null)
        // {
        //     total -= total * Coupon.DiscountPercentage / 100;
        // }

        return 9;
    }

    public void PrintBill()
    {
        decimal total = GetDiscountedTotal();
        Console.WriteLine($"Total: Rs.{total}");
    }
}

namespace Geekdemy
{
    public class Invoker
    {
        private List<ICommand> _commands = new List<ICommand>();
        private int _totalCost = 0;

        public void AddProgramme(string category, int quantity)
        {
            _commands.Add(new AddProgrammeCommand(category, quantity));
        }

        public void ApplyCoupon(string couponName)
        {
            _commands.Add(new ApplyCouponCommand(couponName));
        }

        public void AddProMembership()
        {
            _commands.Add(new AddProMembershipCommand());
        }

        public void PrintBill()
        {
            _commands.Add(new PrintBillCommand());
        }

        public void ApplyEnrollmentFee()
        {
            if (_totalCost < 6666)
            {
                _commands.Add(new AddEnrollmentFeeCommand(500));
            }
        }

        public void PlaceOrders()
        {
            foreach (var command in _commands)
            {
                if (command is ICalculateCost)
                {
                    _totalCost += ((ICalculateCost)command).CalculateCost();
                }

                command.Execute();
            }

            ApplyEnrollmentFee();
        }
    }
    public class ShoppingCart
    {
        private Dictionary<string, int> _programmes = new Dictionary<string, int>();
        private Dictionary<string, float> _categories = new Dictionary<string, float>()
        {
            { "CERTIFICATION", 3000f },
            { "DEGREE", 5000f },
            { "DIPLOMA", 2500f }
        };
        private Dictionary<string, float> _coupons = new Dictionary<string, float>()
        {
            { "DEAL_G20", 0.2f },
            { "B4G1", 0.25f }
        };
        private bool _isProMember = false;

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
        }

        public void AddProMembership()
        {
            _isProMember = true;
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
    public class OnlineProgramme
    {
        private Dictionary<string, int> _programmePurchases = new Dictionary<string, int>();
        private Dictionary<string, int> _programmeCosts = new Dictionary<string, int>
        {
            { "CERTIFICATION", 3000 },
            { "DEGREE", 5000 },
            { "DIPLOMA", 2500 }
        };
        private bool _hasProMembership = false;
        private string _appliedCoupon = null;

        public void AddProgramme(string category, int quantity)
        {
            if (_programmeCosts.ContainsKey(category))
            {
                if (_programmePurchases.ContainsKey(category))
                {
                    _programmePurchases[category] += quantity;
                }
                else
                {
                    _programmePurchases[category] = quantity;
                }
            }
            else
            {
                Console.WriteLine("Invalid category.");
            }
        }

        public void ApplyCoupon(string couponName)
        {
            _appliedCoupon = couponName;
        }

        public void AddProMembership()
        {
            _hasProMembership = true;
        }

        public void PrintBill()
        {
            Console.WriteLine("Programme Purchases:");
            int total = 0;
            foreach (var purchase in _programmePurchases)
            {
                Console.WriteLine($"{purchase.Key}: {purchase.Value}");
                total += _programmeCosts[purchase.Key] * purchase.Value;
            }

            int proMembershipDiscount = 0;
            if (_hasProMembership)
            {
                proMembershipDiscount = total / 10;
            }

            int couponDiscount = 0;
            if (_appliedCoupon != null)
            {
                switch (_appliedCoupon)
                {
                    case "DEAL_G20":
                        couponDiscount = total / 5;
                        break;
                    default:
                        Console.WriteLine("Invalid coupon.");
                        break;
                }
            }

            Console.WriteLine("Sub Total: " + total);
            Console.WriteLine("Pro Membership Discount: " + proMembershipDiscount);
            Console.WriteLine("Coupon Discount: " + couponDiscount);
            Console.WriteLine("Total: " + (total - proMembershipDiscount - couponDiscount));
        }
    }
    public class Invoker
    {

        private List<ICommand> _commands = new List<ICommand>();

        public void AddProgramme(string category, int quantity)
        {
            _commands.Add(new AddProgrammeCommand(category, quantity));
        }

        public void ApplyCoupon(string couponName)
        {
            _commands.Add(new ApplyCouponCommand(couponName));
        }

        public void AddProMembership()
        {
            _commands.Add(new AddProMembershipCommand());
        }

        public void PrintBill()
        {
            _commands.Add(new PrintBillCommand());
        }

        public void PlaceOrders()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }
    //public class AddProgrammeCommand : ICommand
    //{
    //    private readonly string _category;
    //    private readonly int _quantity;
    //    private readonly OnlineProgramme _onlineProgramme;
    //    public AddProgrammeCommand(string category, int quantity, OnlineProgramme onlineProgramme)
    //    {
    //        _category = category;
    //        _quantity = quantity;
    //        _onlineProgramme = onlineProgramme;
    //    }

    //    public void Execute()
    //    {
    //        _onlineProgramme.AddProgramme(_category, _quantity);
    //    }
    //}
    class AddProgrammeCommand : Command
    {
        private Dictionary<string, int> programmes;
        public AddProgrammeCommand(Receiver receiver, Dictionary<string, int> programmes) : base(receiver)
        {
            this.programmes = programmes;
        }
        public override void Execute()
        {
            receiver.AddProgramme(programmes);
        }
    }

    class ApplyCouponCommand : Command
    {
        private Dictionary<string, int> couponValues;
        public ApplyCouponCommand(Receiver receiver, Dictionary<string, int> couponValues) : base(receiver)
        {
            this.couponValues = couponValues;
        }
        public override void Execute()
        {
            receiver.ApplyCoupon(couponValues);
        }
    }

    class AddProMembershipCommand : Command
    {
        public AddProMembershipCommand(Receiver receiver) : base(receiver) { }
        public override void Execute()
        {
            receiver.AddProMembership();
        }
    }

    public class AddEnrollmentFeeCommand : ICommand
    {
        private Cart _cart;
        private readonly int _enrollmentFeeThreshold = 6666;
        private readonly int _enrollmentFeeAmount = 500;

        public AddEnrollmentFeeCommand(Cart cart)
        {
            _cart = cart;
        }

        public void Execute()
        {
            if (_cart.GetTotalCost() < _enrollmentFeeThreshold)
            {
                _cart.AddCost(_enrollmentFeeAmount);
            }
        }
    }

    class PrintBillCommand : Command
    {
        public PrintBillCommand(Receiver receiver) : base(receiver) { }
        public override void Execute()
        {
            receiver.PrintBill();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            Dictionary<string, int> programmes = new Dictionary<string, int>();
            Dictionary<string, int> couponValues = new Dictionary<string, int>()
        {
            {"DEAL_G20", 20},
            {"B4G1", 25}
        };

            invoker.SetCommand(new AddProgrammeCommand(receiver, programmes));
            invoker.ExecuteCommand("ADD_PROGRAMME CERTIFICATION 1");
            invoker.ExecuteCommand("ADD_PROGRAMME DEGREE 1");
            invoker.ExecuteCommand("ADD_PROGRAMME DIPLOMA 2");

            invoker.SetCommand(new ApplyCouponCommand(receiver, couponValues));
            invoker.ExecuteCommand("APPLY_COUPON DEAL_G20");

            invoker.SetCommand(new AddProMembershipCommand(receiver));
            invoker.ExecuteCommand("ADD_PRO_MEMBERSHIP");

            invoker.SetCommand(new PrintBillCommand(receiver));
            invoker.ExecuteCommand("PRINT_BILL");
        }
    }
}