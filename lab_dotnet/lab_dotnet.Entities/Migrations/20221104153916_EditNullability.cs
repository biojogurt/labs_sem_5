using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab_dotnet.Entities.Migrations
{
    public partial class EditNullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Borrowers_BorrowerId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Contributors_ContributorId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Borrowers_BorrowerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Requesters_RequesterId",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Borrowers_BorrowerId",
                table: "Contributions",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Contributors_ContributorId",
                table: "Contributions",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Borrowers_BorrowerId",
                table: "Requests",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Requesters_RequesterId",
                table: "Requests",
                column: "RequesterId",
                principalTable: "Requesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Borrowers_BorrowerId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Contributors_ContributorId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Borrowers_BorrowerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Requesters_RequesterId",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Borrowers_BorrowerId",
                table: "Contributions",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Contributors_ContributorId",
                table: "Contributions",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Borrowers_BorrowerId",
                table: "Requests",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Requesters_RequesterId",
                table: "Requests",
                column: "RequesterId",
                principalTable: "Requesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
