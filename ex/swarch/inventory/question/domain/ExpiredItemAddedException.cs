namespace Domain
{
  public class ExpiredItemAddedException : Exception
  {
    public ExpiredItemAddedException () :
           base("Attempted to add expired product to database")
    {}
  }
}
