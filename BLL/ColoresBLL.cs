using Microsoft.EntityFrameworkCore;
using Repaso1ERParcial.DAL;
using Repaso1ERParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repaso1ERParcial.BLL
{
    public class ColoresBLL
    {
        public static bool Guardar(Colores color)
        {
            if (!Existe(color.ColoresId))
                return Insertar(color);
            else
                return Modificar(color);
        }

        private static bool Insertar(Colores color)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Colores.Add(color);
                esValido = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        private static bool Modificar(Colores color)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(color).State = EntityState.Modified;
                esValido = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        public static bool Eliminar(int id)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();

            try
            {
                var color = contexto.Colores.Find(id);

                if (color != null)
                {
                    contexto.Colores.Remove(color);//Remover la entidad
                    esValido = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        public static Colores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Colores color;

            try
            {
                color = contexto.Colores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return color;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Colores.Any(e => e.ColoresId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static List<Colores> GetList(Expression<Func<Colores, bool>> criterio)
        {
            List<Colores> lista = new List<Colores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Colores.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}

