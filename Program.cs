using System;
using System.Collections.Generic;

class Program
{
    static List<Dictionary<string, string>> productos = new List<Dictionary<string, string>>();

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine(@$"
MENU
***********************************************
(1) Agregar producto
(2) Actualizar producto
(3) Ver lista de productos
(4) Eliminar producto
(5) Buscar producto por nombre
(6) Salir
");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarProducto();
                    break;
                case "2":
                    ActualizarProducto();
                    break;
                case "3":
                    VerListaDeProductos();
                    break;
                case "4":
                    EliminarProducto();
                    break;
                case "5":
                    BuscarProducto();
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("La opcion que ingrasaste no es valida, pon un numero del 1 al 6.");
                    break;
            }
        }
    }


    static void AgregarProducto()
    {
        var producto = new Dictionary<string, string>();
        Console.WriteLine("Cual es el nombre del producto?");
        producto["nombre"] = Console.ReadLine();

        Console.WriteLine("Cual es el precio del producto?");
        producto["precio"] = Console.ReadLine();

        Console.WriteLine("Cual es la cantidad del producto?");
        producto["cantidad"] = Console.ReadLine();

        productos.Add(producto);
        Console.WriteLine("El producto se agrego correctamente.");
    }

    static void ActualizarProducto()

    {
        Console.WriteLine("Cual es el nombre del producto para actualizar");
        string? nombre = Console.ReadLine();
        var producto = productos.Find(p => p["nombre"].Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (producto != null)
        {
            Console.WriteLine("Cual es el nuevo nombre del producto?");
            producto["nombre"] = Console.ReadLine();

            Console.WriteLine("Cual es el nuevo precio del producto?");
            producto["precio"] = Console.ReadLine();

            Console.WriteLine("Cual es la nueva cantidad del producto?");
            producto["cantidad"] = Console.ReadLine();

            Console.WriteLine("¡¡¡¡EL PRODUCTO HA SIDO ACTUALIZADO CORRECTAMENTE!!!!.");
        } else 
        {
            Console.WriteLine("El producto no fue encontrado.");
        }
    }

    static void VerListaDeProductos()
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("Todavia no hay productos en la lista.\n");
        }
        else
        {
            Console.WriteLine("LISTA DE PRODUCTOS: ===>\n");

            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto["nombre"]}");
                Console.WriteLine($"Precio: {producto["precio"]}");
                Console.WriteLine($"Cantidad: {producto["cantidad"]}");
                Console.WriteLine("---------------------------------------");
            }

            Console.WriteLine();

        }
    }


    static void EliminarProducto()
    {
        Console.WriteLine("Cual es el nombre del producto para eliminar?");
        string nombre = Console.ReadLine();
        var producto = productos.Find(p => p["nombre"].Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (producto!= null)
        {
            productos.Remove(producto);
            Console.WriteLine("El producto ha sido eliminado correctamente.");
        } else
        {
            Console.WriteLine("El producto no fue encontrado.");
        }
    }


    static void BuscarProducto()
    {
        Console.WriteLine("Cual es el nombre del producto para buscar?");
        string nombre = Console.ReadLine();
        var producto = productos.Find(p => p["nombre"].Equals(nombre, StringComparison.OrdinalIgnoreCase)); 

        if (producto != null)
        {
            Console.WriteLine($"Producto encontrado \nNombre: {producto["nombre"]}\nPrecio: {producto["precio"]}\nCantidad: {producto["cantidad"]}\n");
        } else
        {
            Console.WriteLine(" lo sentimos... El producto no fue encontrado.\n");
        }
    }    

}


