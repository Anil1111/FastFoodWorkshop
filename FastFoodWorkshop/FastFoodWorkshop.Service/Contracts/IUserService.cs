namespace FastFoodWorkshop.Service.Contracts
{
    using Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        FastFoodUser CreateManager
            (string firstName, 
            string lastName, 
            string userName, 
            string dateOfBirth, 
            string address, 
            string email);
    }
}