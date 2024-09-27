using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Cliente.Cadastro;

public class ClienteCadastroCommandValidator : AbstractValidator<ClienteCadastroCommand>
{
    public ClienteCadastroCommandValidator()
    {
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