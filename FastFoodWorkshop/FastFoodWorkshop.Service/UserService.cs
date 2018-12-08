namespace FastFoodWorkshop.Service
{
    using Contracts;
    using Models;
    using System;
    using System.Globalization;

    public class UserService : IUserService
    {
        
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
    }
}
