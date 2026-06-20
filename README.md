# Laberinto BFS

## Descripción

Laberinto BFS es una aplicación desarrollada en **C# con Windows Forms** que implementa el algoritmo **Breadth-First Search (BFS)** para encontrar el camino más corto dentro de un laberinto.

El sistema representa un laberinto mediante una matriz bidimensional, donde las celdas pueden ser espacios libres o paredes. Al ejecutar la búsqueda, el algoritmo explora el laberinto desde un punto de inicio hasta encontrar la salida, mostrando visualmente la ruta encontrada.

---

## Características

* Implementación del algoritmo Breadth-First Search (BFS).
* Búsqueda automática del camino más corto.
* Representación gráfica del laberinto.
* Visualización del recorrido encontrado.
* Identificación visual de inicio y salida.
* Registro de movimientos realizados.
* Interfaz gráfica desarrollada con Windows Forms.

---

## Tecnologías Utilizadas

* C#
* .NET Framework
* Windows Forms
* Algoritmos de Búsqueda
* Estructuras de Datos
* Programación Orientada a Objetos (POO)

---

## Funcionamiento

### Representación del Laberinto

El laberinto se almacena en una matriz de enteros:

```text
0 = Camino libre
1 = Pared
```

Ejemplo:

```text
0 0 1 0
0 1 1 0
0 0 0 0
1 1 0 0
```

---

### Punto de Inicio

El algoritmo comienza en la posición:

```text
(0,0)
```

Representada visualmente en color rojo.

---

### Punto de Salida

La meta se encuentra en:

```text
(10,10)
```

Representada visualmente en color azul.

---

### Algoritmo BFS

El algoritmo explora los nodos por niveles utilizando una cola (Queue), garantizando encontrar el camino más corto disponible.

Movimientos permitidos:

* Arriba
* Abajo
* Izquierda
* Derecha

Durante la búsqueda se almacenan:

* Posiciones visitadas.
* Camino recorrido.
* Direcciones tomadas.

---

### Visualización

Colores utilizados:

| Color  | Significado       |
| ------ | ----------------- |
| Negro  | Pared             |
| Blanco | Camino libre      |
| Rojo   | Inicio            |
| Azul   | Salida            |
| Verde  | Camino encontrado |

---

## Ejemplo de Salida

```text
Paso 1: (0,0) - Inicio
Paso 2: (1,0) - Abajo
Paso 3: (2,0) - Abajo
Paso 4: (3,0) - Abajo
Paso 5: (3,1) - Derecha
...
Paso N: (10,10) - Salida
```

---

## Estructura del Proyecto

```text
LaberintoBFS/
│
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
├── Properties/
└── Resources/
```

---

## Componentes Principales

### BFS()

Método encargado de encontrar el camino más corto entre el inicio y la salida utilizando búsqueda en anchura.

Funciones:

* Explorar posiciones vecinas.
* Evitar nodos repetidos.
* Registrar movimientos.
* Construir la ruta final.

---

### OnPaint()

Responsable de dibujar:

* El laberinto.
* Las paredes.
* El camino encontrado.
* El punto de inicio.
* El punto de salida.

---

### Button Buscar Camino

Ejecuta el algoritmo BFS y actualiza la interfaz gráfica con la solución encontrada.

---

## Aplicaciones

Este proyecto puede utilizarse para:

* Aprendizaje de algoritmos BFS.
* Inteligencia Artificial.
* Sistemas de navegación.
* Robótica móvil.
* Planeación de rutas.
* Videojuegos.
* Investigación de caminos mínimos.

---

## Objetivo del Proyecto

Demostrar el funcionamiento del algoritmo Breadth-First Search mediante la resolución visual de un laberinto, mostrando cómo encontrar el camino más corto entre dos puntos dentro de una estructura de búsqueda.

---

## Autor

Proyecto desarrollado en C# utilizando Windows Forms para la visualización gráfica de laberintos y la implementación del algoritmo BFS (Breadth-First Search).
