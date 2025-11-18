using System;

class Program
{
    static void Main()
    {
        var gestor = new GestorProductosFacade();
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("      GESTOR DE PRODUCTOS (Decorator + Facade)");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Crear producto");
            Console.WriteLine("2. Agregar categoría");
            Console.WriteLine("3. Agregar marca");
            Console.WriteLine("4. Agregar etiqueta extra");
            Console.WriteLine("5. Ver producto");
            Console.WriteLine("6. Listar todos los productos");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==============================================");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
                opcion = -1;

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    CrearProducto(gestor);
                    break;
                case 2:
                    AgregarCategoria(gestor);
                    break;
                case 3:
                    AgregarMarca(gestor);
                    break;
                case 4:
                    AgregarEtiquetaExtra(gestor);
                    break;
                case 5:
                    VerProducto(gestor);
                    break;
                case 6:
                    ListarProductos(gestor);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla.");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 0);
    }

    static void CrearProducto(GestorProductosFacade gestor)
    {
        Console.Write("ID del producto: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        gestor.CrearProducto(id, nombre, precio);

        Console.WriteLine("Producto creado exitosamente.");
    }

    static void AgregarCategoria(GestorProductosFacade gestor)
    {
        Console.Write("ID del producto: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Categoría: ");
        string categoria = Console.ReadLine();

        gestor.AgregarCategoria(id, categoria);

        Console.WriteLine("Categoría agregada.");
    }

    static void AgregarMarca(GestorProductosFacade gestor)
    {
        Console.Write("ID del producto: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Marca: ");
        string marca = Console.ReadLine();

        gestor.AgregarMarca(id, marca);

        Console.WriteLine("Marca agregada.");
    }

    static void AgregarEtiquetaExtra(GestorProductosFacade gestor)
    {
        Console.Write("ID del producto: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Clave de la etiqueta: ");
        string clave = Console.ReadLine();

        Console.Write("Valor: ");
        string valor = Console.ReadLine();

        gestor.AgregarEtiquetaExtra(id, clave, valor);

        Console.WriteLine("Etiqueta extra agregada.");
    }

    static void VerProducto(GestorProductosFacade gestor)
    {
        Console.Write("ID del producto: ");
        int id = int.Parse(Console.ReadLine());

        var p = gestor.ObtenerProducto(id);

        if (p == null)
            Console.WriteLine("Producto no encontrado.");
        else
            Console.WriteLine("\n" + p.ObtenerDescripcion());
    }

    static void ListarProductos(GestorProductosFacade gestor)
    {
        var productos = gestor.ListarProductos();

        Console.WriteLine("PRODUCTOS REGISTRADOS:\n");

        foreach (var p in productos)
            Console.WriteLine(p.ObtenerDescripcion());

        if (!productos.GetEnumerator().MoveNext())
            Console.WriteLine("(No hay productos)");
    }
}
