using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<Benchmarking>();
class BaseCalculate
{
    public virtual double FindTriangleArea(double a, double b)
    {
        return a * b;
    }
}

class Calculate:BaseCalculate
{
    public override double FindTriangleArea(double a, double b)
    {
        return a * b / 2;
    }
}

sealed class SealedCalculate:BaseCalculate
{
    public override double FindTriangleArea(double a, double b)
    {
        return a * b / 2;
    }
}


// Benchmark Testleri
[MemoryDiagnoser]
public class Benchmarking
{
    Calculate calculate = new();
    SealedCalculate sealedCalculate = new();
    [Benchmark]
    public void CallingVirtualMethod()
    {

        for (int i = 0; i < 100; i++)
        {
            calculate.FindTriangleArea(8,2);
        }
    }
    [Benchmark]
    public void CallignWithSealedMethod()
    {
        for (int i = 0; i < 100; i++)
        {
            sealedCalculate.FindTriangleArea(8, 2);
        }
    }

}