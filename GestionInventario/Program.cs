using System;

namespace GestionInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            bool salir = false;

            Console.WriteLine("Bienvenido al Sistema de Gestión de Inventario");

            while (!salir)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Actualizar Precio de Producto");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. Contar y Agrupar Productos por Rango de Precio");
                Console.WriteLine("5. Generar Reporte Resumido del Inventario");
                Console.WriteLine("6. Filtrar y Ordenar Productos por Precio Mínimo");
                Console.WriteLine("7. Salir");

                Console.Write("Opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine();
                        double precio;
                        do {
                            Console.Write("Precio del producto: ");
                            precio = double.Parse(Console.ReadLine());
                            if (precio <= 0)
                            {
                                Console.WriteLine("Ingrese un valor valido");
                            }
                        } while (precio <= 0);

                        Producto producto = new Producto(nombre, precio);
                        inventario.AgregarProducto(producto);
                        break;

                    case 2:
                        Console.Write("Nombre del producto a actualizar: ");
                        string nombreActualizar = Console.ReadLine();

                        double nuevoPrecio;
                        do
                        {
                            Console.Write("Nuevo precio: ");
                            nuevoPrecio = double.Parse(Console.ReadLine());
                            if (nuevoPrecio <= 0)
                            {
                                Console.WriteLine("Ingrese un Dato valido");
                            }
                        } while (nuevoPrecio <= 0);

                        inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                        break;

                    case 3:
                        Console.Write("Nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        inventario.EliminarProducto(nombreEliminar);
                        break;

                    case 4:
                        inventario.AgruparProductos();
                        break;

                    case 5:
                        inventario.GenerarReporte();
                        break;

                    case 6:
                        double precioMinimo;
                        do {
                            Console.Write("Ingrese el precio mínimo para filtrar: ");
                            precioMinimo = double.Parse(Console.ReadLine());

                            if (precioMinimo <= 0)
                            {
                                Console.WriteLine("Ingrese un dato vailido");
                            }
                        } while (precioMinimo <= 0);

                        var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);
                        Console.WriteLine("\nProductos filtrados y ordenados:");
                        foreach (var p in productosFiltrados)
                        {
                            p.MostrarInfo();
                        }
                        break;

                    case 7:
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}