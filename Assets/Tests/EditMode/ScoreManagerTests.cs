using System;
using Game;
using NUnit.Framework;

/// <summary>
/// EditMode: testes unitários rápidos, sem rodar o jogo.
/// </summary>
public class ScoreManagerTests
{
    private ScoreManager _score;

    [SetUp] // roda antes de CADA teste
    public void SetUp()
    {
        _score = new ScoreManager();
    }

    [Test]
    public void ComecaComZeroPontos()
    {
        Assert.AreEqual(0, _score.Score);
    }

    [TestCase(1, 1)]
    [TestCase(10, 10)]
    [TestCase(0, 0)]
    public void AddPoints_SomaNaPontuacao(int pontos, int esperado)
    {
        _score.AddPoints(pontos);

        Assert.AreEqual(esperado, _score.Score);
    }

    [Test]
    public void AddPoints_Negativo_LancaExcecao()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _score.AddPoints(-5));
    }

    [Test]
    public void Reset_ZeraAPontuacao()
    {
        _score.AddPoints(30);

        _score.Reset();

        Assert.That(_score.Score, Is.Zero);
    }
}
