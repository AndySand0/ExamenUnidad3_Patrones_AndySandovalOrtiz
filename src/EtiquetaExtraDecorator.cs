public class EtiquetaExtraDecorator : ProductoDecorator
{
    private readonly string _clave;
    private readonly string _valor;

    public EtiquetaExtraDecorator(IProducto producto, string clave, string valor)
        : base(producto)
    {
        _clave = clave;
        _valor = valor;
    }

    public override string ObtenerDescripcion()
    {
        return base.ObtenerDescripcion() + $" | {_clave}: {_valor}";
    }
}
