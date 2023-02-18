using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust.Services
{
    internal class ProcessCommandService
    {
        //public void processCommand();
    }
}

//public enum ShoppingCartOperator
//{
//    ADD_PROGRAMME(2, () => new AddProgrammeService()),
//    APPLY_COUPON(1, () => new ApplyCouponService()),
//    ADD_PRO_MEMBERSHIP(0, () => new AddProMembershipService()),
//    PRINT_BILL(0, () => new PrintBillService());

//private int numberOfArguments;
//private Func<IShoppingCartService> operationService;

//ShoppingCartOperator(int numberOfArguments, Func < IShoppingCartService > operationService) {
//    this.numberOfArguments = numberOfArguments;
//    this.operationService = operationService;
//}

//public IShoppingCartService GetOperationService()
//{
//    return operationService();
//}

//public int GetNumberOfArguments()
//{
//    return numberOfArguments;
//}
//}

//// first the addprogram and addcoupon service will only initialize some object with specified programmes and coupons 
//and when printbill is called, the discount is calculated
//we should delegate the discount calculation till end, after applying discount from promembership and then coupons
