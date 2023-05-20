namespace ProjetApiLFL.Dtos.User
   
{
    using FluentValidation;

    public class UserSignUpDtoValidator : AbstractValidator<UserSignUpDto>
    {
        public UserSignUpDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty();
            RuleFor(dto => dto.Password).NotEmpty();
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
        }
    }
}
