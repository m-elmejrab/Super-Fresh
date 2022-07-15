public class Fruit //Base fruit class
{
    FruitType type;

    public enum FruitType
    {
        Apple,
        Banana,
        Lemon,
        Pear
    }

    public Fruit(FruitType typeCollected)
    {
        this.type = typeCollected;
    }

    public string GetFruitTypeString()
    {
        return type.ToString();
    }

    public FruitType GetFruitType()
    {
        return type;
    }

}
