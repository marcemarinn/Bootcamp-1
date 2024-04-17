1.- El cliente está interesado en un producto del banco, lo cual hay que registrar.
	>> Ejemplos de productos
	* Crèdito: el cliente establece el monto que desea y el plazo de preferencia
	* Tarjeta de crèdito: el cliente establece la marca
	* Cuenta corriente: el monto a depositar
	* En todos los casos:
	- Se debe establecer la moneda.
	- Fecha de solicitud.
	- Fecha de aprobaciòn por parte del banco.

--> Criterios de aceptación:
	a.) Endpoint que me permita registrar la solicitud.
	b.) Entidad que guardará las solicitudes, con su correcta configuración y migración.

2.- Transferencias entre cuentas. Quiero poder transferir dinero ya sea entre mis propias cuentas, 
u otras cuentas, ya sean del mismo banco o de otros bancos.
	* Se establece la cuenta de origen mediante su id.
	* Para la cuenta de destino, el cliente debe de cargar:
	- Banco de Destino.
	- Nro Cuenta.
	- Nro Documento.
	- Moneda.
	>> Se busca la cuenta que coincida con dichos datos para realizar la transferencia.
	* Monto.
	* Se debe guardar la fecha de la realización de esta operación.

--> Criterios de aceptación:
	a.) Endpoint para realizar la transferencia.
	b.) Debe ser una transacción.
	c.) Movements.
	d.) Validaciones:
		d.1) Tiene que ser el mismo tipo de cuenta.
		d.2) Debe ser la misma moneda.
		d.3) El monto de transferencia no debe ser superior al saldo actual de la cuenta.
		d.4) La cuenta de origen debe estar activa.
		d.5) Verificar Si la operación sobrepasa el límite operacional
	e.) Si la transferencia es entre cuentas del mismo banco, con el id de la cuenta destino ya alcanza.

3.- Pagos de servicios. Quiero poder pagar los servicios que tengo registrados en mi base de datos.
	* Nro Documento.
	* Monto.
	* Descripción.
	* Cuenta de la que se debita el importe.

--> Criterios de aceptación:
	a.) Endpoint para realizar pago.
	b.) Correcta actualización del saldo de la cuenta.
	c.) Registro del pago. Entidad que guardará el pago, con su correcta configuración y migración.

4.- Depósito. Quiero poder depositar dinero en cualquier cuenta.
	* Id de cuenta a depositar.
	* Id del banco.
	* Monto.
	* Se debe guardar la fecha de la operación.
	
--> Criterios de aceptación:
	a.) Debe actualizar correctamente el saldo.
	b.) Se debe validar que el monto no sobrepase el límite operacional si fuera el caso.

5.- Extracción. Quiero poder extraer dinero de mi cuenta.
		* Id de cuenta de la que se extraerá.
		* Id del banco.
		* Monto.
		* Se debe guardar la fecha de la operación.
		
--> Criterios de aceptación:
	a.) Debe actualizar correctamente el saldo.
	b.) Se debe validar que el monto no sobrepase el límite operacional si fuera el caso.

6.- Historial de transacciones de la cuenta.
	* Listar las transacciones que se realizaron.
	** Filtros:
	*** Cuenta (obligatorio)
	*** Mes/Anho: Se recibe por parametros tanto el mes como el año.
	Por ejemplo, si elijo "Abril - 2024", se deben traer todas las operaciones desde el 01/04/2024 hasta el 30/04/2024.
	*** Rango de Fechas: traer todas las operaciones que se comprenden en dicho rango.
	*** Descripción: todas las operaciones tienen una descripción que me permiten saber qué significan o a qué hacen referencia.

	--> Criterios de aceptación:
	a.) Todos los filtros son opcionales, excepto cuenta. Pero por ejemplo, si especifico el "mes", y no el "año", la api me debe indicar claramente este requerimiento.
	b.) Si especifico más de un filtro, deben funcionar en conjunto.
	c.) Se deben listar todas las operaciones correspondientes según los filtros aplicados.
	d.) Unión de los resultados tanto de las transferencias como de los pagos, dado que ambos están relacionados a la cuenta.


CRITERIOS GENERALES
1.- Funcionalidad: El código debe generar el resultado esperado.
2.- Buenas prácticas:
	* Nombramiento: establecidas en el readme del repo guía del profesor.
	* SOLID.
	* DRY (Dont repeat yourself).
	* Que no haya código innecesario.
	* Elegir los tipos de variables correctos según la situación.
3.- Entendimiento: Saber justificar los desarrollos realizados.
4.- Perfomance:
	* Menor cantidad de viajes a la base de datos. (trips)
	* Presencia de sólo las líneas necesarias para el funcionamiento.
5.- Velocidad:
	* Rapidez con la que se entregan los desarrollos solicitados.
6.- Pulcritud:
	* El código debe ser lo más agradable posible a la vista.
	* Nada de tener que scrollear horizontalmente.
	* Que el formato me facilite lo más posible su análisis.
7.- Responsabilidad: Seguimiento a las reglas establecidas por el profesor.
8.- Disciplina: Respeto a los horarios, personas, etc.