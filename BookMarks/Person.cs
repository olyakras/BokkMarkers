using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarks
{
    [Serializable]
    class Person
    {
        string _login;
        string _password;
        List<Book> _books;

        public Person (string login, string password,List<Book> books)
        {
            _login = login;
            _password = password;
            _books = books;
        }

        public Person(string login, string password)
        {
            _login = login;
            _password = password;
            _books = new List<Book>();
        }

        public Person() { }

        public string Login
        {
            get { return _login;}
            set { _login = value;}
        }

        public string Password
        {
            get { return _password;}
            set { _password = value;}
        }

        public List<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }
    }
}
