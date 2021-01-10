using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderingApp
{
    public partial class Form1 : Form
    {
        // Method to Initialize the form and checkboxes
        public Form1()
        {
            InitializeComponent();
            initializeCheckBoxes();
        }

        // List of Items
        public List<Food> foodList = new List<Food>();

        // List of CheckBoxes on the Form
        private List<CheckBox> pizzaCheckBox = new List<CheckBox>();
        private List<CheckBox> pastaCheckBox = new List<CheckBox>();
        private List<CheckBox> saladCheckBox = new List<CheckBox>();
        private List<CheckBox> dessertCheckBox = new List<CheckBox>();
        private List<CheckBox> drinksCheckBox = new List<CheckBox>();
        private List<CheckBox> toppingsCheckBox = new List<CheckBox>();

        // Add each checkbox into a list to keep track of which boxes have been checked
        private void initializeCheckBoxes()
        {
            // Initialize Pizza Styles
            pizzaCheckBox.Add(newYorkStyle);
            pizzaCheckBox.Add(chicagoStyle);
            pizzaCheckBox.Add(sicilianStyle);

            // Initialize Pasta Types
            pastaCheckBox.Add(spaghetti);
            pastaCheckBox.Add(ravioli);
            pastaCheckBox.Add(penne);

            //Initialize Salad Types
            saladCheckBox.Add(greenSalad);
            saladCheckBox.Add(caesarSalad);
            saladCheckBox.Add(waldorfSalad);

            // Initialize Dessert Types
            dessertCheckBox.Add(hotSundae);
            dessertCheckBox.Add(chocolateCake);
            dessertCheckBox.Add(chocChipCookies);
            dessertCheckBox.Add(cremeBrulee);
            dessertCheckBox.Add(flan);
            dessertCheckBox.Add(baklava);

            // Initialize Drink Types
            drinksCheckBox.Add(soda);
            drinksCheckBox.Add(icedTea);
            drinksCheckBox.Add(juice);
            drinksCheckBox.Add(milk);
            drinksCheckBox.Add(beer);
            drinksCheckBox.Add(wine);

            // Initialize Toppings/Add-on Types
            toppingsCheckBox.Add(meatballs);
            toppingsCheckBox.Add(ham);
            toppingsCheckBox.Add(anchovies);
            toppingsCheckBox.Add(sausage);
            toppingsCheckBox.Add(pepperoni);
            toppingsCheckBox.Add(chicken);
            toppingsCheckBox.Add(olives);
            toppingsCheckBox.Add(pineapple);
            toppingsCheckBox.Add(garlic);
            toppingsCheckBox.Add(mushrooms);
            toppingsCheckBox.Add(onions);
            toppingsCheckBox.Add(greenPeppers);
            toppingsCheckBox.Add(tomatoes);
            toppingsCheckBox.Add(broccoli);
            toppingsCheckBox.Add(cheese);
            toppingsCheckBox.Add(shrimp);
            toppingsCheckBox.Add(grilledFish);
            toppingsCheckBox.Add(pesto);
            toppingsCheckBox.Add(roastedTomatoes);
            toppingsCheckBox.Add(pastaMeatballs);
            toppingsCheckBox.Add(grilledChicken);
            toppingsCheckBox.Add(whiteSauce);
            toppingsCheckBox.Add(redSauce);
            toppingsCheckBox.Add(parmCheese);
            toppingsCheckBox.Add(russianDressing);
            toppingsCheckBox.Add(greenGoddess);
            toppingsCheckBox.Add(balsamicVinegar);
            toppingsCheckBox.Add(blueCheese);
            toppingsCheckBox.Add(frenchDressing);
            toppingsCheckBox.Add(ranchDressing);
            toppingsCheckBox.Add(honeyMustard);
            toppingsCheckBox.Add(thousandIsland);
            toppingsCheckBox.Add(italianDressing);
        }

        // Keeping track of total cost of the order
        public double totalCost;

        // Keeping track of which order is in the queue
        public List<Task> orderQueue = new List<Task>();

        // Create a scheduler to manage tasks
        public OrderScheduler scheduler = new OrderScheduler();


        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // When Pizza Button is clicked, show only Pizza Panel
        private void pizzaButton_Click(object sender, EventArgs e)
        {
            pizzaPanel.Visible = true;
            pastaPanel.Visible = false;
            saladPanel.Visible = false;
            dessertPanel.Visible = false;
            drinksPanel.Visible = false;
        }

        // When Pasta Button is clicked, show only Pasta Panel
        private void pastaButton_Click(object sender, EventArgs e)
        {
            pizzaPanel.Visible = false;
            pastaPanel.Visible = true;
            saladPanel.Visible = false;
            dessertPanel.Visible = false;
            drinksPanel.Visible = false;
        }

        // When Dessert Button is clicked, show only Dessert Panel
        private void dessertButton_Click(object sender, EventArgs e)
        {
            pizzaPanel.Visible = false;
            pastaPanel.Visible = false;
            saladPanel.Visible = false;
            dessertPanel.Visible = true;
            drinksPanel.Visible = false;
        }

        // When Salad Button is clicked, show only Salad Panel
        private void saladButton_Click(object sender, EventArgs e)
        {
            pizzaPanel.Visible = false;
            pastaPanel.Visible = false;
            saladPanel.Visible = true;
            dessertPanel.Visible = false;
            drinksPanel.Visible = false;
        }

        // When Drinks Button is clicked, show only Drinks Panel
        private void drinksButton_Click(object sender, EventArgs e)
        {
            pizzaPanel.Visible = false;
            pastaPanel.Visible = false;
            saladPanel.Visible = false;
            dessertPanel.Visible = false;
            drinksPanel.Visible = true;
        }

        // When Close button is pressed, exit the application
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cartItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // When New York Style Button Pressed, Disable other Styles
        private void newYorkStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (newYorkStyle.Checked == true)
            {
                chicagoStyle.Enabled = false;
                sicilianStyle.Enabled = false;
            }
            else
            {
                newYorkStyle.Enabled = true;
                chicagoStyle.Enabled = true;
                sicilianStyle.Enabled = true;
            }
        }

        // When Chicago Style Button Pressed, Disable other Styles
        private void chicagoStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chicagoStyle.Checked == true)
            {
                newYorkStyle.Enabled = false;
                sicilianStyle.Enabled = false;
            }
            else
            {
                newYorkStyle.Enabled = true;
                chicagoStyle.Enabled = true;
                sicilianStyle.Enabled = true;
            }
        }

        // When Sicilian Style Button Pressed, Disable other Styles
        private void sicilianStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (sicilianStyle.Checked == true)
            {
                newYorkStyle.Enabled = false;
                chicagoStyle.Enabled = false;
            }
            else
            {
                newYorkStyle.Enabled = true;
                chicagoStyle.Enabled = true;
                sicilianStyle.Enabled = true;
            }
        }

        // Method for button to handle Items Added to Cart
        private void addToCartButton_Click(object sender, EventArgs e)
        {
            // For every Pizza Item Checked, Add to the Cart AND Add to Pizza List
            for (int i = 0; i < pizzaCheckBox.Count; i++)
            {
                if (pizzaCheckBox[i].Checked == true)
                {
                    // Create a Pizza object and add Pizza Item to the Cart Menu
                    FoodAbs p = new Pizza();
                    cartItems.Items.Add(pizzaCheckBox[i].Text.Trim() + " " + p.getPrice());
                    totalCost += p.addPrice();
                    totalBox.Items.Clear();

                    // Update the Total Cost
                    totalBox.Items.Add(totalCost.ToString("N2"));

                    // Set the style to the pizza object
                    p.setStyle(pizzaCheckBox[i].Text.Trim());

                    // Uncheck Selection
                    pizzaCheckBox[i].Checked = false;


                    // For every Topping Checked
                    for (int j = 0; j < toppingsCheckBox.Count; j++)
                    {
                        if (toppingsCheckBox[j].Checked == true)
                        {
                            // Create a toppings object and add each Topping Item to the Cart Menu
                            Toppings t = new PizzaToppings();
                            cartItems.Items.Add(toppingsCheckBox[j].Text.Trim() + " " + t.getPrice());
                            totalCost += t.addPrice();
                            totalBox.Items.Clear();
                            totalBox.Items.Add(totalCost.ToString("N2"));

                            // Add each topping to the pizza object's list of toppings
                            p.addOns.Add(t.addToppings(toppingsCheckBox[j].Text.Trim()));

                            // Uncheck all the toppings selected
                            toppingsCheckBox[j].Checked = false;
                        }
                    }
                    // Add the food object to the list for the order
                    foodList.Add(p);

                }
            }

            // For every Pasta Item Checked, Add to the Cart AND Add to Pasta List
            for (int i = 0; i < pastaCheckBox.Count; i++)
            {
                if (pastaCheckBox[i].Checked == true)
                {
                    // Create a Pasta object and add Pasta Item to the Cart Menu
                    FoodAbs p = new Pasta();
                    cartItems.Items.Add(pastaCheckBox[i].Text.Trim() + " " + p.getPrice());
                    totalCost += p.addPrice();
                    totalBox.Items.Clear();

                    // Update the Total Cost
                    totalBox.Items.Add(totalCost.ToString("N2"));

                    // Set the style to the pasta object
                    p.setStyle(pastaCheckBox[i].Text.Trim());

                    // Uncheck Selection
                    pastaCheckBox[i].Checked = false;

                    // For every Topping Checked
                    for (int j = 0; j < toppingsCheckBox.Count; j++)
                    {
                        if (toppingsCheckBox[j].Checked == true)
                        {
                            // Create a toppings object and add each Topping Item to the Cart Menu
                            Toppings t = new PastaToppings();
                            cartItems.Items.Add(toppingsCheckBox[j].Text.Trim() + " " + t.getPrice());
                            totalCost += t.addPrice();
                            totalBox.Items.Clear();
                            totalBox.Items.Add(totalCost.ToString("N2"));

                            // Add each topping to the pasta object's list of toppings
                            p.addOns.Add(t.addToppings(toppingsCheckBox[j].Text.Trim()));

                            // Uncheck all the toppings selected
                            toppingsCheckBox[j].Checked = false;
                        }
                    }
                    // Add the food object to the list for the order
                    foodList.Add(p);
                    
                }
            }

            // For every Salad Item Checked, Add to the Cart AND Add to Salad List
            for (int i = 0; i < saladCheckBox.Count; i++)
            {
                if (saladCheckBox[i].Checked == true)
                {
                    // Create a Salad object and add Salad Item to the Cart Menu
                    FoodAbs s = new Salad();
                    cartItems.Items.Add(saladCheckBox[i].Text.Trim() + " " + s.getPrice());
                    totalCost += s.addPrice();
                    totalBox.Items.Clear();

                    // Update the Total Cost
                    totalBox.Items.Add(totalCost.ToString("N2"));

                    // Set the style to the salad object
                    s.setStyle(saladCheckBox[i].Text.Trim());

                    // Uncheck Selection
                    saladCheckBox[i].Checked = false;

                    // For every Topping Checked
                    for (int j = 0; j < toppingsCheckBox.Count; j++)
                    {
                        if (toppingsCheckBox[j].Checked == true)
                        {
                            // Create a toppings object and add each Topping Item to the Cart Menu
                            Toppings t = new SaladDressing();
                            cartItems.Items.Add(toppingsCheckBox[j].Text.Trim() + " " + t.getPrice());
                            totalCost += t.addPrice();
                            totalBox.Items.Clear();
                            totalBox.Items.Add(totalCost.ToString("N2"));

                            // Add each topping to the salad object's list of toppings
                            s.addOns.Add(t.addToppings(toppingsCheckBox[j].Text.Trim()));

                            // Uncheck all the toppings selected
                            toppingsCheckBox[j].Checked = false;
                        }
                    }
                    // Add the food object to the list for the order
                    foodList.Add(s);

                }
            }

            // For every Dessert Item Checked, Add to the Cart AND Add to Dessert List
            for (int i = 0; i < dessertCheckBox.Count; i++)
            {
                if (dessertCheckBox[i].Checked == true)
                {
                    // Create a Dessert object and add Dessert Item to the Cart Menu
                    FoodAbs d = new Dessert();
                    cartItems.Items.Add(dessertCheckBox[i].Text.Trim() + " " + d.getPrice());
                    totalCost += d.addPrice();
                    totalBox.Items.Clear();

                    // Update the Total Cost
                    totalBox.Items.Add(totalCost.ToString("N2"));
                    
                    // Set the name of the Dessert item selected
                    d.setName(dessertCheckBox[i].Text.Trim());

                    // Add the food object to the list for the order
                    foodList.Add(d);

                    // Uncheck Selection
                    dessertCheckBox[i].Checked = false;
                }
            }

            // For every Drinks Item Checked, Add to the Cart AND Add to Drinks List
            for (int i = 0; i < drinksCheckBox.Count; i++)
            {
                if (drinksCheckBox[i].Checked == true)
                {
                    // Create a Drink object and add Drink Item to the Cart Menu
                    FoodAbs d = new Drinks();
                    cartItems.Items.Add(drinksCheckBox[i].Text.Trim() + " " + d.getPrice());
                    totalCost += d.addPrice();
                    totalBox.Items.Clear();

                    // Update the Total Cost
                    totalBox.Items.Add(totalCost.ToString("N2"));

                    // Set the name of the Dessert item selected
                    d.setName(drinksCheckBox[i].Text.Trim());

                    // Add the food object to the list for the order
                    foodList.Add(d);

                    // Uncheck Selection
                    drinksCheckBox[i].Checked = false;
                }
            }
        }

        // Method to handle orders when submited
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Call the scheduler 
            using (scheduler)
            {
                // Create a new order and call the method to acknowledge the order
                Task newOrder = new Task(() =>
                {
                    processOrder();
                });

                // Add the Order to the Queue
                orderQueue.Add(newOrder);

                // For Each Order that's in the queue, start the scheduler
                foreach (Task order in orderQueue)
                {
                    order.Start(scheduler);
                }

            }

            // Print to Status Box the order confirmation once processed by the Scheduler
            statusBox.Items.Add("Order Accepted! " + DateTime.Now.ToString());

            // Call The Main Method that Makes the Food
            makeFood();
        }

        // Method called by the Scheduler to show task is handled in the queue and which Thread is being managed
        public static void processOrder()
        {
            string msg = ("New Order Processed: " + DateTime.Now.ToString() + " on Thread " + Thread.CurrentThread.ManagedThreadId.ToString());
            MessageBox.Show(msg);
        }

        // Main method to make food
        public void makeFood()
        {
            // Call the Factory object to create food items
            FoodFactory factory = new FoodFactory();
            FoodAbs food = null;

            // For each food item in the order
            foreach (FoodAbs foodItem in foodList)
            {
                // Call Factory's prepareFood method to "make" the food
                food = factory.prepareFood(foodItem.getType());

                // As long as the food item is not null
                if (food != null)
                {
                    // Tell Customer what Food is being made
                    statusBox.Items.Add("Making " + foodItem.getType());

                    // If Food is Dessert or Drinks, get name of the item from the subclass
                    if (foodItem.getType() == "Dessert" || foodItem.getType() == "Drinks")
                    {
                        statusBox.Items.Add("That is " + foodItem.getName());
                    }

                    // If there are toppings/additions added to the food item, list all the toppings that were added
                    if(foodItem.addOns.Count != 0)
                    {
                        for (int i = 0; i < foodItem.addOns.Count; i++)
                        {
                            statusBox.Items.Add("Adding toppings of " + foodItem.addOns[i].getName());
                        }
                    }

                    // If the food item has a style/type (using the Wrapper), call the Wrapper and list which wrapper is used
                    if (foodItem.style != null)
                    {
                        FoodAbs temp = foodItem;
                        string tempString = foodItem.style;

                        switch(tempString)
                        {
                            case "New York Style":
                                temp = new NYStyle(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Chicago Style":
                                temp = new ChicagoStyle(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Sicilian Style":
                                temp = new Sicilian(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Spaghetti":
                                temp = new Spaghetti(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Ravioli":
                                temp = new Ravioli(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Penne":
                                temp = new Penne(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Green Salad":
                                temp = new GreenSalad(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Caesar Salad":
                                temp = new Caesar(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            case "Waldorf Salad":
                                temp = new Waldorf(temp);
                                statusBox.Items.Add(temp.getStyle());
                                break;
                            default:
                                break;
                        }    

                    }
                }
            }

            // Call the Chain of Responsibility method to find out which delivery person will deliver the order
            statusBox.Items.Add(getDeliveryPerson(foodList));
            statusBox.Items.Add("Thank you!!!");
        }

        // Method to call the Chain of Responsibility class
        public string getDeliveryPerson(List<Food> foodOrder)
        {
            Chain chainHot = new HotFoodDelivery("Bob");
            Chain chainCold = new ColdFoodDelivery("Kelly");
            Chain chainBoth = new HotAndColdDelivery("Michael");

            chainHot.setNextChain(chainCold);
            chainCold.setNextChain(chainBoth);

            return chainHot.deliverOrder(foodOrder);
        }
    }

    // Food Interface with shared methods
    public interface Food
    {
        public string getType();

        public string getPrice();
    }

    // Food Abstract Class for Different Food Items
    public abstract class FoodAbs : Food
    {
        private string type;
        private double price;
        public string name;
        public string style;
        public List<FoodAbs> addOns = new List<FoodAbs>();

        public string getType()
        {
            return type;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getPrice()
        {
            return String.Format("{0:0.00}", price);
        }

        public string getName()
        {
            return name;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public double addPrice()
        {
            return price;
        }

        public virtual string getStyle()
        {
            return style;
        }

        public void setStyle(string style)
        {
            this.style = style;
        }
    }

    public abstract class SeasonalItems : FoodAbs
    {

    }

    // Pizza as a subclass of FoodAbs
    public class Pizza : SeasonalItems
    {
        public Pizza()
        {
            setType("Pizza");
            setPrice(20.00);
        }
    }

    // Pasta as a subclass of FoodAbs
    public class Pasta : SeasonalItems
    {
        public Pasta()
        {
            setType("Pasta");
            setPrice(15.00);
        }
    }

    // Salad as a subclass of FoodAbs
    public class Salad : SeasonalItems
    {
        public Salad()
        {
            setType("Salad");
            setPrice(10.00);
        }
    }

    // Dessert as a subclass of FoodAbs
    public class Dessert : FoodAbs
    {
        public Dessert()
        {
            setType("Dessert");
            setPrice(5.00);
        }
    }

    // HotSundae is a concerte subclass of Dessert
    public class HotSundae : Dessert
    {
        public HotSundae() 
        {
            setName("Hot Sundae");
        }
    }

    // ChocolateCake is a concrete subclass of Dessert
    public class ChocolateCake : Dessert
    {
        public ChocolateCake()
        {
            setName("Chocolate Cake");
        }
    }

    // ChocChipCookie is a concerte subclass of Dessert
    public class ChocChipCookie : Dessert
    {
        public ChocChipCookie()
        {
            setName("Choc Chip Cookie");
        }
    }

    // CremeBrulee is a concrete subclass of Dessert
    public class CremeBrulee : Dessert
    {
        public CremeBrulee()
        {
            setName("Creme Brulee");
        }
    }

    // Flan is a concerte subclass of Dessert
    public class Flan : Dessert
    {
        public Flan()
        {
            setName("Flan");
        }
    }

    // Baklava is a concerete subclass of Dessert
    public class Baklava : Dessert
    {
        public Baklava()
        {
            setName("Baklava");
        }
    }

    // Drinks is a subclass of FoodAbs
    public class Drinks : FoodAbs
    {
        public Drinks()
        {
            setType("Drinks");
            setPrice(3.00);
        }
    }

    // Soda is a concrete subclass of Drinks
    public class Soda : Drinks
    {
        public Soda()
        {
            setName("Soda");
        }
    }

    // IcedTea is a concrete subclass of Drinks
    public class IcedTea : Drinks
    {
        public IcedTea()
        {
            setName("Iced Tea");
        }
    }

    // Juice is a concrete subclass of Drinks
    public class Juice : Drinks
    {
        public Juice()
        {
            setName("Juice");
        }
    }

    // Milk is a concrete subclass of Drinks
    public class Milk : Drinks
    {
        public Milk()
        {
            setName("Milk");
        }
    }

    // Beer is a concrete subclass of Drinks
    public class Beer : Drinks
    {
        public Beer()
        {
            setName("Beer");
        }
    }

    // Wine is a concrete subclass of Drinks
    public class Wine : Drinks
    {
        public Wine()
        {
            setName("Wine");
        }
    }

    // ToppingsComposite is a subclass of FoodAbs
    public abstract class Toppings : FoodAbs
    {
        public Toppings()
        {
            setType("Toppings");
            setPrice(0.50);
        }

        public abstract FoodAbs addToppings(string topping);

    }

    // Order Scheduler for the Scheduler Pattern Implementation
    public sealed class OrderScheduler : TaskScheduler, IDisposable
    {
        // Create a list of Tasks
        private BlockingCollection<Task> orderCollection = new BlockingCollection<Task>();

        // Create a new thread
        private Thread mainThread = null;

        // When Scheduler object is created, start and execute the new thread
        public OrderScheduler()
        {
            mainThread = new Thread(new ThreadStart(Execute));
            if (!mainThread.IsAlive)
            {
                mainThread.Start();
            }
        }

        // Method to Execute the orders in the queue
        private void Execute()
        {
            foreach (var order in orderCollection.GetConsumingEnumerable())
            {
                TryExecuteTask(order);
            }
        }

        // Get the task within the array
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return orderCollection.ToArray<Task>();
        }

        // Add orders into the queue
        protected override void QueueTask(Task task)
        {
            orderCollection.Add(task);

            if (!mainThread.IsAlive)
            {
                mainThread.Start();
            }
        }

        // Check to see if task can be executed
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }

        // Terminate when completed
        public void Dispose()
        {
            orderCollection.CompleteAdding();
        }
    }

    // Food Factory for Factory Pattern Implementation
    public class FoodFactory
    {
        // Prepare food items when retrieved from teh order
        public FoodAbs prepareFood(String newFoodType)
        {
            FoodAbs foodType = null;

            // Call the corresponding class when string matches food item
            switch (newFoodType)
            {
                case "Pizza":
                    return new Pizza();
                case "Pasta":
                    return new Pasta();
                case "Salad":
                    return new Salad();
                case "Dessert":
                    return new Dessert();
                case "Drinks":
                    return new Drinks();
                default:
                    return foodType;

            }
        }
    }

    // Composite Pattern Implementation
    // PizzaToppingsComposite is a subset of Toppings in the ToppingsComposite class
    public class PizzaToppings : Toppings
    {
        // Add the appropriate topping for the pizza object
        public override FoodAbs addToppings(string topping)
        {
            switch (topping)
            {
                case "Meatballs":
                    return new PizzaMeatBalls();
                case "Ham":
                    return new Ham();
                case "Anchovies":
                    return new Anchovies();
                case "Sausage":
                    return new Sausage();
                case "Pepperoni":
                    return new Pepperoni();
                case "Chicken":
                    return new Chicken();
                case "Olives":
                    return new Olives();
                case "Pineapple":
                    return new Pineapple();
                case "Garlic":
                    return new Garlic();
                case "Mushrooms":
                    return new Mushrooms();
                case "Onions":
                    return new Onions();
                case "Green Peppers":
                    return new GreenPeppers();
                case "Tomatoes":
                    return new Tomatoes();
                case "Broccoli":
                    return new Broccoli();
                case "Extra Cheese":
                    return new ExtraCheese();
                default:
                    return null;
            }
        }
    }

    // PizzaMeatBalls is a type of Pizza topping
    public class PizzaMeatBalls : PizzaToppings
    {
        public PizzaMeatBalls()
        {
            setName("Meatballs");
        }
    }

    // Ham is a type of Pizza topping
    public class Ham : PizzaToppings
    {
        public Ham()
        {
            setName("Ham");
        }
    }

    // Anchovies is a type of Pizza topping
    public class Anchovies : PizzaToppings
    {
        public Anchovies()
        {
            setName("Anchovies");
        }
    }

    // Sausage is a type of Pizza topping
    public class Sausage : PizzaToppings
    {
        public Sausage()
        {
            setName("Sausage");
        }
    }

    // Pepperoni is a type of Pizza topping
    public class Pepperoni : PizzaToppings
    {
        public Pepperoni()
        {
            setName("Pepperoni");
        }
    }

    // Chicken is a type of Pizza topping
    public class Chicken : PizzaToppings
    {
        public Chicken()
        {
            setName("Chicken");
        }
    }

    // Olives is a type of Pizza topping
    public class Olives : PizzaToppings
    {
        public Olives()
        {
            setName("Olives");
        }
    }

    // Pineapple is a type of Pizza topping
    public class Pineapple : PizzaToppings
    {
        public Pineapple()
        {
            setName("Pineapple");
        }
    }

    // Garlic is a type of Pizza topping
    public class Garlic : PizzaToppings
    {
        public Garlic()
        {
            setName("Garlic");
        }
    }

    // Mushrooms is a type of Pizza topping
    public class Mushrooms : PizzaToppings
    {
        public Mushrooms()
        {
            setName("Mushrooms");
        }
    }

    // Onions is a type of Pizza topping
    public class Onions : PizzaToppings
    {
        public Onions()
        {
            setName("Onions");
        }
    }

    // GreenPeppers is a type of Pizza topping
    public class GreenPeppers : PizzaToppings
    {
        public GreenPeppers()
        {
            setName("Green Peppers");
        }
    }

    // Tomatoes is a type of Pizza topping
    public class Tomatoes : PizzaToppings
    {
        public Tomatoes()
        {
            setName("Tomatoes");
        }
    }

    // Broccoli is a type of Pizza topping
    public class Broccoli : PizzaToppings
    {
        public Broccoli()
        {
            setName("Broccoli");
        }
    }

    // ExtraCheese is a type of Pizza topping
    public class ExtraCheese : PizzaToppings
    {
        public ExtraCheese()
        {
            setName("Extra Cheese");
        }
    }

    // PastaToppingsComposite is a subset of Toppings in the ToppingsComposite class
    public class PastaToppings : Toppings
    {
        // Add the appropriate topping to the pasta object
        public override FoodAbs addToppings(string topping)
        {
            switch (topping)
            {
                case "Shrimp":
                    return new Shrimp();
                case "Grilled Fish":
                    return new GrilledFish();
                case "Pesto":
                    return new Pesto();
                case "Roasted Tomatoes":
                    return new RoastedTomatoes();
                case "Meatballs":
                    return new PastaMeatBalls();
                case "Grilled Chicken":
                    return new GrilledChicken();
                case "White Sauce":
                    return new WhiteSauce();
                case "Red Sauce":
                    return new RedSauce();
                case "Parmesan Cheese":
                    return new ParmesanCheese();
                default:
                    return null;
            }
        }
    }

    // Shrimp is a type of Pasta topping
    public class Shrimp : PastaToppings
    {
        public Shrimp()
        {
            setName("Shrimp");
        }
    }

    // GrilledFish is a type of Pasta topping
    public class GrilledFish : PastaToppings
    {
        public GrilledFish()
        {
            setName("Grilled Fish");
        }
    }

    // Pesto is a type of Pasta topping
    public class Pesto : PastaToppings
    {
        public Pesto()
        {
            setName("Pesto");
        }
    }

    // RoastedTomatoes is a type of Pasta topping
    public class RoastedTomatoes : PastaToppings
    {
        public RoastedTomatoes()
        {
            setName("Roasted Tomatoes");
        }
    }

    // PastaMeatBalls is a type of Pasta topping
    public class PastaMeatBalls : PastaToppings
    {
        public PastaMeatBalls()
        {
            setName("Meatballs");
        }
    }


    // GrilledChicken is a type of Pasta topping
    public class GrilledChicken : PastaToppings
    {
        public GrilledChicken()
        {
            setName("Grilled Chicken");
        }
    }


    // WhiteSauce is a type of Pasta topping
    public class WhiteSauce : PastaToppings
    {
        public WhiteSauce()
        {
            setName("White Sauce");
        }
    }

    // RedSauce is a type of Pasta topping
    public class RedSauce : PastaToppings
    {
        public RedSauce()
        {
            setName("Red Sauce");
        }
    }

    // ParmesanCheese is a type of Pasta topping
    public class ParmesanCheese : PastaToppings
    {
        public ParmesanCheese()
        {
            setName("Parmesan Cheese");
        }
    }

    // SaladToppingsComposite is a subset of Toppings in the ToppingsComposite class
    public class SaladDressing : Toppings
    {
        // Add appropriate salad dressings to the salad object
        public override FoodAbs addToppings(string topping)
        {
            switch (topping)
            {
                case "Russian Dressing":
                    return new RussianDressing();
                case "Green Goddess Dressing":
                    return new GreenGoddessDressing();
                case "Balsamic Vinegar":
                    return new BalsamicVinegar();
                case "Blue Cheese Dressing":
                    return new BlueCheeseDressing();
                case "French Dressing":
                    return new FrenchDressing();
                case "Ranch Dressing":
                    return new RanchDressing();
                case "Honey Mustard Dressing":
                    return new HoneyMustardDressing();
                case "Thousand Island Dressing":
                    return new ThousandIslandDressing();
                case "Italian Dressing":
                    return new ItalianDressing();
                default:
                    return null;
            }
        }
    }

    // RussianDressing is a type of Salad topping
    public class RussianDressing : SaladDressing
    {
        public RussianDressing()
        {
            setName("Russian Dressing");
        }
    }

    // GreenGoddessDressing is a type of Salad topping
    public class GreenGoddessDressing : SaladDressing
    {
        public GreenGoddessDressing()
        {
            setName("Green Goddess Dressing");
        }
    }

    // BalsamicVinegar is a type of Salad topping
    public class BalsamicVinegar : SaladDressing
    {
        public BalsamicVinegar()
        {
            setName("Balsamic Vinegar");
        }
    }

    // BlueCheeseDressing is a type of Salad topping
    public class BlueCheeseDressing : SaladDressing
    {
        public BlueCheeseDressing()
        {
            setName("Blue Cheese Dressing");
        }
    }

    // FrenchDressing is a type of Salad topping
    public class FrenchDressing : SaladDressing
    {
        public FrenchDressing()
        {
            setName("French Dressing");
        }
    }

    // RanchDressing is a type of Salad topping
    public class RanchDressing : SaladDressing
    {
        public RanchDressing()
        {
            setName("Ranch Dressing");
        }
    }

    // HoneyMustardDressing is a type of Salad topping
    public class HoneyMustardDressing : SaladDressing
    {
        public HoneyMustardDressing()
        {
            setName("Honey Mustard Dressing");
        }
    }

    // ThousandIslandDressing is a type of Salad topping
    public class ThousandIslandDressing : SaladDressing
    {
        public ThousandIslandDressing()
        {
            setName("Thousand Island Dressing");
        }
    }

    // ItalianDressing is a type of Salad topping
    public class ItalianDressing : SaladDressing
    {
        public ItalianDressing()
        {
            setName("Italian Dressing");
        }
    }

    // Implementation of the Decorator Pattern
    public abstract class Wrappers : FoodAbs
    {

    }

    // Pizza Wrapper is a subclass of Wrappers
    public abstract class pizzaWrapper : Wrappers
    {
        public FoodAbs pizza;

        public pizzaWrapper(FoodAbs pizza)
        {
            this.pizza = pizza;
        }

        public override string getStyle()
        {
            return this.pizza.getStyle();
        }
    }

    // Concrete NYStyle wrapper for Pizza Wrapper
    public class NYStyle : pizzaWrapper
    {
        public NYStyle(FoodAbs pizza) : base(pizza)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it NY Style crust";
        }
    }

    // Concrete Chicago wrapper for Pizza Wrapper
    public class ChicagoStyle : pizzaWrapper
    {
        public ChicagoStyle(FoodAbs pizza) : base(pizza)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Chicago Style crust";
        }
    }

    // Concrete Scilian wrapper for Pizza Wrapper
    public class Sicilian : pizzaWrapper
    {
        public Sicilian(FoodAbs pizza) : base(pizza)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Sicilian Style crust";
        }
    }

    // Pasta Wrapper is a subclass of Wrappers
    public abstract class pastaWrapper : Wrappers
    {
        public FoodAbs pasta;

        public pastaWrapper(FoodAbs pasta)
        {
            this.pasta = pasta;
        }

        public override string getStyle()
        {
            return this.pasta.getStyle();
        }
    }

    // Concrete Spaghetti wrapper for Pasta Wrapper
    public class Spaghetti : pastaWrapper
    {
        public Spaghetti(FoodAbs pasta) : base(pasta)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Spaghetti type pasta";
        }
    }

    // Concrete Ravioli wrapper for Pasta Wrapper
    public class Ravioli : pastaWrapper
    {
        public Ravioli(FoodAbs pasta) : base(pasta)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Ravioli type pasta";
        }
    }

    // Concrete Penne wrapper for Pasta Wrapper
    public class Penne : pastaWrapper
    {
        public Penne(FoodAbs pasta) : base(pasta)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Penne type pasta";
        }
    }

    // Salad Wrapper is a subclass of Wrappers
    public abstract class saladWrapper : Wrappers
    {
        public FoodAbs salad;

        public saladWrapper(FoodAbs salad)
        {
            this.salad = salad;
        }

        public override string getStyle()
        {
            return this.salad.getStyle();
        }
    }

    // Concrete Waldorf wrapper for Salad Wrapper
    public class Waldorf : saladWrapper
    {
        public Waldorf(FoodAbs salad) : base(salad)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Waldorf type salad";
        }
    }

    // Concrete Caesar wrapper for Salad Wrapper
    public class Caesar : saladWrapper
    {
        public Caesar(FoodAbs salad) : base(salad)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Caesar type salad";
        }
    }

    // Concrete GreenSalad wrapper for Salad Wrapper
    public class GreenSalad : saladWrapper
    {
        public GreenSalad(FoodAbs salad) : base(salad)
        {

        }

        public override string getStyle()
        {
            return "Use wrapper to make it Green type salad";
        }
    }

    // Implemenation of Chain of Responsibility
    // Chain interface of shared methods
    public interface Chain
    {
        public void setNextChain(Chain nextChain);

        public string deliverOrder(List<Food> foodOrder);

        public string getName();
    }

    // Concrete Chain for handling Hot Foods Only
    public class HotFoodDelivery : Chain
    {
        private Chain nextInChain;
        private string name;

        // Set delivery person's name
        public HotFoodDelivery(string name)
        {
            this.name = name;
        }

        // Set their next chain of responsibility
        public void setNextChain(Chain nextChain)
        {
            nextInChain = nextChain;
        }

        // Get the person's name
        public string getName()
        {
            return this.name;
        }

        // If order consists of cold foods, pass off to the next delivery person - otherwise handle the request
        public string deliverOrder(List<Food> foodOrder)
        {
            foreach (Food item in foodOrder)
            {
                if (item.getType() == "Salad" || item.getType() == "Dessert")
                {
                    return nextInChain.deliverOrder(foodOrder);
                }
            }

            return getName() + " will be your delivery person!";
        }
    }

    // Concrete Chain for handling Cold Foods Only
    public class ColdFoodDelivery : Chain
    {
        private Chain nextInChain;
        private string name;

        // Set the delivery person's name
        public ColdFoodDelivery(string name)
        {
            this.name = name;
        }

        // Set the next Chain of Responsibility
        public void setNextChain(Chain nextChain)
        {
            nextInChain = nextChain;
        }

        // Get Person's name
        public string getName()
        {
            return this.name;
        }

        // If order consists of hot foods, pass off to the next delivery person - otherwise handle the request
        public string deliverOrder(List<Food> foodOrder)
        {
            foreach (Food item in foodOrder)
            {
                if(item.getType() == "Pizza" || item.getType() == "Pasta")
                {
                    return nextInChain.deliverOrder(foodOrder);
                }
            }
            return getName() + " will be your delivery person";
        }
    }

    // Concrete Chain that can handle both Hot and Cold Food Items at the same time
    public class HotAndColdDelivery : Chain
    {
        private Chain nextInChain;
        private string name;

        // Set delivery person's name
        public HotAndColdDelivery(string name)
        {
            this.name = name;
        }

        // Set next chain of responsbility
        public void setNextChain(Chain nextChain)
        {
            nextInChain = nextChain;
        }

        // Get person's name
        public string getName()
        {
            return this.name;
        }

        // Last in the chain, handle the order
        public string deliverOrder(List<Food> foodOrder)
        {
            return getName() + " will be your delivery person";
        }
    }
}
