using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpellChecker.Dal.DomainObjects;
using SpellChecker.Dal.DataTransferObjects;
using AutoMapper;
using SpellChecker.Models;

namespace SpellChecker
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<WordViewModel, Word>().ReverseMap();
            Mapper.CreateMap<SpellingBeeTestStatViewModel, SpellingBeeTestStatDto>().ReverseMap();
        }
    }
}