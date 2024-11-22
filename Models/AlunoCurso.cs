namespace SmartSchool.API.Models
{
    public class AlunoCurso
    {

        public AlunoCurso()   {}

        public AlunoCurso(int alunoId, int cursoId) 
        {
            this.CursoId = cursoId;
            this.AlunoId = alunoId;
         }

        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }        
        public int AlunoId { get; set;}
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
