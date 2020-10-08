using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace StoreProject.Data
{
    public class LineItem
    {
        public int Quantity { get; set; }

        public Item Item { get; set; }

    }
}