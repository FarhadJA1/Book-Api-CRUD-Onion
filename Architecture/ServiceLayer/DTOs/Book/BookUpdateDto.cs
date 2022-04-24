using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Book
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
    }

    public class BookUpdateValidator : AbstractValidator<BookUpdateDto>
    {
        public BookUpdateValidator()
        {
            RuleFor(m => m.Author).NotEmpty().WithMessage("Please add Author Name").MinimumLength(5).MaximumLength(40);
            RuleFor(m => m.Title).NotEmpty().MinimumLength(1).MaximumLength(100);
        }
    }
}
