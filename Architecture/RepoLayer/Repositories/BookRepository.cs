using DomainLayer.Entities;
using RepoLayer.Data;
using RepoLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Repositories
{
    public class BookRepository:Repository<Book>,IBookRepository
    {
        public BookRepository(AppDbContext context):base(context)
        {

        }

        
    }
}
