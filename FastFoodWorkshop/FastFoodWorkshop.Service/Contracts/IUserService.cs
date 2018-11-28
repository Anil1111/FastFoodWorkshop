namespace FastFoodWorkshop.Service.Contracts
{
    using Models;

    public interface IUserService
    {
        FastFoodUser CreateManager(string firstName, string lastName, string userName, string dateOfBirth, string address);
    }

}