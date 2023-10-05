using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave3s1
{
    public class BookRepository
    {
        private int nextid = 1;

        private List<Book> books = new();

        public BookRepository()
        {
            books.Add(new Book { Id = nextid++, Title = "Harry Potter", Price = 250 });
            books.Add(new Book { Id = nextid++, Title = "Hamlet", Price = 200 });
            books.Add(new Book { Id = nextid++, Title = "Agile Samurai", Price = 400 });
            books.Add(new Book { Id = nextid++, Title = "Alice in Wonderland", Price = 175 });
            books.Add(new Book { Id = nextid++, Title = "The holy Bible", Price = 310 });
        }

        public Book Add(Book book)
        {
            book.Id = nextid++;
            books.Add(book);
            return book;
        }
        public Book? Delete(int id)
        {
            Book? book = GetByID(id);
            if (book is null)
            {
                return null;
            }
            books.Remove(book);
            return book;
        }
        public List<Book> Get(string? orderBy = null, string? titlePart = null, int? priceBelow = null)
        {
            IEnumerable<Book> result = new List<Book>(books);
            List<Book> book = new List<Book>(books);
            if (titlePart != null)
            {
                result = result.Where(book =>
                    book.Title != null && book.Title.Contains(titlePart));
            }
            if (priceBelow != null)
            {
                result = result.Where(
                    book => book.Price < priceBelow);
            }
            if (orderBy != null)
            {
                result = orderBy switch
                {
                    "Title" => result.OrderBy(book => book.Title),
                    "TitleDesc" => result.OrderByDescending(book => book.Title),
                    "Price" => result.OrderBy(teacher => teacher.Price),
                    _ => throw new ArgumentException("Invalid orderBy value")
                };
            }
            return result.ToList();

        }
        public Book? GetByID(int id)
        {
            return books.FirstOrDefault(book => book.Id == id);
        }
        public Book? Update(int id, Book data)
        {
            Book? book = GetByID(id);
            if (book is null)
            {
                return null;
            }
            book.Title = data.Title;
            book.Price = data.Price;
            return book;
        }

    }
}
