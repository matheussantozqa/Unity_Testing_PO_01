using UnityEngine;

namespace Game
{
    /// <summary>
    /// Moeda: quando o Player encosta, soma pontos e a moeda some.
    /// Precisa de um Collider com "Is Trigger" marcado.
    /// </summary>
    public class Coin : MonoBehaviour
    {
        public int points = 10;

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            if (player == null) return;

            player.Score.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
