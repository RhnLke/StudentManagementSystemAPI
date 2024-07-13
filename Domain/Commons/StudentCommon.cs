using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons
{
    public record StudentCommon(
        string Name,
        string CityId,
        int CourseId,
        int? GenderId
        );
}
