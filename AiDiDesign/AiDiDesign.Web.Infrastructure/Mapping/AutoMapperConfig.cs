﻿namespace AiDiDesign.Web.Infrastructure.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using System.Web;

    public class AutoMapperConfig
    {
        private Assembly assembly;

        public AutoMapperConfig(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public void Execute()
        {
            var types = this.assembly.GetExportedTypes();

            LoadStandardMappings(types);

            LoadCustomMappings(types);

            LoadGlobbalMappings();
        }

        private void LoadGlobbalMappings()
        {
            Mapper.CreateMap<string, Guid>().ConvertUsing(s =>
            {
                var guid = Guid.Empty;
                Guid.TryParse(s, out guid);
                return guid;
            });

            Mapper.CreateMap<Guid, string>().ConvertUsing(g =>
            {
                return g.ToString();
            });
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        });

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
                // reverse all the mappings
                Mapper.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IMapCustom).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IMapCustom)Activator.CreateInstance(t));

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }
    }
}
