public class Producto : IProducto
{
    public int Id { get; }
    public string Nombre { get; }
    public decimal Precio { get; }

    public Producto(int id, string nombre, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }

    public virtual string ObtenerDescripcion()
    {
        return $"{Nombre} - {Precio:C}";
    }
}
