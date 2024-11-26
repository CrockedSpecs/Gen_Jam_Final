using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float _moveSpeed = 3f;
    private Vector3 movement;

    private Rigidbody rb;
    private Camera cam;

    public Vector3 mousePos;
    public bool aiming;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Aiming();

    }

    void PlayerMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position +  movement * _moveSpeed * Time.deltaTime);

    }

    

    void Aiming()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        // Obtener la posici�n del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;
        // Crear un rayo desde la posici�n del mouse
        Ray ray = cam.ScreenPointToRay(mousePos);
        // Crear un plano horizontal (Y=0)
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        // Verificar si el rayo intersecta el plano
        if (groundPlane.Raycast(ray, out distance))
        {
            // Obtener el punto en el mundo donde intersecta el rayo
            Vector3 point = ray.GetPoint(distance);
            // Calcular la direcci�n hacia el punto objetivo
            Vector3 direction = point - transform.position;
            direction.y = 0; // Evitar rotaci�n en los ejes X y Z
            // Aplicar la rotaci�n al Rigidbody
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * 25f));
        }
    }
}
