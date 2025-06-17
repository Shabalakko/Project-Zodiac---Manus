# Guida all'Avvio del Progetto Unity: Project Zodiac

## 1. Introduzione

Questo documento fornisce una guida dettagliata per l'avvio e la configurazione iniziale del progetto Unity per "Project Zodiac", basandosi sui requisiti delineati nel documento di design originale. L'obiettivo è fornire una base solida per lo sviluppo, includendo la struttura del progetto, gli script di base e le istruzioni per l'implementazione in Unity.

## 2. Requisiti del Progetto

"Project Zodiac" è un Action RPG con elementi di esplorazione e raccolta risorse, ispirato a titoli come Kingdom Hearts e Phantasy Star Online. Il gioco sarà single-player, con la possibilità di espansioni future per il co-op. I requisiti chiave includono un sistema di combattimento dinamico, gestione delle statistiche del giocatore, un sistema di armi elementali e un layout di controllo ottimizzato per il controller.

Per un riepilogo completo dei requisiti, fare riferimento al file `project_requirements.md` generato in precedenza.

## 3. Struttura del Progetto Unity

Una struttura di progetto ben organizzata è fondamentale per uno sviluppo efficiente. Di seguito è riportata la struttura delle cartelle consigliata per "Project Zodiac" all'interno della cartella `Assets` del vostro progetto Unity:

```
ProjectZodiac/
├── Assets/
│   ├── Scenes/             # Contiene tutte le scene del gioco (es. MainMenu, Gameplay, DungeonCrawler)
│   ├── Scripts/            # Contiene tutti gli script C# organizzati per funzionalità
│   │   ├── Player/         # Script relativi al giocatore (Controller, Statistiche, Combattimento)
│   │   ├── Enemies/        # Script per l'intelligenza artificiale e le statistiche dei nemici
│   │   ├── Weapons/        # Script per la gestione delle armi e delle abilità
│   │   ├── UI/             # Script per l'interfaccia utente (HUD, Menu)
│   │   ├── Core/           # Script di gestione del gioco (GameManager, AudioManager)
│   │   └── Utilities/      # Script di utilità generici
│   ├── Models/             # Modelli 3D (personaggi, nemici, armi, ambienti)
│   │   ├── Characters/
│   │   ├── Enemies/
│   │   └── Weapons/
│   ├── Materials/          # Materiali per i modelli 3D
│   ├── Textures/           # Texture per modelli e UI
│   ├── Animations/         # Animazioni per personaggi e oggetti
│   ├── Audio/              # File audio (musica, effetti sonori)
│   │   ├── Music/
│   │   └── SFX/
│   ├── Prefabs/            # Prefab di oggetti di gioco (personaggi, nemici, armi, UI)
│   │   ├── Player/
│   │   ├── Enemies/
│   │   ├── Weapons/
│   │   └── UI/
│   ├── Resources/          # Asset caricati dinamicamente (opzionale)
│   ├── Shaders/            # Shader personalizzati
│   ├── VFX/                # Effetti visivi (particelle, ecc.)
│   └── ThirdParty/         # Asset e plugin di terze parti
└── ProjectSettings/        # Impostazioni del progetto Unity (generate automaticamente)
```

**Scene Principali:**

-   **MainMenu.unity:** La scena iniziale del gioco, con opzioni per iniziare una nuova partita, caricare una partita esistente e accedere alle impostazioni.
-   **Gameplay.unity:** La scena principale dove si svolgerà l'esplorazione del mondo e il combattimento.
-   **DungeonCrawler.unity:** Una scena dedicata alla modalità dungeon crawler, se implementata.
-   **LoadingScreen.unity:** Una scena di caricamento per transizioni fluide tra le scene.
-   **GameOver.unity:** La scena che viene mostrata quando il giocatore perde.

Questa struttura facilita la navigazione e la gestione degli asset man mano che il progetto cresce.



## 4. Script e Componenti di Base

Abbiamo preparato due script C# di base per iniziare lo sviluppo del giocatore: `PlayerController.cs` per la gestione del movimento e degli input, e `PlayerStats.cs` per la gestione delle statistiche del giocatore.

### 4.1. PlayerController.cs

Questo script gestisce il movimento del giocatore, il salto, la schivata/blocco, l'interazione e il cambio arma, basandosi sui controlli definiti nel documento di design. È progettato per essere attaccato a un GameObject che rappresenta il giocatore e richiede un componente `Rigidbody` per la gestione della fisica.

**Codice:**

```csharp
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
            if (movement.magnitude > 0.1f)
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
```

**Configurazione in Unity:**

