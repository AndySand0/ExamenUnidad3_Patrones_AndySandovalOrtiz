public abstract class ProductoDecorator : IProducto
{
    protected IProducto _producto;

    public ProductoDecorator(IProducto producto)
    {
        _producto = producto;
    }

    public int Id => _producto.Id;
    public string Nombre => _producto.Nombre;
    public decimal Precio => _producto.Precio;

    public virtual string ObtenerDescripcion()
    {
        return _producto.ObtenerDescripcion();
    }
}
