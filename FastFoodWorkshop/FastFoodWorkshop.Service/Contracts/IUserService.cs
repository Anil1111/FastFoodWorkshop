namespace FastFoodWorkshop.Service.Contracts
{
    using ServiceModels.User;
    using Models;
    using System.Threading.Tasks;
    using System.Security.Claims;

    public interface IUserService
    {
        FastFoodUser CreateManager
            (string firstName, 
            string lastName, 
            string userName, 
            string dateOfBirth, 
            string address, 
            string email);

        Task<UserDetailsViewModel> GetUserDetailsAsync(ClaimsPrincipal user);
    }
}