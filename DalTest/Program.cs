using DalApi;
using DalTest;
using DO;
using System.Reflection;
using Tools;

internal class Program
{
    private static readonly IDal s_dal = DalApi.Factory.Get;


    //תפריט ראשון לבחירת יישות
    public static int PrintMainMenu()
    {
        Console.WriteLine(" For Custemer Press 1");
        Console.WriteLine(" For Product Press 2");
        Console.WriteLine(" For Sales Press 3");
        Console.WriteLine(" To Exist Press 0");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            select = -1;
        return select;
    }
    //אחרי בחירת ישות עובר לתפריט בחירת פונקציה
    public static int PrintSubMenu(string item)
    {
        Console.WriteLine($" To readAll for {item} Press 1");
        Console.WriteLine($" To read for {item} Press 2");
        Console.WriteLine($" To UpDate for {item} Press 3");
        Console.WriteLine($" To Create for {item} Press 4");
        Console.WriteLine($" To Delete for {item} Press 5");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            select = -1;
        return select;
    }

    private static Product AskProduct(int code = 0)
    {
        int productId = code;

        //קליטת כל הנתונים 
        Console.WriteLine("Enter Name of the Product");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter the Category 0-5");
        Category category;
        if (!int.TryParse(Console.ReadLine(), out int cat))
            category = 0;
        else
            category = (Category)cat;

        Console.WriteLine("Enter price");
        if (!double.TryParse(Console.ReadLine(), out double price))
            price = 10;

        Console.WriteLine("Enter count in stock");
        if (!int.TryParse(Console.ReadLine(), out int count))
            count = 0;
        //החזרת מוצר תקין עם כל הפרמטרים שלו
        return new Product(productId, name, category, price, count);
    }
    
    private static Custemer AskCustemer(int code = 0)
    {
        int Custemer_Id, Custemer_Phone; string Custemer_Address, Custemer_Name;

        if (code == 0)
        {
            Console.WriteLine("Enter custemer code");
            int.TryParse(Console.ReadLine(), out code);
        }

        Console.WriteLine("Enter custemer name");
        Custemer_Name = Console.ReadLine();
        Console.WriteLine("Enter custemer address");
        Custemer_Address = Console.ReadLine();
        Console.WriteLine("Enter custemer phone");
        Custemer_Phone = int.Parse(Console.ReadLine());

        //שליחה של לקוח חדש
        return new Custemer(code, Custemer_Name, Custemer_Address, Custemer_Phone);
    }

