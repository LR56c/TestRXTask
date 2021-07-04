using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public struct MyBool : IEquatable<MyBool>
{
    [FieldOffset(0)]
    private int value;

    internal const int True = 1;
    internal const int False = 0;
    internal const string TrueLiteral = "True";
    internal const string FalseLiteral = "False";

    public bool Equals(MyBool other) => value == other.value;

    public override string ToString() => value != 0 ? TrueLiteral : FalseLiteral;

    public override bool Equals(object obj) => obj is MyBool other && Equals(other);

    public override int GetHashCode() => value;

    public static implicit operator bool(MyBool val) => val.value == 1;

    public static implicit operator MyBool(bool val)
    {
        MyBool myBool;
        myBool.value = val ? True : False;
        return myBool;
    }
}