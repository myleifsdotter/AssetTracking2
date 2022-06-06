// See https://aka.ms/new-console-template for more information
using AssetTracking2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
Console.WriteLine("\r\nAsset Tracking 2");
Console.WriteLine("--------------------");
Console.WriteLine("Loading database");
Console.WriteLine("--------------------");
MyDbContext context = new MyDbContext(); //the database is represented by this object 
string userInput, assetType;
LaptopComputer Laptop = new LaptopComputer();
MobilePhone Phone = new MobilePhone();
var assetList = context.Assets.Include(x => x.Office);
List<Asset> sortedAssetList = new List<Asset>();
while (true)
{
    Console.WriteLine("\r\n ( 1 ) Show assets");
    Console.WriteLine(" ( 2 ) Add a new asset");
    Console.WriteLine(" ( 3 ) Update an asset");
    Console.WriteLine(" ( 4 ) Delete an asset");
    Console.WriteLine(" ( 5 ) Quit");
    userInput = Console.ReadLine();
    if(userInput == "5") { break; }
    // Shows the list of assets in Console
    if (userInput == "1")
    {
        userInput = "0"; // Reset user input
        while (true)
        {
            Console.WriteLine("Sort list by type or by office?");
            Console.WriteLine(" ( 1 ) Type");
            Console.WriteLine(" ( 2 ) Office");
            userInput = Console.ReadLine();
            if (userInput == "1") // Sort by type, then by purchase date
            {
                sortedAssetList = assetList.OrderBy(x => x.Type).ThenBy(x => x.Purchasedate).ToList();
                break;
            }
            else if (userInput == "2") // Sort by Office, then by purchase date
            {
                sortedAssetList = assetList.OrderBy(x => x.Office.Country).ThenBy(x => x.Purchasedate).ToList();
                break;
            }
            else { Console.WriteLine("Choose '1' or '2' "); }
        }
        Methods.printAssetList(sortedAssetList);
        userInput = "0"; // Reset user input
    }

    // User adding new asset to db
    if (userInput == "2")
    {
        userInput = "0"; // Reset user input
        assetType = Methods.getAssetType();
        if (assetType == "Mobile Phone")
        {
            Phone = Methods.getNewMobile();
            context.Assets.Add(Phone);
            context.SaveChanges();
            assetList = context.Assets.Include(x => x.Office);
        }
        else if (assetType == "Laptop Computer")
        {
            Laptop = Methods.getNewLaptop();
            context.Assets.Add(Laptop);
            context.SaveChanges();
            assetList = context.Assets.Include(x => x.Office);
        }
        else { Console.WriteLine("Invalid return from method."); }
        userInput = "0"; // Reset user input
    }

    // User editing asset in db
    if (userInput == "3")
    {
        userInput = "0"; // Reset user input
        Methods.printAssetList(assetList.ToList());
        Console.WriteLine("Which asset you would like to edit?");
        Asset assetToEdit = Methods.getAssetToEdit(context);
        while (true)
        {
            Console.WriteLine("Which attribute would you like to edit?");
            Console.WriteLine(" ( 1 ) Model");
            Console.WriteLine(" ( 2 ) Purchasedate");
            Console.WriteLine(" ( 3 ) Price");
            Console.WriteLine(" ( 4 ) Office");
            Console.WriteLine(" ( 5 ) I changed my mind. Take me out of editing mode.");
            userInput = Console.ReadLine();
            if (userInput == "1") { assetToEdit.Model = Methods.getAssetModel(); break; }
            else if (userInput == "2") { assetToEdit.Purchasedate = Methods.getAssetPurchaseDate(); break; }
            else if (userInput == "3") { assetToEdit.PriceUSD = Methods.getAssetPrice(); break; }
            else if (userInput == "4") { assetToEdit.OfficeId = Methods.getOfficeId(); break; }
            else if (userInput == "5") { Console.WriteLine("No worries, nothing changed."); break; }
            else { Console.WriteLine("Choose between 1-5"); }
        }
        if (userInput != "5")
        {
            context.SaveChanges();
            assetList = context.Assets.Include(x => x.Office);
        }
        userInput = "0"; // Reset user input
    }

    // User deleting asset from db
    if (userInput == "4") // Delete asset
    {
        userInput = "0"; // Reset user input
        Methods.printAssetList(assetList.ToList());
        Console.WriteLine("Which asset you would like to delete?");
        Asset assetToDelete = Methods.getAssetToEdit(context);
        Console.WriteLine("Deleting asset with ID " + assetToDelete.Id + ": " + assetToDelete.Brand + " " + assetToDelete.Model);
        while (true)
        {
            Console.WriteLine(" ( Y ) Yes, confirm delete. ");
            Console.WriteLine(" ( N ) No, keep the asset. ");
            userInput = Console.ReadLine().Trim().ToUpper();
            if (userInput == "Y")
            {
                Console.WriteLine("Deleting asset.");
                break;
            }
            else if (userInput == "N")
            {
                Console.WriteLine("No worries, nothing was deleted.");
                break;
            }
            else { Console.WriteLine("Choose Y or N"); }
        }
        if (userInput == "Y")
        {
            context.Assets.Remove(assetToDelete);
            context.SaveChanges();
            assetList = context.Assets.Include(x => x.Office);
        }
        userInput = "0"; // Reset user input
    }
}



