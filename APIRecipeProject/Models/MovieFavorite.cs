//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIRecipeProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MovieFavorite
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<int> Year { get; set; }
        public string Rated { get; set; }
        public string Genre { get; set; }
        public Nullable<double> Metascore { get; set; }
        public Nullable<double> imdbRating { get; set; }
        public Nullable<double> BoxOffice { get; set; }
    }
}
