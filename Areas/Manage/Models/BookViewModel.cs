using jhoncedricromano.window.Infrastructure.Domain;
using jhoncedricromano.window.Infrastructure.Domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhoncedricromano.window.Areas.Manage.Models
{
    public class BookViewModel : Book
    {

    }
    public class BookSearchViewModel
    {
        public Paged<BookViewModel> Books { get; set; }
    }
}
