using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Acity.Biblioteca.Application.Util
{
    public class Constantes
    {
        public struct GenericValues
        {
            public const string InternalError = "Hubo un problema al procesar la solicitud, intente nuevamente por favor.";
        }

        public struct MensajesOK
        {
            public const string M01 = "Operación realizada de forma exitosa.";
            public const string M02 = "No se encontraton registros con los datos ingresados.";
            public const string M03 = "No se encontraton registros.";
        }

        public struct MensajesNOOK
        {
            public const string M01 = "Sucedió un inconveniente al realizar la operación.";
            public const string M02 = "Usuario no autorizado.";
            public const string M03 = "Se produjeron uno o más errores de validación";
            public const string M04 = "Los datos de entrada estan incorrectos.";
        }

    }
}
