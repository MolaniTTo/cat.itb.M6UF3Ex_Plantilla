# Descripció del Repositori

Aquest repositori conté els següents apartats:

1. Descripció del projecte
2. Tecnologies utilitzades
3. Instruccions d'ús

## Tecnologies Utilitzades

### Tailwind CSS i Next.js

Per a la creació de la pàgina web, hem utilitzat Tailwind CSS i Next.js. Aquestes tecnologies ens han permès desenvolupar una interfície responsive de manera eficient.

- **Tailwind CSS**: Ens ha facilitat la implementació d'estils i disseny responsivo amb el seu sistema de classes utilitàries. Això ens ha permès crear una experiència d'usuari coherent en diferents dispositius sense escriure CSS personalitzat.
- **Next.js**: Aquest framework de React ens ha ajudat a crear una aplicació web ràpida i escalable. El seu sistema de rutes i la generació de pàgines estàtiques han millorat significativament la performance i el SEU de la nostra web.

### API amb Node.js

La API del projecte ha estat implementada utilitzant Node.js. Encara que Node.js no treballa directament amb objectes, hem estructurat el nostre codi dividint-lo en classes per a mantenir un codi organitzat i modular.

### Base de dades PostgreSQL

Hem utilitzat PostgreSQL com a base de dades. Inicialment, desenvolupem i provem la nostra base de dades en un entorn local. Posteriorment, migrem a un entorn cloud utilitzant ElephantSQL per a millorar l'accessibilitat i escalabilitat de la nostra aplicació.

## Instruccions d'Ús

### Peticions de la API

La API suporta diverses peticions que permeten interactuar amb la base de dades i altres serveis del backend. A continuació, es descriuen algunes de les principals peticions:

- **GET**: Per a obtenir dades específiques des de la base de dades.
- *POST**: Per a enviar dades noves a la base de dades.
- **PUT**: Per a actualitzar dades existents.
- **DELETE**: Per a eliminar dades de la base de dades.

### Connexió de la API a Unity

Per a connectar la API a Unity, hem implementat un sistema que permet realitzar peticions HTTP des de Unity a nostra API. Això ens permet que l'aplicació de Unity pugui interactuar directament amb el backend, obtenint i enviant informació en temps real.

### Corutinas en Unity

En Unity, hem utilitzat corutinas per a gestionar les anomenades a la API de manera asíncrona. Les corutinas ens permeten executar operacions en segon pla sense bloquejar el fil principal, millorant així la fluïdesa i performance de la nostra aplicació. Per exemple, una corutina pot gestionar una petició GET a la API, esperar la resposta i després actualitzar la interfície de l'usuari amb les dades rebudes.
