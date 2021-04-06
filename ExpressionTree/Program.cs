using System;
using System.Linq.Expressions;

namespace HexConvertation
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = "bc614e";
            var second = "343efcea";

            var result = Sum(first, second);
            Console.WriteLine(result);
        }
        public static Func<string, string> Sum(string hex1, string hex2)
        {
            var map = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            var reversMethod = typeof(Array).GetMethod(nameof(Array.Reverse));
            //hex1Array
            var hex1Array = Expression.Variable(typeof(Array), "hex1Array");
            var hex1ArrayReverse = Expression.Call(reversMethod, hex1Array);
            //hex2Array
            var hex2Array = Expression.Variable(typeof(Array), "hex2Array");
            var hex2ArrayReverse = Expression.Call(reversMethod, hex2Array);

            // var maxLength = Math.Max(hex1.Length, hex2.Length);
            var maxLengthMethod = typeof(int).GetMethod(nameof(Math.Max), new[] { typeof(int), typeof(int) });
            var LengthMethod = typeof(int).GetMethod(nameof(String.Length), new[] { typeof(string) });
            var hex1Length = Expression.Call(LengthMethod, Expression.Parameter(typeof(string), hex1));
            var hex2Length = Expression.Call(LengthMethod, Expression.Parameter(typeof(string), hex2));
            var maxLenght = Expression.Call(maxLengthMethod, hex1Length, hex2Length);
            //var sum = new char[maxLength + 1];
            var sumMethod = typeof(int).GetMethod(nameof(Sum), new[] { typeof(int), typeof(int) });
            var sum = Expression.Call(sumMethod, maxLenght, Expression.Constant(1));

            ParameterExpression wholePart = Expression.Variable(typeof(int), "wholePart");
            ParameterExpression i = Expression.Variable(typeof(int), "i");
            var methodIndexOf = typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) });
           
            LabelTarget endLoop = Expression.Label();          
            Expression block = Expression.Block(             
                new[] { wholePart, i },             
                Expression.Assign(wholePart, Expression.Constant(0)),            
                Expression.Assign(i, Expression.Constant(1)),              
                Expression.Loop(
                  Expression.Block(
                        Expression.IfThen(
                            Expression.Not(
                                // i <= n
                                Expression.LessThanOrEqual(i, mas
            var decimal1 = Expression.IfThenElse(Expression.LessThan(hex1Length, i), 0, Expression.Call(map, methodIndexOf, hex1Array));
            var decimal2 = Expression.IfThenElse(Expression.LessThan(hex1Length, i), 0, Expression.Call(map, methodIndexOf, hex2Array));
            var sumPosition = Expression.MultiplyAssign(decimal1, decimal2, wholePart))
                                 var remainder = sumPosition % 16;
            wholePart = Expression.Divide(sumPosition, Expression.Constant(16))
                                sum[i] = map[remainder];
            Expression.PostIncrementAssign(i)),
                    endLoop));
            sum = Expression.IfThenElse(Expression.GreaterThan(wholePart, Expression.Constant(0)), map[wholePart], '0');
                        
            return sum = Expression.Call(reversMethod, sum)
        }
    }
}
