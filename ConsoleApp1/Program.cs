using Helpline.DataAccess.Seeds;
using Helpline.Shared.Models;
using Helpline.Shared.Types;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HelplineSeedResolver seedResolver = new HelplineSeedResolver();

            var rvRentals = seedResolver.LoadJsonDataAsync<RVRental>("rental.json");

            List<RVRental> rentalSeeds = [];
            DateTime start = new DateTime();

            foreach (var rental in rvRentals)
            {
                switch (rental.RentalStatus)
                {
                    case RentalStatusType.Booked:
                        start = DateTime.Now.AddMonths(3);
                        break;
                    case RentalStatusType.OnTrip:
                        start = DateTime.Now.AddDays(-10);
                        break;
                    case RentalStatusType.Completed:
                        start = DateTime.Now.AddMonths(-10);
                        break;
                    default:
                        break;
                }

                rental.RentalStart = start;
                rental.RentalEnd = start.AddDays(30);

                rentalSeeds.Add(rental);
            }
        }
    }
}
