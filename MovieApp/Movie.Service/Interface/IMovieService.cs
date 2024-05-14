using Movie.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Interface
{
    public interface IMovieService
    {
        List<Movie.Domain.Domain.Movie> GetAllMovies();
        Movie.Domain.Domain.Movie GetDetailsForMovie(Guid? id);
        void CreateNewMovie(Movie.Domain.Domain.Movie m);
        void UpdateExistingMove(Movie.Domain.Domain.Movie m);
        void DeleteMovie(Guid id);
    }
}
