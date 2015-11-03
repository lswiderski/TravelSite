using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public static class HtmlExtensions
{
    public static IHtmlString DisplayFormattedData(this HtmlHelper htmlHelper, string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return MvcHtmlString.Empty;
        }

        var result = string.Join(
            "<br/>",
            data
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(htmlHelper.Encode)
        );
        return new HtmlString(result);
    }
}