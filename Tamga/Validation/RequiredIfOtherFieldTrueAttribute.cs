namespace Tamga.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;

    public class RequiredIfOtherFieldTrueAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _otherProperty;
        public RequiredIfOtherFieldTrueAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "requiredif",
            };
            rule.ValidationParameters.Add("other", _otherProperty);
            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_otherProperty);
            if (property == null)
            {
                return new ValidationResult(string.Format(
                    CultureInfo.CurrentCulture,
                    "Unknown property {0}",
                    new[] { _otherProperty }
                ));
            }
            var otherPropertyValue = property.GetValue(validationContext.ObjectInstance, null);

            if (Convert.ToBoolean(otherPropertyValue) == true)
            {
                if (value == null || value as string == string.Empty)
                {
                    return new ValidationResult(string.Format(
                        CultureInfo.CurrentCulture,
                        FormatErrorMessage(validationContext.DisplayName),
                        new[] { _otherProperty }
                    ));
                }
            }

            return null;
        }
    }
}