## GAME DESIGN DOCUMENT

Creado por:  Gonzalo Pulleiro Juncal 

Versión del documento:  1.00 

## HISTORIAL DE REVISIONES

| Versión | Fecha | Comentarios |
| --- | --- | --- |
| 1.00 |  01/05/2024  | Creación del documento |


## PRESENTACIÓN

### Título

> DINEOJUEGO

### Concepto

> Videojuego 2D de plataformas en el cual el personaje principal tiene que obtener todos los objetos posibles, intentando evitar el choque con águilas, que 
le harán perder la vida. 

### Género

> Videojuego 2D de plataformas.

### Público 

> A partir de 4 años, para ambos sexos. 
> Videojuego intuitivo, no violento, en el cual se puede competir, en diferentes partidas, a ver quién consigue mayor puntuación.

### Plataforma
> Videojuego creado para PC con sistema operativo Windows. 

## GAMEPLAY

### Objetivos

> El objetivo principal del juego es conseguir la mayor puntuación posible evitando ser destruido.

### Jugabilidad

> Nuestro personaje avanzará hacia adelante y hacia atrás, también saltará, todo ello para intentar adquirir todos los objetos que están situados a lo largo de la escena,
evitar la colisión con las águilas, que son los enemigos del juego, y conseguir colisionar con los osos y las zarigüellas, para obtener una mayor puntuación.

### Progresión

> El juego se reparte en 3 escenas. La primera es la escena de presentación, donde se incluye el título, autor y mensaje para iniciar la partida cuando el jugador quiera.
La segunda escena es el videojuego, donde se podrá jugar. Cuando el personaje pierda las vidas y muera se pasa a la tercera y última pantalla. 
En ella se mostrará la puntuación obtenida en este último juego, junto con un mensaje que indicará al jugador que tecla pulsar si desea reiniciar o cerrar el juego.

### GUI

> Para escena 1 y 3 ver apartado anterior "Progresión".
En la escena principal el jugador tiene información de las vidas disponibles en la esquina superior izquierda, con miniaturas del personaje principal.
En la esquina superior derecha se muestra la puntuación máxima del juego en la parte más superior, y debajo de esta se muestra la puntuación actual.


## MECÁNICAS DEL JUEGO

### Reglas

> La regla fundamental es conseguir todos los objetivos sin que las águilas colisionen con el jugador. 

### Interacción

> Para el manejo del personaje emplearemos las flechas de dirección (derecha e izquierda) para movernos hacia delante y hacia detrás. También usaremos la barra espaciadora
para saltar y poder subirnos a las plataformas. 
A mayores se incluye el uso de la tecla 'P', para pausar y reanudar el juego.
Tecla 'Esc' para abandonar el juego en cualquier momento.
Tecla 'F1' para dismunir la velocidad del juego.
Tecla 'F2' para aumentar la velocidad del juego.
Tecla 'F3' para volver la velocidad del juego a velocidad normal.

### Puntuaje

> El videojuego consta de 6 objetos con los cuales puedes conseguir puntuación:
	- Cerezas, 10 puntos.
	- Zanahorias, 10 puntos.
	- Gemas, 20 puntos.
	- Estrellas, 40 puntos.
	- Osos, 50 puntos.
	- Zarigüellas, 50 puntos.

### Dificultad

> La dificultad del videojuego a nivel general es baja.
Una vez iniciado el juego, las águilas, que son el enemigo principal, van surgiendo poco a poco, pero a medida que el tiempo de juego avanza, 
la aparicion de las águilas va en aumento, tratando así de poner las cosas más difíciles al personaje principal.
Para que el personaje no se quede en la cueva evitando así la colisión con las águilas, la aparición de las zarigüellas será lenta. 

## ELEMENTOS VIDEOJUEGO

> El videojuego cuenta con plataformas, cuevas y terreno. A través de los cuales el personaje debe avanzar, retroceder y saltar para conseguir los objetivos.
Para acceder a las plataformas deberá saltar hacia ellas y sobre ellas. Para acceder a las cuevas cuenta con dos entradas/salidas, de las cuales deberá salir 
por una de ellas también. Para moverse por el terreno no tendría mayor dificultad que evitar esas entradas/salidas a la cueva.

## ASSETS

### Música

> El videojuego cuenta con una canción de fondo diferente para cada pantalla. 
La música de la pantalla principal se pausa cuando el jugador quiere pausar la partida. Una vez se reanude, la canción suena en el mismo punto en que se pausó, no se reinicia.
Son 3 canciones que considero son apropiadas a cada momento, puesto que estamos hablando de un videojuego de plataformas y se pueden asociar perfectamente. 

### Efectos de sonido

> En el momento que el personaje principal colisiona con alguno de los objetos, surge un efecto.
Cuando colisiona con un oso o una zarigüella, surge otro efecto.
Al colisionar con un águila y perder una vida, surge otro efecto.
Al perder la última vida, surge otro efecto.
Estos 4 son efectos distintos todos. 