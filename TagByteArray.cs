﻿using System;
using System.IO;

namespace Cyotek.Data.Nbt
{
  [TagEditor("Cyotek.Windows.Forms.Nbt.TagByteArrayEditor, Cyotek.Windows.Forms.Nbt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9d164292f52c48c9")]
  public class TagByteArray : Tag
  {
    #region  Public Constructors

    public TagByteArray()
      : this(string.Empty, new byte[0])
    { }

    public TagByteArray(string name)
      : this(name, new byte[0])
    { }

    public TagByteArray(byte[] value)
      : this(string.Empty, value)
    { }

    public TagByteArray(Stream input)
    {
      this.Name = TagString.ReadString(input);
      this.Value = ReadByteArray(input);
    }

    public TagByteArray(string name, byte[] value)
    {
      this.Name = name;
      this.Value = value;
    }

    #endregion  Public Constructors

    #region  Overriden Properties

    public override TagType Type
    {
      get { return TagType.ByteArray; }
    }

    #endregion  Overriden Properties

    #region  Internal Class Methods

    internal static byte[] ReadByteArray(Stream input)
    {
      int length = TagInt.ReadInt(input);

      byte[] bytes = new byte[length];
      if (length != input.Read(bytes, 0, length))
      {
        throw new Exception();
      }

      return bytes;
    }

    internal static TagByteArray ReadUnnamedTagByteArray(Stream input)
    {
      return new TagByteArray() { Value = ReadByteArray(input) };
    }

    internal static void WriteByteArray(Stream output, byte[] value)
    {
      if (value != null)
      {
        TagInt.WriteInt(output, value.Length);
        output.Write(value, 0, value.Length);
      }
      else
      {
        TagInt.WriteInt(output, 0);
      }
    }

    #endregion  Internal Class Methods

    #region  Public Overridden Methods

    public override string ToString(string indentString)
    {
      return string.Format("{0}[Byte_Array: {1}={2} Bytes", indentString, Name, (Value != null) ? Value.Length : 0);
    }

    public override void Write(Stream output)
    {
      output.WriteByte((byte)Type);
      TagString.WriteString(output, Name);
      TagByteArray.WriteByteArray(output, Value);
    }

    public override void WriteUnnamed(Stream output)
    {
      WriteByteArray(output, Value);
    }

    #endregion  Public Overridden Methods

    #region  Public Properties

    public new byte[] Value
    {
      get { return (byte[])base.Value; }
      set { base.Value = value; }
    }

    #endregion  Public Properties
  }
}