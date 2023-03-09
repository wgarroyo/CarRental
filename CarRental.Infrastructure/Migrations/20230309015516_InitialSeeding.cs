using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeeding : Migration
    {
        private const string _vehicleTypesTable = "VehicleTypes";
        private readonly static string[] _vehicleTypesIds = new[] {
            "EAB8AA26-C448-460F-AE9F-AAC0501DF829",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF830",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF831"
        };
        private const string _vehicleBrandsTable = "VehicleBrands";
        private readonly static string[] _vehicleBrandsIds = new[] {
            "EAB8AA26-C448-460F-AE9F-AAC0501DF832",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF833",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF834"
        };
        private const string _vehiclesTable = "Vehicles";
        private readonly static string[] _vehiclesIds = new[] {
            "EAB8AA26-C448-460F-AE9F-AAC0501DF835",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF836",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF837"
        };
        private const string _clientsTable = "Clients";
        private readonly static string[] _clientsIds = new[] {
            "EAB8AA26-C448-460F-AE9F-AAC0501DF838",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF839",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF840"
        };
        private const string _rentalsTable = "Rentals";
        private readonly static string[] _rentalsIds = new[] {
            "EAB8AA26-C448-460F-AE9F-AAC0501DF841",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF842",
            "EAB8AA26-C448-460F-AE9F-AAC0501DF843"
        };

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            InsertVehicleTypesData(migrationBuilder);
            InsertVehicleBrandsData(migrationBuilder);
            InsertVehiclesData(migrationBuilder);
            InsertClientsData(migrationBuilder);
            InsertRentalsData(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            RemoveVehicleTypesData(migrationBuilder);
            RemoveVehicleBrandsData(migrationBuilder);
            RemoveVehiclesData(migrationBuilder);
            RemoveClientsData(migrationBuilder);
            RemoveRentalsData(migrationBuilder);
        }


        private static void InsertVehicleTypesData(MigrationBuilder migrationBuilder)
        {
            string[] columns = new[] { "Id", "Description" };
            migrationBuilder.InsertData(
                table: _vehicleTypesTable,
                columns: columns,
                values: new object[] { _vehicleTypesIds[0], "Truck" });

            migrationBuilder.InsertData(
                table: _vehicleTypesTable,
                columns: columns,
                values: new object[] { _vehicleTypesIds[1], "Car" });

            migrationBuilder.InsertData(
                table: _vehicleTypesTable,
                columns: columns,
                values: new object[] { _vehicleTypesIds[2], "Bus" });
        }

        private static void InsertVehicleBrandsData(MigrationBuilder migrationBuilder)
        {
            string[] fields = new[] { "Id", "Description" };
            migrationBuilder.InsertData(
                table: _vehicleBrandsTable,
                columns: fields,
                values: new object[] { _vehicleBrandsIds[0], "Fiat" });

            migrationBuilder.InsertData(
                table: _vehicleBrandsTable,
                columns: fields,
                values: new object[] { _vehicleBrandsIds[1], "Mercedes Benz" });

            migrationBuilder.InsertData(
                table: _vehicleBrandsTable,
                columns: fields,
                values: new object[] { _vehicleBrandsIds[2], "Ford" });
        }

        private static void InsertVehiclesData(MigrationBuilder migrationBuilder)
        {
            string[] fields = new[] {
                    "Id",
                    "VehicleTypeId",
                    "VehicleBrandId",
                    "Description",
                    "WheelsNumber",
                    "Vin",
                    "Price" };

            migrationBuilder.InsertData(
                table: _vehiclesTable,
                columns: fields,
                values: new object[] {
                    _vehiclesIds[0],
                    _vehicleTypesIds[1],
                    _vehicleBrandsIds[2],
                    "Focus",
                    4u,
                    "LNM 369",
                    1500M});

            migrationBuilder.InsertData(
                table: _vehiclesTable,
                columns: fields,
                values: new object[] {
                    _vehiclesIds[1],
                    _vehicleTypesIds[1],
                    _vehicleBrandsIds[1],
                    "A5",
                    4u,
                    "ZKU 127",
                    13420.51M});

            migrationBuilder.InsertData(
                table: _vehiclesTable,
                columns: fields,
                values: new object[] {
                    _vehiclesIds[2],
                    _vehicleTypesIds[0],
                    _vehicleBrandsIds[2],
                    "4000",
                    6u,
                    "MNU 315",
                    25420.70M});
        }

        private static void InsertClientsData(MigrationBuilder migrationBuilder)
        {
            string[] fields = new[] {
                    "Id",
                    "Name",
                    "MiddleName",
                    "LastName",
                    "SocialNumberId"};

            migrationBuilder.InsertData(
                table: _clientsTable,
                columns: fields,
                values: new object[] {
                    _clientsIds[0],
                    "Rodrigo",
                    "Manuel",
                    "Perez",
                    "A6953636"});

            migrationBuilder.InsertData(
                table: _clientsTable,
                columns: fields,
                values: new object[] {
                    _clientsIds[1],
                    "Emmanuel",
                    "Albert",
                    "Curtz",
                    "ZR8569632585"});

            migrationBuilder.InsertData(
                table: _clientsTable,
                columns: fields,
                values: new object[] {
                    _clientsIds[2],
                    "Sammuel",
                    "Frank",
                    "Evrt",
                    "33659635"});
        }

        private static void InsertRentalsData(MigrationBuilder migrationBuilder)
        {
            string[] fields = new[] {
                    "Id",
                    "VehicleId",
                    "ClientId",
                    "Price",
                    "From",
                    "To",
                    "CreatedDateTime",
                    "UpdatedDateTime"
            };

            migrationBuilder.InsertData(
                table: _rentalsTable,
                columns: fields,
                values: new object[] {
                    _rentalsIds[0],
                    _vehiclesIds[0],
                    _clientsIds[0],
                    1500M,
                    DateTime.Now,
                    DateTime.Now.AddDays(1),
                    DateTime.Now,
                    DateTime.Now});

            migrationBuilder.InsertData(
                table: _rentalsTable,
                columns: fields,
                values: new object[] {
                    _rentalsIds[1],
                    _vehiclesIds[1],
                    _clientsIds[1],
                    13420.51M,
                    DateTime.Now,
                    DateTime.Now.AddDays(1),
                    DateTime.Now,
                    DateTime.Now});

            migrationBuilder.InsertData(
                table: _rentalsTable,
                columns: fields,
                values: new object[] {
                    _rentalsIds[2],
                    _vehiclesIds[2],
                    _clientsIds[2],
                    25420.70M,
                    DateTime.Now,
                    DateTime.Now.AddDays(1),
                    DateTime.Now,
                    DateTime.Now});
        }

        private static void RemoveVehicleTypesData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(_vehicleTypesTable, "Id", new object[] {
                _vehicleTypesIds[0],
                _vehicleTypesIds[1],
                _vehicleTypesIds[2]});
        }

        private static void RemoveVehicleBrandsData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(_vehicleBrandsTable, "Id", new object[] {
                _vehicleBrandsIds[0],
                _vehicleBrandsIds[1],
                _vehicleBrandsIds[2]});
        }

        private static void RemoveVehiclesData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(_vehiclesTable, "Id", new object[] {
                _vehiclesIds[0],
                _vehiclesIds[1],
                _vehiclesIds[2]});
        }

        private static void RemoveClientsData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(_clientsTable, "Id", new object[] {
                _clientsIds[0],
                _clientsIds[1],
                _clientsIds[2]});
        }

        private static void RemoveRentalsData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(_rentalsTable, "Id", new object[] {
                _rentalsIds[0],
                _rentalsIds[1],
                _rentalsIds[2]});
        }

    }
}