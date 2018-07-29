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

        private IHtmlGenerator generator;

        public FormControlTagHelper(IHtmlGenerator generator)
        {
            this.generator = generator;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = new StringBuilder();

            result.AppendLine(@"<div class=""form-group"">");

            await new LabelTagHelper(this.generator).ProcessAsync(context, output);

            result.AppendLine("</div>");
            output.Content.SetHtmlContent(result.ToString());
        }
    }
}
