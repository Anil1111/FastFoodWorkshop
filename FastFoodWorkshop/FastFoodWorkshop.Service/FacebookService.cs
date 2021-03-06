﻿namespace FastFoodWorkshop.Service
{
    using Models;
    using Service.Contracts;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class FacebookService : IFacebookService
    {
        private readonly SignInManager<FastFoodUser> signInManager;

        public FacebookService(SignInManager<FastFoodUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<List<string>> GetFacebookInfo()
        {
            var facebookData = new List<string>();

            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();

            string FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? info.Principal.FindFirstValue(ClaimTypes.Name);
            facebookData.Add(FirstName);

            string LastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
            facebookData.Add(LastName);

            return facebookData;
        }
    }
}
