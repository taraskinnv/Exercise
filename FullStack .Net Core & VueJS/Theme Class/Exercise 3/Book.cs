using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Book
    {
        public Title _title;
        public Author _author;
        public Content _content;

        public Book()
        {
            _title = new Title();
            _author = new Author();
            _content = new Content();
        }

    }
}
