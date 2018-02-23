using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Persistence;
using Vega.Core;
using Vega.Core.Models;
using System.Collections.Generic;

namespace Vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            return await context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(v => v.Make)
                .ToListAsync();
        }
        public async Task<Vehicle> GetVehicleAsync(int id, bool includeRelated=true)
        {
            if (!includeRelated)
                return await context.Vehicles.FindAsync(id);
            
            return await context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(v => v.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }
    }
}