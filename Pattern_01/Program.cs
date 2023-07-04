/*********************
 * 
 * 工厂模式：通过一个单独的类来根据具体的情况创建对应的类对象，核心是使用了多态的方法。
 *              
 * ******************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input two numbers:");
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            Console.WriteLine("Input operator symbol: ");
            string operateChar = Console.ReadLine();

            

            Operate myObj = OperateFactory.CreateOperateObject(operateChar);
            if(myObj == null)
            {
                Console.WriteLine("Error operator symbol");
                return;
            }

            myObj.num1 = double.Parse(num1);
            myObj.num2 = double.Parse(num2);


            double retVal = myObj.GetResult();
            Console.WriteLine($"{num1} {operateChar} {num2} = {retVal}");

        }
    }


    public class Operate
    {
        public double num1 { get; set; }
        public double num2 { get; set; }

        public virtual double GetResult()
        {
            Console.WriteLine("This is base class");
            return 0;
        }

    }

    public class OperateAdd: Operate
    {
        public override double GetResult()
        {
            return num1 + num2;
        }
    }

    public class OperateSub : Operate
    {
        public override double GetResult()
        {
            return num1 - num2;
        }
    }

    public class OperateMultiply : Operate
    {
        public override double GetResult()
        {
            return num1 * num2;
        }

    }

    public class OperateDivide:Operate
    {
        public override double GetResult()
        {
            if(num2 == 0)
            {
                Console.WriteLine("The divide num2 can't be 0");
                return 0;
            }
            else
            {
                return num1 / num2;
            }
        }
    }


    public class OperateFactory
    {
        public static Operate CreateOperateObject(string operatorSymbol)
        {
            Operate obj = null;
            switch (operatorSymbol)
            {
                case "+":
                    {
                        obj = new OperateAdd();
                        break;
                    }
                case "-":
                    {
                        obj = new OperateSub();
                        break;
                    }
                case "*":
                    {
                        obj = new OperateMultiply();
                        break;
                    }
                case "/":
                    {
                        obj = new OperateDivide();
                        break;
                    }
            }

            return obj;
        }
    }

}
