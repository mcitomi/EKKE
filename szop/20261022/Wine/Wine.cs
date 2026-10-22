using System;
using System.Collections.Generic;
using System.Text;

namespace Vine
{
    internal class Wine
    {
        public WineType winetype { get; set; } //red or white
        public int Id { get; set; } //id of the wine

        public Wine(WineType name, int id)
        {
            this.winetype = name;
            this.Id = id;
        }
    }
}
