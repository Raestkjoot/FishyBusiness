public partial class Fish
{
    public enum FishType
    {
        A,
        B,
        C,
    }
    public static string GetFishName(FishType type)
    {
        switch (type)
        {
            case FishType.A:
                return "A";
            case FishType.B:
                return "B";
            case FishType.C:
                return "C";
        }
    
        return "Error";
    }
}