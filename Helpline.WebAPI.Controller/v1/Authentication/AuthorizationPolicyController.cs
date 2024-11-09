using Helpline.Common.Constants;
using Helpline.WebAPI.Controller.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.Authentication
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
                HelplineConstants.AdministratorPolicy,
                HelplineConstants.EmployeeAdminPolicy,
                HelplineConstants.EmployeeContractorPolicy,
                HelplineConstants.EmployeeLimitedPolicy,
                HelplineConstants.CustomerLimitedPolicy,
                HelplineConstants.CustomerGuestPolicy,
                HelplineConstants.RVRenterGuestPolicy,
                HelplineConstants.TechnicianLimitedPolicy,
                HelplineConstants.DealershipLimitedPolicy,
                HelplineConstants.ContractorPolicy
            };
        }

        [HttpGet]
        [Authorize(Policy = HelplineConstants.AdministratorPolicy)]
        [Authorize(Policy = HelplineConstants.EmployeeAdminPolicy)]
        [Authorize(Policy = HelplineConstants.EmployeeLimitedPolicy)]
        [Authorize(Policy = HelplineConstants.EmployeeContractorPolicy)]
        [Authorize(Policy = HelplineConstants.CustomerLimitedPolicy)]
        [Authorize(Policy = HelplineConstants.CustomerGuestPolicy)]
        [Authorize(Policy = HelplineConstants.RVRenterGuestPolicy)]
        [Authorize(Policy = HelplineConstants.TechnicianLimitedPolicy)]
        [Authorize(Policy = HelplineConstants.DealershipLimitedPolicy)]
        [Authorize(Policy = HelplineConstants.ContractorPolicy)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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