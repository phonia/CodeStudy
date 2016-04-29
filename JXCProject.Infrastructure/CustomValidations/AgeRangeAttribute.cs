using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JXCProject.Infrastructure.CustomValidations
{
    public class AgeRangeAttribute : RangeAttribute,IClientValidatable
    {
        public AgeRangeAttribute(int minimum, int maximum)
            : base(minimum, maximum)
        { }

        public override bool IsValid(object value)
        {
            DateTime birthDate = (DateTime)value;
            DateTime age = new DateTime(DateTime.Now.Ticks - birthDate.Ticks);
            return age.Year >= (int)this.Minimum && age.Year <= (int)this.Maximum;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule validationRule = new ModelClientValidationRule() { ValidationType = "agerange", ErrorMessage = this.ErrorMessage };
            validationRule.ValidationParameters.Add("currentdate", DateTime.Today.ToString("yyyy-MM-dd"));
            validationRule.ValidationParameters.Add("minage", this.Minimum);
            validationRule.ValidationParameters.Add("maxage", this.Maximum);
            yield return validationRule;
        }
    }
}
