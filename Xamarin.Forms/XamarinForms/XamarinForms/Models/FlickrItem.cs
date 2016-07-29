using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForms.Models
{
    public class FlickrItem
    {

        public string OwnerName { get; set; }

        public string PathAlias { get; set; }

        public string OwnerImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SmallImageUrl { get; set; }

        public string MediumImageUrl { get; set; }

        public string LargeImageUrl { get; set; }

        public string Published { get; set; }

        public int Views { get; set; }
    }
}
