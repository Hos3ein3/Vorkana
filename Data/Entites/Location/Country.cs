using Common.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entites
{
    public class Country:GenericRepository<Country>
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public ICollection<State> States { get; set; }
        public Region Region{ get; set; }
    }
}
