using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using BWJ.Net.Http.RequestBuilder;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BWJ.Net.Http.RequestBuilderExtensions.Html
{
    public static class RequestBuilderHtmlExtensions
    {
        public static async Task<IHtmlDocument> SendForHtmlAsync(
            this HttpRequestBuilder builder,
            Func<Exception, HttpResponseMessage, Task<IHtmlDocument>> onError,
            HttpCompletionOption completionOption,
            CancellationToken? cancellationToken = null)
        => await builder.SendAsync(
                onSuccess: GetHtmlDocument,
                onError: onError,
                completionOption: completionOption,
                cancellationToken: cancellationToken);

        public static async Task<IHtmlDocument> SendForHtmlAsync(
            this HttpRequestBuilder builder,
            Func<Exception, HttpResponseMessage, Task<IHtmlDocument>> onError,
            CancellationToken? cancellationToken = null)
        => await builder.SendAsync(
                onSuccess: GetHtmlDocument,
                onError: onError,
                cancellationToken: cancellationToken);

        public static async Task<IHtmlDocument> SendForHtmlAsync(
            this HttpRequestBuilder builder,
            Func<Exception, HttpResponseMessage, IHtmlDocument> onError,
            HttpCompletionOption completionOption,
            CancellationToken? cancellationToken = null)
        => await builder.SendAsync(
                onSuccess: GetHtmlDocument,
                onError: onError,
                completionOption: completionOption,
                cancellationToken: cancellationToken);

        public static async Task<IHtmlDocument> SendForHtmlAsync(
            this HttpRequestBuilder builder,
            Func<Exception, HttpResponseMessage, IHtmlDocument> onError,
            CancellationToken? cancellationToken = null)
        => await builder.SendAsync(
                onSuccess: GetHtmlDocument,
                onError: onError,
                cancellationToken: cancellationToken);

        public static async Task<IHtmlDocument> SendForHtmlAsync(
            this HttpRequestBuilder builder,
            HttpCompletionOption completionOption,
            CancellationToken? cancellationToken = null)
        => await builder.SendAsync(
                onSuccess: GetHtmlDocument,
                completionOption: completionOption,
                cancellationToken: cancellationToken);

        public static async Task<IHtmlDocument> SendForHtmlAsync(
            this HttpRequestBuilder builder,
            CancellationToken? cancellationToken = null)
        => await builder.SendAsync(
                onSuccess: GetHtmlDocument,
                cancellationToken: cancellationToken);

        private async static Task<IHtmlDocument> GetHtmlDocument(HttpResponseMessage response)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var source = await response.Content.ReadAsStringAsync();

            return parser.ParseDocument(source);
        }
    }
}
