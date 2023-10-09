namespace Practico7
{
    public enum Estados
    {
        Pendiente,
        EnProgreso,
        Completada
    };
    public class Tarea
    {

        
        private int id;
        private string titulo;
        private string descripcion;
        private Estados estado;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estados Estado { get => estado; set => estado = value; }
        
    }
}
