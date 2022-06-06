using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking2
{
    // Keeping methods here because I find it easier to organise it like this.
    internal class Methods
    {
        // Creates a new MobilPhone and returns the object
        public static MobilePhone getNewMobile()
        {
            MobilePhone Phone = new MobilePhone();
            Phone.Type = "Mobile Phone";
            Phone.Brand = Methods.getPhoneBrand(); //string
            Phone.Model = Methods.getAssetModel(); //string
            Phone.Purchasedate = Methods.getAssetPurchaseDate(); //DateTime
            Phone.PriceUSD = Methods.getAssetPrice(); //double
            Phone.OfficeId = Methods.getOfficeId(); //int
            return Phone;
        }

        // Creates a new LaptopComputer and returns the object
        public static LaptopComputer getNewLaptop()
        {
            LaptopComputer Laptop = new LaptopComputer();
            Laptop.Type = "Laptop Computer";
            Laptop.Brand = Methods.getLaptopBrand();
            Laptop.Model = Methods.getAssetModel();
            Laptop.Purchasedate = Methods.getAssetPurchaseDate();
            Laptop.PriceUSD = Methods.getAssetPrice();
            Laptop.OfficeId = Methods.getOfficeId();
            return Laptop;
        }

        // Get input from user and return which type the asset is.
        // The return is a descriptive string.
        public static string getAssetType()
        {
            string? assetType;
            while (true)
            {
                Console.WriteLine("Enter type: ");
                Console.WriteLine(" ( 1 ) Laptop Computer");
                Console.WriteLine(" ( 2 ) Mobile Phone");
                assetType = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(assetType)) { Console.WriteLine("Type cannot be empty."); }
                else if (assetType == "1") { assetType = "Laptop Computer"; break; }
                else if (assetType == "2") { assetType = "Mobile Phone"; break; }
                else { Console.WriteLine("Choose '1' or '2' "); }
            }
            return assetType;
        }

        // Get input from user and return which brand the laptop is.
        // The return is a descriptive string with the brand name.
        public static string getLaptopBrand()
        {
            string? assetBrand;
            while (true)
            {
                Console.WriteLine("Enter brand: ");
                Console.WriteLine(" ( 1 ) MacBook");
                Console.WriteLine(" ( 2 ) Asus");
                Console.WriteLine(" ( 3 ) Lenovo");
                assetBrand = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(assetBrand)) { Console.WriteLine("Brand cannot be empty."); ; }
                else if (assetBrand == "1") { assetBrand = "MacBook"; break; }
                else if(assetBrand == "2") { assetBrand = "Asus"; break; }
                else if (assetBrand == "3") { assetBrand = "Lenovo"; break; }
                else { Console.WriteLine("Choose '1' , '2' or '3' "); }
            }
            return assetBrand;
        }

        // Get input from user and return which brand the phone is.
        // The return is a descriptive string with the brand name.
        public static string getPhoneBrand()
        {
            string? assetBrand;
            while (true)
            {
                Console.WriteLine("Enter brand: ");
                Console.WriteLine(" ( 1 ) Iphone");
                Console.WriteLine(" ( 2 ) Samsung");
                Console.WriteLine(" ( 3 ) Nokia");
                assetBrand = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(assetBrand)) { Console.WriteLine("Brand cannot be empty."); ; }
                else if (assetBrand == "1") { assetBrand = "Iphone"; break; }
                else if (assetBrand == "2") { assetBrand = "Samsung"; break; }
                else if (assetBrand == "3") { assetBrand = "Nokia"; break; }
                else { Console.WriteLine("Choose '1' , '2' or '3' "); }
            }
            return assetBrand;
        }


        // Get input from user and return which model the asset is.
        // The return is the input string from the user.
        public static string getAssetModel()
        {
            string? assetModel;
            while (true)
            {
                Console.Write("Enter model: ");
                assetModel = Console.ReadLine();
                if (String.IsNullOrEmpty(assetModel)) { Console.WriteLine("Model cannot be empty."); ; }
                else { break; }
            }
            return (assetModel);
        }

        // Get input from user and return which office the asset belongs to
        // The return is the ID of the office, which is the foreign key in the db.
        public static int getOfficeId()
        {
            int OfficeId;
            string? input;
            while (true)
            {
                Console.WriteLine("Which office does this asset belong to? ");
                Console.WriteLine(" ( 1 ) Sweden");
                Console.WriteLine(" ( 2 ) Spain");
                Console.WriteLine(" ( 3 ) USA");
                input = Console.ReadLine().Trim();
                if(int.TryParse(input, out int temp)) { OfficeId = temp; break; }
                else { Console.WriteLine("Choose '1' , '2' or '3' "); }
            }
            return OfficeId;
        }

        // Get input from user and return the date of purchase.
        public static DateTime getAssetPurchaseDate()
        {
            DateTime assetPurchaseDate;
            while (true)
            {
                Console.Write("Enter purchase date YYYY-MM-DD ");
                string? inputDate = Console.ReadLine();
                if (DateTime.TryParse(inputDate, out DateTime temp)) { assetPurchaseDate = temp; break; }
                else { Console.WriteLine("Input date on format YYYY-MM-DD "); }
            }
            return assetPurchaseDate;
        }

        // Get input from user and return the price for which the asset was bought.
        public static double getAssetPrice()
        {
            double assetPrice;
            while (true)
            {
                Console.Write("Enter price in USD: ");
                string? inputPrice = Console.ReadLine();
                double temp;
                if (double.TryParse(inputPrice, out temp)) { assetPrice = temp; break; }
                else { Console.WriteLine("Price must be a number."); }
            }
            return assetPrice;
        }

        //Lets the user choose an asset to edit, and returns that asset
        public static Asset getAssetToEdit(MyDbContext context)
        {
            string userInput= "0";
            int assetId;
            Asset assetToEdit;
            while (true)
            {
                Console.Write("Enter asset ID: ");
                userInput = Console.ReadLine();
                if (int.TryParse(userInput.Trim(), out assetId))
                {
                    if (context.Assets.Select(x => x.Id).Contains(assetId))
                    {
                        assetToEdit = context.Assets.SingleOrDefault(x => x.Id == assetId);
                        break;
                    }
                    else { Console.WriteLine("That ID does not excist."); }
                }
                else { Console.WriteLine("Could not parse to number."); }
            }
            return assetToEdit;
        }

        // Prints out assetList to console.
        // Yellow if assets end of life is less than 6 months away
        // Red if assets end of life is less than 3 months away
        // Magenta if it has expired already
        public static void printAssetList(List<Asset> assetList)
        {
            int printpadding = 15;
            var today = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID".PadRight(5) + "Type".PadRight(20) + "Brand".PadRight(printpadding) + "Model".PadRight(printpadding) + "Office".PadRight(printpadding) + "Purchase Date".PadRight(printpadding) + "Price in USD".PadRight(printpadding) + "Currency".PadRight(printpadding) + "Local price today".PadRight(printpadding));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var asset in assetList)
            {
                var years = today.Year - asset.Purchasedate.Year;
                var months = today.Month - asset.Purchasedate.Month;
                var days = today.Day - asset.Purchasedate.Day;
                if (years == 3)
                {
                    if ((months == -3 && days > 0) || months > -3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if ((months == -6 && days > 0) || months > -6)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                else if (years > 3) { Console.ForegroundColor = ConsoleColor.Magenta; }
                double localPriceToday = LocalPriceToday(asset);
                Console.WriteLine(asset.Id.ToString().PadRight(5)
                    + asset.Type.PadRight(20)
                    + asset.Brand.PadRight(printpadding)
                    + asset.Model.PadRight(printpadding)
                    + asset.Office.Country.PadRight(printpadding)
                    + asset.Purchasedate.ToShortDateString().PadRight(printpadding)
                    + asset.PriceUSD.ToString().PadRight(printpadding)
                    + asset.Office.Currency.PadRight(printpadding)
                    + localPriceToday.ToString("C", CultureInfo.CurrentCulture)
                    );
                Console.ResetColor();
                
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
        }

        //Gets todays rates from floatrates.com
        //Returns the price of the asset in local currency
        public static double LocalPriceToday(Asset asset)
        {
            if (asset.PriceUSD == null) { return 0; }
            double localPrice = asset.PriceUSD;
            if (asset.Office.Currency == "USD") { return asset.PriceUSD; }
            double rate;
            WebRequest request = WebRequest.Create("http://www.floatrates.com/daily/usd.json");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string sRateBegin = "Euro\",\"rate\":";
            string sRateEnd = ",";
            if (asset.Office.Currency == "SEK")
            {
                sRateBegin = "Swedish Krona\",\"rate\":";
                sRateEnd = ",";
            }
            string sRate = responseFromServer.Substring(responseFromServer.IndexOf(sRateBegin) + sRateBegin.Length);
            sRate = sRate.Substring(0, sRate.IndexOf(sRateEnd));
            if (double.TryParse(sRate, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out rate)) { localPrice = asset.PriceUSD * rate; }
            else { throw new Exception("Couldn't parse exchange rate, string to double."); }
            reader.Close();
            response.Close();
            return localPrice;
        }

    }
}