1.  Crea una nuova cartella `Scripts/Player` all'interno della cartella `Assets` del tuo progetto Unity.
2.  Crea un nuovo script C# chiamato `PlayerController` all'interno di questa cartella e incolla il codice sopra.
3.  Crea un GameObject vuoto nella tua scena (es. `Player`).
4.  Aggiungi il componente `PlayerController` a questo GameObject.
5.  Aggiungi un componente `Rigidbody` al GameObject `Player` e assicurati che 


`Use Gravity` sia abilitato e `Is Kinematic` sia disabilitato. Puoi anche congelare le rotazioni (Constraints -> Freeze Rotation) per evitare rotazioni indesiderate.
6.  Assicurati che il tuo GameObject `Player` abbia un `Collider` (es. `Capsule Collider`) e che ci sia un `Collider` sul terreno con il tag "Ground" per il rilevamento della collisione.
7.  Configura gli Input Manager di Unity (Edit -> Project Settings -> Input Manager) per i pulsanti `Jump`, `Fire2`, `Interact`, `LockOn`, `Weapon1`, `Weapon2`, `Weapon3`, `Weapon4`, `Cancel`, `ChangeTarget` come specificato nello script. Ad esempio, per `Jump` puoi usare "Space", per `Fire2` puoi usare "Mouse1" (tasto destro del mouse) o un pulsante del controller.

### 4.2. PlayerStats.cs

Questo script gestisce le statistiche fondamentali del giocatore come HP, AP, Attacco, Magia, Difesa ed Esperienza. Include metodi per subire danni, guadagnare esperienza e salire di livello, aggiornando le statistiche di conseguenza.

**Codice:**

```csharp
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int level = 1;
    public float currentExp = 0f;
    public float maxExp = 100f;
    public float currentHp = 100f;
    public float maxHp = 100f;
    public float currentAp = 50f;
    public float maxAp = 50f;
    public float attack = 10f;
    public float magic = 10f;
    public float defense = 10f;
    [Range(-100, 100)]
    public float dexterity = 0f; // Percentage based

    void Start()
    {
        UpdateStats();
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }
        Debug.Log("Player took " + amount + " damage. Current HP: " + currentHp);
    }

    public void GainExp(float amount)
    {
        currentExp += amount;
        if (currentExp >= maxExp)
        {
            LevelUp();
        }
        Debug.Log("Player gained " + amount + " EXP. Current EXP: " + currentExp);
    }

    void LevelUp()
    {
        level++;
        currentExp -= maxExp; // Carry over remaining exp
        maxExp *= 1.2f; // Increase max exp for next level

        // Increase core stats on level up
        maxHp += 10;
        currentHp = maxHp;
        attack += 2;
        magic += 2;
        defense += 2;

        Debug.Log("Player Leveled Up! New Level: " + level);
        UpdateStats();
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // Implement game over logic
    }

    void UpdateStats()
    {
        // Logic to update UI or other systems based on stat changes
        Debug.Log($"Stats Updated: Level {level}, HP: {currentHp}/{maxHp}, AP: {currentAp}/{maxAp}, Atk: {attack}, Mgk: {magic}, Def: {defense}, Dex: {dexterity}%");
    }

    public void RestoreHp(float amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        Debug.Log("HP Restored. Current HP: " + currentHp);
    }

    public void RestoreAp(float amount)
    {
        currentAp = Mathf.Min(currentAp + amount, maxAp);
        Debug.Log("AP Restored. Current AP: " + currentAp);
    }
}
```

**Configurazione in Unity:**

1.  Crea una nuova cartella `Scripts/Player` (se non esiste già) all'interno della cartella `Assets` del tuo progetto Unity.
2.  Crea un nuovo script C# chiamato `PlayerStats` all'interno di questa cartella e incolla il codice sopra.
3.  Aggiungi il componente `PlayerStats` allo stesso GameObject `Player` a cui hai aggiunto `PlayerController`.
4.  Puoi modificare i valori iniziali delle statistiche direttamente nell'Inspector di Unity.

Questi script forniscono una base funzionale per il tuo giocatore. Sarà necessario espanderli e integrarli con altri sistemi di gioco man mano che il progetto avanza.

## 5. Prossimi Passi in Unity

Dopo aver configurato la struttura del progetto e gli script di base, ecco i prossimi passi consigliati per continuare lo sviluppo in Unity:

