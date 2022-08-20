using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.API
{
    public class DateTimeValidateAttribute:
        ValidationAttribute, IClientModelValidator
    {
        public string NameCompare { get; set; }
        public DateTimeValidateAttribute(string nameCompare)
        {
            NameCompare = nameCompare;
        }
        protected override ValidationResult IsValid(object value,
                                                    ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance != null)
            {
                Type _t = validationContext.ObjectInstance.GetType();
                PropertyInfo _d = _t.GetProperty(NameCompare);
                if (_d != null)
                {
                    DateTime _dtNascimento = (DateTime)value;
                    
                    if (_dtNascimento < DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult("Data de nascimento não pode ser maior que a data de hoje!");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("data-val-datetimecompare", ErrorMessageString);
            context.Attributes.Add("data-val-datetimecompare-param", NameCompare);
        }

    }
}
