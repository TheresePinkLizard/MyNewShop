using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNewShop.Models;

namespace MyNewShop.Controllers;

public class ItemController : Controller
{
    // en action som korresponderer til en bruker interaksjon, slik som å liste opp items når en url lastes
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
