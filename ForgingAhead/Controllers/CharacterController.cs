using Microsoft.AspNetCore.Mvc;
using ForgingAhead.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ForgingAhead.Controllers{
	  public class CharacterController : Controller{
	  	 
		 private readonly ApplicationDbContext _context;
		 
		 public CharacterController(ApplicationDbContext context){
		 	_context = context;
			}
			
		public IActionResult Index(){
		       var model = _context.Characters.ToList();
		       // ViewData is a property of the controller
		       ViewData["Title"] = "Charatcers";
		       return View("Index",model);
		       }
		       
		 [HttpGet]
		 public IActionResult Create(){
		 	ViewData["Title"] = "Create";
		 	return View("Create");
			}
		       		       
		 public IActionResult Create(Character character){
		 	ViewData["Title"] = "Create";
		 	_context.Characters.Add(character);
			_context.SaveChanges();
			return RedirectToAction("Index");
			}
		
		public IActionResult Details(string name){
		       ViewData["Title"] = name + "'s Detail";
		       var model = _context.Characters.FirstOrDefault(e => e.Name == name);
		       return View("Details",model);
		       }
		      
		public IActionResult Edit(string name){
		       ViewData["Title"] = "Edit " + name;
		       var model = _context.Characters.FirstOrDefault(e => e.Name == name);
		       return View("Edit",model);
		       }

		public IActionResult Update(Character character){
		       ViewData["Title"] = "Update" + character.Name;
		       _context.Entry(character).State = EntityState.Modified;
		       _context.SaveChanges();	       
		       return RedirectToAction("Index");
		       }
		      
	}
}