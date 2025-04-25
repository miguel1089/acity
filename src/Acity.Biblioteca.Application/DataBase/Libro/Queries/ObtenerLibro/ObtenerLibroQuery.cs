using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Acity.Biblioteca.Application.DataBase.Libro.Queries.ObtenerLibro
{
    public class ObtenerLibroQuery: IObtenerLibroQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public ObtenerLibroQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<List<ObtenerLibroModel>> Execute(int idLibro)
        {
            var listaEntity = await _dataBaseService.Libro.ToListAsync();
            return _mapper.Map<List<ObtenerLibroModel>>(listaEntity.Find(x => x.IdLibro == idLibro));
        }
    }
}
