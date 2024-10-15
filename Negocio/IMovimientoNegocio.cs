using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public interface IMovimientoNegocio
    {
        Task<IEnumerable<Movimiento>> ListarMovimiento(Movimiento mov);

        Task<Movimiento> ObtenerxCodigo(string codigo);
        Task Crear(Movimiento mov);

        Task Actualizar(Movimiento mov);

        Task Eliminar(string codigo);
    }
}
