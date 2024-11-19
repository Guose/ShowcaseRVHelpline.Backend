namespace Helpline.Contracts.v1.Responses
{
    public class SubscriptionResponse
    {
        private readonly List<CustomerResponse> customers = [];

        public string? Term { get; set; }

        public IReadOnlyCollection<CustomerResponse> Customers => customers;
    }
}
