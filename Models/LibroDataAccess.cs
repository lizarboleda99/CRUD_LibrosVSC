using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CRUD_LibrosVSC.Models
{
    public class LibroDataAccess
    {
        string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=Libreria;Server=DESKTOP-SQNPVTG"  ;    
    
        //To View all Libros details      
        public IEnumerable<Libro> TraerLibros()    
        {    
            List<Libro> lstLibro = new List<Libro>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spTodosLosLibros", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Libro Libro = new Libro();    
    
                    Libro.id = Convert.ToInt32(rdr["id"]);    
                    Libro.nombre = rdr["nombre"].ToString();    
                    Libro.paginas = Convert.ToInt32(rdr["paginas"]);    
                    Libro.editorial = rdr["editorial"].ToString();    
                    Libro.autor = rdr["autor"].ToString();  
                    Libro.precio = (float)Convert.ToSingle(rdr["precio"]);   
    
                    lstLibro.Add(Libro);    
                }    
                con.Close();    
            }    
            return lstLibro;    
        }    
    
        //To Add new Libro record      
        public void AgregarLibro(Libro Libro)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAgregarLibro", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@nombre", Libro.nombre);    
                cmd.Parameters.AddWithValue("@paginas", Libro.paginas);    
                cmd.Parameters.AddWithValue("@editorial", Libro.editorial);    
                cmd.Parameters.AddWithValue("@autor", Libro.autor); 
                cmd.Parameters.AddWithValue("@precio", Libro.precio);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //To Update the records of a particluar Libro    
        public void ActualizarLibro(Libro Libro)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spActualizarLibro", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@id", Libro.id);    
                cmd.Parameters.AddWithValue("@nombre", Libro.nombre);    
                cmd.Parameters.AddWithValue("@paginas", Libro.paginas);    
                cmd.Parameters.AddWithValue("@editorial", Libro.editorial);    
                cmd.Parameters.AddWithValue("@autor", Libro.autor); 
                cmd.Parameters.AddWithValue("@precio", Libro.precio);   
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular Libro    
        public Libro TraerLibroPorId(int? id)    
        {    
            Libro Libro = new Libro();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM Libros WHERE id= " + id;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Libro.id = Convert.ToInt32(rdr["id"]);    
                    Libro.nombre = rdr["nombre"].ToString();    
                    Libro.paginas = Convert.ToInt32(rdr["paginas"]);    
                    Libro.editorial = rdr["editorial"].ToString();    
                    Libro.autor = rdr["autor"].ToString();  
                    Libro.precio = (float)Convert.ToSingle(rdr["precio"]);    
                }    
            }    
            return Libro;    
        }    
    
        //To Delete the record on a particular Libro    
        public void BorrarLibro(int? id)    
        {    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spBorrarLibro", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@id", id);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    }
}
