using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookMarks
{
    class Pages
    {
        private static BeginPage _beginPage = new BeginPage();
        private static RegisterPage _registerPage = new RegisterPage();
        private static MainPage _mainPage = new MainPage();
        private static AddingPage _addingPage = new AddingPage();
        private static SearchPage _searchPage = new SearchPage();
        private static AllBooksPage _allBooksPage = new AllBooksPage();
        private static MarkersPage _markersPage = new MarkersPage();

        public static BeginPage BeginPage
        {
            get
            {
                return _beginPage;
            }
        }

        public static RegisterPage RegisterPage
        {
            get
            {
                return _registerPage;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }

        public static AddingPage AddingPage
        {
            get
            {
                return _addingPage;
            }
        }

        public static SearchPage SearchPage
        {
            get
            {
                return _searchPage;
            }
        }

        public static AllBooksPage AllBooksPage
        {
            get
            {
                return _allBooksPage;
            }
        }

        public static MarkersPage MarkersPage
        {
            get
            {
                return _markersPage;
            }
        }
    }
}
