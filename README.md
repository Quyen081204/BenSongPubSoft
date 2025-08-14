# WinForms Restaurant Management Application
A Windows Forms application for managing a small restaurant.

## Features
1. **Account Management** – Create, read, update, delete user accounts.
2. **Table Management** – Manage tables, check availability (full/empty).
3. **Menu Management** – CRUD operations for food and drink items.
4. **Order Management** – Take and manage customer orders.
5. **Billing** – Process payments via Momo.

## Tech Stack
- **Language:** C#
- **Framework:** .NET 8 (WinForms)
- **Database:** SQL Server
- **Payment Integration:** Momo API

## Getting Started
1. Clone the repository:
   ```bash
   git clone https://github.com/Quyen081204/BenSongPubSoft.git
2. Open the .sln file in Visual Studio.
3. Restore NuGet packages.

## Database Setup
You can set up the database using **SQL Server Management Studio (SSMS)** or the **command line**.

### **Option 1 – Using SSMS**
1. Open **SQL Server Management Studio**.
2. Connect to your SQL Server instance.
3. Click **New Query**.
4. Copy and paste the contents of [DatabaseQLNhaHangNhau.sql](https://raw.githubusercontent.com/Quyen081204/BenSongPubSoft/main/DatabaseQLNhaHangNhau.sql) into the query window.
5. Click **Execute** (or press **F5**) to run the script and create the database.

### **Option 2 – Using Command Line**
1. Make sure `sqlcmd` is installed (it comes with SQL Server tools).
2. Open **Command Prompt**.
3. Run this command (replace placeholders with your server name, username, and password):

   **SQL Authentication:**
   ```cmd
   sqlcmd -S SERVER_NAME -U USERNAME -P PASSWORD -i "C:\Path\To\DatabaseQLNhaHangNhau.sql" (Path to the file)

## Run 
> After setup the database then go back to Visual Studio Press F5 to run.

## Known Issues
- **Momo Payment**: The payment feature is currently unstable and may not work correctly.  
  Because of this, setup instructions for Momo integration are **not included** at the moment.  


