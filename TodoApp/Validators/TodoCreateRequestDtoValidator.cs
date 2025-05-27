using FluentValidation;
using TodoApp.Dtos.RequestDtos;
using TodoApp.Entites;

namespace TodoApp.Validators
{
    public class TodoCreateRequestDtoValidator : AbstractValidator<TodoCreateRequestDto>
    {
        public TodoCreateRequestDtoValidator()
        {
            // Title Boş Geçilemez.
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.");
        }
    }
}
