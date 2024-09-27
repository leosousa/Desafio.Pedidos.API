using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Produto.Edicao;

public class ProdutoEdicaoCommandValidator : AbstractValidator<ProdutoEdicaoCommand>
{
    public ProdutoEdicaoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage($"{nameof(Entidades.Produto.Id)} é campo obrigatório.")
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Produto.Id)} inválido.");

        RuleFor(v => v.Nome)
            .NotEmpty()
                .WithMessage($"{nameof(Entidades.Produto.Nome)} é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage($"{nameof(Entidades.Produto.Nome)} não pode ultrapassar 255 caracteres.");

        RuleFor(v => v.Valor)
            .GreaterThan(0)
                .WithMessage($"{nameof(Entidades.Produto.Valor)} é campo obrigatório.");
    }
}