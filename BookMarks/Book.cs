using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookMarks
{
    [Serializable]
    class Book
    {
        string _title;
        string _autor;
        Genres _genre;
        bool _marker;


        public string Title
        {
            get { return _title;}
            set { _title = value;}
        }

        public string Autor
        {
            get { return _autor;}
            set { _autor = value;}
        }

        [XmlIgnore]
        public Genres Genre
        {
            get { return _genre;}
            set { _genre = value;}
        }

        public bool Marker
        {
            get { return _marker;}
            set { _marker = value;}
        }

        public string Info
        {
            get
            {
                return $"{_autor} - {_title} - {_genre}";
            }
        }

        public Book (string title, string autor, Genres genre, bool marker)
        {
            _title = title;
            _autor = autor;
            _genre = genre;
            _marker = marker;

        }

        public Book(string autor, string title)
        {
            _title = title;
            _autor = autor;
            _genre = null;
            _marker = Marker;
        }

    }
}