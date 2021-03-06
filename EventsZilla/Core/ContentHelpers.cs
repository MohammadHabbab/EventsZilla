﻿using System;
using System.Web.Mvc;
using HibernatingRhinos.Loci.Common.Models;
using MarkdownDeep;

namespace EventsZilla.Core
{
	public static class ContentHelpers
	{
		public static MvcHtmlString CompiledMarkdownContent(this string str, bool trustContent = false)
		{
			if (str == null) return MvcHtmlString.Empty;

			var md = new Markdown
			         	{
			         		AutoHeadingIDs = true,
			         		ExtraMode = true,
			         		NoFollowLinks = !trustContent,
			         		SafeMode = false,
			         		NewWindowForExternalLinks = true,
			         	};

			var contents = md.Transform(str);
			return MvcHtmlString.Create(contents);
		}

		public static MvcHtmlString CompiledContent(this IDynamicContent contentItem, bool trustContent = false)
		{
			if (contentItem == null) return MvcHtmlString.Empty;

			switch (contentItem.ContentType)
			{
				case DynamicContentType.Markdown:
					var md = new Markdown
					{
						AutoHeadingIDs = true,
						ExtraMode = true,
						NoFollowLinks = !trustContent,
						SafeMode = false,
						NewWindowForExternalLinks = true,
					};

					var contents = contentItem.Content;
					contents = md.Transform(contents);
					return MvcHtmlString.Create(contents);
				case DynamicContentType.Html:
					return trustContent ? MvcHtmlString.Create(contentItem.Content) : MvcHtmlString.Empty;
			}
			return MvcHtmlString.Empty;
		}

		public static string FullContentPageId(string slug)
		{
			return "contentpages/" + slug;
		}

		public static string StyleFromStatic(this UrlHelper url, string stylesheetName)
		{
			return url.Content("~/Static/css/" + stylesheetName);
		}

		public static string ScriptFromStatic(this UrlHelper url, string scriptName)
		{
			return url.Content("~/Static/scripts/" + scriptName);
		}

		public static string ImageFromStatic(this UrlHelper url, string imagePath)
		{
			return url.Content("~/Static/images/" + imagePath);
		}

		public static MvcHtmlString Html5EventDateTimeTag(this HtmlHelper html, DateTimeOffset timestamp)
		{
			return MvcHtmlString.Create(string.Format(@"<time datetime=""{0}"">{1}</time>", timestamp.ToString("yyyy-MM-ddTHH:mm"), timestamp.ToString("dddd, dd MMMM yyyy, HH:mm")));
		}

		public static MvcHtmlString Html5EventDateTimeTag(this HtmlHelper html, DateTimeOffset beginsAt, DateTimeOffset endsAt)
		{
			return MvcHtmlString.Create(string.Format(@"<time datetime=""{0}"">{1} - {2}</time>", beginsAt.ToString("yyyy-MM-ddTHH:mm"),
				                                   beginsAt.ToString("dddd, dd MMMM yyyy, HH:mm"), endsAt.ToString("HH:mm")));
		}
	}
}