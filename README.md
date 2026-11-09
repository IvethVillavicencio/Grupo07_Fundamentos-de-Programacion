# Sistema de Gestión de una Botica

Proyecto de escritorio desarrollado en C# con Windows Forms sobre .NET Framework 4.7.2.

## Módulos
- Gestión de medicamentos: registrar, buscar por código/nombre, actualizar y eliminar.
- Inventario: listado general, stock bajo (5 unidades o menos), próximos a vencer (90 días) y vencidos.
- Ventas: carrito, validación de stock, cálculo de subtotales y total, descuento de existencias y registro de ventas.
- Persistencia: los medicamentos se guardan en `Data/medicamentos.txt` y las ventas en `Data/ventas.txt`, junto al ejecutable.

## Abrir
1. Abrir `Desafio 5.slnx` con Visual Studio compatible con soluciones `.slnx`, o abrir directamente `Desafio 5/SistemaBotica.csproj`.
2. Verificar que esté instalada la carga de trabajo **Desarrollo de escritorio con .NET** y .NET Framework 4.7.2 Developer Pack.
3. Establecer el proyecto como inicio y ejecutar con F5.

## Uso
1. Registrar medicamentos desde la ventana principal.
2. Abrir Control de inventario para consultar existencias y vencimientos.
3. Abrir Gestionar ventas para agregar productos al carrito y confirmar la venta.
4. Los archivos de datos se crean automáticamente en la carpeta `Data` junto al ejecutable.

## Git
```bash
git init
git add .
git commit -m "Sistema de gestion de botica"
```

Los datos de prueba son responsabilidad del usuario. No utilizar este prototipo como sistema farmacéutico comercial sin validaciones, controles de seguridad y revisión profesional adicionales.
