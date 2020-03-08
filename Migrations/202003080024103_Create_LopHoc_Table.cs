namespace ASP_SEM3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_LopHoc_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LopHocs",
                c => new
                    {
                        MSV = c.String(nullable: false, maxLength: 128),
                        Hinh_Thuc_Nop_Phat = c.Int(nullable: false),
                        NopPhat = c.Long(nullable: false),
                        NgayNop = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MSV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LopHocs");
        }
    }
}
