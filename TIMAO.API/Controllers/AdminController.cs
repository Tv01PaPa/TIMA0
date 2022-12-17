using Microsoft.AspNetCore.Mvc;
using TIMAO.Infrastructure.Repository;
using TIMAO.Domain;
using TIMAO.Infrastructure;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TIMAO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminRepository _adminRepository;
        public AdminController(Context context )
        {
            _adminRepository = new AdminRepository( context );
        }
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<List<Admin>> Get()
        {
           return await _adminRepository.GetAllAsync();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task Get(Guid id)
        {
            await _adminRepository.GetByAsync(id); ;
        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task Post(Admin admin)
        {
             await _adminRepository.AddAdmin(admin);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public async Task Put(Admin admin)
        {
            await _adminRepository.UpdateAsync(admin);
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
             await _adminRepository.DeleteAdmin(id);
        }
    }
}
