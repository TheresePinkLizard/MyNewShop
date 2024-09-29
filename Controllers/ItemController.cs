using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNewShop.Models;
using MyNewShop.ViewModels;


namespace MyNewShop.Controllers;

public class ItemController : Controller
{

    private readonly ItemDbContext _itemDbContext; // deklarerer en privat kun lesbar felt for å lagre instanser av ItemDbContext

    public ItemController(ItemDbContext itemDbContext) // konstruktør som tar en ItemDbContext instans som et parameter og assigner til _itemDbContext 
    {                                                           // Dette er et eksempel på en dependency injectionm hvor DbContext is provided to the controllerer via ASP.NET Core rammeverk.
        _itemDbContext = itemDbContext;                         //Konstruktøren blir kalt når en instans er laget, vanligvis under behandling av inkommende HTTP request. Når Views er kalt. eks: table grid, details
    }

    // async i metodene:
    // gjør siden mer responsive. den lar programmet kjøre flere tasks concurrently uten å blokkere main thread.
    // dette får siden til å virke mer responsiv ved å la andre oppgaver gå i forveien istedet for at alt venter på et program.
    // await hører også til async

    // en action som korresponderer til en brukers interaksjon, slik som å liste opp items når en url lastes
    public async Task<IActionResult> Table()
    {  
        // henter alle items fra items table i databasen og konverterer til en liste
        List<Item> items = await _itemDbContext.Items.ToListAsync();

        var itemsViewModel = new ItemsViewModel(items, "Table");
        // en action kan returnere enten: View, JSON, en Redirect, eller annet. 
        // denne returnerer en view
        return View(itemsViewModel);
    }

    public async Task<IActionResult> Grid()
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var itemsViewModel = new ItemsViewModel(items, "Grid");
        return View(itemsViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var item = items.FirstOrDefault(i => i.ItemId == id); // søker igjennom listen items til første som matcher id
        if (item == null)
            return NotFound();
        return View(item); // returnerer view med et item
    }

    //  Http Get og post for å gjøre CRUD
    //Get: It returns a view (the "Create" view) that contains a form where the user can enter details for creating the new item
    [HttpGet]
    public IActionResult Create() // trigges når bruker navigerer til create siden
    {
        return View(); // returnerer view hvor bruker kan skrice inn detaljer for å lage et nytt item
    }

// post:  is used to handle the submission of the form when the user clicks the "Create" button
    [HttpPost]
    public async Task<IActionResult> Create(Item item) // tar inn item objekt som parameter
    {
        if (ModelState.IsValid) // sjekker validering
        {
            _itemDbContext.Items.Add(item);  //legges til i database
           await _itemDbContext.SaveChangesAsync(); // endringer lagres
            return RedirectToAction(nameof(Table)); // redirects to show items in table
        }
        return View(item);
    }

    // kodene under gjør at update og delete fungerer
    [HttpGet]
    public async Task<IActionResult> Update(int id)  // denne metoden viser utfyllingsskjemaet for å oppdatere en eksisterende item
    {                                   // metoden slår ut når bruker navigerer seg til update siden
        var item = await _itemDbContext.Items.FindAsync(id); // henter fra database ved hjelp av id
        if (item == null)               // sjekk om den finner item
        {
            return NotFound();
        }
        return View(item); 
    }

    [HttpPost]
    public async Task<IActionResult> Update(Item item)  // tar informasjonen som er skrevet i update skjema,
    {                                           // ser hvis det er valid og oppdaterer i database
        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Update(item);
            await _itemDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Table)); // displayer den oppdaterte listen
        }
        return View(item);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)  // displayer confirmation page for å slette en item
    {
        var item = await _itemDbContext.Items.FindAsync(id);  // identifiserer og henter item som skal bli slettet
        if (item == null)
        {
            return NotFound();
        }
        return View(item);   // hvis funnet, returnerer view med item data for bekreftelse
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id) // metoden som faktisk sletter item fra database
    {
        var item = await _itemDbContext.Items.FindAsync(id); // finner item i database ved bruk at id
        if (item == null)
        {
            return NotFound();
        }
        _itemDbContext.Items.Remove(item); // sletter item
        await _itemDbContext.SaveChangesAsync();  // lagrer endringene 
        return RedirectToAction(nameof(Table)); //returnerer bruker til table view hvor item nå er fjernet
    }
    
}


    /*
    ikke behov for denne koden lengre når database kode ble implementert

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
    */
    




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