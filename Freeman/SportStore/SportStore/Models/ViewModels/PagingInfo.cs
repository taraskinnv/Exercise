﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int Totalitems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages()
        {
            return (int) Math.Ceiling((decimal) Totalitems / ItemsPerPage);
        }
    }
}
