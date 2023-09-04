using FluentAssertions;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Dominio.Tests;

public class InstrumentoUnitTest
{
    [Fact(DisplayName = "Cria instrumento com estado v�lido.")]
    public void CriarInstrumento_ComParametrosValidos_ResultadoObjetoValido()
    {
        Action action = () => new Instrumento(1, "Viol�o", TipoInstrumento.CORDA, 12.3m, "Faz voc� dormir entediado");
        action.Should()
            .NotThrow<SonsMagicos.Dominio.Validacao.DominioValidacaoExcecao>();
    }

    [Fact(DisplayName = "Tenta criar instrumento com ID negativo.")]
    public void CriarInstrumento_ComIdNegativo_ResultadoExcecaoIdInvalido()
    {
        Action action = () => new Instrumento(-1, "Viol�o", TipoInstrumento.CORDA, 12.30m, "Faz voc� dormir entediado");
        action.Should()
            .Throw<SonsMagicos.Dominio.Validacao.DominioValidacaoExcecao>()
            .WithMessage("Valor de ID inv�lido.");
    }
}