﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Operacion;

namespace KiiniNet.Entities.Cat.Mascaras
{
    [DataContract(IsReference = true)]
    public class Mascara
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int NoCampos { get; set; }
        [DataMember]
        public string NombreTabla { get; set; }
        [DataMember]
        public string ComandoInsertar { get; set; }
        [DataMember]
        public string ComandoActualizar { get; set; }
        [DataMember]
        public bool Habilitado { get; set; }

        [DataMember]
        public virtual List<CampoMascara> CampoMascara { get; set; }
        [DataMember]
        public virtual List<InventarioArbolAcceso> InventarioArbolAcceso { get; set; }
    }
}
