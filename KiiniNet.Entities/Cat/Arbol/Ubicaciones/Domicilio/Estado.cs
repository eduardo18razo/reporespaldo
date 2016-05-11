﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KiiniNet.Entities.Cat.Arbol.Ubicaciones.Domicilio
{
    [DataContract(IsReference = true)]
    public class Estado
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public virtual List<Municipio> Municipio { get; set; }
    }
}
