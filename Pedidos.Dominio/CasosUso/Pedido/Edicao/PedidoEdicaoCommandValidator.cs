using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Pedido.Edicao;

public class PedidoEdicaoCommandValidator : AbstractValidator<PedidoEdicaoCommand>
{
    public PedidoEdicaoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Pedido.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Pedido.Id)} inválido.");

        //RuleFor(v => v.Nome)
        //    .NotEmpty()
        //        .WithMessage($"{nameof(Entidades.Pedido.Nome)} é campo obrigatório.")
        //    .MaximumLength(255)
        //        .WithMessage($"{nameof(Entidades.Pedido.Nome)} não pode ultrapassar 255 caracteres.");

        //RuleFor(v => v.Valor)
        //    .GreaterThan(0)
        //        .WithMessage($"{nameof(Entidades.Pedido.Valor)} é campo obrigatório.");
    }
}