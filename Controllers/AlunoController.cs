using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {        
        private readonly Contexto _contexto;
        public readonly IRepository _repo;

        public AlunoController(Contexto contexto, IRepository repo) 
       {
           _contexto = contexto;
           _repo = repo;
       }

       [HttpGet("resposta")]
       public IActionResult pegaResposta()
       {
           
           return Ok(_repo.pegaResposta());
       }      


       [HttpGet]
       public IActionResult Get()
       {
           var alunos = _contexto.Alunos.ToList();
           return Ok(alunos);
       }      

       [HttpGet("{id}")] 
       public IActionResult GetById(int id)
       {
           try
           {
               var aluno = _contexto.Alunos.FirstOrDefault(a => a.Id == id);
               if(aluno == null)
                return NotFound("Id não encontrado");
               return Ok(aluno);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar buscar aluno: {ex.Message}");
           }
       }

       [HttpGet("GetByName")]
       public IActionResult GetByName(string nome, string sobrenome)
       {
           try
           {
               var aluno = _contexto.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
               if(aluno == null)
                return NotFound("Aluno não encontrado");
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
               _contexto.Alunos.Add(aluno);
               _contexto.SaveChanges();
               return Ok(aluno);
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
               var alunoBanco = _contexto.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
               if(alunoBanco == null)
                return NotFound("Aluno não encontrado");
                _contexto.Update(alunoBanco);
                _contexto.SaveChanges();
                return Ok(alunoBanco);
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
               var alunoBanco = _contexto.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
               if(alunoBanco == null)
                return NotFound("Aluno não encontrado");
                _contexto.Update(alunoBanco);
                _contexto.SaveChanges();
                return Ok(alunoBanco);
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
               var aluno = _contexto.Alunos.FirstOrDefault(a => a.Id == id);
               if(aluno == null)
                return NotFound("Aluno não encontrado");
                _contexto.Remove(aluno);
                _contexto.SaveChanges();
                return Ok("Aluno deletado com sucesso");
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar deletar o Aluno: {ex.Message}");
           }
       }
    }
}
