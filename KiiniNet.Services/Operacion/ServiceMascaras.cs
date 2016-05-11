﻿using System.Collections.Generic;
using KiiniNet.Entities.Cat.Mascaras;
using KinniNet.Core.Operacion;

namespace KiiniNet.Services.Operacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuarios" en el código y en el archivo de configuración a la vez.
    public class ServiceMascaras : IServiceMascaras
    {
        public void CrearMascara(Mascara mascara)
        {
            using (BusinessMascaras negocio = new BusinessMascaras())
            {
                negocio.CrearMascara(mascara);
            }
        }

        public Mascara ObtenerMascaraCaptura(int idMascara)
        {
            using (BusinessMascaras negocio = new BusinessMascaras())
            {
                return negocio.ObtenerMascaraCaptura(idMascara);
            }
        }

        public List<Mascara> ObtenerMascarasAcceso(bool insertarSeleccion)
        {
            using (BusinessMascaras negocio = new BusinessMascaras())
            {
                return negocio.ObtenerMascarasAcceso(insertarSeleccion);
            }
        }
    }
}
