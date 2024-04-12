using System.Data.SqlClient;
namespace PruebasOlimpicas.Data
{
    public class ConexionData
    {
        private string cadenaSQL = string.Empty;

        public ConexionData()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
