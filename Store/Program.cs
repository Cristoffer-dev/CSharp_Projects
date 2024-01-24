using System;

namespace MyStore_Montoya
{
    class Program
    {
        #region Stucts Declaration

        /// <summary>
        /// Represents an employee with an ID and password.
        /// </summary>
        struct Employee
        {
            public int Id;
            public string Password;

            /// <summary>
            /// Constructor for the Employee struct.
            /// </summary>
            /// <param name="id">The employee ID.</param>
            /// <param name="password">The employee password.</param>
            public Employee(int id, string password)
            {
                Id = id;
                Password = password;
            }
        }
        /// <summary>
        /// Represents a client with an ID, first name, last name, and password.
        /// </summary>
        public struct Client
        {
            public int Id;
            public string FirstName;
            public string LastName;
            public string Password;
            /// <summary>
            /// Constructor for the Client struct.
            /// </summary>
            /// <param name="id">The client ID.</param>
            /// <param name="firstName">The client's first name.</param>
            /// <param name="lastName">The client's last name.</param>
            /// <param name="password">The client password.</param>
            public Client(int id, string firstName, string lastName, string password)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Password = password;
            }
        }
        /// <summary>
        /// Represents a product with an ID, name, unit price, and available quantity.
        /// </summary>
        public struct Product
        {
            public int Id;
            public string Name;
            public double UnitPrice;
            public int QuantityAvailable;
            /// <summary>
            /// Constructor for the Product struct.
            /// </summary>
            /// <param name="id">The product ID.</param>
            /// <param name="name">The product name.</param>
            /// <param name="unitPrice">The unit price of the product.</param>
            /// <param name="quantityAvailable">The available quantity of the product.</param>
            public Product(int id, string name, double unitPrice, int quantityAvailable)
            {
                Id = id;
                Name = name;
                UnitPrice = unitPrice;
                QuantityAvailable = quantityAvailable;
            }
        }
        /// <summary>
        /// Represents a sale with a client, an array of products, subtotal, taxes, and total price.
        /// </summary>
        struct Sale
        {
            public Client Client;
            public Product[] Products;
            public double Subtotal;
            public double Taxes;
            public double TotalPrice;

        }
        /// <summary>
        /// Represents a purchase with a client, an array of products, subtotal, taxes, and total price.
        /// </summary>
        public struct Purchase
        {
            public Client Client;
            public Product[] Products;
            public double Subtotal;
            public double Taxes;
            public double TotalPrice;
            /// <summary>
            /// Constructor for the Purchase struct.
            /// </summary>
            /// <param name="client">The client making the purchase.</param>
            /// <param name="products">The array of products in the purchase.</param>
            /// <param name="subtotal">The subtotal of the purchase.</param>
            /// <param name="taxes">The taxes applied to the purchase.</param>
            /// <param name="totalPrice">The total price of the purchase.</param>
            public Purchase(Client client, Product[] products, double subtotal, double taxes, double totalPrice)
            {
                Client = client;
                Products = products;
                Subtotal = subtotal;
                Taxes = taxes;
                TotalPrice = totalPrice;
            }
        }
        #endregion
        #region Variables Declaration
        /// <summary>
        /// Represents the maximum number of clients allowed.
        /// </summary>
        const int MAXCLIENTS = 10;

        /// <summary>
        /// Represents the maximum number of products allowed.
        /// </summary>
        const int MAXPRODUCTS = 100;


        /// <summary>
        /// Array declaration for employees.
        /// </summary>
        static Employee[] employees = new Employee[1];
        /// <summary>
        /// Array declaration for clients.
        /// </summary>
        static Client[] clients = new Client[MAXCLIENTS];
        /// <summary>
        /// Array declaration for products.
        /// </summary>
        static Product[] products = new Product[MAXPRODUCTS];
        /// <summary>
        /// Array declaration for sales.
        /// </summary>
        static Sale[] sales = new Sale[MAXCLIENTS];

