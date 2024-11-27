using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float _moveSpeed = 3f;
    private Vector3 movement;

    private Rigidbody rb;
    private Camera cam;
    private PlayerAnimationController animationController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        animationController = GetComponent<PlayerAnimationController>();

        if (animationController == null)
        {
            Debug.LogError("PlayerAnimationController no encontrado en el GameObject.");
        }
    }

    void Update()
    {
        PlayerMovement();
        Aiming();
    }

    void PlayerMovement()
    {
        // Obtener entrada de movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        // Mover al jugador
        rb.MovePosition(rb.position + movement * _moveSpeed * Time.deltaTime);

        // Calcular la dirección del movimiento
        bool isMoving = movement.magnitude > 0.1f;
        bool isMovingForward = movement.z > 0.1f; // Se está moviendo hacia adelante
        bool isMovingBackward = movement.z < -0.1f; // Se está moviendo hacia atrás

        // Actualizar el estado en el controlador de animación
        if (animationController != null)
        {
            animationController.SetMovementDirection(isMoving, isMovingForward, isMovingBackward);
        }

        // Debug para verificar si el movimiento está detectado
    }

    void Aiming()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        Vector3 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (groundPlane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 direction = point - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * 25f));
        }
    }
}


