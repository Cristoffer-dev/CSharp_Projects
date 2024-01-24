# Sales and Purchase Management System 📊

## Overview 🚀

Welcome to the Sales and Purchase Management System! This console application allows you to efficiently manage clients, products, and transactions. Dive into the structured world of sales with a visually organized approach.

## Entities 📑

### Employee 🧑‍💼
Represents an employee with an ID and password.

### Client 👥
Represents a client with an ID, first name, last name, and password.

### Product 📦
Represents a product with an ID, name, unit price, and available quantity.

### Sale 🛍️
Represents a sale with a client, an array of products, subtotal, taxes, and total price.

### Purchase 🛒
Represents a purchase with a client, an array of products, subtotal, taxes, and total price.

## Key Variables 📈

- **MAXCLIENTS:** Maximum number of clients allowed.
- **MAXPRODUCTS:** Maximum number of products allowed.
- **employees:** Array for employees.
- **clients:** Array for clients.
- **products:** Array for products.
- **sales:** Array for sales.

## Main Function 🚀

The `Main` function acts as your gateway, initializing data and presenting a visually appealing role selection menu.

## Bonus Section 🌟

### DisplayCurrentDate() 📅
Showcases the current date in the format "yyyy-MM-dd."

### FindAndModifyProduct() 🔄
Locate and modify product information effortlessly by name or ID.

### FindProductByName(string productName) 🔍
Efficiently locate a product by its name.

## Interactive Functions 🎮

### InitializeData() 🚀
Kickstarts the system by setting up employee, client, product, and sales data.

### ShowRoleSelectionMenu() 📌
A visually interactive menu to choose between the roles of Employee or Client.

### ReadString() 📝
An interactive input method for strings.

### ReadDouble(double minValue, double maxValue) 📏
User-friendly input for doubles within a specified range.

### ReadInteger() 🔢
Interactive input method for integers.

## Get Started 🚀

1. **Run the program.**
2. Choose your role: *Employee* or *Client*.
3. Explore functionalities seamlessly:
    - Manage clients and products.
    - Perform sales and purchases.
    - Utilize bonus features like displaying the current date and modifying product information.

Enjoy the visually appealing and organized interface for efficient sales and purchase management!

## Notes 📝

- Console-based application for ease of use.
- Maximum limits for clients and products defined by `MAXCLIENTS` and `MAXPRODUCTS`.
- Code is structured using structs for different entities.

## Contributors 💡

- [Cristoffer Montoya]
- [Daniel Sandoval]

Feel free to contribute and enhance the system's features! Let's make managing sales and purchases visually engaging and straightforward. 🌐