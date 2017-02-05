using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataHandler.Serializer;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}