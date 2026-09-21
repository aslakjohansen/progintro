namespace UnitTests;

public class UtilTest
{
  [Test]
  public void Test1 () {
    Assert.That(Util.Add(1,2), Is.EqualTo(4));
  }
}
