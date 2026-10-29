using System;

namespace Game
{
    /// <summary>
    /// Regra de pontuação em C# puro (sem MonoBehaviour).
    /// Por isso dá para testar em EditMode, sem rodar o jogo.
    /// </summary>
    public class ScoreManager
    {
        public int Score { get; private set; }

        public void AddPoints(int points)
        {
            if (points < 0)
                throw new ArgumentOutOfRangeException(nameof(points), "Pontos não podem ser negativos.");

            Score += points;
        }

        public void Reset() => Score = 0;
    }
}
