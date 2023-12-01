
# Ventas mensuales



|Posicion	 |	Nombre del Campo	| Tipo de dato  |
|------------|----------------------|------------   |
|    1 		 | Fecha del informe    | Fecha (8)     |
|	 9 	     | Codigo del vendedor  | varchar (3)   |
|    12      | Venta                | numerico(11)  |
|    23      |Venta a empresa grande| varchar(1) => Flag / mapearlo como true o false |


1. Crear las siguientes tablas:
    * ventas_mensuales => Guardar los datos mapeados
    * parametria => insertar un registro con la fecha_proceso en 2023-10-31
    * rechazos => insertar aca los registros que no pasaron alguna validacion
2. Leer el archivo, parsear a objetos. Puede que el archivo informe mal algun dato asi que deben implementar las validaciones correspondientes:
   * Siempre debe venir un codigo de vendedor. Si no viene se rechaza el registro
   * La fecha del informe debe ser igual a la fecha que se inserto en la tabla de parametria, si no es asi rechazar el registro
   * El flag "Venta a empresa grande" tiene solo dos valores posibles "S" o "N" cualquier otro dato es incorrecto y se rechaza
3. La solucion debe ser una aplicacion de consola utilizando EF CORE. Insertar los registros validados correctamentge en ventas_mensuales y los registros erroneos en rechazos
4. Listar todos los vendedores que hayan superado los 100.000 en el mes. Ejemplo: "El vendedor 001 vendio 250.000" 
5. Listar todos los vendedores que NO hayan superado los 100.000 en el mes. Ejemplo: "El vendedor 001 vendio 90.000" 
6. Listar todos los vendedores que haya  vendido al menos una vez a una empresa grande. Solo listar los codigos de vendedor
7. Listar rechazos

```
 Nota:
    Las ventas son 11 caracteres, 8 para los enteros, 1 caracter para el separador de decimal y 2 para los decimales
```