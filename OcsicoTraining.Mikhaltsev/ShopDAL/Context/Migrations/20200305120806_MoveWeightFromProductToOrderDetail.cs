using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDAL.Context.Migrations
{
    public partial class MoveWeightFromProductToOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
