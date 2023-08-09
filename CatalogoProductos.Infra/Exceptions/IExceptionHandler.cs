using Microsoft.AspNetCore.Mvc;

namespace CatalogoProductos.Infra.Exceptions
{
    public interface IExceptionHandler
    {
        IActionResult Handle(Exception exception);
    }
}
