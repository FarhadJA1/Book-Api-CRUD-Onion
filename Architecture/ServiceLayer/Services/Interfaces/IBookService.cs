using DomainLayer.Entities;
using ServiceLayer.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookListDTO>> GetAll();
        Task CreateAsync(BookCreateDto bookCreateDto);
        Task UpdateAsync(int id, BookUpdateDto bookUpdateDto);
        Task<IEnumerable<BookListDTO>> GetAllByConditionAsync(string search);
        Task ArchiveAsync(int id);
    }
}
