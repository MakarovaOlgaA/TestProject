using System;
using System.ComponentModel.DataAnnotations;

namespace BookCataloque.Infrastructure.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PastDateAttribute : ValidationAttribute
    {
        public static readonly DateTime DEFAULT_MIN_DATETIME = new DateTime(1753, 1, 1);

        private readonly DateTime lowerDateBound;

        /// <summary> 
        /// Requires a date between default minimum date and today`s date (both included).
        /// Default minimum date matches the SQL Server date minimum. 
        /// </summary>
        public PastDateAttribute()
        {
            lowerDateBound = DEFAULT_MIN_DATETIME;
        }

        /// <summary> 
        /// Requires a date between a specified and today`s date (both included).
        /// </summary>
        public PastDateAttribute(DateTime lowerDateBound)
        {
            this.lowerDateBound = lowerDateBound;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            DateTime? dt = value as DateTime?;


            if (!dt.HasValue || (dt.Value.Date >= lowerDateBound.Date && dt.Value.Date <= DateTime.Now.Date))
            {
                return ValidationResult.Success;
            }

            else
            {
                if (ErrorMessage != null)
                {
                    return new ValidationResult(ErrorMessage);
                }
                else
                {
                    string message = String.Format("Date has to be between {0} and {1}",
                        dt.Value.ToShortDateString(), DateTime.Now.ToShortDateString());
                    return new ValidationResult(message);
                }
            }
        }
    }
}
