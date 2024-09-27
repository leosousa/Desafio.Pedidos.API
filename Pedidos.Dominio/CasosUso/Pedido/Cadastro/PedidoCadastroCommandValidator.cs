using FluentValidation;

namespace Pedidos.Dominio.CasosUso.Pedido.Cadastro;

public class PedidoCadastroCommandValidator : AbstractValidator<PedidoCadastroCommand>
{
    public PedidoCadastroCommandValidator()
    {
        RuleFor(v => v.Cliente)
            .NotNull()
                .WithMessage("Cliente é campo obrigatório.");

        RuleFor(v => v.Cliente.Nome)
            .NotEmpty()
                .WithMessage("Nome do cliente é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage($"Nome do cliente não pode ultrapassar 255 caracteres.");

        RuleFor(v => v.Cliente.Email)
            .NotEmpty()
                .WithMessage("Email do cliente é campo obrigatório.")
            .MaximumLength(255)
                .WithMessage($"Email do cliente não pode ultrapassar 255 caracteres.");

        RuleFor(v => v.Itens)
            .NotNull()
                .WithMessage("O pedido precisa ter 1 ou mais itens informados.");
    }
}