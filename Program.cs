using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorLayoutExample;

var services = new ServiceCollection();
services.AddLogging();

var serviceProvider = services.BuildServiceProvider();
var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

var implicitHtml = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var output = await htmlRenderer.RenderComponentAsync<HelloWorld>(ParameterView.Empty);
    return output.ToHtmlString();
});

Console.WriteLine(implicitHtml);

var explicitHtml = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var output = await htmlRenderer.RenderComponentAsync<HelloWorldExplicit>(ParameterView.Empty);
    return output.ToHtmlString();
});

Console.WriteLine(explicitHtml);