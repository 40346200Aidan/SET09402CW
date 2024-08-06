using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModel;
using Haulage.AdminPages;
using Haulage.BaseClasses.BillingHandler;
using Haulage.BillviewModel;


namespace HaulageTests
{
    [CollectionDefinition("databaseTests", DisableParallelization = true)]
    /// <summary>
    /// 
    /// </summary>
    public class VehicleTest
    {
        [Fact]
        public void GetVehiclesFromDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);
            var vehicles = VehicleExecutionService.GetVehicles();
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0, "Did not recieve any records from GetVehicles method");
        }

        [Fact]
        public void DeleteVehicleFromDatabse()
        {

            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);
            var vehicles = VehicleExecutionService.GetVehicles();

            var vehicleToRemove = vehicles.First();
            var initialVehicleCount = vehicles.Count;
            VehicleExecutionService.DeleteVehicle(vehicleToRemove.VehicleId);
            var vehicleCountAfter = VehicleExecutionService.GetVehicles().Count;
            Assert.True(vehicleCountAfter == initialVehicleCount - 1, "Failed to delete a vehicle record");
        }

        [Fact]
        public void SaveVehicleToDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);
            var vehiclesCountBefore = VehicleExecutionService.GetVehicles().Count;
            System.Threading.Thread.Sleep(150);
            Vehicle vehicle = new Vehicle()
            {
                VehicleId = 132321,
                tripID = 4321321,
                Capacity = 123321,
                DriverId = 321213,
                LicensePlate = "ASD23HF",
                Status = Vehicle.StatusType.onroute
            };
            VehicleExecutionService.SaveVehicle(vehicle);
            System.Threading.Thread.Sleep(150);
            var vehiclesCountAfter = VehicleExecutionService.GetVehicles().Count;
            Assert.True(vehiclesCountAfter == vehiclesCountBefore + 1, "VehiclesRecord was not saved");
        }
        [Fact]
        public void GetVehicleViewModel()
        {
            DatabaseSetup.InitializeDatabase();

            var model = new VehicleViewModel();
            Assert.NotNull(model);
            Assert.True(model.Vehicles.Count > 0);
        }

        [Fact]
        public void GetDriversFromDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);
            //Act
            var drivers = DriverExecutionService.GetDrivers();
            System.Threading.Thread.Sleep(150);
            //Assert
            Assert.NotNull(drivers);
            Assert.True(drivers.Count > 0, "Did not recieve any records from GetDrivers method");
        }

        [Fact]

        public void DeleteDriversFromDatabse()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);
            //Act
            var drivers = DriverExecutionService.GetDrivers();
            System.Threading.Thread.Sleep(150);

            var driverToRemove = drivers.First();
            var initialDriverCount = drivers.Count;

            DriverExecutionService.DeleteDriver(driverToRemove.UserId);
            System.Threading.Thread.Sleep(150);

            var DriverCountAfter = DriverExecutionService.GetDrivers().Count;
            System.Threading.Thread.Sleep(150);

            //Assert
            Assert.True(DriverCountAfter == initialDriverCount - 1, "Failed to delete a employee record");
        }

        [Fact]

        public void SaveDriverInDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);

            //Act
            var drivers = DriverExecutionService.GetDrivers();
            var aNewDriver = new Driver(123456, "Aidan Gallagher", "aidan.gallagher@gmail.com", "12345 239387", Role.driver, "21 Test street", "fragile");
            var initialDriverCount = drivers.Count;
            DriverExecutionService.SaveDriver(aNewDriver);
            var DriverCountAfter = DriverExecutionService.GetDrivers().Count;

            //Assert
            Assert.True(DriverCountAfter == initialDriverCount + 1, "Saved employee record successfully");

        }

        [Fact]
        public void GetBillViewModel()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();

            //Act
            var model = new BillViewModel();

            //Assert
            Assert.NotNull(model);
            Assert.True(model.Bills.Count > 0);
        }

        [Fact]
        public void GetBillsFromDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();

            //Act
            var bills = BillExecutionService.GetBills();

            //Assert
            Assert.NotNull(bills);
            Assert.True(bills.Count > 0, "Did not recieve any records from GetBills method");
        }

        [Fact]

        public void DeleteBillsFromDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);

            //Act
            var bills = BillExecutionService.GetBills();
            var billsToRemove = bills.First();
            var initialBillCount = bills.Count;
            BillExecutionService.DeleteBill(billsToRemove.BillId);
            System.Threading.Thread.Sleep(150);
            var BillCountAfter = BillExecutionService.GetBills().Count;
            System.Threading.Thread.Sleep(150);

            //Assert
            Assert.True(BillCountAfter == initialBillCount - 1, "Failed to delete a bill record");
        }

        [Fact]

        public void SaveBillInDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();
            System.Threading.Thread.Sleep(1000);

            //Act
            var bills = BillExecutionService.GetBills();
            var aNewBill = new Billing(123456, "Aidan Gallagher", "aidan.gallagher@gmail.com", "Brake Pads", "Brake pads for test vehicle", 80.00);
            var initialBillCount = bills.Count;
            BillExecutionService.SaveBill(aNewBill);
            var BillCountAfter = BillExecutionService.GetBills().Count;

            //Assert
            Assert.True(BillCountAfter == initialBillCount + 1, "Saved bill record successfully");

        }

    }
}
