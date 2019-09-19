using Cascadian.Abstractions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website
{
    [HtmlTargetElement("img", TagStructure = TagStructure.WithoutEndTag)]
    public class FallbackImgTagHelper : TagHelper
    {
        public IViewModelSettingsProvider PubliclyExposedStringsProvider { get; }

        public FallbackImgTagHelper(IViewModelSettingsProvider publiclyExposedStringsProvider)
        {
            PubliclyExposedStringsProvider = publiclyExposedStringsProvider;
        }



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.AllAttributes.ContainsName("src"))
            {
                var imgElementSrc = context.AllAttributes["src"].Value;

                if (imgElementSrc.ToString().EndsWith("webp"))
                {
                    var modernFormatPath = context.AllAttributes["src"].Value.ToString();
                    var fallbackPath = modernFormatPath.Substring(0, modernFormatPath.Length - 4) + "jpg";

                    var modernformatFullPath = PubliclyExposedStringsProvider.ModernImagesUrl + modernFormatPath;
                    imgElementSrc = PubliclyExposedStringsProvider.LegacyImagesUrl + fallbackPath;

                    output.PreElement.SetHtmlContent($"<picture><source type = 'image/webp' srcset='{modernformatFullPath}'>");
                    output.PostElement.SetHtmlContent("</picture>");

                }
                else
                {
                    imgElementSrc = PubliclyExposedStringsProvider.ModernImagesUrl + imgElementSrc;
                }

                output.Attributes.SetAttribute("src", imgElementSrc);
            }
        }

            //<picture>
            //<source type = "image/webp" srcset="images/butterfly.webp">
            //<img src = "images/butterfly.jpg" alt="a butterfly">
            //</picture>
    }
}
