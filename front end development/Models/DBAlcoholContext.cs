using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Models
{
    public class DBAlcoholContext : DbContext
    {
        public DBAlcoholContext(DbContextOptions<DBAlcoholContext> options) : base(options) { }
    }
}
