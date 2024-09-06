using MyNewShop.Models;

namespace MyNewShop.ViewModels
{
    public class ItemsViewModel
    {
        public IEnumerable<Item> Items;
        
        // for å gjøre det lettere å holde styr på de forskjellige navnene som skal byttes ut med currentViewName
        public string? CurrentViewName;

        public ItemsViewModel(IEnumerable<Item> items, string? currentViewName)
        {
            Items = items;
            CurrentViewName = currentViewName;
        }
    }
}