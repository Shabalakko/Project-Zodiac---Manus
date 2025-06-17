## Struttura delle cartelle del progetto Unity

```
ProjectZodiac/
├── Assets/
│   ├── Scenes/
│   │   ├── MainMenu.unity
│   │   ├── Gameplay.unity
│   │   ├── DungeonCrawler.unity
│   │   └── ... (altre scene)
│   ├── Scripts/
│   │   ├── Player/
│   │   │   ├── PlayerController.cs
│   │   │   ├── PlayerStats.cs
│   │   │   └── PlayerCombat.cs
│   │   ├── Enemies/
│   │   │   ├── EnemyAI.cs
│   │   │   └── EnemyStats.cs
│   │   ├── Weapons/
│   │   │   ├── WeaponManager.cs
│   │   │   └── WeaponAbilities.cs
│   │   ├── UI/
│   │   │   ├── UIManager.cs
│   │   │   └── HUDController.cs
│   │   ├── Core/
│   │   │   ├── GameManager.cs
│   │   │   └── AudioManager.cs
│   │   └── Utilities/
│   ├── Models/
│   │   ├── Characters/
│   │   ├── Enemies/
│   │   └── Weapons/
│   ├── Materials/
│   ├── Textures/
│   ├── Animations/
│   ├── Audio/
│   │   ├── Music/
│   │   └── SFX/
│   ├── Prefabs/
│   │   ├── Player/
│   │   ├── Enemies/
│   │   ├── Weapons/
│   │   └── UI/
│   ├── Resources/
│   ├── Shaders/
│   ├── VFX/
│   └── ThirdParty/
└── ProjectSettings/
```

## Scene Principali

-   **MainMenu.unity:** Schermata iniziale, opzioni, nuovo gioco, carica partita.
-   **Gameplay.unity:** Scena principale per l'esplorazione del mondo e il combattimento.
-   **DungeonCrawler.unity:** Scena dedicata alla modalità dungeon crawler (roguelike).
-   **LoadingScreen.unity:** Schermata di caricamento tra le scene.
-   **GameOver.unity:** Schermata di game over.

## Asset Necessari

-   **Modelli 3D:** Personaggi (giocatore, NPC), nemici, armi, ambienti (terreno, edifici, oggetti di scena).
-   **Texture:** Per modelli 3D, UI, effetti visivi.
-   **Animazioni:** Per personaggi (movimento, attacco, abilità), nemici.
-   **Audio:** Musica (sfondo, combattimento), effetti sonori (attacchi, abilità, UI, ambiente).
-   **UI Elements:** Immagini, font, icone per HUD, menu, inventario, ecc.
-   **VFX (Visual Effects):** Effetti particellari per abilità, attacchi, elementi ambientali.
-   **Shaders:** Per effetti grafici specifici (es. stile grafico KH1).


