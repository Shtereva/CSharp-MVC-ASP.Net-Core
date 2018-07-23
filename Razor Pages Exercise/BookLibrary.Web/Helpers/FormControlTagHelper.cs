namespace BookLibrary.Web.Helpers
{
    using System.Text;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("form-control")]
    public class FormControlTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = new StringBuilder();

            result.AppendLine(@"<div class=""form - group"">");

           

            output.Content.SetHtmlContent(result.ToString());
        }
    }
}
