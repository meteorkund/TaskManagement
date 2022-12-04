using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Daily;

namespace TaskManagement.Application.Validators.UserTasks
{
    public class CreateUserTaskValidator : AbstractValidator<CreateUserTaskDailyCommandRequest>
    {
        public CreateUserTaskValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Girilen açıklama değeri boş olamaz!")
                .MinimumLength(7)
                    .WithMessage("Girilen açıklama en az 7 karakterden oluşmalıdır!");
                
        }
    }
}
