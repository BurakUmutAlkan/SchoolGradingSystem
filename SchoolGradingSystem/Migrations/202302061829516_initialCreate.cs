namespace SchoolGradingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        MinimumAttendancePercentageRequired = c.Single(nullable: false),
                        MinimumAverageRequired = c.Single(nullable: false),
                        Major = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(),
                        StudentNumber = c.String(),
                        AttendancePercentage = c.Single(),
                        Average = c.Single(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(),
                        Email = c.String(),
                        Major = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Class_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Class_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.StudentClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentClasses", new[] { "Class_Id" });
            DropIndex("dbo.StudentClasses", new[] { "Student_Id" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
