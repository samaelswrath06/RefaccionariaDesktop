# Refaccionaria Desktop — avance 3
Aplicación de escritorio WPF para Windows 11 con C#/.NET 10 y SQLite.

## Funciones incorporadas
- Alta, búsqueda, edición y eliminación protegida de productos.
- Catálogo de refacciones agrícolas y de motocicletas.
- Campos de código, descripción, marca, número de parte, costo, precio, existencia y mínimo.
- Aviso de productos en existencia mínima.
- Ventas rápidas con descuento transaccional de inventario.
- Validación de existencia y precio actuales al cobrar, dentro de la transacción.
- Registro de equivalencias por marca y número de parte alternativo.
- Corte diario de caja: cuenta ventas y suma el total del día; guarda el cierre y bloquea nuevas ventas de esa fecha.
- Respaldo manual de la base de datos.

## Compilación automática en Windows
El repositorio incluye un flujo de GitHub Actions para publicar un ejecutable autocontenido Windows x64. La compilación debe completarse correctamente antes de distribuirlo.

## Estado
Este avance aún requiere compilación y pruebas en Windows. Faltan compras/proveedores, devoluciones, impresión de tickets, reportes, usuarios/permisos, respaldos automáticos y CFDI.