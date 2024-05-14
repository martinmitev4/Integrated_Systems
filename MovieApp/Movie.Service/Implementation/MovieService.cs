using Movie.Repository.Interface;
using Movie.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie.Domain.Domain.Movie> _movieRepository;

        public MovieService (IRepository<Movie.Domain.Domain.Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void CreateNewMovie(Domain.Domain.Movie m)
        {
            _movieRepository.Insert(m);
        }

        public void DeleteMovie(Guid id)
        {
            var movie = _movieRepository.Get(id);
            _movieRepository.Delete(movie);
        }

        public List<Domain.Domain.Movie> GetAllMovies()
        {
            return _movieRepository.GetAll().ToList();
        }

        public Domain.Domain.Movie GetDetailsForMovie(Guid? id)
        {
            return _movieRepository.Get(id);
        }

        public void UpdateExistingMove(Domain.Domain.Movie m)
        {
           _movieRepository.Update(m);
        }
    }
}
