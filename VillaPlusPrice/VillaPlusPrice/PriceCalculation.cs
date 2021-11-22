using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaPlusPrice
{
    class PriceCalculation
    {
        public double TotalAmountWithoutDiscount(double _item1, double _item2, double _price1, double _price2)
        {
            return _item1 * _price1 + _item2 * _price2;
        }

        public double TotalAmountWithDiscount(double _item1, double _item2, double _price1, double _price2, double _itemsondiscount, double _itemsdiscounted)
        {
            string _discounteditemno = ((_item1 + _item2) *  (_itemsdiscounted / _itemsondiscount)).ToString();
            int _itemsnotincluded;

            if (_discounteditemno.IndexOf(".") > 0)
            {
                _itemsnotincluded = Convert.ToInt32(_discounteditemno.Substring(0, _discounteditemno.IndexOf(".")));
            }
            else
            {
                _itemsnotincluded = Convert.ToInt32(_discounteditemno);
            }

            if (_item1 > _item2)
            {
                _item1 = _item1 - _itemsnotincluded;
            }
            else
            {
                _item2 = _item2 - _itemsnotincluded;
            }

            return _item1 * _price1 + _item2 * _price2;
        }
    }
}
