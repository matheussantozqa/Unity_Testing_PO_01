using UnityEngine;

namespace Game
{
    /// <summary>
    /// Player: anda no plano XZ e guarda a pontuação.
    /// Precisa de Collider + Rigidbody (kinematic) para encostar nas moedas.
    /// </summary>
    public class Player : MonoBehaviour
    {
        public float speed = 5f;

        // Nos testes, desligamos o teclado e controlamos o input direto por aqui.
        public bool useKeyboard = true;
        public Vector2 moveInput;

        public ScoreManager Score { get; } = new ScoreManager();

        private void Update()
        {
            if (useKeyboard)
                moveInput = ReadKeyboard();

            Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
            transform.position += direction * (speed * Time.deltaTime);
        }

        private static Vector2 ReadKeyboard()
        {
#if ENABLE_LEGACY_INPUT_MANAGER
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#else
            return Vector2.zero; // Se o projeto usa só o Input System novo, ligue "Both" em Player Settings.
#endif
        }
    }
}
