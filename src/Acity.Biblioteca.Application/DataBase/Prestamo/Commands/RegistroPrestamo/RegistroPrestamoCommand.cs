using AutoMapper;
using Acity.Biblioteca.Domain.Entities.Solicitud;
using Microsoft.EntityFrameworkCore;
using Acity.Biblioteca.Application.Util;

namespace Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo
{
    public class RegistroPrestamoCommand: IRegistroPrestamoCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public RegistroPrestamoCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<long> Execute(RegistroPrestamoModel model)
        {
            //validamos si hay stock
            var libros = await _dataBaseService.Libro.ToListAsync();
            var libro = libros.Find(x => x.IdLibro == model.IdLibro);
            if (libro != null)
            {
                if (libro.Stock == 0)
                {
                    throw new ArgumentException("No hay stock disponible.");
                }
            }
            else
            {
                throw new ArgumentException("El libro no existe.", nameof(model.IdLibro));
            }

            //obtenemos una copia disponible
            var librosCopia = await _dataBaseService.LibroCopia.ToListAsync();
            var copiaDisponible = librosCopia.Find(x => x.IdLibro == model.IdLibro && x.Estado == (int)VariablesGlobales.TablaEstadoLibro.DISPONIBLE);

            //Registramos Solicitud de préstamo
            var entity = _mapper.Map<SolicitudEntity>(model);
            entity.IdLibroCopia = copiaDisponible!.IdLibroCopia;
            entity.IdEstado = (int)VariablesGlobales.TablaEstadoSolicitud.PENDIENTE;
            entity.IdTipo = (int)VariablesGlobales.TablaTipoSolicitud.PRESTAMO;
            entity.FechaCreacion = DateTime.Now;
            entity.Activo = true;
            await _dataBaseService.Solicitud.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            //Actualizamos estado de libroCopia
            copiaDisponible.Estado = (int)VariablesGlobales.TablaEstadoLibro.NO_DISPONIBLE;
            _dataBaseService.LibroCopia.Update(copiaDisponible);
            await _dataBaseService.SaveAsync();

            //Actualizamos stock de libro
            int? stockActualizado = (libro?.Stock - 1);
            libro!.Stock = stockActualizado ?? 0;
            _dataBaseService.Libro.Update(libro);
            await _dataBaseService.SaveAsync();

            return entity.IdSolicitud;
        }
    }
}
