using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddTransient<IValidator<BookCreateDto>, BookCreateValidator>();
            services.AddTransient<IValidator<BookUpdateDto>, BookUpdateValidator>();
            return services;

        }
    }
}
