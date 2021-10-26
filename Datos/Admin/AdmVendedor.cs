using Datos.Models;
using Datos.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
    public static class AdmVendedor
    {
        public static List<Vendedor> Listar()
        {
            string querySql = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor";

            SqlCommand command = new SqlCommand(querySql, AdminDB.ConectarBase());

            SqlDataReader reader;
            reader = command.ExecuteReader();

            List<Vendedor> listaVendedores = new List<Vendedor>();

            while (reader.Read())
            {
                listaVendedores.Add
                    (
                    new Vendedor
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        DNI = reader["DNI"].ToString(),
                        Comision = (decimal)reader["Comision"]
                    }
                    );
            }
            AdminDB.ConectarBase().Close();
            reader.Close();

            return listaVendedores;
        }

        public static DataTable TraerPorId(int idVendedor)
        {
            string querySql = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = idVendedor;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vendedor");
    
            return ds.Tables["Vendedor"];
        }

        public static int Insertar(Vendedor vendedor)
        {
            string querySql = "INSERT INTO dbo.Vendedor(Nombre, Apellido,DNI, Comision) VALUES (@Nombre, @Apellido, @DNI, @Comision)";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());


            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            adapter.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            adapter.SelectCommand.Parameters.Add("@DNI", SqlDbType.Char, 11).Value = vendedor.DNI;
            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static DataTable traerVendedoresPorComision(decimal comision)
        {
            string querySql =  "SELECT Id, Nombre, Apellido, DNI, Comision FROM dbo.Vendedor WHERE Comision = @Comision";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = comision;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vendedor");   

            return ds.Tables["Vendedor"];
        }

        public static int Modificar(Vendedor vendedor)
        {
            string querySql = "UPDATE dbo.Vendedor SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Comision = @Comision WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());


            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            adapter.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            adapter.SelectCommand.Parameters.Add("@DNI", SqlDbType.Char, 11).Value = vendedor.DNI;
            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = vendedor.Id;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int Eliminar(int idVendedor)
        {
            string querySql = "DELETE FROM dbo.Vendedor WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = idVendedor;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }

    }
}
