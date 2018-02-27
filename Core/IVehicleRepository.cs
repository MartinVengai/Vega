using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
        Task<QueryResult<Vehicle>> GetVehiclesAsync(VehicleQuery filter);
        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated=true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}