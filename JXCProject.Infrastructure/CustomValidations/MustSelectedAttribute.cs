using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JXCProject.Infrastructure.CustomValidations
{
    public class MustSelectedAttribute : RequiredAttribute, IClientValidatable
    {
        public override bool IsValid(object value) 
        {
            return base.IsValid(value) && ((string)value) != "--请选择--";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new List<ModelClientValidationRule> { new ModelClientValidationRule { ValidationType = "mustselected", ErrorMessage = this.ErrorMessage } };
        }
    }
}
