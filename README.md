# uRenamer

üRenamer es un programa para renombrar archivos por lotes. 

Carpeta: Aquí se especifica el directorio que contiene los archivos a
	renombrar. Debe existir en el equipo. Se puede escribir o seleccionar
	pulsando en el icono de al lado.

Nuevo Nombre: El nombre de los archivos después de renombrar. Por defecto
	(dejado en blanco) es el nombre de la carpeta. 

Nº digitos: Para indicar si la numeracion debe aparecer como:
	Nombre - 1.ext
	Nombre - 01.ext
	Nombre - 001.ext

Nº Inicio: En que número empieza la enumeración.


Seleccionando un archivo o varios en el cuadro izquierdo se pueden mover hacia arribao abajo en la lista para evitar situaciones como:

PresProcesoP_Tema_1.pdf -> Tema - 01.pdf
Requisitos_Tema_3.pdf 	-> Tema - 02.pdf
UML_Tema_2.pdf		-> Tema - 03.pdf

También se puede eliminar un archivo o más para evitar un cambio de nombre no
deseado. A



# Ejemplos de uso

Carpeta: D:\Videos\VGHS T1
Nuevo Nombre: 

[D244578A]Video Game High School (VGHS) - Ep. 1[720p].mp4
[C345E76F]Video Game High School (VGHS) - Ep. 2[720p].mp4
[345A6E73]Video Game High School (VGHS) - Ep. 3[720p].mp4
[DBB37656]Video Game High School (VGHS) - Ep. 4[720p].mp4
[1267AC32]Video Game High School (VGHS) - Ep. 5[720p].mp4
[34ABB341]Video Game High School (VGHS) - Ep. 6[720p].mp4
[A987DCFE]Video Game High School (VGHS) - Ep. 7[720p].mp4

VGHS T1 - 01.mp4
VGHS T1 - 02.mp4
VGHS T1 - 03.mp4
VGHS T1 - 04.mp4
VGHS T1 - 05.mp4
VGHS T1 - 06.mp4
VGHS T1 - 07.mp4


Carpeta: D:\Videos\VGHS T1
Nuevo Nombre: 

[D244578A]Video Game High School (VGHS) - Ep. 1[720p].mp4
[C345E76F]Video Game High School (VGHS) - Ep. 2[720p].mp4
[345A6E73]Video Game High School (VGHS) - Ep. 3[720p].mp4
[DBB37656]Video Game High School (VGHS) - Ep. 4[720p].mp4 X
[1267AC32]Video Game High School (VGHS) - Ep. 5[720p].mp4 X
[34ABB341]Video Game High School (VGHS) - Ep. 6[720p].mp4
[A987DCFE]Video Game High School (VGHS) - Ep. 7[720p].mp4

VGHS T1 - 01.mp4
VGHS T1 - 02.mp4
VGHS T1 - 03.mp4
VGHS T1 - 04.mp4
VGHS T1 - 05.mp4
[DBB37656]Video Game High School (VGHS) - Ep. 4[720p].mp4
[1267AC32]Video Game High School (VGHS) - Ep. 5[720p].mp4


Carpeta: D:\Videos\VGHS T1
Nuevo Nombre: 

[D244578A]Video Game High School (VGHS) - Ep. 1[720p].mp4
[C345E76F]Video Game High School (VGHS) - Ep. 2[720p].mp4 ^
[345A6E73]Video Game High School (VGHS) - Ep. 3[720p].mp4
[DBB37656]Video Game High School (VGHS) - Ep. 4[720p].mp4
[1267AC32]Video Game High School (VGHS) - Ep. 5[720p].mp4
[34ABB341]Video Game High School (VGHS) - Ep. 6[720p].mp4 v
[A987DCFE]Video Game High School (VGHS) - Ep. 7[720p].mp4

VGHS T1 - 01.mp4 (antes 2)
VGHS T1 - 02.mp4 (antes 1)
VGHS T1 - 03.mp4
VGHS T1 - 04.mp4
VGHS T1 - 05.mp4
VGHS T1 - 06.mp4 (antes 7)
VGHS T1 - 07.mp4 (antes 6)

