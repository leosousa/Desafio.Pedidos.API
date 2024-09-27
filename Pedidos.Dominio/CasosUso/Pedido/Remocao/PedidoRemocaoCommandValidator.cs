using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Pedido.Remocao;

public sealed class PedidoRemocaoCommandValidator : AbstractValidator<PedidoRemocaoCommand>
{
    public PedidoRemocaoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Pedido.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Pedido.Id)} inválido.");
    }
}