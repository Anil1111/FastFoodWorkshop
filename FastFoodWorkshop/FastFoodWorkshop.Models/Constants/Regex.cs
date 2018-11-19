namespace FastFoodWorkshop.Models.Constants
{
    public class Regex
    {
        public const string EmailRegex = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        public const string PhoneNumberRegex = @"[0 - 9]{7,15}";
    }
}
