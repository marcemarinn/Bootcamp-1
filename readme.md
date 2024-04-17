# Requisitos del Sistema Bancario

## 1. Registro de SOLICITUD Productos del Banco

### Ejemplos de Productos
- **Crédito:** El cliente establece el monto que desea y el plazo de preferencia.
- **Tarjeta de crédito:** El cliente elige la marca.
- **Cuenta corriente:** El cliente especifica el monto a depositar.

### General
- Se debe establecer la moneda.
- Fecha de solicitud.
- Fecha de aprobación por parte del banco.

### Criterios de aceptación
- **a)** Endpoint que permita registrar la solicitud.
- **b)** Entidad que guardará las solicitudes, con su correcta configuración y migración.

## 2. Transferencias entre Cuentas

### Detalles
- Se establece la cuenta de origen mediante su ID.
- Datos requeridos para la cuenta de destino:
  - Banco de destino.
  - Número de cuenta.
  - Número de documento.
  - Moneda.
- Monto.
- Se debe guardar la fecha de la realización de esta operación.

### Criterios de aceptación
- **a)** Endpoint para realizar la transferencia.
- **b)** Debe ser una transacción.
- **c)** Movimientos.
- **d)** Validaciones:
  - **d.1)** Tiene que ser el mismo tipo de cuenta.
  - **d.2)** Debe ser la misma moneda.
  - **d.3)** El monto de transferencia no debe ser superior al saldo actual de la cuenta.
  - **d.4)** La cuenta de origen debe estar activa.
  - **d.5)** Verificar si la operación sobrepasa el límite operacional.
- **e)** Si la transferencia es entre cuentas del mismo banco, con el ID de la cuenta destino ya alcanza.

## 3. Pagos de Servicios

### Detalles
- Número de documento.
- Monto.
- Descripción.
- Cuenta de la que se debita el importe.

### Criterios de aceptación
- **a)** Endpoint para realizar pago.
- **b)** Correcta actualización del saldo de la cuenta.
- **c)** Registro del pago. Entidad que guardará el pago, con su correcta configuración y migración.

## 4. Depósito

### Detalles
- ID de cuenta a depositar.
- ID del banco.
- Monto.
- Se debe guardar la fecha de la operación.

### Criterios de aceptación
- **a)** Debe actualizar correctamente el saldo.
- **b)** Se debe validar que el monto no sobrepase el límite operacional si fuera el caso.

## 5. Extracción

### Detalles
- ID de cuenta de la que se extraerá.
- ID del banco.
- Monto.
- Se debe guardar la fecha de la operación.

### Criterios de aceptación
- **a)** Debe actualizar correctamente el saldo.
- **b)** Se debe validar que el monto no sobrepase el límite operacional si fuera el caso.

## 6. Historial de Transacciones de la Cuenta

### Detalles
- Listar las transacciones realizadas.

### Filtros
- **Cuenta (obligatorio)**
- **Mes/Año:** Se recibe por parámetros tanto el mes como el año.
- **Rango de Fechas:** Traer todas las operaciones que se comprenden en dicho rango.
- **Descripción:** Todas las operaciones tienen una descripción que permite saber qué significan o a qué hacen referencia.

### Criterios de aceptación
- **a)** Todos los filtros son opcionales, excepto cuenta. Pero si se especifica solo el "mes" y no el "año", la API debe indicar claramente este requerimiento.
- **b)** Si se especifican más de un filtro, deben funcionar en conjunto.
- **c)** Se deben listar todas las operaciones correspondientes según los filtros aplicados.
- **d)** Unión de los resultados tanto de las transferencias como de los pagos, dado que ambos están relacionados a la cuenta.

## Criterios Generales

### 1. Funcionalidad
- El código debe generar el resultado esperado.

### 2. Buenas prácticas
- Nombramiento establecido en el README del repositorio guía del profesor.
- Principios SOLID.
- DRY (Don't Repeat Yourself).
- Evitar código innecesario.
- Elegir los tipos de variables correctos según la situación.

### 3. Entendimiento
- Justificar los desarrollos realizados.

### 4. Performance
- Menor cantidad de viajes a la base de datos.
- Presencia de solo las líneas necesarias para el funcionamiento.

### 5. Velocidad
- Rapidez con la que se entregan los desarrollos solicitados.

### 6. Pulcritud
- El código debe ser lo más agradable posible a la vista.
- Evitar la necesidad de desplazamiento horizontal.
- Formato que facilite el análisis del código.

### 7. Responsabilidad
- Seguimiento a las reglas establecidas por el profesor.

### 8. Disciplina
- Respeto a los horarios y personas.
