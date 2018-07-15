using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace BookCataloque.Infrastructure.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NonEmptyCollectionAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var collection = value as ICollection;

            if (collection.Count > 0)
            {
                return ValidationResult.Success;
            }

            else
            {
               return new ValidationResult(ErrorMessage ?? "Collection has to contain at least 1 element");
            }
        }
    }
}
