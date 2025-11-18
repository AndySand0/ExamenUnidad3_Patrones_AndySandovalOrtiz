public interface IProducto
{
    int Id { get; }
    string Nombre { get; }
    decimal Precio { get; }
    string ObtenerDescripcion();
}
