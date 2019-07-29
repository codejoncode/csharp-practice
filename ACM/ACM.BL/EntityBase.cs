using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }
    /// <summary>
    /// Base class cannot be instantiated  (cannot use new keyword)
    /// </summary>
    public abstract class EntityBase
    {
        public EntityStateOption EntityState { get; set; }
        public bool IsNew { get; private set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate();

        //abstract method does not have a default implementation because each new class will be overriding 
        /*basically doing it this way allows line 22 Validate() to be called and actually call the childs version*/
        public abstract bool Validate();
    }
}
