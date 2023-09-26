# TechOil
# Alkemy Integrador TechOil C# .Net
El proyecto está desarrollado con Net Core 6
​
## **Especificación de la Arquitectura**
​
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext y crearemos los seeds correspondientes para popular nuestras entidades.
​
### **Capa Models**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Repositories**
En esta capa definiremos las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo
​

* DataAcces: Es donde definiremos el DbContext y crearemos los seeds correspondientes para probar nuestras entidades.​
*	DTOs: Transferir datos entre las capas de la aplicación
*	Mapper: Asignar datos de un objeto a otro objeto con una estructura diferente
*	Models: Modelo de las clases y definicion de la base de datos
*	Services: Creacion del IunitOfWork y UnitOfWork
​
## **Especificación de GIT**
​
* Se trabajo sobre la rama develop para la fase de prueba de la API y al agregar funcionalidades, estas se pusheaban a la rama principal cuando el codigo no presentaba errores.
