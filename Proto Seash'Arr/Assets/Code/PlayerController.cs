using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementInput;
    public float health = 100f;
    private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();  // On obtient le PlayerInput attaché au clone

        // Le système d'input est activé pour ce joueur spécifique
        playerInput.actions.Enable();  // Assurer que les actions de ce joueur soient activées

        // L'action de déplacement est assignée spécifiquement à ce joueur
        playerInput.actions["Move"].performed += Move;
        playerInput.actions["Move"].canceled += StopMoving;
    }

    private void OnDisable()
    {
        playerInput.actions["Move"].performed -= Move;
        playerInput.actions["Move"].canceled -= StopMoving;

        playerInput.actions.Disable();
    }

    private void Update()
    {
        // Appliquer les mouvements seulement sur l'axe X et Y
        Vector3 moveVector = new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime;
        transform.Translate(moveVector, Space.World);
    }

    private void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();  // Lire les inputs pour le mouvement
    }

    private void StopMoving(InputAction.CallbackContext context)
    {
        movementInput = Vector2.zero;  // Réinitialiser à zéro quand le joueur arrête de bouger
    }
}