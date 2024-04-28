namespace Group_Practice;

public class GroceryItem
{

    public string ItemName;
    public string ItemStatus;
    public double ItemPrice;
    public GroceryItem(string ItemName)
    {

        this.ItemName = ItemName;
        this.ItemStatus = "On the list";

    
    }

    public GroceryItem(string ItemName, string ItemStatus)
    {
        this.ItemName = ItemName;
        this.ItemStatus = ItemStatus;

    }


}