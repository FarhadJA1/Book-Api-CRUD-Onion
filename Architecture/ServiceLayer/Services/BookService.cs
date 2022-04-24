using AutoMapper;
using DomainLayer.Entities;
using RepoLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateDto bookCreateDto)
        {
             await _bookRepository.CreateAsync(_mapper.Map<Book>(bookCreateDto));
        }

        public async Task UpdateAsync(int id,BookUpdateDto bookUpdateDto)
        {
            var entity = await _bookRepository.GetAsync(id);
            _mapper.Map(bookUpdateDto, entity);
            await _bookRepository.UpdateAsync(entity);
        }

        public async Task<List<BookListDTO>> GetAll()
        {
            var model = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookListDTO>>(model);
        }
        public async Task<IEnumerable<BookListDTO>> GetAllByConditionAsync(string search)
        {
            return _mapper.Map<IEnumerable<BookListDTO>>(await _bookRepository.FindAllAsync(m => m.Title.Contains(search)||m.Author.Contains(search)));
        }
        public async Task ArchiveAsync(int id)
        {
            Book book = await _bookRepository.GetAsync(id);
            await _bookRepository.SoftDeleteAsync(book);
        }


    }
}
