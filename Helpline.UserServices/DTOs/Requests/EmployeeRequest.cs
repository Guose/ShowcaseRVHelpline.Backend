﻿using Helpline.Common.Models;

namespace Helpline.UserServices.DTOs.Requests
{
    public class EmployeeRequest
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public string? ReferralCode { get; set; }
        public UserRequest User { get; set; } = new();
    }
}