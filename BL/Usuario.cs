using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> ChangeStatus(int IdUsuario, bool estado)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false } };
            try
            {
                using (DL.LescogidoNormalizacionContext context = new DL.LescogidoNormalizacionContext())
                {
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioChangeStatus {IdUsuario}, {estado}");
                 
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }

        public static Dictionary<string, object> Add(ML.Usuario usuario)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false } };
            try
            {
                using (DL.LescogidoNormalizacionContext context = new DL.LescogidoNormalizacionContext())
                {
                    //Entity Framework
                    //FromSqlRaw--joins
                    //var filasAfectadasLinq = context.Usuarios.Add();
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', {usuario.Edad}, '{""}', {1} ,@Imagen", new SqlParameter("@Imagen", usuario.Imagen));
                    //LINQ
                    //DL.Usuario usuar = new DL.Usuario();
                    //var filasAfectadas = context.Usuarios.Add(usuar);
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
        //public static Dictionary<string, object> GetAll(ML.Usuario usuario)
        //{
        //    Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Usuario", null} };
        //    try
        //    {
        //        using (DL.LescogidoNormalizacionContext context = new DL.LescogidoNormalizacionContext())
        //        {
        //            //Entity Framework
        //            //FromSqlRaw--joins
        //            var registros = context.Usuarios.FromSqlRaw($"UsuarioGetAll '{usuario.Nombre}', '{usuario.ApellidoPaterno}'").ToList();
        //            //LINQ
        //            //DL.Usuario usuar = new DL.Usuario();
        //            //var filasAfectadas = context.Usuarios.Add(usuar);
        //            if (registros.Count > 0)
        //            {
        //                usuario.Usuarios = new List<object>();
        //                foreach (var registro in registros)
        //                {
        //                    ML.Usuario user = new ML.Usuario();
        //                    user.IdUsuario = registro.IdUsuario;
        //                    user.Nombre = registro.Nombre;
        //                    user.ApellidoMaterno = registro.ApellidoMaterno;
        //                    user.Direccion = new ML.Direccion();

        //                    usuario.Usuarios.Add(user);
        //                }
        //                diccionario["Resultado"] = true;
        //            }
        //            else
        //            {

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        diccionario["Exepcion"] = ex;
        //    }
        //    return diccionario;
        //}
        public static Dictionary<string, object> GetAll(ML.Usuario usuario)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Usuario", null } };
            try
            {
                using (DL.LescogidoNormalizacionContext context = new DL.LescogidoNormalizacionContext())
                {
                    //Entity Framework
                    //FromSqlRaw--joins
                    //var registrosLinq = context.Usuarios.ToList();


                    //LINQ

                    var registros = (from usario in context.Usuarios
                                     join direccion in context.Direccions on usario.IdUsuario equals direccion.IdDireccion
                                     select new
                                     {
                                         IdUsuario = usario.IdUsuario,
                                         Nombre = usario.Nombre,
                                         ApellidoMaterno = usario.ApellidoMaterno,
                                         IdColonia = direccion.IdColonia,
                                         Calle = direccion.Calle,
                                         Imagen = usario.Imagen,
                                         Status = true
                                     }).ToList();



                    //DL.Usuario usuar = new DL.Usuario();
                    //var filasAfectadas = context.Usuarios.Add(usuar);
                    if (registros.Count > 0)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (var registro in registros)
                        {
                            ML.Usuario user = new ML.Usuario();
                            user.IdUsuario = registro.IdUsuario;
                            user.Nombre = registro.Nombre;
                            user.ApellidoMaterno = registro.ApellidoMaterno;
                            user.Direccion = new ML.Direccion();
                            user.Direccion.Calle = registro.Calle;

                            usuario.Usuarios.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
        //public static Dictionary<string,object> Add(ML.Usuario usuario)
        //{
        //    Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }};
        //    try
        //    {
        //        using (DL.LescogidoNormalizacionContext context = new LescogidoNormalizacionContext())
        //        {
        //            var query = context.Database.ExecuteSqlRaw($"UsuarioAdd {usuario.Nombre}, {usuario.ApellidoPaterno}, {usuario.ApellidoMaterno}, {usuario.Edad}, {""}, {""}, {usuario.Imagen}");

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return diccionario;
        //}
    }
}