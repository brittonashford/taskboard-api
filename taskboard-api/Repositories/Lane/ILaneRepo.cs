namespace taskboard_api.Repositories.Lane
{
    public interface ILaneRepo
    {
        Task<ServiceResponse<List<Models.Lane>>> GetAllLanes();
    }
}
