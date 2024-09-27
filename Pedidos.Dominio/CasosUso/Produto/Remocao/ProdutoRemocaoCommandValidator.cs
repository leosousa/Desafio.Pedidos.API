using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Produto.Remocao;

public sealed class ProdutoRemocaoCommandValidator : AbstractValidator<ProdutoRemocaoCommand>
{
    public ProdutoRemocaoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Produto.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Produto.Id)} inválido.");
    }
}