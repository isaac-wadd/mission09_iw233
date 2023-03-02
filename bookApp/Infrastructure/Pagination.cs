
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using bookApp.Models;
using bookApp.Models.ViewModels;

namespace bookApp.Infrastructure {
    [HtmlTargetElement("div", Attributes="page-blah")]
    public class PaginationHelper : TagHelper {

        private IUrlHelperFactory uhf;
        public PaginationHelper(IUrlHelperFactory temp) {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PagesInfoModel pageBlah { get; set; }
        public string pageAction { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho) {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i < pageBlah.totalPages; i++) {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(pageAction, new { pageNum = i });
                tb.InnerHtml.Append(i.ToString());
                final.InnerHtml.AppendHtml(tb);
            }
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
