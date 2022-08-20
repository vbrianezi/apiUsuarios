using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace CadastroDeUsuarios.API.Validadores
{
    public class EscolaridadeValidateAttribute: 
        ValidationAttribute, IClientModelValidator
    {
        public string NameCompare { get; set; }
        public EscolaridadeValidateAttribute(string nameCompare)
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
                    int id= (int)value;

                    if (id>0 && id<5)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult("Valor possíveis para Escolaridade: 1-Infantil, 2 - Fundamental, 3 - Médio, 4 - Superior");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("dado-val-dadocompare", ErrorMessageString);
            context.Attributes.Add("dado-val-dadocompare-param", NameCompare);
        }
    }
}
