using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
         private readonly Contexto _contexto;
        private readonly IRepository _repo;

        public ProfessorController(Contexto contexto, IRepository repo) 
       {
            _repo = repo;
           _contexto = contexto;
       }

       [HttpGet]
       public IActionResult Get()
       {
           var professores = _contexto.Professores.ToList();
           return Ok(professores);
       } 

       [HttpGet("{id}")]
       public IActionResult GetById(int id)
       {
           return Ok(new { id });
       } 

       [HttpGet("ByNome")]
       public IActionResult GetByNome(string nome)
       {
            try
           {
               var professor = _contexto.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
               if(professor == null)
                return NotFound("Professor não encontrado");
               return Ok(professor);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar buscar o professor: {ex.Message}");
           }
       }

       [HttpPost]
       public IActionResult Post(Professor professor)
       {
            try
           {
                _repo.Add(professor);
                if(_repo.SaveChanges())
                {
                    return Ok(professor);
                }              
               return BadRequest("Professor não cadastrado");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar adicionar o Professor: {ex.Message}");
           }      
       }   

       [HttpPut("{id}")]
       public IActionResult Put(int id, Professor professor)
       {
           try
           {
               var professorBanco = _contexto.Professores.FirstOrDefault(a => a.Id == id);
               if(professorBanco == null)
                return NotFound("Professor não encontrado");
                _contexto.Update(professorBanco);
                _contexto.SaveChanges();
                return Ok(professorBanco);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar atualizar o Professor: {ex.Message}");
           }
       } 

       [HttpPatch("{id}")]       
       public IActionResult Patch(int id, Professor professor) 
       {
              try
           {
               var professorBanco = _contexto.Professores.FirstOrDefault(a => a.Id == id);
               if(professorBanco == null)
                return NotFound("Professor não encontrado");
                _contexto.Update(professorBanco);
                _contexto.SaveChanges();
                return Ok(professorBanco);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar atualizar o Professor: {ex.Message}");
           }
       }

       [HttpDelete("{id}")]
       public IActionResult Delete(int id)
       {
           try
           {
               var professor = _contexto.Professores.FirstOrDefault(a => a.Id == id);
               if(professor == null)
                return NotFound("Professor não encontrado");
                _contexto.Professores.Remove(professor);
                return Ok(professor);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar deletar o Professor: {ex.Message}");
           }
       }
    }
}