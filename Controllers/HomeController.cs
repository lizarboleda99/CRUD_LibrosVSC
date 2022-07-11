using CRUD_LibrosVSC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_LibrosVSC.Controllers
{
    public class HomeController : Controller
    {
        LibroDataAccess objlibro = new LibroDataAccess();  
  
        public IActionResult Index()  
        {  
            List<Libro> lstLibro = new List<Libro>();  
            lstLibro = objlibro.TraerLibros().ToList();  
  
            return View(lstLibro);  
        } 
        [HttpGet]  
public IActionResult Create()  
{  
    return View();  
}  
  
[HttpPost]  
[ValidateAntiForgeryToken]  
public IActionResult Create([Bind] Libro libro)  
{  
    if (ModelState.IsValid)  
    {  
        objlibro.AgregarLibro(libro);  
        return RedirectToAction("Index");  
    }  
    return View(libro);  
}  

[HttpGet]    
public IActionResult Update(int? id)    
{    
    if (id == null)    
    {    
        return NotFound();    
    }    
    Libro libro = objlibro.TraerLibroPorId(id);    
  
    if (libro == null)    
    {    
        return NotFound();    
    }    
    return View(libro);    
}    
  
[HttpPost]    
[ValidateAntiForgeryToken]    
public IActionResult Update(int id, [Bind]Libro libro)    
{    
    if (id != libro.id)    
    {    
        return NotFound();    
    }    
    if (ModelState.IsValid)    
    {    
        objlibro.ActualizarLibro(libro);    
        return RedirectToAction("Index");    
    }    
    return View(libro);    
}

[HttpGet]  
public IActionResult Delete(int? id)  
{  
    if (id == null)  
    {  
        return NotFound();  
    }  
    Libro libro = objlibro.TraerLibroPorId(id);  
  
    if (libro == null)  
    {  
        return NotFound();  
    }  
    return View(libro);  
}  
  
[HttpPost, ActionName("Delete")]  
[ValidateAntiForgeryToken]  
public IActionResult DeleteConfirmed(int? id)  
{  
    objlibro.BorrarLibro(id);  
    return RedirectToAction("Index");  
}  
    }
}