using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VillaPlusPrice
{
    class UserInput
    {
        private string _usrInput { get; set; }
        private string _getusrInput { get; set; }
        private string _discountavalibility { get; set; }
        private string recorddiscountavailibility { get; set; }
        private string _userwarning { get; set; }

        public bool UInput()
        {
            try
            {
                _usrInput = "Do you wish to calculate prices (yes/no):   ";
                Console.Write(_usrInput);

                _getusrInput = Console.ReadLine();
                if (_getusrInput.ToLower() == "yes")
                {
                    return true;
                }
                else
                {
                    _usrInput = "Take Care! Bye";
                    Console.Write(_usrInput);

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

                return false;
            }
        }

        public bool DiscountAvailibility()
        {
            try
            {
                _discountavalibility = "Do you want to give the discount (yes/no):     ";
                Console.Write(_discountavalibility);

                recorddiscountavailibility = Console.ReadLine();
                if(recorddiscountavailibility.ToLower() == "yes")
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

                return false;
            }
        }

        public bool CheckNumbers(string num1, string num2)
        {
            try
            {
                if ((Regex.Matches(num1, @"[a-zA-Z]").Count > 0) || (Regex.Matches(num2, @"[a-zA-Z]").Count > 0))
                {
                    _userwarning = "Please eneter both values in numbers!";
                    Console.WriteLine(_userwarning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckDecimals(string num1, string num2)
        {
            try
            {
                if(num1.IndexOf(".") > 0 || num2.IndexOf(".") > 0)
                {
                    _userwarning = "Please eneter both values in numbers not decimals!";
                    Console.WriteLine(_userwarning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool CheckZeroValues(string num1, string num2)
        {
            try
            {
               
                if(Convert.ToDouble(num1) < 0 || Convert.ToDouble(num2) < 0)
                {
                    _userwarning = "Please eneter both values greater than zero!";
                    Console.WriteLine(_userwarning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool CheckDiscountedItems(string num1, string num2)
        {
            try
            {
                if (Convert.ToDouble(num1) <= Convert.ToDouble(num2))
                {
                    _userwarning = "The number of items purchased should be greater than number of discounted items!";
                    Console.WriteLine(_userwarning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
