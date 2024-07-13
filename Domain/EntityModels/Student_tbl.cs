using Domain.Resources;
using System;
using System.Collections.Generic;

namespace Domain.EntityModels;

public partial class Student_tbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CityId { get; set; } = null!;

    public int CourseId { get; set; }

    public int? GenderId { get; set; }
}
