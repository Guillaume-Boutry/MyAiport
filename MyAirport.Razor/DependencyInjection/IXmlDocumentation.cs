using System;
using System.Reflection;
using System.Threading.Tasks;

namespace GBO.MyAirport.Razor.DependencyInjection
{
    public interface IXmlDocumentation
    {
        public string GetAssociatedXmlComment(Type objectType, String propertyName);
    }
}