namespace Nemonuri.Common.Primitives.Test.Models;

public static class ImmutableArrayBasedList
{
    public static ImmutableArrayBasedList<T> Create<T>(IEnumerable<T>? values)
    {
        return new ImmutableArrayBasedList<T>(values);
    }

    public static IEnumerable<object[]> GetTestInstances__Item_Type_Is_Object()
    {
        yield return [Create<object>([1,2,3])];
        yield return [Create<object>(["hello", "world"])];
        yield return [Create<object>([(15, "blar1"), (4357, "blar2")])];
        yield return [Create<object>(null)];
        yield return [Create<object>([
            "asregba", 
            new object(), 
            1.1f, 
            new {Person="Bob", Job="Teacher"}, 
            (1, 3, "234", 9L),
            (1, 3, "234", 9L).GetType()
        ])];
        yield return [Create<object>([
            Create<int>(Enumerable.Range(1, 10)),
            Create<double>(Enumerable.Range(0, 6).Select(a => Math.Cos(a))),
            Create<string>(["sadfa", "243sdr47hg", "dkdkdkdkdk"])
        ])];
    }

    public static ImmutableArrayBasedList<int>[] GetIntListArray()
    {
        return [
            Create<int>(Enumerable.Range(1, 10)),
            Create<int>(Enumerable.Range(1, 9)),
            Create<int>(Enumerable.Range(1, 11)),
            Create<int>(Enumerable.Range(2, 11)),
            Create<int>(Enumerable.Range(1, 10).Where(a => a != 5))
        ];
    }

    public static IEnumerable<object[]> GetTestInstances__Logically_Diffrent_Int_Int()
    {
        ImmutableArrayBasedList<int>[] ary = GetIntListArray();

        for (int idx0 = 0;idx0 < ary.Length;idx0++)
        {
            for (int idx1 = idx0 + 1;idx1 < ary.Length;idx1++)
            {
                yield return [ary[idx0], ary[idx1]];
            }
        }
    }


}