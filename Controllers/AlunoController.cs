using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.DTOs;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    { 
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController( IRepository repo, IMapper mapper) 
       {           
            _mapper = mapper;
           _repo = repo;
       }      

       [HttpGet]
       public IActionResult Get()
       {
           var alunos = _repo.GetAllAlunos(true);

          
           return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
       }      

       [HttpGet("{id}")] 
       public IActionResult GetById(int id)
       {
           try
           {
               var aluno = _repo.GetAlunoById(id, false);
               if(aluno == null)
                return NotFound("Id não encontrado");
               return Ok(aluno);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar buscar aluno: {ex.Message}");
           }
       }
       
       [HttpPost]
       public IActionResult Post(Aluno aluno)
       {
           try
           {
                _repo.Add(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok(aluno);
                }              
               return BadRequest("Aluno não cadastrado");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar adicionar o Aluno: {ex.Message}");
           }
       }

       [HttpPut("{id}")]
       public IActionResult Put(int id, Aluno aluno)
        {
           try
           {
               var alunoBanco = _repo.GetAlunoById(id, false);
               if(alunoBanco == null)
                return NotFound("Aluno não encontrado");

                 _repo.Update(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok(aluno);
                }       

                return BadRequest("Aluno não Atualizado");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar atualizar o Aluno: {ex.Message}");
           }
       }

       [HttpPatch("{id}")]      
       public IActionResult Patch(int id, Aluno aluno) {
           try
           {
               var alunoBanco = _repo.GetAlunoById(id, false);
               if(alunoBanco == null)
                return NotFound("Aluno não encontrado");

                 _repo.Update(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok(aluno);
                }              
                return BadRequest("Aluno não Atualizado");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar atualizar o Aluno: {ex.Message}");
           }
       }

       [HttpDelete("{id}")]
       public IActionResult Delete(int id)
       {
           try
           {
               var aluno = _repo.GetAlunoById(id, false);;
               if(aluno == null)
                return NotFound("Aluno não encontrado");

                 _repo.Delete(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok("aluno deletado");
                }              
               return BadRequest("Aluno não Deletado");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar deletar o Aluno: {ex.Message}");
           }
       }
    }
}
