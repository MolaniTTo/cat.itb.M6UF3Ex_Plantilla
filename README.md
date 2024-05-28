# Descripción del Repositorio

Este repositorio contiene los siguientes apartados:

1. Descripción del proyecto
2. Tecnologías utilizadas
3. Instrucciones de uso

## Tecnologías Utilizadas

### Tailwind CSS y Next.js

Para la creación de la página web, hemos utilizado Tailwind CSS y Next.js. Estas tecnologías nos han permitido desarrollar una interfaz responsive de manera eficiente. 

- **Tailwind CSS**: Nos ha facilitado la implementación de estilos y diseño responsivo con su sistema de clases utilitarias. Esto nos ha permitido crear una experiencia de usuario coherente en diferentes dispositivos sin escribir CSS personalizado.
- **Next.js**: Este framework de React nos ha ayudado a crear una aplicación web rápida y escalable. Su sistema de rutas y la generación de páginas estáticas han mejorado significativamente la performance y el SEO de nuestra web.

### API con Node.js

La API del proyecto ha sido implementada utilizando Node.js. Aunque Node.js no trabaja directamente con objetos, hemos estructurado nuestro código dividiéndolo en clases para mantener un código organizado y modular.

### Base de Datos PostgreSQL

Hemos utilizado PostgreSQL como base de datos. Inicialmente, desarrollamos y probamos nuestra base de datos en un entorno local. Posteriormente, migramos a un entorno cloud utilizando ElephantSQL para mejorar la accesibilidad y escalabilidad de nuestra aplicación.

## Instrucciones de Uso

### Peticiones de la API

La API soporta diversas peticiones que permiten interactuar con la base de datos y otros servicios del backend. A continuación, se describen algunas de las principales peticiones:

- **GET**: Para obtener datos específicos desde la base de datos.
- **POST**: Para enviar datos nuevos a la base de datos.
- **PUT**: Para actualizar datos existentes.
- **DELETE**: Para eliminar datos de la base de datos.

### Conexión de la API a Unity

Para conectar la API a Unity, hemos implementado un sistema que permite realizar peticiones HTTP desde Unity a nuestra API. Esto nos permite que la aplicación de Unity pueda interactuar directamente con el backend, obteniendo y enviando información en tiempo real.

### Corutinas en Unity

En Unity, hemos utilizado corutinas para gestionar las llamadas a la API de manera asíncrona. Las corutinas nos permiten ejecutar operaciones en segundo plano sin bloquear el hilo principal, mejorando así la fluidez y performance de nuestra aplicación. Por ejemplo, una corutina puede gestionar una petición GET a la API, esperar la respuesta y luego actualizar la interfaz del usuario con los datos recibidos.
