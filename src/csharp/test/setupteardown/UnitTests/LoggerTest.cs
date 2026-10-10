namespace UnitTests;

public class LoggerTest
{
  string filename = "LoggerTest.txt";
  Logger logger;
  
  string ReadFile () {
    return System.IO.File.ReadAllText(filename);
  }
  
  [SetUp]
  public void Setup()
  {
    System.IO.File.WriteAllText(filename, "");
    logger = new Logger(filename);
  }
  
  [TearDown]
  public void Teardown()
  {
    System.IO.File.Delete(filename);
  }
  
  [Test]
  public void TestEmpty()
  {
    logger.Append("");
    Assert.That(ReadFile(), Is.EqualTo(""));
  }
  
  [Test]
  public void TestSingleCharacter()
  {
    logger.Append("a");
    Assert.That(ReadFile(), Is.EqualTo("a"));
    logger.Append("a");
    Assert.That(ReadFile(), Is.EqualTo("aa"));
  }
}
