using Helpline.Common.Essentials;

namespace Helpline.Contracts.v1.Responses
{
    public class SubscriptionResponse : AggregateRoot
    {
        private readonly List<CustomerResponse> customers = [];

        internal SubscriptionResponse(Guid id) : base(id)
        {

        }

        public string? Term { get; set; }


        public ICollection<CustomerResponse> Customers => customers;
    }
}
