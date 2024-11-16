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
        public async Task<bool> UpdateUsersAddressAsync(string userId, Address address)
        {
            try
            {
                var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null) return false;

                Address? result = await Context.Addresses.FirstOrDefaultAsync(a => a.Id == address.Id && a.Id == user.AddressId);

                if (result == null) return false;

                Context.Addresses.Update(result);

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(UpdateUsersAddressAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
