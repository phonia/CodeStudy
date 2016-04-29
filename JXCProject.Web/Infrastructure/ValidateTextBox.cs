using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JXCProject.Web.Infrastructure
{
    public static  class ValidateTextBoxExtension
    {
        public static MvcHtmlString ValidateTextBox<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            PropertyInfo property = typeof(TModel).GetProperty(metadata.PropertyName);
            ValidationAttribute[] attrs = (ValidationAttribute[])property.GetCustomAttributes(false);

            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.Text));

            foreach (var attr in attrs)
            {
                if (attr is RequiredAttribute)
                {
                    tagBuilder.MergeAttribute("required", "true");
                    tagBuilder.MergeAttribute("missingMessage", attr.ErrorMessage);
                }
                if (attr is StringLengthAttribute)
                {
                    var stringLengthAttr= attr as StringLengthAttribute;
                    tagBuilder.MergeAttribute("validType", string.Format("length[{0},{1}]", stringLengthAttr.MinimumLength, stringLengthAttr.MaximumLength));
                }
                if (attr is RegularExpressionAttribute)
                {
                    var regularAttr = attr as RegularExpressionAttribute;
                    tagBuilder.MergeAttribute("validType", string.Format("regular[{0},{1}]", regularAttr.Pattern.Replace("\\", "\\\\"), regularAttr.ErrorMessage));
                }
            }

            
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    
        
    }
}