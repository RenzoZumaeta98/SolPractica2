using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolPractica2.CustomExtensions;
using SolPractica2.DataAccess;
using SolPractica2.DataAccess.Entities;
using SolPractica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolPractica2.Controllers
{
    public class AlumnosNotasController : Controller
    {
        
        private readonly NotasAlumnoContext _context;
        public AlumnosNotasController(NotasAlumnoContext context)
        {
            this._context = context;
            
        }



        public IActionResult Listar()
        {
            var listResult = _context.Alumnos.ToList();
            List<Notas> listResult2;


            AlumnosNotasListViewModel model = new AlumnosNotasListViewModel();

            for(int i=0; i<listResult.Count();i++)
            {
                listResult2 = _context.Notas.Where(c => c.alumno.cod == listResult[i].cod).ToList();

                string todasNotas = "/";

                for (int y = 0; y < listResult2.Count(); y++)
                    {
                    todasNotas += "Curso: " + listResult2[y].name + " Nota: "+ listResult2[y].nota + "/ ";

                }


                    model.List.Add(new AlumnosNotasListarModel()
                        {
                            cod = listResult[i].cod,
                            name = listResult[i].name,
                            apellido = listResult[i].apellido,
                            dni = listResult[i].dni,
                            fechaNacimiento = listResult[i].fechaNacimiento,
                            notas = todasNotas
                        });

                    

            }



            return View(model);
        }




        public IActionResult AddAlumno()
        {
            AlumnoViewModel model = new AlumnoViewModel();

            if (HttpContext.Session.GetList<NotasTemporalViewModel>("temporal") == null)
            {
                model.TemporalNotas = new List<NotasTemporalViewModel>();
            }
            else
            {
                model.TemporalNotas = (List<NotasTemporalViewModel>)HttpContext.Session.GetList<NotasTemporalViewModel>("temporal");
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult AddTemporalNota(NotasTemporalViewModel param)
        {

            List<NotasTemporalViewModel> temporalNotas = null;

            if (HttpContext.Session.GetList<NotasTemporalViewModel>("temporal") == null)
            {
                temporalNotas = new List<NotasTemporalViewModel>();
            }
            else
            {
                temporalNotas = (List<NotasTemporalViewModel>)HttpContext.Session.GetList<NotasTemporalViewModel>("temporal");
            }
            temporalNotas.Add(param);
            HttpContext.Session.Set<List<NotasTemporalViewModel>>("temporal", temporalNotas);

            return new JsonResult(new { a = 1 });
        }


        [HttpPost]
        public IActionResult AddSaveAction(AlumnoViewModel modelToSave)
        {
            modelToSave.TemporalNotas = (List<NotasTemporalViewModel>)HttpContext.Session.GetList<NotasTemporalViewModel>("temporal");

           
            var alumnoRegistro = _context.Alumnos.Add(new Alumnos()
            {
                name=modelToSave.Nombre.ToString(),
                apellido=modelToSave.Apellidos.ToString(),
                dni=modelToSave.DNI.ToString(),
                fechaNacimiento=modelToSave.FechaNacimiento.ToString(),
            });

            
            foreach (var item in modelToSave.TemporalNotas)
            {
                _context.Notas.Add(new Notas()
                {
                    name = item.name,
                    nota = item.nota,
                    alumno = alumnoRegistro.Entity

                });
            }

            _context.SaveChanges();

            HttpContext.Session.Clear();

            return RedirectToAction("Listar");
        }
    }
}
