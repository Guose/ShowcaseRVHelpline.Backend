namespace Helpline.WebAPI.Controller.Config.Access
{
    public class AuthorizationPolicies
    {
        public AuthorizationPolicies()
        {
            Policies = new Dictionary<string, bool>();
        }

        public IDictionary<string, bool> Policies { get; set; }
    }
}
