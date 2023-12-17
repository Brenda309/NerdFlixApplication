using NerdFlixApplication.Models.Domain;
using NerdFlixApplication.Models.DTO;

namespace NerdFlixApplication.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();

    }
}