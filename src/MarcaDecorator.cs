public class MarcaDecorator : ProductoDecorator
{
    private readonly string _marca;

    public MarcaDecorator(IProducto producto, string marca)
        : base(producto)
    {
        _marca = marca;
    }

    public override string ObtenerDescripcion()
    {
        return base.ObtenerDescripcion() + $" | Marca: {_marca}";
    }
}
