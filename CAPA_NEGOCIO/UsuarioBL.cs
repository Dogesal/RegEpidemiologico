using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public  class UsuarioBL
    {
        private readonly SghrhContext _sghrhContext;
        public UsuarioBL(SghrhContext sghrhContext) {
        
            _sghrhContext = sghrhContext;   

        }


        public int verificarPassword(string usuario, string password)
        {
            // Buscar el usuario en la base de datos por su nombre de usuario
            var usuarioDAL = _sghrhContext.Usuarios.SingleOrDefault(u => u.Usu == usuario);

            if (usuarioDAL == null)
            {
                // Usuario no encontrado
                return -1; // Código de error para usuario inexistente
            }

            // Verificar si la contraseña coincide
            if (usuarioDAL.Clave == password)
            {
                // Contraseña correcta
                return 1; // Usuario autenticado correctamente
            }

            // Contraseña incorrecta
            return 0;
        }
    }
}
