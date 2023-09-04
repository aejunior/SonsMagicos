using FluentAssertions;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Dominio.Tests;

public class InstrumentoUnitTest
{
    [Fact(DisplayName = "Cria instrumento com estado válido.")]
    public void CriarInstrumento_ComParametrosValidos_ResultadoObjetoValido()
    {
        Action action = () => new Instrumento(1, "Violão", TipoInstrumento.CORDA, 12.3m, "Faz você dormir entediado");
        action.Should()
            .NotThrow<SonsMagicos.Dominio.Validacao.DominioValidacaoExcecao>();
    }

    [Fact(DisplayName = "Tenta criar instrumento com ID negativo.")]
    public void CriarInstrumento_ComIdNegativo_ResultadoExcecaoIdInvalido()
    {
        Action action = () => new Instrumento(-1, "Violão", TipoInstrumento.CORDA, 12.30m, "Faz você dormir entediado");
        action.Should()
            .Throw<SonsMagicos.Dominio.Validacao.DominioValidacaoExcecao>()
            .WithMessage("Valor de ID inválido.");
    }
}