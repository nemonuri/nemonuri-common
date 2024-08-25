namespace Nemonuri.Common.Primitives.Test;

using Models;

public class ListToStringMappingTest
{
    private readonly ITestOutputHelper _output;

    public ListToStringMappingTest(ITestOutputHelper output) 
    {
        _output = output;
    }

    [Theory]
    [MemberData(nameof(MemberData__ImmutableArrayBasedList__Forall_Invoke_ToString__No_Exception))]
    public void ImmutableArrayBasedList__Forall_Invoke_ToString__No_Exception(ImmutableArrayBasedList<object> model)
    {
        //Model

        //Act
        string logging = model.ToString();

        //Assert

        //Log
        _output.WriteLine(logging);
    }
    public static IEnumerable<object[]> MemberData__ImmutableArrayBasedList__Forall_Invoke_ToString__No_Exception() =>
        ImmutableArrayBasedList.GetTestInstances__Item_Type_Is_Object();

}