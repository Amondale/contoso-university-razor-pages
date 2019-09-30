//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using ContosoUniversity.Application.ViewModels;
//using Microsoft.AspNetCore.Html;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;

//namespace ContosoUniversity.Web.Extensions
//{
//    public static class HtmlHelperExtensions
//    {
//        public static IHtmlContent CheckBoxListForBootstrap(this HtmlHelper<CheckBoxListItem> helper,
//            IEnumerable<SelectListItem> items,
//            int columns = 1)
//        {
            
            
//            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            
//            var propertyName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);
            
//            var list = expression.Compile().Invoke(helper.ViewData.Model);
            
//            var selectedValues = new List<string>();
            
//            if (list != null)
//                selectedValues = new List<TProperty>(list).ConvertAll(i => i.ToString());
            
            
//            var content = new HtmlContentBuilder();

//            content.AppendLine($"<div style=\"columns:{columns}\">");
            
//            var x = 0;
            
//            foreach (var item in items)
//                content.AppendLine(
//                    $"<div class=\"checkbox\"><label><input type=\"checkbox\" id=\"{
//                        TagBuilder.CreateSanitizedId(propertyName)}{x++}\" name=\"{propertyName}\" value=\"{item.Value}\"{(selectedValues.Contains(item.Value) ? " checked=checked" : "")} /> {item.Text}</label></div>");

//            content.AppendLine("</div><br/>");

//            return content;

//        }
//    }
//}
