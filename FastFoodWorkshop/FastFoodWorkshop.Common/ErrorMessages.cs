namespace FastFoodWorkshop.Common
{
    public class ErrorMessages
    {
        public const string InternalServerError = "Internal server error";

        public const string EndDateMustBeGraterThan = "End date must be grater than Start date";

        public const string ValueMustImplementIComparable = "Value has not implemented IComparable interface";

        public const string ComparisonPropertyNotFound = "Comparison property with this name not found";

        public const string TypeOfFieldsNotSame = "The types of the fields to compare are not the same.";

        public const string InvalidEntry = "Invalid entry";

        public const string DateCannotBeAfterToday = "The date must be today or before that";

        public const string PasswordLength = "Password must be at least 6 characters long.";

        public const string PasswordsDoNotMatch = "The password and confirmation password do not match.";

        public const string NotOldEnough = "You must be at least 18 years old to apply for job";
    }
}
