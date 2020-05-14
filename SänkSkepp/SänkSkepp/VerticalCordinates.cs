using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SänkSkepp
{
    class VerticalCordinates<T>
    {
        private T data;

        // using properties 
        public T Value
        {

            // using accessors 
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
