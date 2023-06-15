 Console.WriteLine("Enter your information:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            string dobInput = Console.ReadLine();
            DateTime dateOfBirth;

            while (!DateTime.TryParse(dobInput, out dateOfBirth))
            {
                Console.WriteLine("Invalid date format. Please enter the date of birth in yyyy-mm-dd format.");
                Console.Write("Date of Birth (yyyy-mm-dd): ");
                dobInput = Console.ReadLine();
            }

            Console.WriteLine("\nCalculating invoice...");

            decimal totalAmount = 0;

            foreach (var selectedProduct in selectedProducts)
            {
                string productName = selectedProduct.Key;
                int quantity = selectedProduct.Value;
                decimal price = products[productName];

                decimal productTotal = price * quantity;
                totalAmount += productTotal;
            }

            decimal vatAmount = totalAmount * 0.02m;
            decimal invoiceAmount = totalAmount + vatAmount;

            Console.WriteLine("\nInvoice Details:");
            Console.WriteLine($"Customer: {firstName} {lastName}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Date of Birth: {dateOfBirth.ToShortDateString()}");
                    Console.WriteLine("\nSelected Products:");

        foreach (var selectedProduct in selectedProducts)
        {
            string productName = selectedProduct.Key;
            int quantity = selectedProduct.Value;
            decimal price = products[productName];
            decimal productTotal = price * quantity;

            Console.WriteLine($"{productName} - Quantity: {quantity} - Price: ${price} - Total: ${productTotal}");
        }
