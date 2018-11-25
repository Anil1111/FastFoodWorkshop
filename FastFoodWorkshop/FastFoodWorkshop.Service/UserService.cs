namespace FastFoodWorkshop.Service
{
    using Data;
    using Contracts;
    using Models;
    using System;
    using System.Globalization;

    public class UserService : IUserService
    {
        private readonly FastFoodWorkshopDbContext db;

        public UserService(FastFoodWorkshopDbContext db)
        {
            this.db = db;
        }

        public FastFoodUser CreateManager(
            string firstName,
            string lastName,
            string userName,
            string dateOfBirth,
            string address)
        {

            var birthDate = DateTime.ParseExact(dateOfBirth, "dd-MM-yyyy", CultureInfo.InstalledUICulture);

            var manager = new FastFoodUser()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Address = address,
            };

            return manager;
        }
    }
}
