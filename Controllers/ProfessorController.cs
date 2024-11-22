using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
       
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo) 
       {
            _repo = repo;          
       }

       [HttpGet]
       public IActionResult Get()
       {
           var professores = _repo.GetAllProfessores(true);
           return Ok(professores);
       } 

       [HttpGet("{id}")]
       public IActionResult GetById(int id)
       {
           return Ok(new { id });
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
               var professorBanco = _repo.GetProfessorById(id, false);
               if(professorBanco == null)
                return NotFound("Professor não encontrado");
                _repo.Update(professorBanco);
                if(_repo.SaveChanges())
                {
                    return Ok(professorBanco);
                }               
                return BadRequest("Professor não Atualizado");
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
               var professorBanco = _repo.GetProfessorById(id, false);
               if(professorBanco == null)
                return NotFound("Professor não encontrado");
                _repo.Update(professorBanco);
                if(_repo.SaveChanges()) {
                    return Ok(professorBanco);
                }
                return BadRequest("Professor não Atualizado");
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
               var professor = _repo.GetProfessorById(id, false);
               if(professor == null)
                return NotFound("Professor não encontrado");
                _repo.Delete(professor);
                if(_repo.SaveChanges()) 
                {
                    return Ok("Professor deletado");
                }
                return BadRequest("Professor não Deletado");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar deletar o Professor: {ex.Message}");
           }
       }
    }
}