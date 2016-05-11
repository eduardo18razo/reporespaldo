﻿using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Sistema;

namespace KiiniNet.Entities.Cat.Mascaras
{
    [DataContract(IsReference = true)]
    public class CampoMascara
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdMascara { get; set; }
        [DataMember]
        public int IdTipoCampoMascara { get; set; }
        [DataMember]
        public int? IdCatalogo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public bool Requerido { get; set; }
        [DataMember]
        public int? LongitudMinima { get; set; }
        [DataMember]
        public int? LongitudMaxima { get; set; }
        [DataMember]
        public string SimboloMoneda { get; set; }
        [DataMember]
        public int? ValorMaximo { get; set; }

        [DataMember]
        public virtual Mascara Mascara { get; set; }
        [DataMember]
        public virtual TipoCampoMascara TipoCampoMascara { get; set; }
        [DataMember]
        public virtual Catalogos Catalogos { get; set; }
    }
}
