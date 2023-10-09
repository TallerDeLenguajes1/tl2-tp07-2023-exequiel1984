using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Practico7;
namespace Practico7.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private ManejoTarea manejoTarea;

    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        var accesoADatos = new AccesoADatos();
        manejoTarea = new ManejoTarea(accesoADatos);
    }

    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        var nuevaTarea = manejoTarea.CrearTarea(tarea);
        return Ok(tarea);
    }

    [HttpGet("GetTarea")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        var tarea = manejoTarea.GetTarea(id);
        if(tarea == null)
            return BadRequest();
        else 
            return tarea;
    }

    [HttpPut("UpdTarea")]
    public ActionResult<Tarea> UpdTarea(Tarea tarea)
    {
        var auxTarea = manejoTarea.UpdTarea(tarea);
        if(auxTarea == null)
            return BadRequest();
        else
            return auxTarea;
    }

    [HttpDelete("DeleteTarea")]
    public ActionResult<Tarea> DeleteTarea(int id)
    {
        var auxTarea = manejoTarea.DeleteTarea(id);
        if(auxTarea == null)
            return BadRequest();
        else
            return auxTarea;
    }

    [HttpGet]
    [Route("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        return Ok(manejoTarea.GetTareas());
    }

    [HttpGet]
    [Route("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        return Ok(manejoTarea.GetTareasCompletadas());
    }
}
