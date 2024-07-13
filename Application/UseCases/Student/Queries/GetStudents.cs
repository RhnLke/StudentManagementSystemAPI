using Application.Interfaces;
using Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Student.Queries
{
    public class GetStudents
    {
        public record Query () : IRequest<List<Result>>;
        public record Result
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public CityModel City { get; set; }

            public CourseModel Course { get; set; }

            public GenderModel Gender { get; set; }
        }
        public record Handler(IApplicationDbContext ApplicationDbContext) : IRequestHandler<Query, List<Result>>
        {
            public async Task<List<Result>> Handle(Query query, CancellationToken cancellationToken)
            {
                return await (from student in ApplicationDbContext.Student_tbls
                              join city in ApplicationDbContext.City_tbls on Convert.ToInt32(student.CityId) equals city.Id
                              join course in ApplicationDbContext.Course_tbls on student.CourseId equals course.Id
                              join degree in ApplicationDbContext.DegreeType_tbls on course.DegreeTypeId equals degree.Id
                              join gender in ApplicationDbContext.Gender_tbls on student.GenderId equals gender.Id
                              select new Result
                              {
                                  Id = student.Id,
                                  Name = student.Name,
                                  City = new CityModel
                                      {
                                          Id = city.Id,
                                          Name = city.Name,
                                      },
                                  Course = new CourseModel
                                      {
                                          Id = course.Id,
                                          Name = course.Name,
                                          DegreeType = new DegreeTypeModel
                                          {
                                              Id = degree.Id,
                                              Degree = degree.Degree,
                                              DurationInMonths = degree.DurationInMonths
                                          },
                                      },
                                  Gender = new GenderModel
                                      {
                                          Id = gender.Id,
                                          GenderName = gender.GenderName
                                      }
                              }).ToListAsync();
            }
        }
    }
}
