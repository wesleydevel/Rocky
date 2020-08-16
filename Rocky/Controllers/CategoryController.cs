﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocky.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
      _db = db;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
      IEnumerable<Category> categories = _db.Category;
      return View(categories);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        _db.Category.Add(category);
        _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
