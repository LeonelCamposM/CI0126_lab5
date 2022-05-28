using Laboratorio05.Models;
using System.Data;
using System.Data.SqlClient;


namespace Laboratorio05.Handlers
{
    public class CountryHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;
        public CountryHandler()
        {
            var builder = WebApplication.CreateBuilder();
            rutaConexion = builder.Configuration.GetConnectionString("PaisesContext");
            conexion = new SqlConnection(rutaConexion);
        }

        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptadorParaTabla = new
            SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }
        public List<CountryModel> ObtenerPaises()
        {
            List<CountryModel> paises = new List<CountryModel>();
            string consulta = "SELECT * FROM dbo.Pais ";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                paises.Add(
                new CountryModel
                {
                    Id = Convert.ToInt32(columna["Id"]),
                    Name = Convert.ToString(columna["Nombre"]),
                    Idiom = Convert.ToString(columna["Idioma"]),
                    Continent = Convert.ToString(columna["Continente"]),
                });
            }
            return paises;
        }

        public bool CrearPais(CountryModel pais)
        {
            var consulta = @"INSERT INTO [dbo].[Pais] ([Nombre],[Idioma] ,[Continente])
                            VALUES(@Nombre, @Idioma, @Continente) ";
            var comandoParaConsulta = new SqlCommand(consulta, conexion);
            comandoParaConsulta.Parameters.AddWithValue("@Nombre", pais.Name);
            comandoParaConsulta.Parameters.AddWithValue("@Idioma", pais.Idiom);
            comandoParaConsulta.Parameters.AddWithValue("@Continente", pais.Continent);
            conexion.Open();
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();
            return exito;
        }

        public bool EditarPais(CountryModel pais)
        {
            var consulta = @"UPDATE [dbo].[Pais] SET Nombre = @Nombre,
                            Idioma = @Idioma,
                            Continente = @Continente
                            WHERE Id = @Id";

            var comandoParaConsulta = new SqlCommand(consulta, conexion);
            comandoParaConsulta.Parameters.AddWithValue("@Nombre", pais.Name);
            comandoParaConsulta.Parameters.AddWithValue("@Idioma", pais.Idiom);
            comandoParaConsulta.Parameters.AddWithValue("@Continente", pais.Continent);
            comandoParaConsulta.Parameters.AddWithValue("@Id", pais.Id);

            conexion.Open();
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();
            return exito;
        }

    }
}