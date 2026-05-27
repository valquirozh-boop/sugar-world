# Sugar World — Proyecto 4: Platformer de Universos Narrativos

## Integrantes

- Sara Nuñes Echeverri
- Valentina Quiroz Herrera

---

## Descripción del juego

**Sugar World** es un platformer 2D de desplazamiento lateral ambientado en un universo dulce y fantástico. El jugador controla a un personaje que debe atravesar un nivel construido con plataformas de azúcar, esquivar peligros y recolectar golosinas para sumar puntos. El objetivo final es llegar a la **Nevera**, que representa la meta del nivel dentro del universo narrativo del proyecto.

---

## Requisitos del proyecto (Proyecto 4)

### Género y narrativa

| Requisito | Implementación |
|-----------|----------------|
| Platformer 2D con movimiento lateral y salto | `PlayerController.cs`: movimiento A/D o flechas, salto con Space/W/flecha arriba |
| Universo narrativo de otra materia | Mundo **Sugar World**: donas, pasteles, algodones, nevera, estética de dulces |
| Tilemaps para el nivel | Escena `Nivel_main` construida con Tilemaps y plataformas |
| Animaciones del personaje y entorno | Animación por sprites en `PlayerSpriteAnimator.cs` (idle, walk, jump) y elementos animados del entorno |

### Mecánicas de juego

| Requisito | Implementación |
|-----------|----------------|
| Dos tipos de coleccionables con puntos distintos | **Donas** (+10 pts) y **Pasteles** (+20 pts) con script `Collectible.cs` |
| Condición de victoria | Llegar a la **Nevera** (`Fridge.cs`) o usar el power-up final que impulsa al jugador hacia ella |
| Condición de derrota | Caer al vacío (`DeathZone.cs`) o ser alcanzado por el **Sol** (`SunEnemy.cs`) |
| Físicas y colisiones | `Rigidbody2D`, colliders, raycast de suelo y triggers para interacciones |

### Interfaz de usuario

**Menú principal** (`Assets/Scenes/Menu_Principal/menu.unity`):

- **Jugar**: carga el nivel principal
- **Créditos**: panel con integrantes y assets
- **Configuración**: panel visual dummy con botón Cerrar
- **Salir**: cierra la aplicación

**Escena de juego** (`Assets/Scenes/Nivel_main.unity`):

- **Panel de instrucciones**: pausa al inicio (`PanelInstrucciones.cs`)
- **HUD**: contadores de donas, pasteles y puntuación total (`UIManager.cs`, `ScoreManager.cs`)
- **Menú de pausa**: botón de pausa, Continuar, Configuración dummy, Volver al menú (`MenuPausa.cs`)
- **Panel de muerte**: al morir, con botón Reiniciar
- **Panel de victoria**: al completar, con Reiniciar e Ir al menú

**Diseño visual de la UI**: botones y paneles con imágenes personalizadas y estados Normal / Hover / Presionado (`EfectoBoton.cs`).

### Audio

| Evento | Dónde configurarlo |
|--------|-------------------|
| Salto | `Player` → `PlayerController` → **Jump Clip** |
| Recoger dona / pastel | `ScoreManager` → **Collect Dona Clip** / **Collect Pastel Clip** |
| Muerte | `Player` → `PlayerController` → **Defeat Clip** |
| Botones | `SonidoBoton.cs` |
| Música menú / juego | `MusicaMenu.cs` y fuentes en `Assets/Audio/` |

Los clips se asignan en el Inspector de Unity. Por defecto el nivel usa sonidos de `Assets/Audio/`; puedes reemplazarlos por archivos propios sin cambiar código.

---

## Características adicionales (3 mecánicas investigadas)

### 1. Sol que persigue al jugador

**Script:** `SunEnemy.cs`

El sol actúa como enemigo móvil que sigue la posición del jugador cada frame. Si entra en contacto con el personaje, detiene su movimiento y activa la derrota. Esto obliga al jugador a avanzar con rapidez y planear rutas sin quedarse quieto demasiado tiempo.

### 2. Plataformas que desaparecen

**Script:** `AlgodonEsfumable.cs` (plataformas de algodón de azúcar)

Cuando el jugador pisa la plataforma, comienza un temporizador. Tras unos segundos la plataforma se desvanece (alpha + collider desactivado) y puede reaparecer después de un intervalo configurable. Esto añade presión temporal y exige timing en los saltos.

### 3. Power-up del final

**Scripts:** `FloatPowerUp.cs` + `PlayerController.StartFloat()`

Cerca del final del nivel hay un coleccionable especial que, al recogerlo, lanza al jugador en un arco rápido hacia la Nevera, cambia temporalmente su sprite y reproduce el sonido de salto. Facilita el cierre del nivel y funciona como recompensa por llegar a la zona alta del mapa.

---

## Controles

| Acción | Tecla |
|--------|-------|
| Mover izquierda | A / Flecha izquierda |
| Mover derecha | D / Flecha derecha |
| Saltar | Space / W / Flecha arriba |
| Pausa | Botón de pausa en pantalla |

---

## Escenas

| Escena | Ruta |
|--------|------|
| Menú principal | `Assets/Scenes/Menu_Principal/menu.unity` |
| Nivel de juego | `Assets/Scenes/Nivel_main.unity` |

Orden de build: menú primero, luego `Nivel_main`.

---

## Cómo ejecutar el proyecto

1. Abrir la carpeta del proyecto en **Unity** (versión compatible con el `ProjectSettings` del repo).
2. Abrir la escena `Assets/Scenes/Menu_Principal/menu.unity`.
3. Pulsar **Play** o generar build para Windows desde *File → Build Settings*.

---
