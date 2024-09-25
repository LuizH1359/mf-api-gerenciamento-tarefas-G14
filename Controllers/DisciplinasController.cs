using mf_api_gerenciamento_tarefas_G14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mf_api_gerenciamento_tarefas_G14.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        

            private readonly AppDbContext _context;

            public DisciplinasController(AppDbContext context)
            {
                _context = context;

            }

            
            
        }
}
