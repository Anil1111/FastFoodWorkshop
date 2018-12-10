namespace FastFoodWorkshop.Common.CustomValidations
{
    using Common;
    using Common.StringConstants;
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class AttributeGreaterThan : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public AttributeGreaterThan(string comparisonProperty) { _comparisonProperty = comparisonProperty; }

        protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            ErrorMessage = ErrorMessages.EndDateMustBeGraterThan;

            if (value.GetType() == typeof(IComparable))
            {
                throw new ArgumentException(ErrorMessages.ValueMustImplementIComparable);
            }

            var currentValue = (IComparable)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
            {
                throw new ArgumentException(ErrorMessages.ComparisonPropertyNotFound);
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);
            if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
            {
                throw new ArgumentException(ErrorMessages.TypeOfFieldsNotSame);
            }

            return currentValue.CompareTo((IComparable)comparisonValue) > 0 ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
