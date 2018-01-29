namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    public sealed class Calculator
    {
        private readonly Dictionary <string, Operation> operations;

        public Calculator()
        {
            operations = new Dictionary <string, Operation>
                             {
                                 ["+"] = delegate(double a, double b) { return a + b;},//инициализация делегата анонимным методом.
                                 ["-"] = (double a, double b) =>  { return a - b; },//лямбда, которая указывает на анонимный метод. Ненужное указание типа.
                                 ["*"] = (a, b) => { return a - b; },//лямбда, также указывает на анонимный метод.
                                 ["/"] = (a,b) => DoDivision(a,b), // лямбда, указывающая на неанонимный метод.
                                 ["%"] = (a,b) => a % b //лямбда в "привычном" виде. 
                                 // Cyclomatic complexity говорит, что это все равно анонимный метод. Ну что ж, возможно, лямбды - это синтаксический сахар для анонимный методов.
                             };
        }

        public delegate double Operation(double number1, double number2);

        public double DoAddition(double number1, double number2)
        {
            return number1 + number2;
        }

        public double DoSubtraction(double number1, double number2)
        {
            return number1 - number2;
        }

        public double DoMultiplication(double number1, double number2)
        {
            return number1 * number2;
        }

        public double DoDivision(double number1, double number2)
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
            res = operations[op](a, b); // сокращенная запись для предыдущей строки. Логично, мы же активируем делегат, который оболочка над функциями.
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

            ////Свитч, привет
            switch (op)
            {
                case "+":
                    return DoAddition(a, b);
                case "-":
                    return DoSubtraction(a, b);
                case "*":
                    return DoMultiplication(a, b);
                case "/":
                    return DoDivision(a, b);
                default:
                    throw new ArithmeticException("Operation "+op+" is invalid");
            }
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