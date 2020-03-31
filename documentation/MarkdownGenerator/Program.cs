using MarkdownGenerator.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MarkdownGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Markdown Generator!");

            // Get Configuration
            var configuration = GetConfigurationSettings();
            var projectConfiguration = configuration.GetSection("projectConfiguration").Get<ProjectConfiguration>();

            //if (string.IsNullOrWhiteSpace(projectConfiguration.BuildTarget)) 
            //    throw new InvalidOperationException("Please check configuration for Build Path");
            
            var target = projectConfiguration?.BuildTarget;

            //if (string.IsNullOrWhiteSpace(projectConfiguration.DocumentationTarget))
            //    throw new InvalidOperationException("Please check configuration for Markdown Path");

            var destination = projectConfiguration?.DocumentationTarget;

            GenerateMarkdown(@"C:\Source\Repos\CIBC\OData_OpenAPI_Reference\source\Phoenix.CRM.Integration.Entities\bin\Debug\netcoreapp3.1\Phoenix.CRM.Integration.Entities.dll", "C:\\Source\\Repos\\CIBC\\OData_OpenAPI_Reference\\documentation\\MarkdownGenerator\\markdown\\");
        }

        private static IConfiguration GetConfigurationSettings()
        {
            var configBuilder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return configBuilder.Build();
        }

        private static void GenerateMarkdown(string target, string destination)
        {
            Console.WriteLine($"Generating markdown in location: {destination}");

            var types = MarkdownGenerator.Load(target, string.Empty);

            // Home Markdown Builder
            var homeBuilder = new MarkdownBuilder();
            homeBuilder.Header(1, "References");
            homeBuilder.AppendLine();

            foreach (var g in types.GroupBy(x => x.Namespace).OrderBy(x => x.Key))
            {
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

                homeBuilder.HeaderWithLink(2, g.Key, g.Key);
                homeBuilder.AppendLine();

                var sb = new StringBuilder();
                foreach (var item in g.OrderBy(x => x.Name))
                {
                    homeBuilder.ListLink(MarkdownBuilder.MarkdownCodeQuote(item.BeautifyName), g.Key + "#" + item.BeautifyName.Replace("<", "").Replace(">", "").Replace(",", "").Replace(" ", "-").ToLower());

                    sb.Append(item.ToString());
                }

                File.WriteAllText(Path.Combine(destination, g.Key + ".md"), sb.ToString());
                homeBuilder.AppendLine();
            }

            // Gen Home
            File.WriteAllText(Path.Combine(destination, "Home.md"), homeBuilder.ToString());
        }
    
    }
}
