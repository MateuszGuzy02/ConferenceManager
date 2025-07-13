using Microsoft.AspNetCore.Builder;
using ConferenceManager;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("ConferenceManager.Web.csproj");
await builder.RunAbpModuleAsync<ConferenceManagerWebTestModule>(applicationName: "ConferenceManager.Web" );

public partial class Program
{
}
