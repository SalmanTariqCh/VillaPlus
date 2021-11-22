using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaPlusPrice
{
    class Program
    {
        public static string _firstInput { get; set; }
        public static string _secondInput { get; set; }
        public static string _discountitems { get; set; }
        public static string _itemsDiscounted { get; set; }
        public static string _item1price { get; set; }
        public static string _item2price { get; set; }
        public static string _totalprice { get; set; }
        static void Main(string[] args)
        {
            _firstInput = "How many apples customer wants: ";
            _secondInput = "How many oranges customer wants: ";
            _discountitems = "Number of items on which you want to give discount:    ";
            _itemsDiscounted = "Please give the number of items discounted:     ";
            _item1price = "Cost of 1 Apple:    ";
            _item2price = "Cost of 1 Orange:   ";
            
            UserInput _userinput = new UserInput();

            for (int i = 0; i < 100; i++)
            {
                bool _discountavailibility;
                string _item1, _item2, _itemprice1, _itemprice2;
                double _totalamount;

                while (true)
                {
                    bool user = _userinput.UInput();
                    if (user == true)
                    {
                        break;
                    }
                    else
                    {
                        return;
                    }
                }

                while (true)
                {
                    Console.Write(_firstInput);
                    _item1 = Console.ReadLine();

                    Console.Write(_secondInput);
                    _item2 = Console.ReadLine();

                    bool _checkitmnumbers = _userinput.CheckNumbers(_item1, _item2);
                    bool _checkitemdecimals = _userinput.CheckDecimals(_item1, _item2);
                    bool _checkitemzerovalues = _userinput.CheckZeroValues(_item1, _item2);

                    if (_checkitmnumbers == true && _checkitemdecimals == true && _checkitemzerovalues == true)
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write(_item1price);
                    _itemprice1 = Console.ReadLine();

                    Console.Write(_item2price);
                    _itemprice2 = Console.ReadLine();

                    bool _ispricezerovalue = _userinput.CheckZeroValues(_itemprice1, _itemprice2);
                    
                    if (_userinput.CheckNumbers(_itemprice1, _itemprice2) == true && _ispricezerovalue == true)
                    {
                        break;
                    }
                }

                _discountavailibility = _userinput.DiscountAvailibility();
                if (_discountavailibility == true)
                {
                    while (true)    
                    {
                        Console.Write(_discountitems);
                        string _itemondiscount = Console.ReadLine();

                        Console.Write(_itemsDiscounted);
                        string _discounteditems = Console.ReadLine();

                        bool _discountinputvaliditiy = _userinput.CheckNumbers(_itemondiscount, _discounteditems);
                        bool _checkdiscountecimals = _userinput.CheckDecimals(_itemondiscount, _discounteditems);
                        bool _checkdiscountzerovalues = _userinput.CheckZeroValues(_itemondiscount, _discounteditems);
                        bool _checkdiscounteditems = _userinput.CheckDiscountedItems(_itemondiscount, _discounteditems);


                        if (_discountinputvaliditiy == true && _checkdiscountecimals == true &&
                            _checkdiscountzerovalues == true && _checkdiscounteditems == true)
                        {
                            PriceCalculation _pricecalculation = new PriceCalculation();

                            _totalamount = 0;
                            _totalamount = _pricecalculation.TotalAmountWithDiscount(Convert.ToDouble(_item1),
                            Convert.ToDouble(_item2), Convert.ToDouble(_itemprice1), Convert.ToDouble(_itemprice2),
                            Convert.ToDouble(_itemondiscount), Convert.ToDouble(_discounteditems));

                            _totalprice = "Total Price with discount is £" + _totalamount.ToString();
                            Console.WriteLine(_totalprice);

                            Console.ReadLine();
                            break;
                         }
                    }
                }
                else
                {
                    PriceCalculation _pricecalculation = new PriceCalculation();
                    _totalamount = _pricecalculation.TotalAmountWithoutDiscount(Convert.ToDouble(_item1),
                        Convert.ToDouble(_item2), Convert.ToDouble(_itemprice1), Convert.ToDouble(_itemprice2));

                    _totalprice = "Total price without discount is £" + _totalamount.ToString();
                    Console.WriteLine(_totalprice);

                    Console.ReadLine();
                }
            }

        }
    }
}
