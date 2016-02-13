namespace SpellChecker.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WordsPerTestOnSpellingBeeTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpellingBeeTests", "WordsPerTest", c => c.Int(nullable: false, defaultValue: 10));
            this.Sql("update dbo.SpellingBeeTests " +
                "set WordsPerTest = 10 " +
                "where SpellingBeeTestId = 1");
            this.Sql("update dbo.SpellingBeeTests " +
                "set WordsPerTest = (select count(b.WordId) from dbo.Words b where b.SpellingBeeTestId = 2) " +
                "where SpellingBeeTestId = 2");
            this.Sql("update dbo.SpellingBeeTests " +
                "set WordsPerTest = (select count(b.WordId) from dbo.Words b where b.SpellingBeeTestId = 3) " +
                "where SpellingBeeTestId = 3");
            this.Sql("update dbo.SpellingBeeTests " +
                "set WordsPerTest = (select count(b.WordId) from dbo.Words b where b.SpellingBeeTestId = 4) " +
                "where SpellingBeeTestId = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpellingBeeTests", "WordsPerTest");
        }
    }
}
