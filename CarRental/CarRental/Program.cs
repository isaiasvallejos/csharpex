using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Main {

    class Program {

        static void Main(string[] args) {

            bool running = true;
            string option;

            do {

                Console.Clear();

                Console.WriteLine("***** CAR RENTAL *****");
                Console.Write("\n");
                Console.WriteLine("1 - Register vehicle");
                Console.WriteLine("2 - Register user");
                Console.WriteLine("3 - Register driver");
                Console.WriteLine("4 - Create trip");
                Console.WriteLine("5 - Consult trip");
                Console.WriteLine("6 - Exit");
                Console.Write("\n");
                Console.Write("Choose an option: ");

                option = Console.ReadLine();

                switch (option) {

                    case "1":

                        Console.Clear();

                        Console.WriteLine("***** REGISTER VEHICLE *****");
                        Console.Write("\n");

                        Console.Write("Vehicle: (brand) ");
                        string vehicleBrand = Console.ReadLine();

                        Console.Write("Vehicle: (board) ");
                        string vehicleBoard = Console.ReadLine();

                        if (DAO.Vehicle.SelectOneByProperty("board", vehicleBoard) != null) {
                            Console.WriteLine("\nVehicle board already registred.");
                            break;
                        }

                        Vehicle vehicle = new Vehicle(vehicleBrand, vehicleBoard);

                        DAO.Vehicle.Add(vehicle);

                        Console.WriteLine("\nVehicle #{0} registered successfully!", vehicle.id);

                        break;

                    case "2":

                        Console.Clear();

                        Console.WriteLine("***** REGISTER USER *****");
                        Console.Write("\n");

                        Console.Write("User: (name) ");
                        string userName = Console.ReadLine();

                        Console.Write("User: (document) ");
                        string userDocument = Console.ReadLine();

                        if (DAO.User.SelectOneByProperty("document", userDocument) != null) {
                            Console.WriteLine("\nUser document already registred.");
                            break;
                        }

                        User user = new User(userName, userDocument);

                        DAO.User.Add(user);

                        Console.WriteLine("\nUser #{0} registered successfully!", user.id);

                        break;

                    case "3":

                        Console.Clear();

                        Console.WriteLine("***** REGISTER DRIVER *****");
                        Console.Write("\n");

                        Console.Write("Driver: (name) ");
                        string driverName = Console.ReadLine();

                        Console.Write("Driver: (document) ");
                        string driverDocument = Console.ReadLine();

                        if (DAO.Driver.SelectOneByProperty("document", driverDocument) != null) {
                            Console.WriteLine("\nDriver document already registred.");
                            break;
                        }

                        Console.Write("Driver: (license) ");
                        string driverLicense = Console.ReadLine();

                        if (DAO.Driver.SelectOneByProperty("license", driverLicense) != null) {
                            Console.WriteLine("\nDriver license already registred.");
                            break;
                        }

                        Driver driver = new Driver(driverName, driverDocument, driverLicense);

                        DAO.Driver.Add(driver);

                        Console.WriteLine("\nDriver #{0} registered successfully!", driver.id);

                        break;

                    case "4":

                        Console.Clear();

                        Console.WriteLine("***** CREATE TRIP *****");
                        Console.Write("\n");

                        if (DAO.User.isEmpty() || DAO.Driver.isEmpty() || DAO.Vehicle.isEmpty()) {
                            Console.WriteLine("Trip needs a user, driver and vehicle.");

                            break;
                        }

                        Console.Write("Trip: (start) ");
                        string tripStart = Console.ReadLine();

                        Console.Write("Trip: (finish) ");
                        string tripFinish = Console.ReadLine();

                        Console.Write("Trip: (date) ");
                        string tripDateUnformatted = Console.ReadLine();

                        string[] tripDateArray = tripDateUnformatted.Split('/');

                        DateTime tripDate;

                        try {

                            tripDate = new DateTime(int.Parse(tripDateArray[2]), int.Parse(tripDateArray[0]), int.Parse(tripDateArray[1])).Date;

                        } catch (Exception e) {

                            Console.WriteLine("\nTrip date is invalid.");
                            break;

                        }

                        Console.Write("Trip: (vehicle board) ");
                        Vehicle tripVehicle = DAO.Vehicle.SelectOneByProperty("board", Console.ReadLine());

                        if (tripVehicle == null) {
                            Console.WriteLine("\nVehicle not found.");
                            break;
                        }

                        Console.Write("Trip: (driver document) ");
                        Driver tripDriver = DAO.Driver.SelectOneByProperty("document", Console.ReadLine());

                        if (tripVehicle == null) {
                            Console.WriteLine("\nDriver not found.");
                            break;
                        }

                        Console.Write("\n");
                        Console.WriteLine("Trip: (users) ");
                        Console.Write("\n");

                        bool done = false;
                        List<TripUser> tripUsers = new List<TripUser>();

                        do {

                            Console.Write("(document) ");
                            User tripUser = DAO.User.SelectOneByProperty("document", Console.ReadLine());

                            if (tripUser == null) {

                                Console.WriteLine("\nUser not found.");

                            } else {

                                bool tripUserHasBaggage;

                                Console.Write("(has baggage?) [Y/*] ");

                                if (Console.ReadLine() == "Y") {
                                    tripUserHasBaggage = true;
                                } else {
                                    tripUserHasBaggage = false;
                                }

                                tripUsers.Add(new TripUser(tripUser, tripUserHasBaggage));

                            }

                            Console.Write("\n");

                            Console.Write("Continue? [Y/*] ");

                            if(Console.ReadLine() != "Y") {
                                done = true;
                            }

                            Console.Write("\n");

                        } while (!done);

                        Trip trip = new Trip(tripStart, tripFinish, tripDate, tripVehicle, tripDriver, tripUsers);

                        DAO.Trip.Add(trip);

                        Console.WriteLine("Trip #{0} registered successfully!", trip.id);

                        break;

                    case "5":

                        Console.Clear();

                        Console.WriteLine("***** CONSULT TRIP *****");
                        Console.Write("\n");

                        if (DAO.Trip.isEmpty()) {
                            Console.WriteLine("No registered trips.");

                            break;
                        }

                        Console.Write("Trip: (id) ");
                        Trip tripConsulted = DAO.Trip.SelectOneById(int.Parse(Console.ReadLine()));

                        Console.Write("\n");

                        Console.WriteLine("(start) {0}", tripConsulted.start);
                        Console.WriteLine("(finish) {0}", tripConsulted.finish);
                        Console.WriteLine("(date) {0}", tripConsulted.date.ToString("dd/MM/yyyy"));
                        Console.WriteLine("(vehicle brand) {0}", tripConsulted.vehicle.brand);
                        Console.WriteLine("(vehicle board) {0}", tripConsulted.vehicle.board);
                        Console.WriteLine("(driver name) {0}", tripConsulted.driver.name);
                        Console.WriteLine("(driver document) {0}", tripConsulted.driver.document);

                        Console.Write("\n");
                        Console.WriteLine("(users) ");
                        Console.Write("\n");

                        foreach (TripUser tripUser in tripConsulted.users) {

                            Console.WriteLine("(name) {0}", tripUser.user.name);
                            Console.WriteLine("(document) {0}", tripUser.user.document);
                            Console.WriteLine("(has baggage?) {0}", tripUser.hasBaggage ? "Y" : "N");

                            if (!tripConsulted.users.Last().Equals(tripUser)) {
                                Console.Write("\n");
                            }
                            
                        }

                        break;

                    case "6":

                        running = false;

                        Console.WriteLine("\nBye, bye!");

                        break;

                    default:

                        Console.Clear();

                        Console.WriteLine("***** ERROR *****");
                        Console.WriteLine("\nEnter a valid option.");

                        break;

                }

                if (running) {
                    Console.Write("\nPlease, press any key to back to menu.");
                }

                Console.ReadLine();

            } while (running);

        }

    }

}
