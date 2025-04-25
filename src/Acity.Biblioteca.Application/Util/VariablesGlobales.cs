namespace Acity.Biblioteca.Application.Util
{
    public class VariablesGlobales
    {
        public enum TablaTipoSolicitud
        {
            ALQUILER = 1,
            PRESTAMO = 2,
            VENTA = 3
        }
        public enum TablaEstadoLibro
        {
            DISPONIBLE = 1,
            NO_DISPONIBLE = 2
        }

        public enum TablaEstadoSolicitud
        {
            PENDIENTE = 1,
            APROBADO = 2,
            RECLAZADO = 3
        }

    }
}
