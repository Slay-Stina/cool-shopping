using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using ShoppingList.Application.Interfaces;
using ShoppingList.Domain.Models;

namespace ShoppingList.Application.Services;

public class ShoppingListService : IShoppingListService
{
    private ShoppingItem[] _items;
    private int _nextIndex;

    public ShoppingListService()
    {
        // Initialize with demo data for UI demonstration
        // TODO: Students can remove or comment this out when running unit tests
        _items = [];
        _nextIndex = 0; // We have 4 demo items initialized
    }

    public IReadOnlyList<ShoppingItem> GetAll()
    {
        return _items;
    }

    public ShoppingItem? GetById(string id)
    {
        foreach (var item in _items)
        {
            if (item.Id == id)
                return item;
        }

        throw new NullReferenceException("No item found");
    }

    public ShoppingItem? Add(string name, int quantity, string? notes)
    {
        var newItem = new ShoppingItem
        {
            Name = name,
            Quantity = quantity,
            Notes = notes,
        };
        Array.Resize(ref _items, _nextIndex + 1);
        _items[_nextIndex] = newItem;
        _nextIndex++;

        return newItem;
    }

    public ShoppingItem? Update(string id, string name, int quantity, string? notes)
    {
        // TODO: Students - Implement this method
        // Return the updated item, or null if not found
        return null;
    }

    public bool Delete(string id)
    {
        bool isDeleted = false;
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null && _items[i].Id == id)
            {
                _items[i] = null;
                isDeleted = true;
            }
            if (_items[i] == null && _items[i] != _items.Last())
            {
                _items[i] = _items[i + 1];
                _items[i + 1] = null;
            }
        }
        return isDeleted ? isDeleted : throw new NullReferenceException("Item not found");
    }

    public IReadOnlyList<ShoppingItem> Search(string query)
    {
        List<ShoppingItem> results = [];

        foreach (var item in _items)
        {
            if (
                item.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
                || item.Notes.Contains(query, StringComparison.OrdinalIgnoreCase)
            )
            {
                results.Add(item);
            }
        }
        return results;
    }

    public int ClearPurchased()
    {
        // TODO: Students - Implement this method
        // Return the count of removed items
        return 0;
    }

    public bool TogglePurchased(string id)
    {
        // TODO: Students - Implement this method
        // Return true if successful, false if item not found
        return false;
    }

    public bool Reorder(IReadOnlyList<string> orderedIds)
    {
        // TODO: Students - Implement this method
        // Return true if successful, false otherwise
        return false;
    }
}
