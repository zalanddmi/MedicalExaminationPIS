using ServerME.Models;
using ServerME.Data;

namespace ServerME.Services
{
    public class LocalitiesService
    {
        private LocalityRepository repository;

        public LocalitiesService() => repository = new LocalityRepository();

        public List<Locality> GetLocalities() => repository.GetLocalities(); 
    }
}
