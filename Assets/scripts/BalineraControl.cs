using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BalineraControl : MonoBehaviour
{

    [Header("Referencias")]
    private Rigidbody rb;

    [Header("Parametros Movimiento")]
    public float pushForce = 50f;
    public float turnForce = 2f;
    public float brakeForce = 5f;

    private bool isBraking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.7f, 0); // Más bajo para estabilidad
        rb.solverIterations = 12;
        rb.solverVelocityIterations = 12;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        ApplyBrake();
    }

    private void HandleInput()
    {
        //Impulso Manual
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * pushForce, ForceMode.Impulse);
            rb.maxAngularVelocity = 5f; // Limitar velocidad angular para evitar giros excesivos
        }

        //giro izquierda/derecha
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.up * horizontalInput * turnForce, ForceMode.Force);

        //freno suave
        isBraking = Input.GetKey(KeyCode.LeftShift);
    }

    private void ApplyBrake()
    {
        if (isBraking)
        {
            rb.velocity = rb.velocity * (1f - brakeForce * Time.fixedDeltaTime);
        }
    }
}
