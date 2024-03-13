﻿using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Category.Commands
{
    public abstract class CategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; } = string.Empty;
    }
}
