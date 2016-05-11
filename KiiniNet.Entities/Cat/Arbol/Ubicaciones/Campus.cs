﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Sistema;
using Microsoft.Build.Framework;

namespace KiiniNet.Entities.Cat.Arbol.Ubicaciones
{
    [DataContract(IsReference = true)]
    public class Campus
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTipoUsuario { get; set; }
        [DataMember]
        [Required]
        public string Descripcion { get; set; }
        [DataMember]
        public bool Habilitado { get; set; }
        
        [DataMember]
        public virtual List<Ubicacion> Ubicacion { get; set; }
        [DataMember]
        public virtual List<Domicilio.Domicilio> Domicilio { get; set; }
        [DataMember]
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
