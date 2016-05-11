﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones;
using KiiniNet.Entities.Cat.Sistema;

namespace KiiniNet.Entities.Cat.Operacion
{
    [DataContract(IsReference = true)]
    public class Ubicacion
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTipoUsuario { get; set; }
        [DataMember]
        public int IdPais { get; set; }
        [DataMember]
        public int? IdCampus { get; set; }
        [DataMember]
        public int? IdTorre { get; set; }
        [DataMember]
        public int? IdPiso { get; set; }
        [DataMember]
        public int? IdZona { get; set; }
        [DataMember]
        public int? IdSubZona { get; set; }
        [DataMember]
        public int? IdSiteRack { get; set; }
        [DataMember]
        public bool Habilitado { get; set; }

        [DataMember]
        public virtual List<Entities.Operacion.Usuarios.Usuario> Usuario { get; set; }
        [DataMember]
        public virtual TipoUsuario TipoUsuario { get; set; }
        [DataMember]
        public virtual Pais Pais { get; set; }
        [DataMember]
        public virtual Campus Campus { get; set; }
        [DataMember]
        public virtual Torre Torre { get; set; }
        [DataMember]
        public virtual Piso Piso { get; set; }
        [DataMember]
        public virtual Zona Zona { get; set; }
        [DataMember]
        public virtual SubZona SubZona { get; set; }
        [DataMember]
        public virtual SiteRack SiteRack { get; set; }
    }
}
