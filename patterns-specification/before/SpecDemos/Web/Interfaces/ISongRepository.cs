using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.Interfaces
{
    public interface ISongRepository
    {
        IQueryable<Song> List();
        Song GetById(int id);
        void Add(Song song);
    }
}