using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.Request;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //interface 
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta onRespuesta = new Respuesta();

            try
            {
                // crea contexto para las consultas
                using (VentaRealContext db = new VentaRealContext())
                {
                    // var es una forma de darle el tipo de variable de acuerdo al valor
                    var lst = db.Cliente.ToList();

                    // 1=verdadero, 0=falso
                    onRespuesta.Exito = 1;
                    onRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                onRespuesta.Mensaje = ex.Message;
            }

            return Ok(onRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta onRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.nombre;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();
                    onRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                onRespuesta.Mensaje = ex.Message;
            }

            return Ok(onRespuesta);
        }


        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta onRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(oModel.Id);
                    oCliente.Nombre = oModel.nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    onRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                onRespuesta.Mensaje = ex.Message;
            }

            return Ok(onRespuesta);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta onRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    onRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                onRespuesta.Mensaje = ex.Message;
            }

            return Ok(onRespuesta);
        }


    }
}
