using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarks
{[Serializable]
    class DataPeople
    {
        private List<Person> _people;

        public List<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public DataPeople() { }
    }
}
