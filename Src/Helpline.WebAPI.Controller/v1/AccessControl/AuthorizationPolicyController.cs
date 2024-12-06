using Helpline.Common.Constants;
using Helpline.WebAPI.Controller.Config.Access;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.AccessControl
{
    [Route("api/authpolicies")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthorizationPolicyController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IEnumerable<string> policiesToEvaluate;

        public AuthorizationPolicyController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;

            policiesToEvaluate = new List<string>()
            {
                HelplinePolicies.AdministratorPolicy,
                HelplinePolicies.EmployeeAdminPolicy,
                HelplinePolicies.EmployeeContractorPolicy,
                HelplinePolicies.EmployeeLimitedPolicy,
                HelplinePolicies.CustomerLimitedPolicy,
                HelplinePolicies.CustomerGuestPolicy,
                HelplinePolicies.RVRenterGuestPolicy,
                HelplinePolicies.TechnicianLimitedPolicy,
                HelplinePolicies.DealershipLimitedPolicy,
                HelplinePolicies.ContractorPolicy
            };
        }

        [HttpGet]
        [Authorize(Policy = HelplinePolicies.AdministratorPolicy)]
        [Authorize(Policy = HelplinePolicies.EmployeeAdminPolicy)]
        [Authorize(Policy = HelplinePolicies.EmployeeLimitedPolicy)]
        [Authorize(Policy = HelplinePolicies.EmployeeContractorPolicy)]
        [Authorize(Policy = HelplinePolicies.CustomerLimitedPolicy)]
        [Authorize(Policy = HelplinePolicies.CustomerGuestPolicy)]
        [Authorize(Policy = HelplinePolicies.RVRenterGuestPolicy)]
        [Authorize(Policy = HelplinePolicies.TechnicianLimitedPolicy)]
        [Authorize(Policy = HelplinePolicies.DealershipLimitedPolicy)]
        [Authorize(Policy = HelplinePolicies.ContractorPolicy)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AuthorizationPolicies>> GetPoliciesAuthorizationAllowanceAsync()
        {
            var policies = new Dictionary<string, bool>();
            foreach (var policyName in policiesToEvaluate)
            {
                var policyResult = await authorizationService.AuthorizeAsync(User, policyName).ConfigureAwait(false);
                policies.Add(policyName, policyResult.Succeeded);
            }

            return new AuthorizationPolicies { Policies = policies };
        }
    }
}