1.  **Crea un Terreno o una Scena di Test:** Inizia creando un terreno semplice o importando un modello di scena per testare il movimento del giocatore.
2.  **Importa un Modello Giocatore:** Importa un modello 3D per il tuo giocatore e collegalo al GameObject `Player`. Assicurati che le animazioni siano configurate correttamente.
3.  **Implementa la Camera:** Configura una telecamera che segua il giocatore, magari con un sistema di telecamera in terza persona simile a Kingdom Hearts.
4.  **Sistema di Combattimento:** Inizia a implementare il sistema di combattimento, partendo dagli attacchi base e poi integrando le abilità delle armi.
5.  **Interfaccia Utente (UI):** Inizia a creare l'HUD (Head-Up Display) per mostrare HP, AP, livello e altre informazioni rilevanti del giocatore.
6.  **Sistema di Input Avanzato:** Per gestire le combinazioni di tasti per le abilità e gli oggetti rapidi (L1/LShift e L2/LAlt), considera l'utilizzo del nuovo Input System Package di Unity o la creazione di un manager di input personalizzato.
7.  **Integrazione Armi:** Sviluppa un sistema per gestire il cambio delle armi e l'attivazione delle loro abilità.
8.  **Nemici:** Inizia a creare i primi nemici, implementando la loro AI e le loro statistiche.

Ricorda di testare frequentemente e di iterare sul design man mano che procedi. La documentazione di Unity e la vasta comunità online sono risorse preziose per qualsiasi problema o domanda che potresti incontrare.




## 6. Implementazione del Nuovo Input System di Unity

Per un controllo più flessibile e moderno, il progetto "Project Zodiac" può utilizzare il nuovo Input System di Unity. Questo sistema offre un approccio basato su azioni che facilita la gestione di input complessi e il supporto multi-piattaforma.

### 6.1. Installazione del Pacchetto Input System

1.  Apri il tuo progetto Unity.
2.  Vai su **Window > Package Manager**.
3.  Nel Package Manager, assicurati che il menu a discesa in alto a sinistra sia impostato su **Unity Registry**.
4.  Cerca e seleziona il pacchetto **Input System**.
5.  Clicca sul pulsante **Install** nell'angolo in basso a destra.
6.  Dopo l'installazione, Unity ti chiederà se vuoi abilitare i nuovi backend di input e disabilitare quelli vecchi. Clicca su **Yes** (o **Sì**). L'Editor di Unity si riavvierà.

### 6.2. Creazione di un Input Action Asset e Generazione della Classe C#

Il nuovo Input System utilizza un **Input Action Asset** per definire le azioni di input e i loro binding. Questo asset è fondamentale per il funzionamento degli script che utilizzeranno il nuovo sistema di input.

1.  Nella finestra **Project** di Unity, crea una nuova cartella `Input` (es. `Assets/Input/`).
2.  Clicca con il tasto destro nella cartella `Input`, vai su **Create > Input Actions**.
3.  Nomina il nuovo asset `PlayerInputActions` (o un nome simile).
4.  Fai doppio clic sull'asset `PlayerInputActions` per aprirlo nella finestra **Input Actions**.
5.  In questa finestra, vedrai tre colonne: **Action Maps**, **Actions** e **Properties**.

    -   **Action Maps:** Clicca sul segno `+` sotto la colonna **Action Maps** e crea una nuova Action Map chiamata `Player`.
    -   **Actions:** Con la Action Map `Player` selezionata, clicca sul segno `+` sotto la colonna **Actions** per creare le seguenti azioni. Per ciascuna azione, imposta il **Control Type** appropriato:
        -   `Move` (Type: `Value`, Control Type: `Vector2`)
        -   `Jump` (Type: `Button`)
        -   `Attack` (Type: `Button`)
        -   `DodgeBlock` (Type: `Button`)
        -   `Interact` (Type: `Button`)
        -   `LockOn` (Type: `Button`)
        -   `MenuPause` (Type: `Button`)
        -   `ChangeTarget` (Type: `Button`)

6.  **Aggiungi i Binding:** Per ogni azione, clicca sul segno `+` sotto la colonna **Properties** per aggiungere i binding. Ecco alcuni esempi basati sui requisiti del progetto:

    -   **Move:**
        -   `Path: <Gamepad>/leftStick`
        -   `Path: <Keyboard>/w` (con Composite: `2D Vector`, Up: `W`, Down: `S`, Left: `A`, Right: `D`)
    -   **Jump:**
        -   `Path: <Gamepad>/buttonSouth`
        -   `Path: <Keyboard>/space`
    -   **Attack:**
        -   `Path: <Gamepad>/buttonWest`
        -   `Path: <Mouse>/leftButton`
    -   **DodgeBlock:**
        -   `Path: <Gamepad>/buttonEast`
        -   `Path: <Mouse>/rightButton`
    -   **Interact:**
        -   `Path: <Gamepad>/buttonNorth`
        -   `Path: <Keyboard>/e`
    -   **LockOn:**
        -   `Path: <Gamepad>/rightShoulder`
        -   `Path: <Keyboard>/q`
    -   **MenuPause:**
        -   `Path: <Gamepad>/start`
        -   `Path: <Keyboard>/enter`
    -   **ChangeTarget:**
        -   `Path: <Gamepad>/rightTrigger`
        -   `Path: <Keyboard>/tab`

