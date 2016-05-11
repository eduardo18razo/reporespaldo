using System;
using System.Collections.Generic;
using System.Linq;
using KiiniNet.Entities.Cat.Mascaras;
using KinniNet.Core.Cat;
using KinniNet.Core.Operacion;
using KinniNet.Data.Help;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiiniNet.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesConsultas()
        {
            try
            {
                DataBaseModelContext db = new DataBaseModelContext();
                var org = db.Organizacion.Where(w => w.IdCompania == null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
