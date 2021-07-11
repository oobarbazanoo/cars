using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearModel = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Licensed = table.Column<bool>(type: "bit", nullable: false),
                    Added = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => new { x.WarehouseId, x.Id });
                    table.ForeignKey(
                        name: "FK_Cars_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Lat", "Location", "Long", "Name" },
                values: new object[,]
                {
                    { 1, 47.13111, "West wing", -61.548009999999998, "Warehouse A" },
                    { 2, 15.953860000000001, "East wing", 7.0624599999999997, "Warehouse B" },
                    { 3, 39.127879999999998, "Suid wing", -2.7139799999999998, "Warehouse C" },
                    { 4, -70.843540000000004, "Suid wing", 132.22345000000001, "Warehouse D" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "WarehouseId", "Added", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2018, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Volkswagen", "Jetta III", 12947.52m, 1995 },
                    { 58, 3, new DateTimeOffset(new DateTime(2018, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Mercedes-Benz", "500E", 17141.08m, 1992 },
                    { 57, 3, new DateTimeOffset(new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Infiniti", "Q", 28773.14m, 1996 },
                    { 56, 3, new DateTimeOffset(new DateTime(2017, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Honda", "del Sol", 18840.96m, 1994 },
                    { 55, 3, new DateTimeOffset(new DateTime(2017, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Volvo", "850", 25762.08m, 1995 },
                    { 54, 3, new DateTimeOffset(new DateTime(2018, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Mitsubishi", "RVR", 22560.18m, 1995 },
                    { 53, 3, new DateTimeOffset(new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Mercedes-Benz", "SL-Class", 14066.06m, 2005 },
                    { 52, 3, new DateTimeOffset(new DateTime(2017, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Porsche", "Cayenne", 17066.31m, 2011 },
                    { 59, 3, new DateTimeOffset(new DateTime(2018, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "GMC", "Envoy XL", 18983.52m, 2002 },
                    { 51, 3, new DateTimeOffset(new DateTime(2018, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Cadillac", "Escalade", 7429.18m, 2005 },
                    { 49, 2, new DateTimeOffset(new DateTime(2018, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Saab", "9-7X", 25975.68m, 2005 },
                    { 48, 2, new DateTimeOffset(new DateTime(2018, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Suzuki", "Forenza", 28834.26m, 2005 },
                    { 47, 2, new DateTimeOffset(new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Land Rover", "Freelander", 21770.59m, 2004 },
                    { 46, 2, new DateTimeOffset(new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Cadillac", "SRX", 26750.38m, 2004 },
                    { 45, 2, new DateTimeOffset(new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Pontiac", "Sunfire", 28489.1m, 1997 },
                    { 44, 2, new DateTimeOffset(new DateTime(2018, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Cadillac", "STS", 13740.2m, 2007 },
                    { 43, 2, new DateTimeOffset(new DateTime(2018, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Jaguar", "XK", 10260.79m, 2006 },
                    { 50, 2, new DateTimeOffset(new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Ford", "Fusion", 28091.96m, 2012 },
                    { 42, 2, new DateTimeOffset(new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Infiniti", "FX", 22000.62m, 2012 },
                    { 60, 3, new DateTimeOffset(new DateTime(2018, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Volkswagen", "Touareg 2", 15611.22m, 2008 },
                    { 62, 4, new DateTimeOffset(new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Mazda", "B-Series", 23407.59m, 1998 },
                    { 78, 4, new DateTimeOffset(new DateTime(2018, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Pontiac", "Montana", 11221.14m, 2000 },
                    { 77, 4, new DateTimeOffset(new DateTime(2018, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Volvo", "S60", 28614.95m, 2009 },
                    { 76, 4, new DateTimeOffset(new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "GMC", "Envoy XUV", 20997.71m, 2004 },
                    { 75, 4, new DateTimeOffset(new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Buick", "Skyhawk", 10567.27m, 1985 },
                    { 74, 4, new DateTimeOffset(new DateTime(2018, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Volvo", "XC90", 29009.65m, 2003 },
                    { 73, 4, new DateTimeOffset(new DateTime(2017, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Subaru", "Legacy", 24491.8m, 2010 },
                    { 72, 4, new DateTimeOffset(new DateTime(2017, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Porsche", "944", 7396.95m, 1984 },
                    { 61, 4, new DateTimeOffset(new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Saab", "900", 8771m, 1987 },
                    { 71, 4, new DateTimeOffset(new DateTime(2017, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Chrysler", "LHS", 29444.71m, 2001 },
                    { 69, 4, new DateTimeOffset(new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Land Rover", "Discovery Series II", 18620.19m, 2001 },
                    { 68, 4, new DateTimeOffset(new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Dodge", "Ram 1500 Club", 14008.3m, 1996 },
                    { 67, 4, new DateTimeOffset(new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Bugatti", "Veyron", 8051.64m, 2009 },
                    { 66, 4, new DateTimeOffset(new DateTime(2018, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "GMC", "Sonoma", 18248.21m, 2004 },
                    { 65, 4, new DateTimeOffset(new DateTime(2018, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Toyota", "Tacoma", 11597.18m, 1997 },
                    { 64, 4, new DateTimeOffset(new DateTime(2018, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Chevrolet", "Corvette", 16630.67m, 1964 },
                    { 63, 4, new DateTimeOffset(new DateTime(2018, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "GMC", "Sierra 3500", 5869.23m, 2012 },
                    { 70, 4, new DateTimeOffset(new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Volvo", "960", 7316.93m, 1993 },
                    { 41, 2, new DateTimeOffset(new DateTime(2018, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Pontiac", "Grand Prix", 11600.74m, 1975 },
                    { 40, 2, new DateTimeOffset(new DateTime(2018, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Volkswagen", "Jetta", 25469.49m, 2006 },
                    { 39, 2, new DateTimeOffset(new DateTime(2018, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Mercedes-Benz", "CL-Class", 23494.78m, 2002 },
                    { 17, 1, new DateTimeOffset(new DateTime(2017, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Dodge", "Caravan", 16145.27m, 1995 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "WarehouseId", "Added", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[,]
                {
                    { 16, 1, new DateTimeOffset(new DateTime(2018, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Dodge", "Ram Van 3500", 6244.51m, 1999 },
                    { 15, 1, new DateTimeOffset(new DateTime(2017, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Lexus", "GX", 27395.26m, 2005 },
                    { 14, 1, new DateTimeOffset(new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Ford", "Econoline E250", 26605.54m, 1994 },
                    { 13, 1, new DateTimeOffset(new DateTime(2018, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Acura", "NSX", 23175.76m, 2001 },
                    { 12, 1, new DateTimeOffset(new DateTime(2018, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Cadillac", "DeVille", 18371.53m, 1993 },
                    { 11, 1, new DateTimeOffset(new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Chevrolet", "G-Series 1500", 23362.41m, 1997 },
                    { 18, 1, new DateTimeOffset(new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Dodge", "Dynasty", 15103.84m, 1992 },
                    { 10, 1, new DateTimeOffset(new DateTime(2018, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Ford", "Mustang", 18992.7m, 1993 },
                    { 8, 1, new DateTimeOffset(new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Mitsubishi", "Pajero", 28619.45m, 2002 },
                    { 7, 1, new DateTimeOffset(new DateTime(2018, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Cadillac", "Escalade ESV", 24925.75m, 2008 },
                    { 6, 1, new DateTimeOffset(new DateTime(2018, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Plymouth", "Colt Vista", 6642.45m, 1994 },
                    { 5, 1, new DateTimeOffset(new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "GMC", "Safari", 14772.5m, 1998 },
                    { 4, 1, new DateTimeOffset(new DateTime(2018, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Infiniti", "FX", 8541.62m, 2010 },
                    { 3, 1, new DateTimeOffset(new DateTime(2018, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Ford", "Expedition EL", 27323.42m, 2008 },
                    { 2, 1, new DateTimeOffset(new DateTime(2018, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Chevrolet", "Corvette", 20019.64m, 2004 },
                    { 9, 1, new DateTimeOffset(new DateTime(2017, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Infiniti", "Q", 6103.4m, 1995 },
                    { 19, 1, new DateTimeOffset(new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Dodge", "Ram 1500", 9977.65m, 2004 },
                    { 20, 2, new DateTimeOffset(new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Maserati", "Coupe", 19957.71m, 2005 },
                    { 21, 2, new DateTimeOffset(new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Isuzu", "Rodeo", 6303.99m, 1998 },
                    { 38, 2, new DateTimeOffset(new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Honda", "Civic Si", 18569.86m, 2003 },
                    { 37, 2, new DateTimeOffset(new DateTime(2018, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Mercedes-Benz", "SL-Class", 27717.28m, 1994 },
                    { 36, 2, new DateTimeOffset(new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Chevrolet", "Blazer", 14835.48m, 1994 },
                    { 35, 2, new DateTimeOffset(new DateTime(2018, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Kia", "Sportage", 27106.47m, 2001 },
                    { 34, 2, new DateTimeOffset(new DateTime(2018, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Mercury", "Grand Marquis", 20614.72m, 1996 },
                    { 33, 2, new DateTimeOffset(new DateTime(2017, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Dodge", "Dakota", 14479.37m, 2009 },
                    { 32, 2, new DateTimeOffset(new DateTime(2018, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "GMC", "3500 Club Coupe", 18129.37m, 1992 },
                    { 31, 2, new DateTimeOffset(new DateTime(2018, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Mitsubishi", "Chariot", 15665.23m, 1987 },
                    { 30, 2, new DateTimeOffset(new DateTime(2017, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, "Acura", "RL", 13232.13m, 2010 },
                    { 29, 2, new DateTimeOffset(new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Nissan", "Murano", 25859.78m, 2005 },
                    { 28, 2, new DateTimeOffset(new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Audi", "A8", 16047.9m, 1999 },
                    { 27, 2, new DateTimeOffset(new DateTime(2018, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Nissan", "Maxima", 11187.68m, 2004 },
                    { 26, 2, new DateTimeOffset(new DateTime(2017, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "BMW", "7 Series", 29069.52m, 1998 },
                    { 25, 2, new DateTimeOffset(new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Acura", "MDX", 8487.19m, 2011 },
                    { 24, 2, new DateTimeOffset(new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), false, "Toyota", "Corolla", 23732.11m, 2009 },
                    { 23, 2, new DateTimeOffset(new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Nissan", "Altima", 8252.66m, 1994 },
                    { 22, 2, new DateTimeOffset(new DateTime(2017, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Infiniti", "I", 6910.16m, 2002 },
                    { 79, 4, new DateTimeOffset(new DateTime(2018, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Lexus", "RX", 23194.01m, 2002 },
                    { 80, 4, new DateTimeOffset(new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), false, "Lexus", "RX", 17805.45m, 2000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
