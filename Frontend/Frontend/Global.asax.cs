using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Frontend.Database;
using Frontend.Models;
using Frontend.ViewModels;

namespace Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BookDb, Book>()
                    .ForMember(destination => destination.Title, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Author, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Description, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Isbn, opt => opt.NullSubstitute(""))
                    .ReverseMap()
                    .ForMember(destination => destination.Title, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Author, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Description, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Isbn, opt => opt.NullSubstitute(""));

                cfg.CreateMap<Book, BookViewModel>()
                    .ForMember(destination => destination.Title, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Author, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Description, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Isbn, opt => opt.NullSubstitute(""))
                    .ReverseMap().ForMember(destination => destination.Title, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Author, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Description, opt => opt.NullSubstitute(""))
                    .ForMember(destination => destination.Isbn, opt => opt.NullSubstitute(""));


                cfg.CreateMap<SetDb, Set>()
                    .ForMember(dest => dest.Books,
                        opt => opt.MapFrom(src => src.BooksSetsBindings.Select(b => b.Books).ToList()))
                    .ReverseMap();

                cfg.CreateMap<CategoryDb, Category>()
                    .ForMember(dest => dest.Books,
                        opt => opt.MapFrom(src => src.BooksCategoriesBindings.Select(b => b.Books).ToList()))
                    .ReverseMap();

            });


            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
