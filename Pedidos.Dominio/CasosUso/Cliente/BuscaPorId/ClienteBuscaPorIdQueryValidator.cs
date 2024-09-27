using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Cliente.BuscaPorId;

public sealed class ClienteBuscaPorIdQueryValidator : AbstractValidator<ClienteBuscaPorIdQuery>
{
    public ClienteBuscaPorIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Cliente.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Cliente.Id)} inválido.");
    }
}