using System;
using System.Data;
using MySqlConnector;

namespace CRUD_LibrosVSC.Models
{
    public class LibroDataAccess
    {
        string connectionString = "server=bdnwmify9kzquih5jqrb-mysql.services.clever-cloud.com; port=3306; database=bdnwmify9kzquih5jqrb; user=ug5ijvylqe8n3wvj; password=tHuBMHWfww6ezoERed9K; Persist Security Info=False; Connect Timeout=200";     
    
        //To View all Libros details      
        public IEnumerable<Libro> TraerLibros()    
        {    
            List<Libro> lstLibro = new List<Libro>();    
    
            using (MySqlConnection con = new MySqlConnection(connectionString))    
            {    
                MySqlCommand cmd = new MySqlCommand("spTodosLosLibros", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                MySqlDataReader rdr = cmd.ExecuteReader();    
    
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
            using (MySqlConnection con = new MySqlConnection(connectionString))    
            {    
                MySqlCommand cmd = new MySqlCommand("spAgregarLibro", con);    
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
            using (MySqlConnection con = new MySqlConnection(connectionString))    
            {    
                string sqlQuery = "UPDATE libros SET nombre = '"+ Libro.nombre  +
                "' ,paginas = "+ Libro.paginas+ 
                " ,editorial = '"+ Libro.editorial+ 
                "' ,autor = '"+ Libro.autor+ 
                "' ,precio = "+ Libro.precio+ 
                " WHERE id = " + Libro.id; 

                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);     
    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular Libro    
        public Libro TraerLibroPorId(int? id)    
        {    
            Libro Libro = new Libro();    
    
            using (MySqlConnection con = new MySqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM libros WHERE id= " + id;    
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);    
    
                con.Open();    
                MySqlDataReader rdr = cmd.ExecuteReader();    
    
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
    
            using (MySqlConnection con = new MySqlConnection(connectionString))    
            {    
                string sqlQuery = "Delete FROM libros WHERE id= " + id; 
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);       
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    }
}
