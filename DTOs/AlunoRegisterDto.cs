using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.DTOs
{
    public class AlunoRegisterDto
    {
        public int Id { get; set;}
        public int Matricula { get; set; }
        public string Nome { get; set;}
        public string Sobrenome { get; set;}
        public string Telefone { get; set;} 
        public DateTime DataNascimento { get; set; } 
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public DateTime? DataFinalMatricula { get; set; } = null;
        public bool Ativo { get; set; } = true;        
    }
}