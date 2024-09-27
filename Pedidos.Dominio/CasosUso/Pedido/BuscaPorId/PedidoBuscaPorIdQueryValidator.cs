using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Pedido.BuscaPorId;

public sealed class PedidoBuscaPorIdQueryValidator : AbstractValidator<PedidoBuscaPorIdQuery>
{
    public PedidoBuscaPorIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Pedido.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Pedido.Id)} inválido.");
    }
}