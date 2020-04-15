using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace GBO.MyAirport.Razor.DependencyInjection
{
    public class XmlDocumentation : IXmlDocumentation
    {
        private readonly ILogger<XmlDocumentation> _logger;
        private readonly Dictionary<string, string> _documentations;


        public XmlDocumentation(ILogger<XmlDocumentation> logger)
        {
            _logger = logger;
            _documentations = new Dictionary<string, string>();
            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            referencedAssemblies.ToList().ForEach(assembly =>
            {
                var path = Path.Combine(AppContext.BaseDirectory, $"{assembly.Name}.xml");
                if (!File.Exists(path)) return;
                _logger.LogInformation($"Loaded {assembly.Name} documentation from {path}");
                XElement loaded = XElement.Load(path);
                foreach (var xElement in loaded.Descendants())
                {
                    XAttribute name = xElement.Attribute("name");
                    if (name == null || name.Value[0] != 'P') continue;
                    
                    var summaries = xElement.Descendants("summary").ToList();
                    if (summaries.Count > 0) 
                    {
                        // On part du prince qu'il n'y a au max 1 summary par element
                        _documentations.Add(name.Value, summaries[0].Value);
                    }
                }

            });
        }

        public string GetAssociatedXmlComment(Type objectType, string propertyName)
        {
            return _documentations[$"P:{objectType}.{propertyName}"];
        }
    }
}