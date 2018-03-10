namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Turma", t => t.TurmaId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                        CursoId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TurmaId)
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .ForeignKey("dbo.Professor", t => t.ProfessorId)
                .Index(t => t.CursoId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Aluno", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.CursoProfessor",
                c => new
                    {
                        CursoId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CursoId, t.ProfessorId })
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .ForeignKey("dbo.Professor", t => t.ProfessorId)
                .Index(t => t.CursoId)
                .Index(t => t.ProfessorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "UsuarioId", "dbo.Aluno");
            DropForeignKey("dbo.Aluno", "TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Turma", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Turma", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.CursoProfessor", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.CursoProfessor", "CursoId", "dbo.Curso");
            DropIndex("dbo.CursoProfessor", new[] { "ProfessorId" });
            DropIndex("dbo.CursoProfessor", new[] { "CursoId" });
            DropIndex("dbo.Usuario", new[] { "UsuarioId" });
            DropIndex("dbo.Turma", new[] { "ProfessorId" });
            DropIndex("dbo.Turma", new[] { "CursoId" });
            DropIndex("dbo.Aluno", new[] { "TurmaId" });
            DropTable("dbo.CursoProfessor");
            DropTable("dbo.Usuario");
            DropTable("dbo.Professor");
            DropTable("dbo.Curso");
            DropTable("dbo.Turma");
            DropTable("dbo.Aluno");
        }
    }
}
