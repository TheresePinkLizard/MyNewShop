using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNewShop.Models;

namespace MyNewShop.Controllers;

public class ItemController : Controller
{
    // en action som korresponderer til en brukers interaksjon, slik som å liste opp items når en url lastes
    public IActionResult Table()
    {  
        var items = GetItems();
        ViewBag.CurrentViewName = "Table";
        // en action kan returnere enten: View, JSON, en Redirect, eller annet. 
        // denne returnerer en view
        return View(items);
    }
    public IActionResult Grid()
    {
        var items = GetItems();
        ViewBag.CurrentViewName = "Grid";
        return View(items);
    }
    public List<Item> GetItems()
    {
        var items = new List<Item>();
        var item1 = new Item
        {
            ItemId = 1,
            Name = "Pizza",
            Price = 150,
            Description = "Delicious Italian dish",
            ImageUrl = "/images/pizza.jpg"
        };
        var item2 = new Item
         {
            ItemId = 2,
            Name = "Fish and Chips",
            Price = 110,
            Description = "Delicious British dish",
            ImageUrl = "/images/fishandchips.jpg"
        };
        var item3 = new Item
         {
            ItemId = 3,
            Name = "Tacos",
            Price = 140,
            Description = "Delicious Mexican dish",
            ImageUrl = "/images/tacos.jpg"
        };
     
       
       items.Add(item1);
       items.Add(item2);
       items.Add(item3);
      
       return items;

    }
}
