namespace Delegates
{
    using System;
    using System.Windows.Forms;

    public static class ForDelegates
    {
        public delegate void MyVoidDelegateReturnVoid(); // создали типизированную оболочку для функции. Это как бы типизация абстрактного класса.

        public delegate string AnswerToSay();

        public delegate void MyStringDelegateReturnVoid(string data);

        public delegate string MyStringDelegateReturnString(string data);

        public static void SayHello()
        {
            MessageBox.Show(@"Hello there!");
        }

        public static void SayHello1(string name)
        {
            MessageBox.Show(@"Здорова, " + name);
        }

        public static void SayHelloToName(string name)
        {
            MessageBox.Show(@"Hello " + name);
        }

        public static string BadAnswer()
        {
            return "No man, sorry but not, we cannot afford such a cool man as you";
        }

        public static string GoodAnswer()
        {
            return "Yes, congratulations, you are hired, you satisfy our requirements";
        }

        public static string FuckMildlyAnswer()
        {
            return "We'll call you, get off";
        }

        public static string FuckBrutallyAnswer()
        {
            return "I am calling Chuck Norris, you should run";
        }

        public static void ApplyingForAJob()
        {
            /*MyVoidDelegateReturnVoid sayHello = SayHello;
            //// заметь, нельзя присваивать нечто из method group. Нельзя тут использовать возможности перегрузки.

            sayHello.Invoke();*/

            /*var delegate2 = new MyStringDelegateReturnVoid(SayHello1); // связали делегат с функцией SayHello1
            delegate2 += SayHelloToName;
            delegate2.Invoke("чел"); // т.е. мы отдаем каждому методу в делегате одно и то же значение.
            */
            AnswerToSay givingAnswer;
            var randomNumber = new Random();
            switch (randomNumber.Next(3))
            {
                // хм, если 3 - это максимум, то рандом будет строго меньше, выходит
                case 0:
                    givingAnswer = FuckMildlyAnswer;
                    break;
                case 1:
                    givingAnswer = BadAnswer;
                    break;
                case 2:
                    givingAnswer = GoodAnswer;
                    break;
                default:
                    givingAnswer = FuckBrutallyAnswer;
                    break;
            }
            MessageBox.Show(givingAnswer.Invoke());
            givingAnswer -= givingAnswer;
            givingAnswer += BadAnswer; /* Вычитание делегатов дает непредсказуемый результат... 
            ООО, ну может не удалить ничего, т.к. не будет того, что нужно удалить, ну бывает*/
            givingAnswer -= GoodAnswer;
            var @delegate = Delegate.Remove(givingAnswer, new AnswerToSay(BadAnswer));
            ////Хотя результат Delegate.Remove не считается непредсказуемым. Почему, интересно
            /*если нечего удалить, то не удаляет, вот и все. 
             Да, и все эти указатели на функции находятся всего лишь в списке вызовов делегата. 
             Операции минусов вызывают метод Remove из абстрактного класса Delegate.*/
        }
    }
}