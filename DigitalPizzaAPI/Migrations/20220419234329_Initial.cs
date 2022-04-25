using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalPizzaAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RewardsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "DrinkList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    DipId = table.Column<int>(type: "int", nullable: false),
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    OtherFoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PizzaSize = table.Column<int>(type: "int", nullable: false),
                    IsWellDone = table.Column<bool>(type: "bit", nullable: false),
                    IsPreset = table.Column<bool>(type: "bit", nullable: false),
                    PresetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    StatusMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InOven = table.Column<bool>(type: "bit", nullable: false),
                    IsOnRoute = table.Column<bool>(type: "bit", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderToppings",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderToppings", x => x.EntryId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PwdHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "PresetPizzas",
                columns: table => new
                {
                    PresetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetPizzas", x => x.PresetId);
                });

            migrationBuilder.CreateTable(
                name: "PresetToppings",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresetId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetToppings", x => x.EntryId);
                });

            migrationBuilder.CreateTable(
                name: "ToppingCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToppingCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ToppingList",
                columns: table => new
                {
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToppingList", x => x.ToppingId);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AccountId", "City", "Label", "Notes", "PostCode", "Province", "StreetName", "StreetNumber", "UnitNumber" },
                values: new object[,]
                {
                    { new Guid("756cb90a-fa3d-4cc1-a6dd-db57005aa05f"), 2, "Toronto", "Home", "", "L8A 0C3", "Ontario", "Clarence Court", 1183, "Suite 200" },
                    { new Guid("8c94e2ee-199d-4c43-ad3d-78cac71c1c95"), 1, "Terrace", "Fake Address 1", "This is a fake testing address. It is not my real address.", "V8G 1S2", "British Columbia", "Burdett Avenue", 3898, null },
                    { new Guid("a3144809-7c8f-4ed8-bcf7-527f68fc0a95"), 4, "Toronto", "Home", "Beware of guard cat", "A3H 1D8", "Ontario", "Aspen Court", 864, "" },
                    { new Guid("f2a350d6-5a29-4984-b4e7-2a9c07cc5521"), 3, "Southfield", "Home", "", "H3Z 7B5", "Ontario", "Cross Street North", 1346, "" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "AccountId", "RewardsCount" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "DrinkList",
                columns: new[] { "Id", "IsPremium", "Name" },
                values: new object[,]
                {
                    { 1, false, "Coke" },
                    { 2, false, "Sprite" },
                    { 3, false, "Barq's" },
                    { 4, false, "Fanta" },
                    { 5, false, "Ginger Ale" },
                    { 6, false, "Nestea" },
                    { 7, true, "Power Ade" },
                    { 8, true, "Peace Tea" },
                    { 9, true, "Gold Peak Tea" },
                    { 10, true, "Core Power Milk Shake" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRole",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Cook" },
                    { 3, "Driver" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "AccountId", "FireDate", "HireDate", "IsActive", "RoleId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, null, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { 3, null, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "ItemId", "DipId", "DrinkId", "OrderId", "OtherFoodId", "PizzaId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2a3be73c-f051-4662-ac1a-51d114946234"), 0, 0, 2, 0, 2, 3 },
                    { new Guid("3239cf3e-aa1d-407a-833d-a157827e738d"), 0, 3, 2, 0, 0, 6 },
                    { new Guid("337499ed-9855-46a8-97cc-99e4f4f8e789"), 0, 1, 1, 0, 0, 3 },
                    { new Guid("463cd4eb-1375-45b8-b421-5d775eb1a820"), 0, 0, 1, 0, 1, 1 },
                    { new Guid("6632b3de-1bbd-4529-8ba1-c8b24ccd72dc"), 0, 0, 2, 0, 3, 1 },
                    { new Guid("8512aa11-1ff0-4297-8aa5-8f1a2b25da99"), 0, 0, 2, 0, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderPizzas",
                columns: new[] { "PizzaId", "IsPreset", "IsWellDone", "OrderId", "PizzaSize", "PresetId" },
                values: new object[,]
                {
                    { 1, true, false, 1, 1, 5 },
                    { 2, false, false, 2, 2, 0 },
                    { 3, false, true, 2, 4, 0 },
                    { 4, true, true, 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderToppings",
                columns: new[] { "EntryId", "PizzaId", "ToppingId" },
                values: new object[,]
                {
                    { new Guid("051516e8-df82-48c8-b58a-50646b89f17e"), 2, 8 },
                    { new Guid("25950908-c580-4fa9-86cf-6242a080e93b"), 2, 19 },
                    { new Guid("32aa16ec-fae3-4a07-b8c7-4c72b620809f"), 2, 26 },
                    { new Guid("382bca47-ccd4-4526-be37-3b23a634385f"), 3, 6 },
                    { new Guid("6dfe1ebe-16b5-4f74-89f9-b14c58c4c722"), 3, 13 },
                    { new Guid("87c77d89-c39f-42c9-a493-eca8d9f03ab0"), 3, 17 },
                    { new Guid("c1d3bfe1-b721-4406-ad58-e37e1b90b035"), 3, 24 },
                    { new Guid("d5fe8118-0835-4a4c-9116-a3e68a88c676"), 2, 21 },
                    { new Guid("e8e16cd8-732f-4aed-9b45-450101de19eb"), 2, 3 },
                    { new Guid("ec3150e8-6956-4dfb-9461-4ef3e39a4001"), 3, 16 },
                    { new Guid("f1e491b9-ecb2-4bb6-b750-44e1360c904f"), 2, 14 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AddressId", "CustomerId", "InOven", "IsDelivered", "IsOnRoute", "StatusMessage", "Timestamp", "Total" },
                values: new object[,]
                {
                    { 1, new Guid("a3144809-7c8f-4ed8-bcf7-527f68fc0a95"), 4, false, true, false, "Order delivered on 2022-03-18", new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.949999999999999 },
                    { 2, new Guid("a3144809-7c8f-4ed8-bcf7-527f68fc0a95"), 4, true, false, false, "Order in oven", new DateTime(2022, 4, 19, 19, 43, 29, 99, DateTimeKind.Local).AddTicks(5072), 208.49000000000001 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "AccountId", "EmailAddress", "FirstName", "IsCustomer", "LastName", "PhoneNumber", "PwdHash" },
                values: new object[,]
                {
                    { 1, "manager@test.com", "Stephen", false, "Davis", "647-787-4877", "4AFD6013F1C4F90FCE7E3D29D91BB1F70D10DACFA75FE856FD3494F7CF823133" },
                    { 2, "cook@test.com", "Sandra", false, "Rutkowski", "416-555-7310", "4AFD6013F1C4F90FCE7E3D29D91BB1F70D10DACFA75FE856FD3494F7CF823133" },
                    { 3, "driver@test.com", "Roger", false, "Lee", "647-555-2356", "4AFD6013F1C4F90FCE7E3D29D91BB1F70D10DACFA75FE856FD3494F7CF823133" },
                    { 4, "customer@test.com", "Laura", true, "Kittinger", "437-555-9721", "4AFD6013F1C4F90FCE7E3D29D91BB1F70D10DACFA75FE856FD3494F7CF823133" }
                });

            migrationBuilder.InsertData(
                table: "PresetPizzas",
                columns: new[] { "PresetId", "BasePrice", "Name" },
                values: new object[,]
                {
                    { 1, 19.5, "Special Deluxe" },
                    { 2, 18.0, "Hawaiian Pizza" },
                    { 3, 24.0, "Vegetarian Pizza" },
                    { 4, 25.5, "Greek Special" },
                    { 5, 21.0, "Meat Lovers" }
                });

            migrationBuilder.InsertData(
                table: "PresetToppings",
                columns: new[] { "EntryId", "PresetId", "ToppingId" },
                values: new object[,]
                {
                    { new Guid("045210f6-c733-47b0-9eb4-135170c6834b"), 5, 6 },
                    { new Guid("070b4725-da44-4a24-9145-e615579325ea"), 3, 18 },
                    { new Guid("0b427e11-e53a-4413-af11-093c6178b112"), 5, 12 },
                    { new Guid("31f67151-e972-43dc-81e4-4425acda1615"), 4, 3 },
                    { new Guid("3b5573c0-5f2e-491e-bdf5-8dad5e7242d6"), 3, 22 },
                    { new Guid("4290a837-f5ee-4018-a09d-0721287dcecb"), 4, 17 },
                    { new Guid("549b265d-4346-4326-b0b2-d7e691228e84"), 1, 19 },
                    { new Guid("5959986f-d29e-4736-bf29-cc3891231ec5"), 4, 22 },
                    { new Guid("5a2d4176-0417-4f50-b9bb-e7bbd844d107"), 3, 19 },
                    { new Guid("5d5c268d-816a-4440-8f0b-0a2957d0bd77"), 5, 7 },
                    { new Guid("69772fd6-7885-4b6d-a6d0-3ba54fc17ad2"), 3, 26 },
                    { new Guid("6d4505c0-3c38-44ea-b469-fb7734923af8"), 4, 26 },
                    { new Guid("9f1760d4-bc81-4d01-a331-e31ff92b617e"), 1, 21 },
                    { new Guid("b4738f90-8cd3-4757-9637-1e60b0148478"), 4, 12 },
                    { new Guid("bbb953d7-4b8b-4d28-b0b6-81f7e5531dfe"), 3, 21 },
                    { new Guid("bcc33140-2722-4910-852a-9b17cc11b0ae"), 3, 14 },
                    { new Guid("e1d403c7-3c15-4657-8bbb-d1ab81e5d66a"), 4, 14 },
                    { new Guid("e49badd4-2197-4949-9e8b-1d6a30a26350"), 2, 11 },
                    { new Guid("ec3a9b86-d359-48a0-84f5-30308304cd46"), 2, 23 },
                    { new Guid("f0259366-3014-412a-8074-7f95b1d6068b"), 5, 8 },
                    { new Guid("f280d0e1-90ce-4c8f-95ac-1c66c28dec6f"), 4, 18 },
                    { new Guid("f9f27b47-dce4-4040-9801-22748164f475"), 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "ToppingCategories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Cheese" },
                    { 2, "Meat" },
                    { 3, "Vegetables" }
                });

            migrationBuilder.InsertData(
                table: "ToppingList",
                columns: new[] { "ToppingId", "CategoryId", "IsPremium", "Name" },
                values: new object[,]
                {
                    { 1, 1, true, "Asiago Cheese" },
                    { 2, 1, true, "Cheddar Cheese" },
                    { 3, 1, true, "Feta Cheese" },
                    { 4, 1, true, "Goat Cheese" },
                    { 5, 1, true, "Parmigiano Cheese" },
                    { 6, 2, false, "Pepperoni" }
                });

            migrationBuilder.InsertData(
                table: "ToppingList",
                columns: new[] { "ToppingId", "CategoryId", "IsPremium", "Name" },
                values: new object[,]
                {
                    { 7, 2, true, "Bacon" },
                    { 8, 2, false, "Spicy Sausage" },
                    { 9, 2, true, "Grilled Chicken" },
                    { 10, 2, true, "Anchovies" },
                    { 11, 2, false, "Smoked Ham" },
                    { 12, 2, false, "Ground Beef" },
                    { 13, 3, true, "Artichokes" },
                    { 14, 3, false, "Black Olives" },
                    { 15, 3, false, "Broccoli" },
                    { 16, 3, true, "Bruschetta" },
                    { 17, 3, false, "Roasted Garlic" },
                    { 18, 3, false, "Green Olives" },
                    { 19, 3, false, "Green Peppers" },
                    { 20, 3, false, "Hot Peppers" },
                    { 21, 3, false, "Mushrooms" },
                    { 22, 3, false, "Onions" },
                    { 23, 3, false, "Pineapple" },
                    { 24, 3, true, "Red Peppers" },
                    { 25, 3, true, "Spinach" },
                    { 26, 3, false, "Tomatoes" },
                    { 27, 3, true, "Zucchini" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DrinkList");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderPizzas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderToppings");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PresetPizzas");

            migrationBuilder.DropTable(
                name: "PresetToppings");

            migrationBuilder.DropTable(
                name: "ToppingCategories");

            migrationBuilder.DropTable(
                name: "ToppingList");
        }
    }
}
