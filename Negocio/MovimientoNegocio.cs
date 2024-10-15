using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Repositorio;

namespace Negocio
{
    public class MovimientoNegocio : IMovimientoNegocio
    {
        private IMovimientoRepository _movRepository;
        public MovimientoNegocio(IMovimientoRepository movRepository)
        {
            _movRepository = movRepository;
        }
        public async Task Actualizar(Movimiento mov)
        {
            await _movRepository.Actualizar(mov);
        }

        public async Task Crear(Movimiento mov)
        {
            await _movRepository.Crear(mov);
        }

        public async Task Eliminar(string codigo)
        {
            await _movRepository.Eliminar(codigo);
        }

        public async Task<IEnumerable<Movimiento>> ListarMovimiento(Movimiento mov)
        {
            return await _movRepository.ListarMovimiento(mov);
        }

        public async Task<Movimiento> ObtenerxCodigo(string codigo)
        {
            return await _movRepository.ObtenerxCodigo(codigo);
        }
    }
}
