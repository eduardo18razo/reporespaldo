using System.ComponentModel;

namespace KinniNet.Business.Utils
{
    public static class BusinessVariables
    {
        public static class ComboBoxCatalogo
        {
            public static int Index = 0;
            public static int Value = 0;
            public static string Descripcion = "==SELECCIONE==";
            public static bool Habilitado = false;
        }

        public static class ParametrosMascaraCaptura
        {
            public static string PrefijoTabla = "Mascara";
            public static string PrefijoComandoInsertar = "uspInsert";
            public static string PrefijoComandoActualizar = "uspUpdate";

        }

        public enum EnumTiposInformacionConsulta
        {
            Propietario = 1,
            Documento = 2,
            Paginahtml = 3,
            Servicio = 4
        }

        public enum EnumTiposGrupos
        {
            Administrador = 1,
            Acceso = 2,
            Atención = 3,
            Responsabilidad = 4,
            Especialdeconsulta = 5
        }

        public enum EnumRoles
        {
            Administrador = 1,
            Acceso = 2,
            Atención = 3,
            Responsabilidad = 4,
            Especialdeconsulta = 5,
            Superusuario = 6
        }
    }
}
