using ProjetoDoacaoDeSangue.Application.Services.DoadorServices.InputModels;
using ProjetoDoacaoDeSangue.Application.Services.DoadorServices.ViewModels;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Models;

namespace ProjetoDoacaoDeSangue.Application.Services.DoadorServices
{
    public interface IDoadorService
    {
        public Task<ApiResponse<List<Doador>>> GetAll(CancellationToken cancellationToken);
        public Task<ApiResponse<bool>> Create(CreateDoadorInputDto dto, CancellationToken cancellationToken);
        public Task<ApiResponse<GetDataDoadorViewDto>> GetById(int id, CancellationToken cancellationToken); 
        public Task<ApiResponse<bool>> Update(int id, UpdateDoadorInputDto dto, CancellationToken cancelToken);
        public Task<ApiResponse<bool>> Delete(int id, CancellationToken cancelToken);
        public Task<ApiResponse<List<Doacao>>> GetDonationHistory(int id, CancellationToken cancelToken);
    }
}
