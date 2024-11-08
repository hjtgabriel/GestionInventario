using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{

    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                Console.WriteLine("El nombre del producto no puede estar vacío.");
                return;
            }
            if (producto.Precio <= 0)
            {
                Console.WriteLine("El precio debe ser un valor positivo.");
                return;
            }
            productos.Add(producto);
            Console.WriteLine($"Producto {producto.Nombre} agregado exitosamente.");
        }

        public void ActualizarPrecio(string nombreProducto, double nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"Precio del producto {nombreProducto} actualizado a {nuevoPrecio}.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombreProducto)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto {nombreProducto} eliminado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void AgruparProductos()
        {
            var agrupados = productos
                .GroupBy(p => p.Precio < 100 ? "Menos de 100" : p.Precio <= 500 ? "Entre 100 y 500" : "Más de 500")
                .Select(g => new { Rango = g.Key, Cantidad = g.Count() });

            Console.WriteLine("Productos agrupados por rango de precio:");
            foreach (var grupo in agrupados)
            {
                Console.WriteLine($"Rango: {grupo.Rango}, Cantidad: {grupo.Cantidad}");
            }
        }

        public void GenerarReporte()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            int totalProductos = productos.Count;
            double precioPromedio = productos.Average(p => p.Precio);
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).First();
            var productoMasBarato = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine("Reporte Resumido del Inventario:");
            Console.WriteLine($"Total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio: {precioPromedio}");
            Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre}, Precio: {productoMasCaro.Precio}");
            Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre}, Precio: {productoMasBarato.Precio}");
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(double precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);
        }
    }
}