    //v
    private static Sale AskSale(int code = 0)
    {
        ////קליטת כל הנתונים למבצע 
        Console.WriteLine("Enter Product ID for this sale:");
        if (!int.TryParse(Console.ReadLine(), out int productId))
            productId = 0;

        Console.WriteLine("Enter Sale Price:");
        if (!int.TryParse(Console.ReadLine(), out int priceSale))
            priceSale = 0;

        Console.WriteLine("For all customers? (1 for Yes, 0 for No):");
        int.TryParse(Console.ReadLine(), out int select);
        bool ifAllCustomers = (select == 1);

        Console.WriteLine("Enter count for sale:");
        int.TryParse(Console.ReadLine(), out int countSale);

        Console.WriteLine("Enter start date (yyyy-mm-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime startSale))
            startSale = DateTime.Now; // ברירת מחדל: היום

        Console.WriteLine("Enter end date (yyyy-mm-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime endSale))
            endSale = startSale.AddDays(7); // ברירת מחדל: שבוע מההתחלה

        // 2. שליחת המזהים לקונסטרקטור
        // הפרמטר הראשון הוא 0 כי ה-ID של המבצע ייווצר אוטומטית במחלקה Sale
        // הפרמטר השני הוא ה-productId שקלטנו הרגע
        return new Sale(code, productId, countSale, priceSale, ifAllCustomers, startSale, endSale);

    }
    //הוספת מבצע
    private static void AddSale()
    {
        try
        {
            //קולטת נתוני מבצע מהמשתמש,
            //יוצרת את מבצע בשכבת הנתונים
            //ומעדכנת את ID שנוצר.           
            Sale s = AskSale();
            int code = s_dal.Sale.Create(s);
            s = s with { ProductID = code };
            Console.WriteLine("sucssed!");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the sale is exsists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalAlreadyExistsException("the sale is exsists");
        }
    }
    private static void AddProduct()
    {
        try
        {
            //קולטת נתוני מוצר מהמשתמש,
            //יוצרת את המוצר בשכבת הנתונים
            //ומעדכנת את ID שנוצר. 
            Product p = AskProduct();
            int code = s_dal.Product.Create(p);
            p = p with { ProductId = code };
            Console.WriteLine("sucssed!");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the product is exsists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalAlreadyExistsException("the product is exsists");

        }
    }
    private static void AddCustemer()
    {
        try
        {
            //קולטת לקוח מבצע מהמשתמש,
            //יוצרת את לקוח בשכבת הנתונים
            //ומעדכנת את ID שנוצר. 
            Custemer c = AskCustemer();
            int code = s_dal.Custemer.Create(c);
            c = c with { CustemerID = code };
            Console.WriteLine("sucssed!");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the custemer is exsists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalAlreadyExistsException("the custemer is exsists");
        }
    }
    private static void UpdateSale()
    {
        try
        {
            //קליטת ID מסוים ספציפי
            Console.WriteLine("Enter the Sale ID you want to update:");
            int id = int.Parse(Console.ReadLine());

            //משתנה שמכיל בתוכו את כל הפרטים לפי הID המסוים שהתקבל
            var existing = s_dal.Sale.Read(id);
            if (existing == null)
            {
                //אם הID לא קיים מחזיר הודעה
                Console.WriteLine("Sale not found!");
                return;
            }
            //אם קיים כזה מבצע
            //מכניס את הנתונים החדשים
            //מעדכן שינויים ומודיע למשתמש שהכל התעדכן בשלום
            Sale s = AskSale(id);
            s_dal.Sale.Update(s);
            Console.WriteLine("Update successful!");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the sale with id is not exists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalDoesNotExistException("the sale with id is not exists");

        }
    }
    private static void UpdateCustemer()
    {
        try
        {
            //קליטת ID מסוים ספציפי
            Console.WriteLine("Enter the Custemer ID you want to update:");
            int id = int.Parse(Console.ReadLine());
            //משתנה שמכיל בתוכו את כל הפרטים לפי הID המסוים שהתקבל
            var existing = s_dal.Custemer.Read(id);
            if (existing == null)
            {
                //אם הID לא קיים מחזיר הודעה
                Console.WriteLine("Custemer not found!");
                return;
            }
            //אם קיים כזה לקוח
            //מכניס את הנתונים החדשים
            //מעדכן שינויים ומודיע למשתמש שהלקוח התעדכן בשלום
            Custemer p = AskCustemer(id);
            s_dal.Custemer.Update(p);
            Console.WriteLine("Update successful!");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the custemer with id is not exists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalDoesNotExistException("the custemer with id is not exists");
        }
    }
    private static void UpdateProduct()
    {
        try
        {
            //קליטת ID מסוים ספציפי
            Console.WriteLine("Enter the Product ID you want to update:");
            int id = int.Parse(Console.ReadLine());
            // בדיקה אם המוצר בכלל קיים לפני שמתחילים לשאול שאלות
            var existing = s_dal.Product.Read(id);
            if (existing == null)
            {
                //אם לא נמצא הID מודיע למשתמש
                Console.WriteLine("Product not found!");
                return;
            }
            //אם קיים כזה מוצר
            //מכניס את הנתונים החדשים
            //מעדכן שינויים ומודיע למשתמש שהמוצר התעדכן בשלום     
            Product p = AskProduct(id);
            s_dal.Product.Update(p);
            Console.WriteLine("Update successful!");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the product with id is not exists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalDoesNotExistException("the product with id is not exists");
        }
    }
    private static void ReadAll<T>(ICrud<T> crud)
    {
        try
        {
            //שולח רשימה רשימה לפונקציה שקוראת את כולם
            foreach (var item in crud.ReadAll())
            {
                //ומדפיסה את כל הרשימות
                Console.WriteLine(item);
            }

        }
        catch (Exception e)
        {
            LogManager.WriteToLog("ReadAll", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new Exception("is empty!");
        }
    }
    private static void Read<T>(ICrud<T> crud)
    {
        try
        {
            //מקבל מהמשתמש ID 
            //ושולח לפונקציה קראיה לפי הID הספציפי
            Console.WriteLine("Press Code ID");
            var code = int.Parse(Console.ReadLine());
            Console.WriteLine(crud.Read(code));
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the  id is not exists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalDoesNotExistException("the  id is not exists");

        }
    }
    private static void Delete<T>(ICrud<T> crud)
    {
        try
        {
            //קליטת ID ספציפי
            //ושולח לפונקציה שמוחקת את הרשימה עם ה ID שהתקבל מהמשתמש
            Console.WriteLine("Press Code ID");
            int code = int.Parse(Console.ReadLine());
            crud.Delete(code);
            Console.WriteLine("susside!!!, this is delete");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog("the id is not exists", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new DO.DalDoesNotExistException("the  id is not exists");
        }
    }

    //תפריט
    private static void ProductMenu()
    {
        //שולח לבחירת תפריט
        int select = PrintSubMenu("Product");
        while (select != 0)
        {
            //לפי הבחירת התפריט שולח לפונקציה המתאימה 
            switch (select)
            {
                case 1:
                    ReadAll<Product>(s_dal.Product);
                    break;
                case 2:
                    Read(s_dal.Product);
                    break;
                case 3:
                    UpdateProduct();
                    break;
                case 4:
                    AddProduct();
                    break;
                case 5:
                    Delete<Product>(s_dal.Product);
                    break;
                case 0:
                    Console.WriteLine("go back");
                    break;
                default:
                    Console.WriteLine("worng! press again");
                    break;
            }
            select = PrintSubMenu("Product");
        }
    }
    private static void SaleMenu()
    {
        int select = PrintSubMenu("Sale");
        while (select != 0)
        {
            switch (select)
            {
                //לפי הבחירת התפריט שולח לפונקציה המתאימה 
                case 1:
                    ReadAll<Sale>(s_dal.Sale);
                    break;
                case 2:
                    Read(s_dal.Sale);
                    break;
                case 3:
                    UpdateSale();
                    break;
                case 4:
                    AddSale();
                    break;
                case 5:
                    Delete<Sale>(s_dal.Sale);
                    break;
                case 0:
                    Console.WriteLine("go back");
                    break;
                default:
                    Console.WriteLine("worng! press again");
                    break;
            }
            select = PrintSubMenu("Sale");
        }
    }
    private static void CustemetMenu()
    {
        int select = PrintSubMenu("Custemer");
        while (select != 0)
        {
            switch (select)
            {
                //לפי הבחירת התפריט שולח לפונקציה המתאימה 
                case 1:
                    ReadAll(s_dal.Custemer);
                    break;
                case 2:
                    Read(s_dal.Custemer);
                    break;
                case 3:
                    UpdateCustemer();
                    break;
                case 4:
                    AddCustemer();
                    break;
                case 5:
                    Delete<Custemer>(s_dal.Custemer);
                    break;
                case 0:
                default:
                    Console.WriteLine("worng! press again");
                    break;
            }
            select = PrintSubMenu("Custemer");
        }
    }

    private static void Main(string[] args)
    {
        //יצירת הרשימות לכל יישות
        //Initialization.Initialize();
        //החלפה בשלב 9
        Console.WriteLine("Do you want to initialize data? (Y/N)");
        string? choice = Console.ReadLine();

        if (choice == "Y" || choice == "y")
        {
            Initialization.Initialize();

            try
            {
                //בחירת יישות
                int select = PrintMainMenu();
                while (select != 0)
                {
                    switch (select)
                    {
                        //לפי בחירת הישות שהתקבלה
                        //שולח לתפריט משני של הפונקציות
                        case 1:
                            CustemetMenu();
                            break;
                        case 2:
                            ProductMenu();
                            break;
                        case 3:
                            SaleMenu();
                            break;
                    }
                    select = PrintMainMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("goodbuy");
        }
    }
}