using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    interface IItemsRepository
    {
        IEnumerable<Item> GetItems();

        bool UpdateItem(Item item);
        bool DeleteItem(int id);
        bool CreateItem(Item item);
        void ImportItems(IEnumerable<Item> items);
    }
}
