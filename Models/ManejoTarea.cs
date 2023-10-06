using System.Data.Common;

namespace Practico7
{
    public class ManejoTarea
    {
        private AccesoADatos accesoADatos;
        public ManejoTarea(AccesoADatos accesoADatos){
            this.accesoADatos = accesoADatos;
        }

        public Tarea CrearTarea(Tarea tarea){
            List<Tarea> listaTareas = accesoADatos.Obtener();
            listaTareas.Add(tarea);
            tarea.Id = listaTareas.Count;
            accesoADatos.Guardar(listaTareas);
            return tarea;
        }

        public Tarea GetTarea(int id){
            List<Tarea> listaTareas = accesoADatos.Obtener();
            Tarea tarea = listaTareas.FirstOrDefault(t => t.Id == id);
            return tarea;
        }

        public Tarea UpdTarea(Tarea tarea){
            List<Tarea> listaTareas = accesoADatos.Obtener();
            Tarea auxTarea = listaTareas.FirstOrDefault(t => t.Id == tarea.Id);
            listaTareas.Remove(auxTarea);
            listaTareas.Add(tarea);
            accesoADatos.Guardar(listaTareas);
            return tarea;
        }

        public Tarea DeleteTarea(int id){
            List<Tarea> listaTareas = accesoADatos.Obtener();
            Tarea auxTarea = listaTareas.FirstOrDefault(t => t.Id == id);
            listaTareas.Remove(auxTarea);
            accesoADatos.Guardar(listaTareas);
            return auxTarea;
        }
    }
}