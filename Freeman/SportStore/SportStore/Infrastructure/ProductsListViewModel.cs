using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Infrastructure
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public String CurrentCategory { get; set; }
    }
}
