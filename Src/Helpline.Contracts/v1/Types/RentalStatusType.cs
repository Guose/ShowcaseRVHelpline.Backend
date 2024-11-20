﻿namespace Helpline.Contracts.v1.Types
{
    public enum RentalStatusType : byte
    {
        None = 0,
        Booked = 1,
        OnTrip = 2,
        Completed = 3,
        Maintenance = 4,
        Repair = 5,
        InsuranceRepair = 6,
    }
}