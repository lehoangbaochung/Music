using System;
using System.Collections.Generic;

namespace Website.ViewModels
{
    public class PaginationViewModel
    {
        public List<string> PageNames { get; set; }

        public Tuple<string, dynamic> PartialView { get; set; }
    }
}
