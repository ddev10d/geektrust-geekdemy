using System;

namespace GeekTrust
{
    public class Operator : Enumeration
    {
        public static Operator ADD_PROGRAMME = new Operator(2, "ADD_PROGRAMME", AddProgrammeService.GetInstance());
        public static Operator APPLY_COUPON = new Operator(1, "APPLY_COUPON", ApplyCouponService.GetInstance());
        public static Operator ADD_PRO_MEMBERSHIP = new Operator(0, "ADD_PRO_MEMBERSHIP", AddProMembershipService.GetInstance());
        public static Operator PRINT_BILL = new Operator(0, "PRINT_BILL", PrintBillService.GetInstance());
        public int NumberOfArguments { get; }
        public Operator() { }
        public Operator(int value, string displayName, IOperationService operationService) : base(value, displayName, operationService) { }
    }
}

