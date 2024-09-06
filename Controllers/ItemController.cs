using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNewShop.Models;
using MyNewShop.ViewModels;

namespace MyNewShop.Controllers;

public class ItemController : Controller
{
    // en action som korresponderer til en brukers interaksjon, slik som å liste opp items når en url lastes
    public IActionResult Table()
    {  
        var items = GetItems();
        var itemsViewModel = new ItemsViewModel(items, "Table");
        // en action kan returnere enten: View, JSON, en Redirect, eller annet. 
        // denne returnerer en view
        return View(itemsViewModel);
    }

    public IActionResult Grid()
    {
        var items = GetItems();
        var itemsViewModel = new ItemsViewModel(items, "Grid");
        return View(itemsViewModel);
    }

    public IActionResult Details(int id)
    {
        var items = GetItems();
        var item = items.FirstOrDefault(i => i.ItemId == id); // søker igjennom listen items til første som matcher id
        if (item == null)
            return NotFound();
        return View(item); // returnerer view med et item
    }
    public List<Item> GetItems()
    {
        var items = new List<Item>(); // Liste med alle items
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




/* Gammel kode 1

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
        var items = new List<Item>();
        var item1 = new Item();
        item1.ItemId = 1;
        item1.Name = "Pizza";
        item1.Price = 60;

        var item2 = new Item
        {
            ItemId = 2,
            Name = "Fried Chicken Leg",
            Price = 15
        };

        items.Add(item1);
        items.Add(item2);

        ViewBag.CurrentViewName = "List of Shop Items"; // endrer H1 tittel 

        // en action kan returnere enten: View, JSON, en Redirect, eller annet. 
        // denne returnerer en view
        return View(items);
    }
}



*/