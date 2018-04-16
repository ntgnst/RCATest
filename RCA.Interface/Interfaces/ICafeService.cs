using RCA.DTO.DTO;
using RCA.Interface.Result;

namespace RCA.Interface.Interfaces
{
    public interface ICafeService
    {
        Result<CafeDTO> GetByID(int id);
        Result<CafeDTO> GetByName(string name);
        Result<CafeDTO> GetByOwnerId(string ownerId);
        Result<CafeDTO> GetByExternalCode(string externalCode);
    }
}
