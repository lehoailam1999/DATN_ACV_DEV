using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.FileBase;

namespace DATN_ACV_DEV.Controllers.Condition
{
    public class ConditionOrder
    {
        public static void CreateOrder_C02(DBContext context, Guid? request, string apiCode, string con03, string conCO3Field)
        {
            ACV_Exception aCV_Exception;
            if (request != null)
            {

                var Model = context.TbVouchers.Where(v => v.Id == request && v.EndDate < DateTime.Now).FirstOrDefault();
                if (Model != null)
                {
                    aCV_Exception = new ACV_Exception();
                    //To-do: Lay thong message text tu message code
                    aCV_Exception.Messages.Add(Message.CreateErrorMessage(apiCode, con03, Utility.Utility.VOUCHER_NOTFOUND + Model.Code, conCO3Field));
                    throw aCV_Exception;
                }

            }
        }
    }
}
