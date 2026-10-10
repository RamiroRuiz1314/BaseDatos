using Microsoft.Data.SqlClient;

namespace BaseDatos
{
    public class Program
    {
        private const string CadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;" +
            @"Database=GastosDB;" +
            @"Trusted_Connection=True;" +
            @"TrustServerCertificate=True;";

        public static void Main(string[] args)
        {
            List<Gasto> gastos = LeerGastos();
            MostrarGastos(gastos);
        }

        private static List<Gasto> LeerGastos()
        {
            List<Gasto> gastos = new List<Gasto>();

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();

                string sql = "SELECT Id, Descripcion, Monto, Categoria FROM Gastos";
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Gasto g = new Gasto
                        {
                            id = lector.GetInt32(0),
                            descripcion = lector.GetString(1),
                            monto = lector.GetDecimal(2),
                            categoria = lector.GetString(3)
                        };
                        gastos.Add(g);
                    }
                }
            }

            return gastos;
        }

        private static void MostrarGastos(List<Gasto> gastos)
        {
            if (gastos.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados.");
                return;
            }

            decimal total = 0;
            foreach (Gasto g in gastos)
            {
                Console.WriteLine(g);
                total += g.monto;
            }

            Console.WriteLine($"TOTAL GASTADO: Q {total:N2}");
        }
    }
}