using NUnit.Framework;

namespace Cyotek.Data.Nbt.Tests
{
  [TestFixture]
  internal class TagIntArrayTests : TestBase
  {
    [Test]
    public void ConstructorTest()
    {
      // arrange
      TagIntArray tag;
      int[] expected;

      expected = new int[0];

      // act
      tag = new TagIntArray();

      // assert
      Assert.IsEmpty(tag.Name);
      CollectionAssert.AreEqual(expected, tag.Value);
    }

    [Test]
    public void ConstructorWithNameAndValueTest()
    {
      // arrange
      TagIntArray tag;
      string name;
      int[] value;

      name = "creationDate";
      value = new[] { int.MinValue, int.MaxValue };

      // act
      tag = new TagIntArray(name, value);

      // assert
      Assert.AreEqual(name, tag.Name);
      CollectionAssert.AreEqual(value, tag.Value);
    }

    [Test]
    public void ConstructorWithNameTest()
    {
      // arrange
      TagIntArray tag;
      string name;
      int[] expected;

      name = "creationDate";
      expected = new int[0];

      // act
      tag = new TagIntArray(name);

      // assert
      Assert.AreEqual(name, tag.Name);
      CollectionAssert.AreEqual(expected, tag.Value);
    }

    [Test]
    public void ConstructorWithValueTest()
    {
      // arrange
      TagIntArray tag;
      int[] value;

      value = new[] { int.MinValue, int.MaxValue };

      // act
      tag = new TagIntArray(value);

      // assert
      Assert.IsEmpty(tag.Name);
      CollectionAssert.AreEqual(value, tag.Value);
    }

    [Test]
    public void NameTest()
    {
      // arrange
      TagIntArray target;
      string expected;

      target = new TagIntArray();
      expected = "newvalue";

      // act
      target.Name = expected;

      // assert
      Assert.AreEqual(expected, target.Name);
    }

    [Test]
    public void ToStringTest()
    {
      // arrange
      TagIntArray target;
      string expected;
      string actual;
      string name;
      int[] value;

      name = "tagname";
      value = new[] { int.MinValue, int.MaxValue };
      expected = string.Format("[IntArray: {0}={1} values]", name, value.Length);
      target = new TagIntArray(name, value);

      // act
      actual = target.ToString();

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToStringWithIndentTest()
    {
      // arrange
      TagIntArray target;
      string expected;
      string actual;
      string name;
      int[] value;
      string prefix;

      prefix = "test";
      name = "tagname";
      value = new[] { int.MinValue, int.MaxValue };
      expected = string.Format("{2}[IntArray: {0}={1} values]", name, value.Length, prefix);
      target = new TagIntArray(name, value);

      // act
      actual = target.ToString(prefix);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TypeTest()
    {
      // arrange
      TagType expected;
      TagType actual;

      expected = TagType.IntArray;

      // act
      actual = new TagIntArray().Type;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ValueTest()
    {
      // arrange
      TagIntArray target;
      int[] expected;

      target = new TagIntArray();
      expected = new[] { int.MinValue, int.MaxValue };

      // act
      target.Value = expected;

      // assert
      CollectionAssert.AreEqual(expected, target.Value);
    }
  }
}
