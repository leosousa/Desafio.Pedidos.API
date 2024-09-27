using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Cliente.Edicao;

public class ClienteEdicaoCommandValidator : AbstractValidator<ClienteEdicaoCommand>
{
    public ClienteEdicaoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Cliente.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Cliente.Id)} inválido.");

        RuleFor(v => v.Nome)
            .NotEmpty()
                .WithMessage($"{nameof(Entidades.Cliente.Nome)} é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage($"{nameof(Entidades.Cliente.Nome)} não pode ultrapassar 255 caracteres.");

        RuleFor(v => v.Email)
            .NotEmpty()
                .WithMessage($"{nameof(Entidades.Cliente.Email)} é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage($"{nameof(Entidades.Cliente.Email)} não pode ultrapassar 255 caracteres.");
    }
}