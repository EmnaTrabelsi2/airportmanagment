using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.domaine
{
    public class Plane
    {
        #region Declaration Versions 
        /*private int capacity;
        //public int getCapacity(int capacity) {  return capacity; }
        //public void setCapacity(int capacity) { this.capacity = capacity; }  // CLASSIC VERSION -> JAVA 

        public int Capacity { get; set; }  VERSION LITE 
        public int MyProperty { get; private set; }  VERSION SECURE 

                // FULL VERSION
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

         
         */

        #endregion
        [Range(0,int.MaxValue)]

        public int Capacity { get;  set; }
        public DateTime MAnufactureDate { get; set; }
        public int PLaneiD { get; set; }


        public virtual PlaneType PlaneType { get; set; }
        public  virtual ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return ("Capacity:"+Capacity+"Manufacture Date : "+  MAnufactureDate+"plane type :"+PlaneType);
        }
      public Plane( int capacity, DateTime mAnufactureDate,  PlaneType planeType)
        {
            Capacity = capacity;
            MAnufactureDate = mAnufactureDate;
            PlaneType = planeType;
        }
        public Plane() { }
    }
}

