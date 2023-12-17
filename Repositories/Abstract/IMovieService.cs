using NerdFlixApplication.Models.DTO;
using NerdFlixApplication.Models.Domain;


namespace NerdFlixApplication.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);
        bool Update(Movie model);
        Movie GetById(int id);
        bool Delete(int id);
        MovieListVM List(string term = "", bool paging = false, int currentPage = 0);
        List<int> GetGenreByMovieId(int movieId);

    }
}