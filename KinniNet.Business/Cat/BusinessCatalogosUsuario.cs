using System;
using System.Collections.Generic;
using System.Linq;
using KiiniNet.Entities.Cat.Arbol.Nodos;
using KiiniNet.Entities.Cat.Arbol.Organizacion;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones.Domicilio;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Usuario;
using KiiniNet.Entities.Helper;
using KiiniNet.Entities.Operacion;
using KinniNet.Business.Utils;
using KinniNet.Data.Help;

namespace KinniNet.Core.Cat
{
    public class BusinessCatalogosUsuario
    {

        public class BusinessGrupoUsuario : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessGrupoUsuario(bool proxy = false)
            {
                _proxy = proxy;
            }
            public List<GrupoUsuario> ObtenerGruposUsuario(int idTipoGrupo, bool insertarSeleccion)
            {
                List<GrupoUsuario> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result =
                        db.GrupoUsuario.Where(w => w.IdTipoGrupo == idTipoGrupo && w.Habilitado)
                            .OrderBy(o => o.Descripcion)
                            .ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index,
                            new GrupoUsuario
                            {
                                Id = BusinessVariables.ComboBoxCatalogo.Value,
                                Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion
                            });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public void GuardarGrupoUsuario(GrupoUsuario grupoUsuario)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    grupoUsuario.Descripcion = grupoUsuario.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el que viene embebido
                    grupoUsuario.Habilitado = true;
                    if (grupoUsuario.Id == 0)
                        db.GrupoUsuario.AddObject(grupoUsuario);
                    else
                    {
                        GrupoUsuario tmpJefatura = db.GrupoUsuario.SingleOrDefault(s => s.Id == grupoUsuario.Id);
                        if (tmpJefatura == null) return;
                        tmpJefatura.IdTipoGrupo = grupoUsuario.IdTipoGrupo;
                        tmpJefatura.Descripcion = grupoUsuario.Descripcion;
                        tmpJefatura.Habilitado = grupoUsuario.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public GrupoUsuario ObtenerGrupoUsuario(int idGrupoUsuario)
            {
                GrupoUsuario result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.GrupoUsuario.SingleOrDefault(s => s.Id == idGrupoUsuario);
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
        }

        public class BusinessSubGrupoUsuario : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessSubGrupoUsuario(bool proxy = false)
            {
                _proxy = proxy;
            }
            public List<HelperSubGurpoUsuario> ObtenerSubGruposUsuario(int idGrupoUsuario, bool insertarSeleccion)
            {
                List<HelperSubGurpoUsuario> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.SubGrupoUsuario.Where(w => w.IdGrupoUsuario == idGrupoUsuario).Select(s => new HelperSubGurpoUsuario { Id = s.Id, Descripcion = s.TipoSubGrupo.Descripcion }).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new HelperSubGurpoUsuario { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion });

                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public SubGrupoUsuario ObtenerSubGrupoUsuario(int idGrupoUsuario, int idTipoSubGrupo)
            {
                SubGrupoUsuario result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.SubGrupoUsuario.SingleOrDefault(s => s.IdGrupoUsuario == idGrupoUsuario && s.Id == idTipoSubGrupo);
                    if (result != null)
                        db.LoadProperty(result, "TipoSubGrupo");
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
        }

        public class BusinessOrganizacion : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessOrganizacion(bool proxy = false)
            {
                _proxy = proxy;
            }
            public List<Holding> ObtenerHoldings(int idTipoUsuario, bool insertarSeleccion)
            {
                List<Holding> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Holding.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Habilitado).OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Holding { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Compania> ObtenerCompañias(int idTipoUsuario, int idHolding, bool insertarSeleccion)
            {
                List<Compania> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Organizacion.Where(w => w.IdHolding == idHolding).SelectMany(organizacion => db.Compañia.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == organizacion.IdCompania && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Compania { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Direccion> ObtenerDirecciones(int idTipoUsuario, int idCompañia, bool insertarSeleccion)
            {
                List<Direccion> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Organizacion.Where(w => w.IdCompania == idCompañia).SelectMany(organizacion => db.Direccion.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == organizacion.IdDireccion && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Direccion { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<SubDireccion> ObtenerSubDirecciones(int idTipoUsuario, int idDireccoin, bool insertarSeleccion)
            {
                List<SubDireccion> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Organizacion.Where(w => w.IdDireccion == idDireccoin).SelectMany(organizacion => db.SubDireccion.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == organizacion.IdSubDireccion && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new SubDireccion { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Gerencia> ObtenerGerencias(int idTipoUsuario, int idSubdireccion, bool insertarSeleccion)
            {
                List<Gerencia> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Organizacion.Where(w => w.IdSubDireccion == idSubdireccion).SelectMany(organizacion => db.Gerencia.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == organizacion.IdGerencia && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Gerencia { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<SubGerencia> ObtenerSubGerencias(int idTipoUsuario, int idGerencia, bool insertarSeleccion)
            {
                List<SubGerencia> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Organizacion.Where(w => w.IdGerencia == idGerencia).SelectMany(organizacion => db.SubGerencia.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == organizacion.IdSubGerencia && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new SubGerencia { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Jefatura> ObtenerJefaturas(int idTipoUsuario, int idSubGerencia, bool insertarSeleccion)
            {
                List<Jefatura> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Organizacion.Where(w => w.IdSubDireccion == idSubGerencia).SelectMany(organizacion => db.Jefatura.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == organizacion.IdGerencia && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Jefatura { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public Organizacion ObtenerOrganizacion(int idHolding, int? idCompania, int? idDireccion, int? idSubDireccion, int? idGerencia, int? idSubGerencia, int? idJefatura)
            {
                Organizacion result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    var qry = db.Organizacion.Where(w => w.IdHolding == idHolding);
                    if (idCompania.HasValue)
                        qry = qry.Where(w => w.IdCompania == idCompania);
                    else
                        qry = qry.Where(w => w.IdCompania == null);

                    if (idDireccion.HasValue)
                        qry = qry.Where(w => w.IdDireccion == idDireccion);
                    else
                        qry = qry.Where(w => w.IdDireccion == null);

                    if (idSubDireccion.HasValue)
                        qry = qry.Where(w => w.IdSubDireccion == idSubDireccion);
                    else
                        qry = qry.Where(w => w.IdSubDireccion == null);

                    if (idGerencia.HasValue)
                        qry = qry.Where(w => w.IdGerencia == idGerencia);
                    else
                        qry = qry.Where(w => w.IdGerencia == null);

                    if (idSubGerencia.HasValue)
                        qry = qry.Where(w => w.IdSubGerencia == idSubGerencia);
                    else
                        qry = qry.Where(w => w.IdSubGerencia == null);

                    if (idJefatura.HasValue)
                        qry = qry.Where(w => w.IdJefatura == idJefatura);
                    else
                        qry = qry.Where(w => w.IdJefatura == null);

                    result = qry.FirstOrDefault();
                }
                catch (Exception)
                {
                    throw new Exception("Error al Obtener Organizacion");
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public void GuardarOrganizacion(Organizacion organizacion)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    organizacion.Habilitado = true;
                    if (organizacion.Holding != null)
                        organizacion.Holding.Descripcion = organizacion.Holding.Descripcion.ToUpper();

                    if (organizacion.Compania != null)
                        organizacion.Compania.Descripcion = organizacion.Compania.Descripcion.ToUpper();

                    if (organizacion.Direccion != null)
                        organizacion.Direccion.Descripcion = organizacion.Direccion.Descripcion.ToUpper();

                    if (organizacion.SubDireccion != null)
                        organizacion.SubDireccion.Descripcion = organizacion.SubDireccion.Descripcion.ToUpper();

                    if (organizacion.Gerencia != null)
                        organizacion.Gerencia.Descripcion = organizacion.Gerencia.Descripcion.ToUpper();

                    if (organizacion.SubGerencia != null)
                        organizacion.SubGerencia.Descripcion = organizacion.SubGerencia.Descripcion.ToUpper();

                    if (organizacion.Jefatura != null)
                        organizacion.Jefatura.Descripcion = organizacion.Jefatura.Descripcion.ToUpper();

                    if (organizacion.Id == 0)
                        db.Organizacion.AddObject(organizacion);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarHolding(Holding entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.Holding.AddObject(entidad);
                    else
                    {
                        Holding tmpHolding = db.Holding.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpHolding == null) return;
                        tmpHolding.Descripcion = entidad.Descripcion;
                        tmpHolding.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarCompania(Compania entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.Compañia.AddObject(entidad);
                    else
                    {
                        Compania tmpCompania = db.Compañia.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpCompania == null) return;
                        tmpCompania.Descripcion = entidad.Descripcion;
                        tmpCompania.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarDireccion(Direccion entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.Direccion.AddObject(entidad);
                    else
                    {
                        Direccion tmpDireccion = db.Direccion.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpDireccion == null) return;
                        tmpDireccion.Descripcion = entidad.Descripcion;
                        tmpDireccion.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarSubDireccion(SubDireccion entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.SubDireccion.AddObject(entidad);
                    else
                    {
                        SubDireccion tmpSubDireccion = db.SubDireccion.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpSubDireccion == null) return;
                        tmpSubDireccion.Descripcion = entidad.Descripcion;
                        tmpSubDireccion.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarGerencia(Gerencia entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.Gerencia.AddObject(entidad);
                    else
                    {
                        Gerencia tmpGerencia = db.Gerencia.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpGerencia == null) return;
                        tmpGerencia.Descripcion = entidad.Descripcion;
                        tmpGerencia.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarSubGerencia(SubGerencia entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.SubGerencia.AddObject(entidad);
                    else
                    {
                        SubGerencia tmpSubGerencia = db.SubGerencia.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpSubGerencia == null) return;
                        tmpSubGerencia.Descripcion = entidad.Descripcion;
                        tmpSubGerencia.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }

            public void GuardarJefatura(Jefatura entidad)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    entidad.Descripcion = entidad.Descripcion.ToUpper();
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    entidad.Habilitado = true;
                    if (entidad.Id == 0)
                        db.Jefatura.AddObject(entidad);
                    else
                    {
                        Jefatura tmpJefatura = db.Jefatura.SingleOrDefault(s => s.Id == entidad.Id);
                        if (tmpJefatura == null) return;
                        tmpJefatura.Descripcion = entidad.Descripcion;
                        tmpJefatura.Habilitado = entidad.Habilitado;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        public class BusinessUbicacion : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessUbicacion(bool proxy = false)
            {
                _proxy = proxy;
            }
            public List<Pais> ObtenerPais(int idTipoUsuario, bool insertarSeleccion)
            {
                List<Pais> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Pais.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Habilitado).OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Pais { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Campus> ObtenerCampus(int idTipoUsuario, int idPais, bool insertarSeleccion)
            {
                List<Campus> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Ubicacion.Where(w => w.IdPais == idPais).SelectMany(ubicacion => db.Campus.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == ubicacion.IdCampus && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Campus { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Torre> ObtenerTorres(int idTipoUsuario, int idCampus, bool insertarSeleccion)
            {
                List<Torre> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Ubicacion.Where(w => w.IdCampus == idCampus).SelectMany(ubicacion => db.Torre.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == ubicacion.IdTorre && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Torre { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Piso> ObtenerPisos(int idTipoUsuario, int idTorre, bool insertarSeleccion)
            {
                List<Piso> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Ubicacion.Where(w => w.IdTorre == idTorre).SelectMany(ubicacion => db.Piso.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == ubicacion.IdPiso && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Piso { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<Zona> ObtenerZonas(int idTipoUsuario, int idPiso, bool insertarSeleccion)
            {
                List<Zona> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Ubicacion.Where(w => w.IdPiso == idPiso).SelectMany(ubicacion => db.Zona.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == ubicacion.IdZona && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Zona { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<SubZona> ObtenerSubZonas(int idTipoUsuario, int idZona, bool insertarSeleccion)
            {
                List<SubZona> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Ubicacion.Where(w => w.IdZona == idZona).SelectMany(ubicacion => db.SubZona.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == ubicacion.IdZona && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new SubZona { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public List<SiteRack> ObtenerSiteRacks(int idTipoUsuario, int idSubZona, bool insertarSeleccion)
            {
                List<SiteRack> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Ubicacion.Where(w => w.IdSubZona == idSubZona).SelectMany(ubicacion => db.SiteRack.Where(w => w.IdTipoUsuario == idTipoUsuario && w.Id == ubicacion.IdSiteRack && w.Habilitado)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new SiteRack { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public Ubicacion ObtenerUbicacion(int idPais, int? idCampus, int? idTorre, int? idPiso, int? idZona, int? idSubZona, int? idSiteRack)
            {
                Ubicacion result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    var qry = db.Ubicacion.Where(w => w.IdPais == idPais);
                    if (idCampus.HasValue)
                        qry = qry.Where(w => w.IdCampus == idCampus);
                    else
                        qry = qry.Where(w => w.IdCampus == null);

                    if (idTorre.HasValue)
                        qry = qry.Where(w => w.IdTorre == idTorre);
                    else
                        qry = qry.Where(w => w.IdTorre == null);

                    if (idPiso.HasValue)
                        qry = qry.Where(w => w.IdPiso == idPiso);
                    else
                        qry = qry.Where(w => w.IdPiso == null);

                    if (idZona.HasValue)
                        qry = qry.Where(w => w.IdZona == idZona);
                    else
                        qry = qry.Where(w => w.IdZona == null);

                    if (idSubZona.HasValue)
                        qry = qry.Where(w => w.IdSubZona == idSubZona);
                    else
                        qry = qry.Where(w => w.IdSubZona == null);

                    if (idSiteRack.HasValue)
                        qry = qry.Where(w => w.IdSiteRack == idSiteRack);
                    else
                        qry = qry.Where(w => w.IdSiteRack == null);

                    result = qry.FirstOrDefault();
                }
                catch (Exception)
                {
                    throw new Exception("Error al Obtener Organizacion");
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public void GuardarUbicacion(Ubicacion ubicacion)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    ubicacion.Habilitado = true;
                    if (ubicacion.Campus != null)
                    {
                        ubicacion.Campus.Descripcion = ubicacion.Campus.Descripcion.ToUpper();
                        foreach (Domicilio domicilio in ubicacion.Campus.Domicilio)
                        {
                            domicilio.Calle = domicilio.Calle.ToUpper();
                            domicilio.NoExt = domicilio.NoExt.ToUpper();
                            domicilio.NoInt = domicilio.NoInt.ToUpper();
                        }
                    }
                    if (ubicacion.Torre != null)
                        ubicacion.Torre.Descripcion = ubicacion.Torre.Descripcion.ToUpper();

                    if (ubicacion.Piso != null)
                        ubicacion.Piso.Descripcion = ubicacion.Piso.Descripcion.ToUpper();

                    if (ubicacion.Zona != null)
                        ubicacion.Zona.Descripcion = ubicacion.Zona.Descripcion.ToUpper();

                    if (ubicacion.SubZona != null)
                        ubicacion.SubZona.Descripcion = ubicacion.SubZona.Descripcion.ToUpper();

                    if (ubicacion.SiteRack != null)
                        ubicacion.SiteRack.Descripcion = ubicacion.SiteRack.Descripcion.ToUpper();

                    if (ubicacion.Id == 0)
                        db.Ubicacion.AddObject(ubicacion);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        public class BusinessArbolAcceso : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessArbolAcceso(bool proxy = false)
            {
                _proxy = proxy;
            }
            public List<Nivel1> ObtenerNivel1(int idTipoArbol, int idTipoUsuario, bool insertarSeleccion)
            {
                List<Nivel1> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario).SelectMany(nivel => db.Nivel1.Where(w => w.Id == nivel.IdNivel1)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel1 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public List<Nivel2> ObtenerNivel2(int idTipoArbol, int idTipoUsuario, int idNivel1, bool insertarSeleccion)
            {
                List<Nivel2> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario && w.IdNivel1 == idNivel1 && w.Habilitado).SelectMany(nivel => db.Nivel2.Where(w => w.Id == nivel.IdNivel2)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel2 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public List<Nivel3> ObtenerNivel3(int idTipoArbol, int idTipoUsuario, int idNivel2, bool insertarSeleccion)
            {
                List<Nivel3> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario && w.IdNivel2 == idNivel2 && w.Habilitado).SelectMany(nivel => db.Nivel3.Where(w => w.Id == nivel.IdNivel3)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel3 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public List<Nivel4> ObtenerNivel4(int idTipoArbol, int idTipoUsuario, int idNivel3, bool insertarSeleccion)
            {
                List<Nivel4> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario && w.IdNivel3 == idNivel3 && w.Habilitado).SelectMany(nivel => db.Nivel4.Where(w => w.Id == nivel.IdNivel4)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel4 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public List<Nivel5> ObtenerNivel5(int idTipoArbol, int idTipoUsuario, int idNivel4, bool insertarSeleccion)
            {
                List<Nivel5> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario && w.IdNivel4 == idNivel4 && w.Habilitado).SelectMany(nivel => db.Nivel5.Where(w => w.Id == nivel.IdNivel5)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel5 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public List<Nivel6> ObtenerNivel6(int idTipoArbol, int idTipoUsuario, int idNivel5, bool insertarSeleccion)
            {
                List<Nivel6> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario && w.IdNivel5 == idNivel5 && w.Habilitado).SelectMany(nivel => db.Nivel6.Where(w => w.Id == nivel.IdNivel6)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel6 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }
            public List<Nivel7> ObtenerNivel7(int idTipoArbol, int idTipoUsuario, int idNivel6, bool insertarSeleccion)
            {
                List<Nivel7> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.ArbolAcceso.Where(w => w.IdTipoArbolAcceso == idTipoArbol && w.IdTipoUsuario == idTipoUsuario && w.IdNivel6 == idNivel6 && w.Habilitado).SelectMany(nivel => db.Nivel7.Where(w => w.Id == nivel.IdNivel7)).Distinct().OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index, new Nivel7 { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion, Habilitado = BusinessVariables.ComboBoxCatalogo.Habilitado });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public bool EsNodoTerminal(int idTipoUsuario, int idTipoArbol, int nivel1, int? nivel2, int? nivel3, int? nivel4, int? nivel5, int? nivel6, int? nivel7)
            {
                bool result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    var qry = db.ArbolAcceso.Where(w => w.IdTipoUsuario == idTipoUsuario && w.IdTipoArbolAcceso == idTipoArbol && w.IdNivel1 == nivel1);
                    qry = nivel2.HasValue ? qry.Where(w => w.IdNivel2 == nivel2) : qry.Where(w => w.IdNivel2 == null);
                    qry = nivel3.HasValue ? qry.Where(w => w.IdNivel3 == nivel3) : qry.Where(w => w.IdNivel3 == null);
                    qry = nivel4.HasValue ? qry.Where(w => w.IdNivel4 == nivel4) : qry.Where(w => w.IdNivel4 == null);
                    qry = nivel5.HasValue ? qry.Where(w => w.IdNivel5 == nivel5) : qry.Where(w => w.IdNivel5 == null);
                    qry = nivel6.HasValue ? qry.Where(w => w.IdNivel6 == nivel6) : qry.Where(w => w.IdNivel6 == null);
                    qry = nivel7.HasValue ? qry.Where(w => w.IdNivel7 == nivel7) : qry.Where(w => w.IdNivel7 == null);
                    result = qry.Any(a => a.EsTerminal);
                }
                catch (Exception)
                {
                    throw new Exception("Error al Obtener Organizacion");
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public void GuardarArbol(ArbolAcceso arbol)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    arbol.Habilitado = true;
                    if (arbol.Nivel1 != null)
                    {
                        arbol.Nivel1.Descripcion = arbol.Nivel1.Descripcion.ToUpper();
                        arbol.Nivel1.Habilitado = arbol.Nivel1.Habilitado;
                    }
                    if (arbol.Nivel2 != null)
                    {
                        arbol.Nivel2.Descripcion = arbol.Nivel2.Descripcion.ToUpper();
                        arbol.Nivel2.Habilitado = arbol.Nivel2.Habilitado;
                    }
                    if (arbol.Nivel3 != null)
                    {
                        arbol.Nivel3.Descripcion = arbol.Nivel3.Descripcion.ToUpper();
                        arbol.Nivel3.Habilitado = arbol.Nivel3.Habilitado;
                    }
                    if (arbol.Nivel4 != null)
                    {
                        arbol.Nivel4.Descripcion = arbol.Nivel4.Descripcion.ToUpper();
                        arbol.Nivel4.Habilitado = arbol.Nivel4.Habilitado;
                    }
                    if (arbol.Nivel5 != null)
                    {
                        arbol.Nivel5.Descripcion = arbol.Nivel5.Descripcion.ToUpper();
                        arbol.Nivel5.Habilitado = arbol.Nivel5.Habilitado;
                    }
                    if (arbol.Nivel6 != null)
                    {
                        arbol.Nivel6.Descripcion = arbol.Nivel6.Descripcion.ToUpper();
                        arbol.Nivel6.Habilitado = arbol.Nivel6.Habilitado;
                    }
                    if (arbol.Nivel7 != null)
                    {
                        arbol.Nivel7.Descripcion = arbol.Nivel7.Descripcion.ToUpper();
                        arbol.Nivel7.Habilitado = arbol.Nivel7.Habilitado;
                    }

                    if (arbol.Id == 0)
                        db.ArbolAcceso.AddObject(arbol);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
        public class BusinessInformacionConsulta : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessInformacionConsulta(bool proxy = false)
            {
                _proxy = proxy;
            }

            public List<InformacionConsulta> ObtenerInformacionConsulta(BusinessVariables.EnumTiposInformacionConsulta tipoinfoConsulta, bool insertarSeleccion)
            {
                List<InformacionConsulta> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.InformacionConsulta.Where(w => w.IdTipoInfConsulta == (int)tipoinfoConsulta && w.Habilitado).OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index,
                            new InformacionConsulta
                            {
                                Id = BusinessVariables.ComboBoxCatalogo.Value,
                                Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion
                            });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public void GuardarInformacionConsulta(InformacionConsulta informacion)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    informacion.Descripcion = informacion.Descripcion.Trim().ToUpper();
                    //TODO: Cambiar habilitado por el embebido
                    informacion.Habilitado = true;
                    if (informacion.Id == 0)
                        db.InformacionConsulta.AddObject(informacion);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        public class BusinessSla : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessSla(bool proxy = false)
            {
                _proxy = proxy;
            }
            public List<SLA> ObtenerSla(bool insertarSeleccion)
            {
                List<SLA> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.SLA.Where(w => w.Habilitado).OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index,
                            new SLA
                            {
                                Id = BusinessVariables.ComboBoxCatalogo.Value,
                                Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion
                            });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public void Guardar(SLA sla)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    //TODO: Cambiar habilitado por el embebido
                    sla.Habilitado = true;
                    sla.Descripcion = sla.Descripcion.ToUpper();
                    if (sla.Id == 0)
                        db.SLA.AddObject(sla);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        public class BusinessEncuesta : IDisposable
        {
            private bool _proxy;
            public void Dispose()
            {

            }
            public BusinessEncuesta(bool proxy = false)
            {
                _proxy = proxy;
            }

            public List<Encuesta> ObtenerEncuestas(bool insertarSeleccion)
            {
                List<Encuesta> result;
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    result = db.Encuesta.Where(w => w.Habilitado).OrderBy(o => o.Descripcion).ToList();
                    if (insertarSeleccion)
                        result.Insert(BusinessVariables.ComboBoxCatalogo.Index,
                            new Encuesta
                            {
                                Id = BusinessVariables.ComboBoxCatalogo.Value,
                                Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion
                            });
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
                return result;
            }

            public void GuardarEncuesta(Encuesta encuesta)
            {
                DataBaseModelContext db = new DataBaseModelContext();
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = _proxy;
                    encuesta.Descripcion = encuesta.Descripcion.ToUpper();
                    //TODO: Cambiar habilitado por el embebido
                    encuesta.Habilitado = true;
                    if (encuesta.Id == 0)
                        db.Encuesta.AddObject(encuesta);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception((ex.InnerException).Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}
