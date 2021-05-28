using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhoncedricromano.window.Infrastructure.Domain.model
{
    public class Book
    {
        public Guid? BookID { get; set; }
        public string bktitle { get; set; }
        public string bkauthor { get; set; }
        public string bkpublisher { get; set; }
    }
}