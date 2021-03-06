using NUnit.Framework;

namespace Cyotek.Data.Nbt.Tests
{
  [TestFixture]
  internal class TagListTests : TestBase
  {
    [Test]
    public void ConstructorTest()
    {
      // arrange
      TagList tag;
      TagType defaultType;

      defaultType = TagType.None;

      // act
      tag = new TagList();

      // assert
      Assert.IsEmpty(tag.Name);
      Assert.IsNotNull(tag.Value);
      Assert.AreSame(tag, tag.Value.Owner);
      Assert.AreEqual(defaultType, tag.ListType);
    }

    [Test]
    public void ConstructorWithNameAndValueTest()
    {
      // arrange
      TagList tag;
      string name;
      TagType value;

      name = "creationDate";
      value = TagType.String;

      // act
      tag = new TagList(name, value);

      // assert
      Assert.AreEqual(name, tag.Name);
      Assert.IsNotNull(tag.Value);
      Assert.AreSame(tag, tag.Value.Owner);
      Assert.AreEqual(value, tag.ListType);
    }

    [Test]
    public void ConstructorWithNameTest()
    {
      // arrange
      TagList tag;
      string name;
      TagType defaultType;

      name = "creationDate";
      defaultType = TagType.None;

      // act
      tag = new TagList(name);

      // assert
      Assert.AreEqual(name, tag.Name);
      Assert.IsNotNull(tag.Value);
      Assert.AreSame(tag, tag.Value.Owner);
      Assert.AreEqual(defaultType, tag.ListType);
    }

    [Test]
    public void ConstructorWithValueTest()
    {
      // arrange
      TagList tag;
      TagType value;

      value = TagType.String;

      // act
      tag = new TagList(value);

      // assert
      Assert.IsEmpty(tag.Name);
      Assert.IsNotNull(tag.Value);
      Assert.AreSame(tag, tag.Value.Owner);
      Assert.AreEqual(value, tag.ListType);
    }

    [Test]
    public void NameTest()
    {
      // arrange
      TagList target;
      string expected;

      target = new TagList();
      expected = "newvalue";

      // act
      target.Name = expected;

      // assert
      Assert.AreEqual(expected, target.Name);
    }

    [Test]
    public void ToStringEmptyTest()
    {
      // arrange
      TagList target;
      string expected;
      string actual;
      string name;
      TagType itemType;

      name = "tagname";
      itemType = TagType.String;
      expected = string.Format("[List: {0}] (0 items)", name);
      target = new TagList(name, itemType);

      // act
      actual = target.ToString();

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToStringEmptyWithIndentTest()
    {
      // arrange
      TagList target;
      string expected;
      string actual;
      string name;
      TagType itemType;
      string prefix;

      prefix = "test";
      name = "tagname";
      itemType = TagType.String;
      expected = string.Format("{1}[List: {0}] (0 items)", name, prefix);
      target = new TagList(name, itemType);

      // act
      actual = target.ToString(prefix);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToStringTest()
    {
      // arrange
      TagList target;
      string expected;
      string actual;
      string name;
      TagType itemType;

      name = "tagname";
      itemType = TagType.String;
      expected = string.Format("[List: {0}] (2 items)", name);
      target = new TagList(name, itemType);
      target.Value.Add("item 1", "value1");
      target.Value.Add("item 2", "value2");

      // act
      actual = target.ToString();

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToStringWithIndentTest()
    {
      // arrange
      TagList target;
      string expected;
      string actual;
      string name;
      TagType itemType;
      string prefix;

      prefix = "test";
      name = "tagname";
      itemType = TagType.String;
      expected = string.Format("{1}[List: {0}] (2 items)", name, prefix);
      target = new TagList(name, itemType);
      target.Value.Add("item 1", "value1");
      target.Value.Add("item 2", "value2");

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

      expected = TagType.List;

      // act
      actual = new TagList().Type;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ValueTest()
    {
      // arrange
      TagList target;
      TagCollection expected;
      TagType defaultType;

      target = new TagList();
      expected = new TagCollection();
      defaultType = TagType.None;

      // act
      target.Value = expected;

      // assert
      Assert.AreEqual(expected, target.Value);
      Assert.IsNotNull(target.Value);
      Assert.AreSame(target, target.Value.Owner);
      Assert.AreEqual(defaultType, target.ListType);
    }
  }
}
