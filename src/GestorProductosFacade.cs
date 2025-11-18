using System;

public class GestorProductosFacade
{
    private readonly ProductoRepository _repo = new();

    public IProducto CrearProducto(int id, string nombre, decimal precio)
    {
        var producto = new Producto(id, nombre, precio);
        _repo.Guardar(producto);
        return producto;
    }

    public void AgregarCategoria(int id, string categoria)
        => Decorar(id, p => new CategoriaDecorator(p, categoria));

    public void AgregarMarca(int id, string marca)
        => Decorar(id, p => new MarcaDecorator(p, marca));

    public void AgregarEtiquetaExtra(int id, string clave, string valor)
        => Decorar(id, p => new EtiquetaExtraDecorator(p, clave, valor));

    private void Decorar(int id, Func<IProducto, IProducto> decorator)
    {
        var p = _repo.Obtener(id);
        if (p != null)
        {
            p = decorator(p);
            _repo.Guardar(p);
        }
    }

    public IProducto ObtenerProducto(int id) => _repo.Obtener(id);
    public IEnumerable<IProducto> ListarProductos() => _repo.ObtenerTodos();
}
