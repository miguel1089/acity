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
            //validamos si existe el libro
            var librosCopia = await _dataBaseService.LibroCopia.ToListAsync();
            var libroCopia = librosCopia.Find(x => x.IdLibroCopia == model.IdLibroCopia);
            if (libroCopia == null)
            {
                throw new ArgumentException("El libro no existe.", nameof(model.IdLibroCopia));
            }

            //Validamos disponibilidad del libro
            if (libroCopia.Estado == (int)VariablesGlobales.TablaEstadoLibro.NO_DISPONIBLE)
            {
                throw new ArgumentException("El libro no esta disponible.", nameof(model.IdLibroCopia));
            }

            //validamos si hay stock
            var libros = await _dataBaseService.Libro.ToListAsync();
            var libro = libros.Find(x => x.IdLibro == libroCopia.IdLibro);
            if (libro != null)
            {
                if(libro.Stock == 0)
                {
                    throw new ArgumentException("No hay stock disponible.");
                }
            }

            //Registramos Solicitud de préstamo
            var entity = _mapper.Map<SolicitudEntity>(model);
            entity.IdEstado = (int)VariablesGlobales.TablaEstadoSolicitud.PENDIENTE;
            await _dataBaseService.Solicitud.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            //Actualizamos estado de libroCopia
            libroCopia.Estado = (int)VariablesGlobales.TablaEstadoLibro.NO_DISPONIBLE;
            _dataBaseService.LibroCopia.Update(libroCopia);
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
