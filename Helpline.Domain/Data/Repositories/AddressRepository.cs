using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using LinqToDB;

namespace Helpline.Domain.Data.Repositories
{
    public class AddressRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Address, HelplineContext, int>(context, logging), IAddressRepository
    {
        public async Task<bool> UpdateUserAddressAsync(string userId, Address address)
        {
            try
            {
                var results = await Context.Addresses.FirstOrDefaultAsync(a => a.Id == address.Id);
                var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (results == null && user == null)
                    return false;

                results!.Address1 = address.Address1;
                results.Address2 = address.Address2;
                results.City = address.City;
                results.State = address.State;
                results.PostalCode = address.PostalCode;
                results.Country = address.Country;
                results.County = address.County;

                Context.Addresses.Update(results);

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(UpdateUserAddressAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
