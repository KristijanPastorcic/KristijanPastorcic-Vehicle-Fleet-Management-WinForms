using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    public delegate void InfoMessageDelegate(object sender, SqlInfoMessageEventArgs e);
    interface ITravelWarrentsRepository
    {
        IEnumerable<TravelWarrent> GetTravelWarrents();
        bool CreateTravelWarrent(TravelWarrent warrent);
        bool UpdateTravelWarrent(TravelWarrent warrent);
        bool DeleteTravelWarrent(int id);


         event InfoMessageDelegate TravelWarrents_InfoMessage;

        void ImportWarrents(IEnumerable<TravelWarrent> warrents);
    }
}