7.  **Genera la Classe C#:** **Questo è un passaggio FONDAMENTALE.** Nella finestra **Input Actions**, assicurati che la casella **Generate C# Class** sia spuntata (di solito si trova nelle proprietà dell'asset, potresti dover scorrere verso il basso). Puoi lasciare il **Namespace** vuoto o impostarlo a `UnityEngine.InputSystem` se preferisci. Clicca su **Apply**.

    Questo genererà automaticamente un file C# (es. `PlayerInputActions.cs`) che il tuo script `PlayerController.cs` utilizzerà per accedere alle azioni di input. **Non devi creare questo file manualmente.** Unity lo creerà per te e lo manterrà aggiornato. Assicurati che questo file generato si trovi nella cartella `Assets/Scripts/Player/` o in una sottocartella accessibile.

### 6.3. Aggiornamento di PlayerController.cs per il Nuovo Input System

Una volta generato il file `PlayerInputActions.cs` da Unity, puoi modificare il tuo `PlayerController.cs` per utilizzarlo. Ecco come dovrebbe apparire lo script `PlayerController.cs` per funzionare con il nuovo Input System:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;

    // Input Actions
    private PlayerInputActions playerInputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction dodgeBlockAction;
    private InputAction interactAction;
    private InputAction lockOnAction;
    private InputAction menuPauseAction;
    private InputAction changeTargetAction;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();

        // Assign actions
        moveAction = playerInputActions.Player.Move;
        jumpAction = playerInputActions.Player.Jump;
        attackAction = playerInputActions.Player.Attack;
        dodgeBlockAction = playerInputActions.Player.DodgeBlock;
        interactAction = playerInputActions.Player.Interact;
        lockOnAction = playerInputActions.Player.LockOn;
        menuPauseAction = playerInputActions.Player.MenuPause;
        changeTargetAction = playerInputActions.Player.ChangeTarget;

        // Enable actions
        moveAction.Enable();
        jumpAction.Enable();
        attackAction.Enable();
        dodgeBlockAction.Enable();
        interactAction.Enable();
        lockOnAction.Enable();
        menuPauseAction.Enable();
        changeTargetAction.Enable();

        // Subscribe to events for button presses
        jumpAction.performed += OnJumpPerformed;
        attackAction.performed += OnAttackPerformed;
        dodgeBlockAction.performed += OnDodgeBlockPerformed;
        interactAction.performed += OnInteractPerformed;
        lockOnAction.performed += OnLockOnPerformed;
        menuPauseAction.performed += OnMenuPausePerformed;
        changeTargetAction.performed += OnChangeTargetPerformed;

        // Note: Weapon change actions (Weapon1, Weapon2, etc.) and complex ability/item actions
        // would need to be defined in the Input Action Asset and handled here or in separate managers.
        // For simplicity, they are omitted in this basic PlayerController.
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputVector.x, 0f, inputVector.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("Jump!");
        }
    }

    void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Attack!");
        // Implement attack logic
    }

    void OnDodgeBlockPerformed(InputAction.CallbackContext context)
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        if (inputVector.magnitude > 0.1f)
        {
            Debug.Log("Dodge!");
            // Implement dodge logic
        }
        else
        {
            Debug.Log("Block!");
            // Implement block logic
        }
    }

    void OnInteractPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Interact!");
        // Implement interact logic
    }

    void OnLockOnPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Lock On!");
        // Implement lock-on logic
    }

    void OnMenuPausePerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Menu / Pause!");
        // Implement menu/pause logic
    }

    void OnChangeTargetPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Change Target!");
        // Implement change target logic
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnEnable()
    {
        playerInputActions.Enable();
    }

    void OnDisable()
    {
        playerInputActions.Disable();
    }
}
```

**Configurazione in Unity (Aggiornata):**

1.  Segui i passaggi in **6.1. Installazione del Pacchetto Input System** e **6.2. Creazione di un Input Action Asset e Generazione della Classe C#**.
2.  Assicurati che il file `PlayerInputActions.cs` generato da Unity si trovi nella cartella `Assets/Scripts/Player/`.
3.  Crea un GameObject vuoto nella tua scena (es. `Player`).
4.  Aggiungi il componente `PlayerController` a questo GameObject.
5.  Aggiungi un componente `Rigidbody` al GameObject `Player` e assicurati che `Use Gravity` sia abilitato e `Is Kinematic` sia disabilitato. Puoi anche congelare le rotazioni (Constraints -> Freeze Rotation) per evitare rotazioni indesiderate.
6.  Assicurati che il tuo GameObject `Player` abbia un `Collider` (es. `Capsule Collider`) e che ci sia un `Collider` sul terreno con il tag "Ground" per il rilevamento della collisione.

Con queste modifiche, il tuo `PlayerController` sarà pronto per utilizzare il nuovo Input System, offrendo maggiore flessibilità e controllo sull'input del giocatore.


