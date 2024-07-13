using Application.Interfaces;
using Domain.Commons;
using Domain.EntityModels;
using Domain.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Student.Commands
{
    public class Enroll
    {
        public record Command (StudentCommon student) : IRequest<Unit>;
        public record Handler(IApplicationDbContext ApplicationDbContext, ClaimsPrincipal ClaimsPrincipal) : IRequestHandler<Command, Unit>
        {
            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var tr = ApplicationDbContext.Database.BeginTransaction();
                try
                {
                    var studentModel = command.student.Adapt<Student_tbl>();

                    ApplicationDbContext.Student_tbls.Add(studentModel);

                    await ApplicationDbContext.SaveChangesAsync();

                    tr.Commit();
                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }

                return Unit.Value;
            }
        }
    }
}
