using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
    public static class MapperHelper
    {
        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            Mapper.CreateMap<TSource, TDestination>();

            var destination = new List<TDestination>();
            if (source != null)
            {
                foreach (var s in source)
                {
                    destination.Add(Mapper.Map<TSource, TDestination>(s));
                }
            }
            return destination;
        }
    }
}
