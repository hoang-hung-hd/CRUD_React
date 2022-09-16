using ReactNet.Models;

namespace ReactNet.Services
{
    public class CityService
    {
        private AppDbContext _context;

        public CityService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities;
        }

        public City GetCityById(int id)
        {
            var city = _context.Cities.Find(id);
            if (city == null) throw new KeyNotFoundException("City not found");
            return city;
        }

        public void CreateCity(CityForm model)
        {
            City city = new City();
            city.CityName = model.CityName;

            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void UpdateCity(int id, CityForm model)
        {
            var city = GetCityById(id);
            city.CityName = model.CityName;

            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        public void DeleteCity(int id)
        {
            var city = GetCityById(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
    }
}
