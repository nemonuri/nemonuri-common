namespace Nemonuri.Common.Primitives.Test;

using System.Runtime.CompilerServices;
using Models;

public class StructuralEqualityComparerTest
{
    private readonly ITestOutputHelper _output;

    public StructuralEqualityComparerTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [MemberData(nameof(MemberData__ImmutableArrayBasedList__Forall_Self_Equal__Is_True))]
    public void ImmutableArrayBasedList__Forall_Self_Equal__Is_True(ImmutableArrayBasedList<object> model)
    {
        //Model

        //Act
        bool actual = model.Equals(model);

        //Assert
        Assert.True(actual);
    }
    public static IEnumerable<object[]> MemberData__ImmutableArrayBasedList__Forall_Self_Equal__Is_True() =>
        ImmutableArrayBasedList.GetTestInstances__Item_Type_Is_Object();

    [Theory]
    [MemberData(nameof(MemberData__Logically_Diffrent_Two_Int32Lists__Forall_Equal_Operation__Result_Is_False))]
    public void Logically_Diffrent_Two_Int32Lists__Forall_Equal_Operation__Result_Is_False
    (
        ImmutableArrayBasedList<int> arg0, 
        ImmutableArrayBasedList<int> arg1
    )
    {
        //Model

        //Act
        bool result = arg0.Equals(arg1);

        //Assert
        Assert.False(result);

        //Log
        _output.WriteLine(arg0.ToString());
        _output.WriteLine(arg1.ToString());
        _output.WriteLine("----------------------");
    }
    public static IEnumerable<object[]> MemberData__Logically_Diffrent_Two_Int32Lists__Forall_Equal_Operation__Result_Is_False() =>
        ImmutableArrayBasedList.GetTestInstances__Logically_Diffrent_Int_Int();

    [Theory]
    [MemberData(nameof(MemberData__Logically_Equal_But_Reference_Unequal_Two_Int32Lists__Forall_Equal_Operation__Result_Is_True))]
    public void Logically_Equal_But_Reference_Unequal_Two_Int32Lists__Forall_Equal_Operation__Result_Is_True(ImmutableArrayBasedList<int> modelBase)
    {
        //Model
        object model1 = (object)modelBase;
        object model2 = (object)modelBase;
        if (object.ReferenceEquals(model1,model2)) {throw new ArgumentException("Invalid Model");}

        //Act
        bool result = StructuralEqualityComparer<IReadOnlyList<int>, int>.Default.Equals(
            (ImmutableArrayBasedList<int>)model1, 
            (IReadOnlyList<int>)model2
        );

        //Assert
        Assert.True(result);

        //Log
        IntPtr nint1, nint2;
        unsafe
        {
#pragma warning disable CS8500 // 주소를 가져오거나, 크기를 가져오거나, 관리되는 형식에 대한 포인터를 선언합니다.
            void* address1 = &model1;
            void* address2 = &model2;
#pragma warning restore CS8500 // 주소를 가져오거나, 크기를 가져오거나, 관리되는 형식에 대한 포인터를 선언합니다.
            nint1 = new IntPtr(address1);
            nint2 = new IntPtr(address2);
        }
        _output.WriteLine(nint1.ToString());
        _output.WriteLine(nint2.ToString());
        _output.WriteLine("----------------------");
    }
    public static IEnumerable<object[]> MemberData__Logically_Equal_But_Reference_Unequal_Two_Int32Lists__Forall_Equal_Operation__Result_Is_True() =>
        ImmutableArrayBasedList.GetIntListArray().Select(a => new object[]{a});

}
