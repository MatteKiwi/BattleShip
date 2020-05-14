using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SänkSkepp
{
    class HorizontalCordinates<T>
    {
        private T data;
 
        public T Value
        {

            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

    }
}
