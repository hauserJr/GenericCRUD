
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GenericCRUD
{
    public partial class UserAccount : DBRepo
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
    }
}
