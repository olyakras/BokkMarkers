using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace BookMarks
{
    [DataContract]
    class Book
    {
        string _title;
        string _autor;
        Genres _genre;

        [DataMember]
        public string Title
        {
            get { return _title;}
            set { _title = value;}
        }
        [DataMember]
        public string Autor
        {
            get { return _autor;}
            set { _autor = value;}
        }

        [DataMember]
        public Genres Genre
        {
            get { return _genre;}
            set { _genre = value;}
        }



        public string Info
        {
            get
            {
                return $"{_autor} - {_title} - {_genre}";
            }
        }

        public Book (string title, string autor, Genres genre)
        {
            _title = title;
            _autor = autor;
            _genre = genre;

        }

        public Book(string title, string autor)
        {
            _title = title;
            _autor = autor;
            _genre = null;

        }

    }
}