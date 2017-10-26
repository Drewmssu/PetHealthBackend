using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealthAPI.JsonObjects
{
    public class TipJsonObject
    {
        public Int32? TipId { get; set; }
        public String Content { get; set; }
        public Int32 OwnerId { get; set; }
        public String Image { get; set; }
    }
}