using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Cliente.Remocao;

public sealed class ClienteRemocaoCommandValidator : AbstractValidator<ClienteRemocaoCommand>
{
    public ClienteRemocaoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Cliente.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Cliente.Id)} inválido.");
    }
}