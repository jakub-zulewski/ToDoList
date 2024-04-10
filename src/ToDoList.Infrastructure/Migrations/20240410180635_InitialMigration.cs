using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "ToDoItems",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uuid", nullable: false),
				Title = table.Column<string>(type: "text", nullable: false),
				Description = table.Column<string>(type: "text", nullable: true),
				CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
				DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
				IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
				CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_ToDoItems", x => x.Id);
			});
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "ToDoItems");
	}
}
