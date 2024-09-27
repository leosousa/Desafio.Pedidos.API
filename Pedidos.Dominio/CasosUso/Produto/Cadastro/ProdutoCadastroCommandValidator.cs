using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Produto.Cadastro;

public class ProdutoCadastroCommandValidator : AbstractValidator<ProdutoCadastroCommand>
{
    public ProdutoCadastroCommandValidator()
    {
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