using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public float velocidadMovimiento;

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura la entrada del jugador en cada fotograma
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Calcula el vector de movimiento
        movimiento = new Vector2(movimientoHorizontal, movimientoVertical).normalized;
    }

    void FixedUpdate()
    {
        // Aplica el movimiento al jugador
        MoverJugador(movimiento);
    }

    void MoverJugador(Vector2 direccion)
    {
        // Mueve al jugador en la dirección dada con la velocidad de movimiento especificada
        rb.MovePosition(rb.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
