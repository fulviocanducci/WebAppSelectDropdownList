using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppSelectDropdownList.Controllers
{
    public class SelectController : Controller
    {
        public IActionResult Index()
        {
            //var _items = new object[]
            //{
            //    new {Name = "Numero 1", Value = 1, Group = "Acessórios"},
            //    new {Name = "Numero 2", Value = 2, Group = "Acessórios"},
            //    new {Name = "Numero 3", Value = 3, Group = "Mesa e Banho"},
            //    new {Name = "Numero 4", Value = 4, Group = "Mesa e Banho"},
            //    new {Name = "Numero 5", Value = 5, Group = "Mesa e Banho"}
            //};

            //ViewBag.Items = _items.ToSelectList("Value", "Name", 0, "Group");

            //ViewBag.Status = new SelectList(new object[]
            //{
            //    new {Name = "Sim", Value = "S"},
            //    new {Name = "Não", Value = "N"}
            //}, "Value", "Name");

            ViewBag.Status = new[]
            {
                new SelectListItem(){ Value = "S", Text = "Sim"},
                new SelectListItem(){ Value = "N", Text = "Não"}
            };

            return View();
        }
    }
}