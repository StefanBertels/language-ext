﻿using LanguageExt;
using MediatR;

namespace Contoso.Application.Instructors.Queries
{
    public class GetInstructorById : IRequest<Option<InstructorViewModel>>
    {
        public GetInstructorById(int id) => InstructorId = id;

        public int InstructorId { get; }
    }
}
