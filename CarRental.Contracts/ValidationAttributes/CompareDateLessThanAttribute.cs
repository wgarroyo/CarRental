using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CarRental.Contracts.ValidationAttributes;

public class CompareDateLessThanAttribute : ValidationAttribute
{
    public CompareDateLessThanAttribute(string propToCompare)
    {
        _propToCompare = propToCompare;
    }

    private readonly string _propToCompare;

    protected override ValidationResult? IsValid(object? value, ValidationContext vc)
    {
        if (value is not null)
        {
            DateTime currentValue = (DateTime)value;
            PropertyInfo? pinfo = vc.ObjectType.GetProperty(_propToCompare);

            if (pinfo?.GetValue(vc.ObjectInstance) is not null)
            {
                DateTime comparisonValue = (DateTime)pinfo.GetValue(vc.ObjectInstance);
                DateOnly from = new(currentValue.Year, currentValue.Month, currentValue.Day);
                DateOnly to = new(comparisonValue.Year, comparisonValue.Month, comparisonValue.Day);
                if (from >= to)
                {
                    return new ValidationResult(ErrorMessage, new[] { vc.MemberName });
                }
            }
        }

        return ValidationResult.Success;
    }
}
