using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    // rendre le champ privé visible et modifiable dans l'Inspector de l'éditeur
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        // Déplacement du personnage
        Vector3 movement = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical).normalized;
        _rigidbody.velocity = movement * _moveSpeed;

        // Rotation du personnage
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime));
        }
    }
}
