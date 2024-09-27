using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Produto.BuscaPorId;

public sealed class ProdutoBuscaPorIdQueryValidator : AbstractValidator<ProdutoBuscaPorIdQuery>
{
    public ProdutoBuscaPorIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Produto.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Produto.Id)} inválido.");
    }
}