using System;
using System.Linq;
using GBO.MyAirport.Razor.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GBO.MyAirport.Razor.TagHelpers
{
    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class XmlDocumentationHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";
        public readonly IXmlDocumentation xmlDocumentation;

        public XmlDocumentationHelper(IXmlDocumentation xmlDocumentation)
        {
            this.xmlDocumentation = xmlDocumentation;
        }
        
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (context.AllAttributes["title"] == null) 
            {
                var doc = Documentation(For.Metadata);
                if (doc != null)
                {
                    output.Attributes.Add("data-toggle", "tooltip");
                    output.Attributes.Add("title", doc);
                }
            }

            if (context.AllAttributes["data-placement"] == null)
            {
                output.Attributes.Add("data-placement", "right");
            }
        }

        private string Documentation(ModelMetadata modelMetadata)
        {
            return xmlDocumentation.GetAssociatedXmlComment(modelMetadata.ContainerType, modelMetadata.PropertyName);
        }
        
    }
}