using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookMarks
{
    [Serializable]
    class Genres
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Genres(string name)
        {
            _name = name;
        }

        public Genres() { }
    }
}
