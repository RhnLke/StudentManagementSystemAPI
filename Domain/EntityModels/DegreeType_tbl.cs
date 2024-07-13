using System;
using System.Collections.Generic;

namespace Domain.EntityModels;

public partial class DegreeType_tbl
{
    public int Id { get; set; }

    public string? Degree { get; set; }

    public int? DurationInMonths { get; set; }
}
