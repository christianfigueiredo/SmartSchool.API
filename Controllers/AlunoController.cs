﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {        
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno() {               
                Id = 1,
                Nome = "Paulo",
                Sobrenome = "Silva",
                Telefone = "11999999999"
            },
            new Aluno() {
                Id = 2,
                Nome = "Pedro",
                Sobrenome = "Silva",
                Telefone = "1188888888"
            },
            new Aluno() {
                Id = 3,
                Nome = "Jorge",
                Sobrenome = "Souza",
                Telefone = "2299999999"
            },

        };
       public AlunoController() { }

       [HttpGet]
       public IActionResult Get()
       {
           return Ok(Alunos);
       }      

       [HttpGet("{id}")] 
       public IActionResult GetById(int id)
       {
           try
           {
               var aluno = Alunos.FirstOrDefault(a => a.Id == id);
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
               var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
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
               Alunos.Add(aluno);
               return Ok(Alunos);
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
               var alunoBanco = Alunos.FirstOrDefault(a => a.Id == id);
               if(alunoBanco == null)
                return NotFound("Aluno não encontrado");
                alunoBanco.Nome = aluno.Nome;
                alunoBanco.Sobrenome = aluno.Sobrenome;
                alunoBanco.Telefone = aluno.Telefone;
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
               var alunoBanco = Alunos.FirstOrDefault(a => a.Id == id);
               if(alunoBanco == null)
                return NotFound("Aluno não encontrado");
                if(aluno.Nome != null)
                    alunoBanco.Nome = aluno.Nome;
                if(aluno.Sobrenome != null)
                    alunoBanco.Sobrenome = aluno.Sobrenome;
                if(aluno.Telefone != null)
                    alunoBanco.Telefone = aluno.Telefone;
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
               var aluno = Alunos.FirstOrDefault(a => a.Id == id);
               if(aluno == null)
                return NotFound("Aluno não encontrado");
                Alunos.Remove(aluno);
                return Ok(Alunos);
           }
           catch (System.Exception ex)
           {
               return BadRequest($"Erro ao tentar deletar o Aluno: {ex.Message}");
           }
       }
    }
}