using Microsoft.EntityFrameworkCore;
using taskboard_api.Data;

namespace taskboard_api.Repositories.Lane
{
    public class LaneRepo : ILaneRepo
    {
        private readonly DataContext _context;

        public LaneRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Models.Lane>>> GetAllLanes()
        {
            var serviceResponse = new ServiceResponse<List<Models.Lane>>();
            var lanes = await _context.Lanes
                .Include(l => l.IssuesInLane)
                .ToListAsync();

            if (lanes.Any())
            {
                serviceResponse.Data = lanes;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No lanes found.";
            }

            return serviceResponse;
        }
    }
}
