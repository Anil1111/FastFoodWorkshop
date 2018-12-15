namespace FastFoodWorkshop.Service
{
    using AutoMapper;
    using Contracts;
    using FastFoodWorkshop.Data;
    using ServiceModels.User;
    using Microsoft.AspNetCore.Identity;
    using Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Security.Claims;

    public class UserService : IUserService
    {
        private readonly UserManager<FastFoodUser> userManager;
        private readonly IMapper mapper;

        public UserService(
            UserManager<FastFoodUser> userManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        
        public FastFoodUser CreateManager(
            string firstName,
            string lastName,
            string userName,
            string dateOfBirth,
            string address,
            string email)
        {

            var birthDate = DateTime.ParseExact(dateOfBirth, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var manager = new FastFoodUser()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Address = address,
                Email = email,
            };

            return manager;
        }

        public async Task<UserDetailsViewModel> GetUserDetailsAsync(ClaimsPrincipal user)
        {
            var currentUser = await this.userManager.GetUserAsync(user);
            var viewModel = this.mapper.Map<UserDetailsViewModel>(currentUser);

            viewModel.Picture = Convert.ToBase64String(currentUser.Picture);
            return viewModel;
        }
    }
}
