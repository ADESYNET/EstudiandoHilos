// See https://aka.ms/new-console-template for more information
using EstudiandoHilos;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Xml;

/*******POOL DE HILOS - EJEMPLO
ProbandoPoolHilos ProbandoPoolHilosObject = new ProbandoPoolHilos();
//ProbandoPoolHilosObject.EjecutarProceso();

for (int i = 0; i < 100; i++) 
{
    //Thread t = new Thread(ejecutar);
    //t.Start();

    ThreadPool.QueueUserWorkItem(ejecutar,i);
    

}

Console.ReadLine();

void ejecutar(Object stateInfo)
{
    //Console.WriteLine($"Thread n°: {Thread.CurrentThread.ManagedThreadId} ha comenzado su tarea");

    //Thread.Sleep(1000);

    //Console.WriteLine($"Thread n°: {Thread.CurrentThread.ManagedThreadId} ha terminado su tarea");
    
    int nTarea = (int)stateInfo;

    ProbandoPoolHilosObject.EjecutarProceso(nTarea);
}
*************/

//ConexionSQL cnx = new ConexionSQL();

//cnx.abrirConexion();

ManipularZIP zip = new ManipularZIP();

zip.descomprimirZIP("A:\\@Desarrollo\\C#\\EstudiandoHilos\\ZIP\\Compressed\\TRF_00156_20220908024839.zip", "A:\\@Desarrollo\\C#\\EstudiandoHilos\\ZIP\\Files");

/*****REGISTRAR SP EN LA BBDD
string sqlConnectionString = cnx.setConexion("sa", "SQL%2017STAN", "ADESYNETCON_HyS_20220904", "SRV-DATABASE\\SQL2017STAN");
byte[] data = File.ReadAllBytes("A:\\@Desarrollo\\SQL\\Store Procedures\\HolaMundo.sql");
string text = Encoding.UTF8.GetString(data);

SqlConnection conn = new SqlConnection(sqlConnectionString);
//Server s = new Server(new ServerConnection());
//Server server = new Server(new ServerConnection(conn));
conn.Open();
var qry = new SqlCommand(text,conn);
qry.ExecuteNonQuery();
conn.Close();
*/

string setConexion(string pUser, string pContrasena, string pBaseDatos, string pServidor)
{
    return $"Persist Security Info=False;User ID={pUser};Password={pContrasena};Initial Catalog={pBaseDatos};Server={pServidor}";
}

void ejecutar(string pRutaXML)
{
    SqlConnection cnx = new SqlConnection(setConexion("sa", "SQL%2017STAN", "ADESYNETCON_HyS_20220904", "SRV-DATABASE\\SQL2017STAN"));
    cnx.Open();

    SqlXml mixml = new SqlXml(new XmlTextReader(pRutaXML));

    string qry = "exec Alta_VENTAD_OTROS @xmlParameter";

    SqlCommand consulta = new SqlCommand(qry, cnx);
    consulta.Parameters.AddWithValue("@xmlParameter", mixml);
    try
    {
        consulta.ExecuteNonQuery();
        Console.WriteLine("Proceso terminado");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}



/*using (SqlConnection cn = new SqlConnection("connection string"))
{
    cn.Open();

    SqlCommand cmd = new SqlCommand("NombreStoreProcedure", cn);
    cmd.CommandType = CommandType.StoredProcedure;

    cmd.Parameters.AddWithValue("@param", Convert.ToInt32(Textbox1.Text));

    SqlDataReader dr = cmd.ExecuteReader();

    if (dr.Read())
    {
        //aqui cargas la lista
    }
}*/