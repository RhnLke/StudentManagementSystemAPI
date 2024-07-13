using System;
using System.Collections.Generic;

namespace Domain.EntityModels;

public partial class Course_tbl
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? DegreeTypeId { get; set; }
}
