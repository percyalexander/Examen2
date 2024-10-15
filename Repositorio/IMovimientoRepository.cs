using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorio
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> ListarMovimiento(Movimiento mov);

        Task<Movimiento> ObtenerxCodigo(string codigo);
        Task Crear(Movimiento mov);

        Task Actualizar(Movimiento mov);

        Task Eliminar(string codigo);

    }
}
