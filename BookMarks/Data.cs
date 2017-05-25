using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarks
{
    class Data
    {
        private List<Person> _people;

        public List<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }

        private List<Book> _books;

        public List<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }
    }
}
