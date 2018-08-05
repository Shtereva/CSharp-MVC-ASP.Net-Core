namespace SoftUniClone.Web.Common
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Infrastructure;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var types = AppDomain
                .CurrentDomain
                .GetAssemblies()
            .Where(a => a.GetName().Name.Contains("SoftUniClone.Web"))
            .SelectMany(a => a.GetTypes())
            .ToList();

            var mappings = types
                .Where(t => t.IsClass
                            && !t.IsAbstract
                            && t.GetInterfaces()
                                .Where(i => i.IsGenericType)
                                .Select(i => i.GetGenericTypeDefinition())
                                .Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Destination = t,
                    Source = t.GetInterfaces()
                            .Where(i => i.IsGenericType)
                            .Select(i => new
                            {
                                Definition = i.GetGenericTypeDefinition(),
                                Arguments = i.GetGenericArguments()
                            })
                            .Where(i => i.Definition == typeof(IMapFrom<>))
                            .SelectMany(i => i.Arguments)
                            .First()
                })
                .ToList();

            foreach (var mapping in mappings)
            {
                this.CreateMap(mapping.Source, mapping.Destination);
            }

            types
                .Where(t => t.IsClass
                            && !t.IsAbstract
                            && typeof(ICustomMapper).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<ICustomMapper>()
                .ToList()
                .ForEach(t => t.ConfigureMapping(this));
        }
    }
}
