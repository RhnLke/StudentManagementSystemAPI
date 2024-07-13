using System;
using System.Collections.Generic;

namespace Domain.EntityModels;

public partial class Subject_tbl
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int StudentCapacity { get; set; }

    public bool? isActive { get; set; }

    public int CourseId { get; set; }
}