        #endregion
        #region Main Function

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            InitializeData();
            ShowRoleSelectionMenu();
        }

        #endregion
        #region Functions
        /// <summary>
        /// Initializes sample data for employees and clients.
        /// </summary>
        static void InitializeData()
        {
            // Initialize an employee
            employees[0] = new Employee
            {
                Id = 111111,
                Password = "tester"

            };
            // Initialize a client
            clients[0] = new Client
            {
                Id = 100000,
                FirstName = "Cris",
                LastName = "Montoya",
                Password = "client"
            };

            // Initialize 10 products with names
            products[0] = new Product { Id = 01, Name = "Laptop", UnitPrice = 899.99, QuantityAvailable = 15 };
            products[1] = new Product { Id = 02, Name = "Smartphone", UnitPrice = 599.99, QuantityAvailable = 20 };
            products[2] = new Product { Id = 03, Name = "Headphones", UnitPrice = 79.99, QuantityAvailable = 10 };
            products[3] = new Product { Id = 04, Name = "Mouse", UnitPrice = 29.99, QuantityAvailable = 30 };
            products[4] = new Product { Id = 05, Name = "Monitor", UnitPrice = 249.99, QuantityAvailable = 25 };
            products[5] = new Product { Id = 06, Name = "Keyboard", UnitPrice = 49.99, QuantityAvailable = 18 };
            products[6] = new Product { Id = 07, Name = "Printer", UnitPrice = 129.99, QuantityAvailable = 22 };
            products[7] = new Product { Id = 08, Name = "External Hard Drive", UnitPrice = 89.99, QuantityAvailable = 12 };
            products[8] = new Product { Id = 09, Name = "Webcam", UnitPrice = 34.99, QuantityAvailable = 16 };
            products[9] = new Product { Id = 10, Name = "Tablet", UnitPrice = 199.99, QuantityAvailable = 28 };


        }
        /// <summary>
        /// Displays the role selection menu and manages authentication for employees and clients.
        /// </summary>
        static void ShowRoleSelectionMenu()
        {
            int roleOption;
            do
            {
                // Display current date and role selection menu
                Console.WriteLine("--------------------------------");
                DisplayCurrentDate();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select your role:");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Client");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Choose an option:");
                // Validate and read user input for role selection
                while (!Int32.TryParse(Console.ReadLine(), out roleOption))
                {
                    Console.WriteLine("Invalid value, please try again: ");
                }

                switch (roleOption)
                {
                    case 1:
                        // Employee login and menu
                        Console.WriteLine("Enter Employee ID:");
                        int employeeId = ReadInteger();
                        Console.WriteLine("Enter Employee Password:");
                        string employeePassword = ReadString();
                        if (AuthenticateEmployee(employeeId, employeePassword))
                        {
                            ShowEmployeeMenu();
                        }
                        else
                        {
                            Console.WriteLine("Authentication failed. Invalid ID or password.");
                        }
                        break;

                    case 2:
                        // Client login and menu
                        Console.WriteLine("Enter Client ID:");
                        int clientId = ReadInteger();
                        Console.WriteLine("Enter Client Password:");
                        string clientPassword = ReadString();

                        if (AuthenticateClient(clientId, clientPassword))
                        {
                            var loggedInClient = FindClientById(clientId);
                            ShowClientMenu(loggedInClient);
                            // ShowClientMenu();
                        }
                        else
                        {
                            Console.WriteLine("Authentication failed. Invalid ID or password.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Exiting the application...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (roleOption != 3);
        }

        /// <summary>
        /// Displays the main menu for employees and manages actions based on the employee's choice.
        /// </summary>
        static void ShowEmployeeMenu()
        {
            Console.Clear();
            int option;

            do
            {
                // Display current date and Employee selection menu
                DisplayCurrentDate();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Create products");
                Console.WriteLine("2. Modify a product");
                Console.WriteLine("3. Display all products ordered by ID");
                Console.WriteLine("4. Search for a specific product (ID or NAME) and modify it");
                Console.WriteLine("5. Create a client");
                Console.WriteLine("6. Modify a client");
                Console.WriteLine("7. Display all clients ordered by ID");
                Console.WriteLine("8. Sell a product");
                Console.WriteLine("9. Display all sales");
                Console.WriteLine("10. Display total sales");
                Console.WriteLine("11. Log out");
                Console.WriteLine("Choose an option:");
                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid value, please try again: ");
                }

                switch (option)
                {
                    case 1:
                        // Create a new product
                        CreateProduct();
                        break;
                    case 2:
                        // Modify an existing product
                        DisplayProducts(); // Display all products before modification
                        ModifyProduct();
                        break;
                    case 3:
                        // Display all products
                        DisplayProducts();

                        break;
                    case 4:
                        // Modify an existing product
                        DisplayProducts(); // Display all products before modification
                        ModifyProductByIdOrName();
                        DisplayProducts(); // Display all products after modification
                        break;

                    case 5:
                        // Create a new client
                        CreateClient();
                        break;
                    case 6:
                        // Modify an existing client
                        ModifyClient();
                        break;
                    case 7:
                        // Display all clients
                        DisplayClients();
                        break;
                    case 8:
                        // Sell a product
                        DisplayProducts(); // Display all products before modification
                        SellProduct();
                        break;
                    case 9:
                        // Display all sales
                        DisplayAllSales();
                        break;
                    case 10:
                        // Display total sales
                        DisplayTotalSales();
                        break;
                    case 11:
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (option != 11);
        }

        /// <summary>
        /// Displays the main menu for clients and manages actions based on the client's choice.
        /// </summary>
        static void ShowClientMenu(Client loggedInClient)
        {
            int option;
            do
            {
                // Display current date, Client name and selection menu
                Console.WriteLine("--------------------------------");
                DisplayCurrentDate();
                Console.WriteLine($"Logged in as Client: {loggedInClient.FirstName} {loggedInClient.LastName}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Display all products");
                Console.WriteLine("2. Display all my purchases");
                Console.WriteLine("3. Log out");
                Console.WriteLine("Choose an option:");
                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid value, please try again: ");
                }

                switch (option)
                {
                    case 1:
                        // Display all products
                        DisplayProducts();
                        break;
                    case 2:
                        // Display purchases for the specific client
                        DisplayClientPurchases();
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (option != 3);
        }

        #region functions 
        /// <summary>
        /// Adds a new product to the inventory with information provided by the employee.
        /// </summary>
        static void CreateProduct()
        {
            Console.WriteLine("Enter the product ID:");
            int id = ReadInteger();
            Console.WriteLine("Enter the product name:");
            string name = ReadString();
            Console.WriteLine("Enter the unit price of the product:");
            double unitPrice = ReadDouble();
            Console.WriteLine("Enter the quantity available of the product:");
            int quantityAvailable = ReadInteger();

            for (int i = 0; i < MAXPRODUCTS; i++)
            {
                if (products[i].Name == null)
                {
                    // Add the new product to the array
                    products[i] = new Product { Id = id, Name = name, UnitPrice = unitPrice, QuantityAvailable = quantityAvailable };
                    break;
                }
            }
        }

        /// <summary>
        /// Modifies a product in the 'products' array based on the provided product ID.
        /// </summary>
        static void ModifyProduct()
        {
            Console.WriteLine("Enter the product ID to modify:");
            int productId = ReadInteger();

            int productIndex = -1;

            // Iterate through the 'products' array to find the product by ID
            for (int i = 0; i < MAXPRODUCTS; i++)
            {
                if (products[i].Id == productId)
                {
                    // Set the index when the product ID is found
                    productIndex = i;
                    break;
                }
            }

            if (productIndex != -1)
            {

                Console.WriteLine("Enter the new product name:");
                string newName = ReadString();
                if (!string.IsNullOrEmpty(newName))
                {
                    // Update the product name if a new name is provided
                    products[productIndex].Name = newName;
                }
                else
                {
                    Console.WriteLine("Enter a valid product name.");
                }

                Console.WriteLine("Enter the new unit price (Enter to keep existing):");
                double newUnitPrice = ReadDouble();
                if (newUnitPrice >= 0)
                {
                    // Update the unit price if a valid new value is provided
                    products[productIndex].UnitPrice = newUnitPrice;
                }
                else
                {
                    Console.WriteLine("Enter a valid non-negative unit price.");
                }

                Console.WriteLine("Enter the new quantity available (Enter to keep existing):");
                if (int.TryParse(Console.ReadLine(), out int newQuantity) && newQuantity >= 0)
                {
                    // Update the quantity available if a valid new value is provided
                    products[productIndex].QuantityAvailable = newQuantity;
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative number.");
                }
                Console.WriteLine("Product information modified successfully.");
                Console.WriteLine("--------------------------------");
                // Display modified product information
                Console.WriteLine("Modified Product Details:");
                Console.WriteLine($"ID: {products[productIndex].Id}");
                Console.WriteLine($"Name: {products[productIndex].Name}");
                Console.WriteLine($"Unit Price: {products[productIndex].UnitPrice:C}");
                Console.WriteLine($"Quantity Available: {products[productIndex].QuantityAvailable}");
                Console.WriteLine("--------------------------------");
            }
            else
            {
                Console.WriteLine("Product not found. Unable to modify information.");
            }
        }
        /// <summary>
        /// Displays detailed information about all products available in the inventory.
        /// </summary>
        static void DisplayProducts()
        {
            foreach (var product in products)
            {
                if (product.Name != null)
                {
                    // Display product information
                    Console.WriteLine("---------------------------------------------------------------------------------|");

                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Unit Price: {product.UnitPrice}, Quantity Available: {product.QuantityAvailable}");
                }
            }
        }

        /// <summary>
        /// Creates a new client with information provided by the employee.
        /// </summary>
        static void CreateClient()
        {
            // Implementation for creating a new client
            Console.WriteLine("Enter the client ID:");
            int id = ReadInteger();
            Console.WriteLine("Enter the client first name:");
            string firstName = ReadString();
            Console.WriteLine("Enter the client last name:");
            string lastName = ReadString();
            Console.WriteLine("Enter the client password:");
            string password = ReadString();

            for (int i = 0; i < MAXCLIENTS; i++)
            {
                if (clients[i].FirstName == null)
                {
                    // Add the new client to the array
                    clients[i] = new Client { Id = id, FirstName = firstName, LastName = lastName, Password = password };
                    break;
                }
            }

        }

        /// <summary>
        /// Modifies the information of an existing client in the database.
        /// </summary>
        static void ModifyClient()
        {
            Console.WriteLine("Enter the client ID to modify:");
            int clientId = ReadInteger();

            for (int i = 0; i < MAXCLIENTS; i++)
            {
                if (clients[i].Id == clientId)
                {
                    // Client found, modify information
                    Console.WriteLine("Enter the new first name:");
                    clients[i].FirstName = ReadString();
                    Console.WriteLine("Enter the new last name:");
                    clients[i].LastName = ReadString();
                    Console.WriteLine("Enter the new password:");
                    clients[i].Password = ReadString();

                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Client information modified successfully.");
                    return;
                }
            }

            // If the client ID is not found
            Console.WriteLine("Client not found. Unable to modify information.");
        }

        /// <summary>
        /// Displays information for all clients.
        /// </summary>
        static void DisplayClients()
        {
            foreach (var client in clients)
            {
                if (client.FirstName != null)
                {
                    // Display client information
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"ID: {client.Id}, Name: {client.FirstName} {client.LastName}");
                    Console.WriteLine("--------------------------------");

                }
            }
        }

        /// <summary>
        /// Processes the sale of products to a client, updates the inventory, and records the transaction.
        /// </summary>
        static void SellProduct()
        {
            Console.WriteLine("Enter your client ID:");
            int clientId = ReadInteger();

            // Find the client
            Client client = FindClientById(clientId);

            if (client.Id != 0)
            {
                // Create a new sale
                Sale sale = new Sale { Client = client, Products = new Product[10] }; // Assuming a sale can have up to 10 products

                // Add products to the sale
                Console.WriteLine("Enter the number of products to sell:");
                int numProducts = ReadInteger();

                for (int i = 0; i < numProducts; i++)
                {
                    Console.WriteLine($"Enter product {i + 1} ID:");
                    int productId = ReadInteger();

                    // Find the product
                    Product product = FindProductById(productId);

                    if (product.Id != 0 && product.QuantityAvailable > 0)
                    {
                        Console.WriteLine($"Enter quantity for product {i + 1}:");
                        int quantity = ReadInteger();

                        if (quantity <= product.QuantityAvailable)
                        {
                            // Add the product to the sale
                            sale.Products[i] = new Product { Id = product.Id, Name = product.Name, UnitPrice = product.UnitPrice, QuantityAvailable = quantity };

                            // Update product quantity
                            product.QuantityAvailable -= quantity;

                            // Update sale subtotal
                            sale.Subtotal += quantity * product.UnitPrice;
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient quantity available for product {i + 1}. Sale canceled.");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Product {productId} not found or out of stock. Sale canceled.");
                        return;
                    }
                }

                // Calculate taxes and total price
                sale.Taxes = sale.Subtotal * 0.1; // Assuming 10% tax
                sale.TotalPrice = sale.Subtotal + sale.Taxes;

                // Add the sale to the sales array
                for (int i = 0; i < MAXCLIENTS; i++)
                {
                    if (sales[i].Client.Id == 0)
                    {
                        sales[i] = sale;
                        Console.WriteLine("Sale completed successfully.");
                        return;
                    }
                }

                Console.WriteLine("Maximum number of sales reached. Sale canceled.");
            }
            else
            {
                Console.WriteLine("Client not found. Sale canceled.");
            }
        }

        /// <summary>
        /// Displays the sales history and the cumulative total of sales.
        /// </summary>
        static void DisplayTotalSales()
        {
            double totalSales = 0;

            foreach (var sale in sales)
            {
                if (sale.Client.Id != 0)
                {
                    // Accumulate total sales
                    totalSales += sale.TotalPrice;
                }
            }

            // Display total sales
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Total Sales: {totalSales}");
            Console.WriteLine("--------------------------------");

        }
        /// <summary>
        /// Displays detailed information about all sales.
        /// </summary>
        static void DisplayAllSales()
        {
            Console.WriteLine("*********************");

            Console.WriteLine("Sales History:");

            // Check if there are any sales
            if (sales.Length == 0)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("No sales found.");
                Console.WriteLine("----------------------------");
            }
            else
            {
                bool salesFound = false; // Flag to track if valid sales are found

                // Iterate through each sale
                foreach (var sale in sales)
                {
                    // Check if the client ID is not zero (assuming zero means no client)
                    if (sale.Client.Id != 0)
                    {
                        salesFound = true; // Set the flag to true

                        Console.WriteLine($"Client: {sale.Client.FirstName} {sale.Client.LastName}");
                        Console.WriteLine($"Subtotal: {sale.Subtotal}, Taxes: {sale.Taxes}, Total Price: {sale.TotalPrice}");

                        Console.WriteLine("Products:");

                        // Iterate through each product in the sale
                        foreach (var product in sale.Products)
                        {
                            // Check if the product ID is not zero (assuming zero means no product)
                            if (product.Id != 0)
                            {
                                Console.WriteLine($" - Product: {product.Name}, Quantity: {product.QuantityAvailable}");
                            }
                        }

                        Console.WriteLine("----------------------------");
                    }
                }

                // Check if no valid sales were found
                if (!salesFound)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("No sales found.");
                    Console.WriteLine("----------------------------");

                }
            }
        }
        /// <summary>
        /// Finds a client in the 'clients' array based on the provided client ID.
        /// </summary>
        /// <param name="clientId">The ID of the client to find.</param>
        /// <returns>
        /// The found client if the client ID is found in the 'clients' array; otherwise,
        /// returns a new instance of the Client class if the client ID is not found.
        /// </returns>
        static Client FindClientById(int clientId)
        {
            foreach (var client in clients)
            {
                if (client.Id == clientId)
                {
                    return client;
                }
            }

            // If the client ID is not found
            return new Client();
        }
        /// <summary>
        /// Finds a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to find.</param>
        /// <returns>The product if found, otherwise an empty product.</returns>
        static Product FindProductById(int productId)
        {
            foreach (var product in products)
            {
                if (product.Id == productId)
                {
                    return product;
                }
            }

            // If the product ID is not found
            return new Product();
        }

        #endregion


        static void DisplayClientPurchases()
        {
            Console.WriteLine("Enter your client ID:");
            int clientId = ReadInteger();

            bool clientFound = false;

            foreach (var sale in sales)
            {
                if (sale.Client.Id == clientId)
                {
                    // Display sale information for the specific client
                    Console.WriteLine($"Subtotal: {sale.Subtotal}, Taxes: {sale.Taxes}, Total Price: {sale.TotalPrice}");
                    foreach (var product in sale.Products)
                    {
                        // Display product information for each product in the sale
                        Console.WriteLine($"Product: {product.Name}, Quantity: {product.QuantityAvailable}");
                    }

                    clientFound = true; // Set the flag to true when the client is found
                }
            }

            if (!clientFound)
            {
                Console.WriteLine("---------------------------");

                Console.WriteLine("No Purchase history.");
            }
        }

        #endregion
        #region //Bonus Section 
        //?BONUS
        /// <summary>
        /// Displays the current date in the format "yyyy-MM-dd".
        /// </summary>
        static void DisplayCurrentDate()
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        }

        /// <summary>
        /// Modifies a product by either its ID or Name based on user input.
        /// </summary>
        static void ModifyProductByIdOrName()
        {
            Console.Write("Enter the product ID or Name to modify: ");
            string input = ReadString();

            // Try to parse input as an integer (to check if it's an ID)
            if (int.TryParse(input, out int productId))
            {
                ModifyProductById(productId);
            }
            else
            {
                ModifyProductByName(input);
            }
        }



        /// <summary>
        /// Modifies a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to modify.</param>
        static void ModifyProductById(int productId)
        {

            int productIndex = -1;
            int i = 0;

            while (i < products.Length && productIndex == -1)
            {
                if (products[i].Id == productId)
                {
                    productIndex = i;
                }
                i++;
            }

            if (productIndex != -1)
            {
                UpdateProductDetails(productIndex);
                Console.WriteLine("Product modified successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        

        /// <summary>
        /// Modifies a product by its Name.
        /// </summary>
        /// <param name="productName">The Name of the product to modify.</param>
        static void ModifyProductByName(string productName)
        {
            int productIndex = -1;
            int i = 0;

            while (i < products.Length && productIndex == -1)
            {
                if (string.Equals(products[i].Name, productName, StringComparison.OrdinalIgnoreCase))
                {
                    productIndex = i;
                }
                i++;
            }

            if (productIndex != -1)
            {
                UpdateProductDetails(productIndex);
                Console.WriteLine("Product modified successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        /// <summary>
        /// Updates the details of a product at the specified position in the 'products' array.
        /// Prompts the user to enter new values for the product's name, unit price, and quantity available.
        /// If the user presses Enter without entering a new value, the existing value is retained.
        /// </summary>
        /// <param name="productIndex">Index of the product in the 'products' array to be updated.</param>
        static void UpdateProductDetails(int productIndex)
        {
            Console.Write("New Name (Enter to keep existing): ");
            string newName = ReadString();
            if (!string.IsNullOrEmpty(newName))
            {
                products[productIndex].Name = newName;
            }

            Console.Write("New Unit Price (Enter to keep existing): ");
            double.TryParse(Console.ReadLine(), out double newUnitPrice);
            if (newUnitPrice > 0)
            {
                products[productIndex].UnitPrice = newUnitPrice;
            }
            Console.Write("New Quantity Available (Enter to keep existing): ");
            int.TryParse(Console.ReadLine(), out int newQuantity);
            if (newQuantity >= 0)
            {
                products[productIndex].QuantityAvailable = newQuantity;
            }
        }

        #endregion
        #region //Functions for Validation 

        /// <summary>
        /// Authenticates an employee based on ID and password.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="password">The employee password.</param>
        /// <returns>True if authentication is successful, otherwise false.</returns>
        static bool AuthenticateEmployee(int id, string password)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                // Check if the provided ID and password match any employee
                if (employees[i].Id == id && employees[i].Password == password)
                {
                    return true; // Authentication successful
                }
            }
            return false; // Authentication failed
        }

        /// <summary>
        /// Authenticates a client based on ID and password.
        /// </summary>
        /// <param name="id">The client ID.</param>
        /// <param name="password">The client password.</param>
        /// <returns>True if authentication is successful, otherwise false.</returns>
        static bool AuthenticateClient(int id, string password)
        {
            for (int i = 0; i < clients.Length; i++)
            {
                // Check if the provided ID and password match any client
                if (clients[i].Id == id && clients[i].Password == password)
                {
                    return true; // Authentication successful
                }
            }
            return false; // Authentication failed
        }
        /// <summary>
        /// Reads a non-empty string from the console.
        /// </summary>
        /// <returns>The entered string.</returns>
        static string ReadString()
        {
            string toReturn = null;
            while (String.IsNullOrEmpty(toReturn))
            {
                toReturn = Console.ReadLine();
            }

            return toReturn;
        }
        /// <summary>
        /// Reads an integer from the console.
        /// </summary>
        /// <returns>The entered integer value.</returns>
        static int ReadInteger()
        {
            int toReturn = 0;
            while (!Int32.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid integer value, please try again: ");
            }

            return toReturn;
        }
        /// <summary>
        /// Reads a double-precision floating-point number from the console.
        /// </summary>
        /// <returns>The entered double value.</returns>
        static double ReadDouble()
        {
            double toReturn = 0;
            while (!Double.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid real value, please try again: ");
            }

            return toReturn;
        }
        /// <summary>
        /// Reads a double-precision floating-point number from the console within a specified range.
        /// </summary>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>The entered double value within the specified range.</returns>
        static double ReadDouble(double min, double max)
        {
            double toReturn = ReadDouble();
            while (!IsWithinRange(toReturn, min, max))
            {
                Console.Write($"The value must be between {min} and {max}. Please try again: ");
                toReturn = ReadDouble();
            }

            return toReturn;
        }
        /// <summary>
        /// Checks if a given double value is within a specified range.
        /// </summary>
        /// <param name="num">The value to check.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>True if the value is within the specified range, otherwise false.</returns>
        static bool IsWithinRange(double num, double min, double max)
        {
            return num >= min && num <= max;
        }
        #endregion
    }
}
