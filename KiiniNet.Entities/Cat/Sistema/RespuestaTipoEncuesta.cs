﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using KiiniNet.Entities.Cat.Usuario;

namespace KiiniNet.Entities.Cat.Sistema
{
    [DataContract(IsReference = true)]
    public class RespuestaTipoEncuesta
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTipoEncuesta { get; set; }
        [DataMember]
        public string Respuesta { get; set; }
        [DataMember]
        public string TipoDatoSql { get; set; }
        [DataMember]
        public virtual TipoEncuesta TipoEncuesta { get; set; }
    }
}
