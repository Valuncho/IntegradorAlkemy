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
### **Capa Entities**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Repositories**
En esta capa definiremos las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo
​
### **Capa Core**
Es nuestra capa principal, en ella encontramos varios subniveles

*	Helper: 
*	Interfaces: 
*	Mapper: 
*	Models: 
*	Services: 
​
## **Especificación de GIT**
​
* 
