using Helpline.Shared.Models;
using Helpline.Shared.Types;

namespace Helpline.DataAccess.Seeds
{
    public class CustomerBasedSeeds
    {
        public static CustomerVehicle CreateCustomerVehicleSeeds()
        {
            return new CustomerVehicle
            {
                
            };
        }

        public static Customer CreateCustomerSeeds(
            SubscriptionType subType,
            DateTime SubStart,
            DateTime subEnd,
            bool status,
            string userId,
            int subId)
        {
            return new Customer
            {
                SubscriptionType = subType,
                SubscriptionStartDate = SubStart,
                SubscriptionEndDate = subEnd,
                SubscriptionStatus = status,
                UserId = userId,
                SubscriptionId = subId
            };
        }
    }
}
