using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public record StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CityId { get; set; }

        public CourseModel CourseId { get; set; }

        public GenderModel GenderId { get; set; }
    }

    public record CityModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }

    public record CourseModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DegreeTypeModel DegreeType { get; set; }
    }

    public record DegreeTypeModel
    {
        public int Id { get; set; }

        public string? Degree { get; set; }

        public int? DurationInMonths { get; set; }
    }

    public record GenderModel
    {
        public int Id { get; set; }

        public string? GenderName { get; set; }
    }
}
