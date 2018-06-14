namespace Tamga
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    public static class Helpers
    {
        public static MvcHtmlString PhoneNumberFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData = null)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("wrap-phone-input");

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("phone-code");
            span.SetInnerText("380");

            var input = html.EditorFor(expression, additionalViewData);
            div.InnerHtml += span;
            div.InnerHtml += input.ToString();
            return new MvcHtmlString(div.ToString());
        }
    }
}