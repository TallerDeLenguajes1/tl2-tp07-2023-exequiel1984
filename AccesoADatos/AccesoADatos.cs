using System.Text.Json;

namespace Practico7
{
    public class AccesoADatos
    {
        public AccesoADatos(){
            
        }
        
        public List<Tarea> Obtener(){
            List<Tarea> ListaDeserealizada;
            string StringADeserealizar;
            using (var ArchivoOpen = new FileStream("ListaTareas.json", FileMode.Open))
            {
                using (var strReader = new StreamReader(ArchivoOpen))
                {
                    StringADeserealizar = strReader.ReadToEnd();
                    ArchivoOpen.Close();
                }
                ListaDeserealizada = JsonSerializer.Deserialize<List<Tarea>>(StringADeserealizar);
            }
            return ListaDeserealizada;
        }

        public void Guardar(List<Tarea> listaCadetes){
            var json = JsonSerializer.Serialize(listaCadetes);
            File.WriteAllText("ListaTareas.json", json);
        }
    }
}