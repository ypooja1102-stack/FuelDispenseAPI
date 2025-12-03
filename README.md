Project Overview
    The Fuel Dispensing Management System is a full-stack web application designed to log and manage fuel dispensing details at a petrol pump.
    It allows an authenticated user to:    
    Add new dispensing records with details like dispenser number, quantity filled, vehicle number, payment mode, and payment proof.    
    View and filter past dispensing records by dispenser, payment mode, and date range.    
    Download or view uploaded payment receipts.    
    This system ensures secure access via JWT-based authentication and provides a simple, user-friendly interface for petrol pump operations.
Tech Stack
    Used asp.net  core C# web api for communicating with the frontend.
Setup Instructions    
    1.clone the Repository "https://github.com/ypooja1102-stack/FuelDispenseAPI/" and Navigate to the FuelDispenseAPI project folder
    2.Update connection string in appsettings.json: 
      "ConnectionStrings": {
                              "DefaultConnection": "Server=YOUR_SERVER;Database=FuelDB;Trusted_Connection=True;"
                            }
    3. Run the DBScipts on SQL Sever  in the same sequence provide in the "DBScrpts" Folder
    4.Run the application

Assumptions
     1. Single demo user; no registration or password recovery implemented.
     2. Payment proof files stored locally under FuelDispenseAPI\PaymentProofs.
     3. Basic validation is applied on both client and server sides.
     4. Listing page updates dynamically with applied filters.
     5. Date filters are inclusive of start and end dates.
    
