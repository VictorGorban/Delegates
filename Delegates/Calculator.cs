namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    public sealed class Calculator
    {
        private readonly Dictionary <string, Operation> operations = new Dictionary <string, Operation>
                                                                         {
                                                                             ["+"] = Calculator.DoAddition,
                                                                             ["-"] = Calculator.DoSubtraction,
                                                                             ["*"] = Calculator.DoMultiplication,
                                                                             ["/"] = Calculator.DoDivision
                                                                         };

        // public Calculator() { }
        public delegate double Operation(double number1, double number2);

        public static double DoAddition(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double DoSubtraction(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double DoMultiplication(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double DoDivision(double number1, double number2)
        {
            return number1 / number2;
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public bool TryPerformOperation(string op, double a, double b, out double res)
        {
            Debug.Assert(operations != null, nameof(Calculator.operations) + " != null");
            if (op                  == null
                || !operations.ContainsKey(op))
            {
                res = 0;
                return false;
            }

            res = operations[op].Invoke(a, b);
            return true;
        }

        public double PerformOperation(string op, double a, double b)
        {
            if (op == null)
            {
                throw new ArgumentNullException(nameof(op));
            }

            Debug.Assert(operations != null, nameof(Calculator.operations) + " != null");
            if (operations.ContainsKey(op))
            {
                return operations[op].Invoke(a, b);
            }

            throw new ArithmeticException($"Wrong operation, calculator does not contains operation {op} {a, -10}");
            //// a, -10 - это выравнивание числа a "слева на 10 символместах"
            //// $ - легальный чит для String.Format
            // блин, можно даже условия использовать( ? : ) ! 
            // Ну да, эта фигня все равно преобразуется в String.Format. 
            // Хотя и допускает более сложные варианты использования.
            // Поэтому {a+b} аналогично {3}(допустим)", 3,4, a+b; 
        }

        public double PerformOperationHardCode(string op, double a, double b)
        {
            if (op == null)
            {
                throw new ArgumentNullException(nameof(op));
            }



            return 0;
        }

        public void DefineOperation1(string op, Func <double, double, double> body)
        { /* что такое Func<...>? Это предопределенные сигнатуры функций. Последный аргумент - возвращаемое значение. 
             Action<...> - это Func с возвращаемым void значением. Процедура, короче. Func = Action + returned.
             Короче, это работает как предопределенные стандартные делегаты.
             */
            if (op == null)
            {
                throw new ArgumentNullException(nameof(op));
            }

            if (operations.ContainsKey(op))
            {
                operations.Remove(op);
            }

            operations.Add(op, (Operation)body.Method.CreateDelegate(typeof(Operation)));
            //// ну это пипец просто, столько приведений типов
        }

        public void DefineOperation1(string op, Operation body) // хах, проблема с уровнями доступа... Для этого тут и приходится писать приведения типов.
        { /* что такое Func<...>? Это предопределенные сигнатуры функций. Последный аргумент - возвращаемое значение. 
             Action<...> - это Func с возвращаемым void значением. Процедура, короче. Func = Action + returned.
             Короче, это работает как предопределенные стандартные делегаты.
             */
            if (op == null)
            {
                throw new ArgumentNullException(nameof(op));
            }
            
            if (operations.ContainsKey(op))
            {
                operations.Remove(op);
            }

            operations.Add(op, body);
            /*Func - это не Operation. И как бы даже не совсем делегат(отдельно),
             это именно Func, ну округленно - делегат с генериками. 
             Поэтому приходится извлекать из нее method(Рефлексия!), 
             а потом делать делегат нужного типа,
             который(ура) уже можно привести к нужному типу.*/
        }
    }
}