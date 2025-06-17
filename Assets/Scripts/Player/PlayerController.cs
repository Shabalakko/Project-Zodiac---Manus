using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimento del giocatore (Left Analog / WASD)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Salto (Circle / Space)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Schivata / Blocco (Square / Right Click)
        if (Input.GetButtonDown("Fire2")) // Right Click or Square button
        {
            // Se in movimento, schiva
            if (movement.magnitude > 0.05f)
            {
                Debug.Log("Schivata!");
                // Implementare logica di schivata (es. breve impulso di velocità)
            }
            else // Se fermo, blocca
            {
                Debug.Log("Blocco!");
                // Implementare logica di blocco
            }
        }

        // Interagisci / Parla / Analizza (Triangle / E)
        if (Input.GetButtonDown("Interact")) // E button or Triangle button
        {
            Debug.Log("Interagisci!");
            // Implementare logica di interazione
        }

        // Lock On (R1 / Q)
        if (Input.GetButtonDown("LockOn")) // Q button or R1 button
        {
            Debug.Log("Lock On!");
            // Implementare logica di lock-on sui nemici
        }

        // Cambio arma (Dpad / Numbers)
        if (Input.GetButtonDown("Weapon1")) { Debug.Log("Cambio arma: Spada"); /* Logica cambio arma */ }
        if (Input.GetButtonDown("Weapon2")) { Debug.Log("Cambio arma: Pugnali"); /* Logica cambio arma */ }
        if (Input.GetButtonDown("Weapon3")) { Debug.Log("Cambio arma: Scudo"); /* Logica cambio arma */ }
        if (Input.GetButtonDown("Weapon4")) { Debug.Log("Cambio arma: Pistole"); /* Logica cambio arma */ }

        // Menu / Pausa (Start / Enter)
        if (Input.GetButtonDown("Cancel")) // Enter button or Start button
        {
            Debug.Log("Menu / Pausa!");
            // Implementare logica menu/pausa
        }

        // Cambia nemico bloccato (R2 / TAB)
        if (Input.GetButtonDown("ChangeTarget")) // TAB button or R2 button
        {
            Debug.Log("Cambia nemico bloccato!");
            // Implementare logica cambio target
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Metodi per le abilità e gli oggetti rapidi (L1/LShift e L2/LAlt)
    // Questi richiederanno un sistema di input più avanzato o un manager delle abilità
    public void UseElementalAbility() { Debug.Log("Abilità Elementale!"); }
    public void UseSupportAbility() { Debug.Log("Abilità di Supporto!"); }
    public void UsePowerAbility() { Debug.Log("Abilità di Potenza!"); }

    public void UseItem1() { Debug.Log("Usa Oggetto 1!"); }
    public void UseItem2() { Debug.Log("Usa Oggetto 2!"); }
    public void UseItem3() { Debug.Log("Usa Oggetto 3!"); }
}


