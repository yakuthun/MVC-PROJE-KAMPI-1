﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        public int HeadingID { get; set; }//bu yorum hangi başlığa yazıldı
        public virtual Heading Heading { get; set; }
        public int? WriterID { get; set; } //int? nullable type oldu
        public virtual Writer Writer { get; set; } 
    }
}
