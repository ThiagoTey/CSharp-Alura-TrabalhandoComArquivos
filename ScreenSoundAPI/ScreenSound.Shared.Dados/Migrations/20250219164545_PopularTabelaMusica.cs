using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" } , new object[] { "Duality", 2004 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Wait and Bleed", 1999 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Psychosocial", 2008 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Before I Forget", 2004 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Snuff", 2008 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "The Devil in I", 2014 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Vermilion", 2004 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Dead Memories", 2008 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "All Out Life", 2018 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
