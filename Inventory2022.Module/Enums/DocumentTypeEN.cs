using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory2022.Module.Enums
{
    /// <summary>
    /// Simple list
    /// </summary>
    public enum DocumentTypeEN : int
    {
        Entry = 0,
        Discharge = 1,
        Balance = 2
    }
    
    /*   Comprehensive List:
     * 
     * - Purchase Order     = 0
     * - Sales Quotation    = 1
     * - Sales Order        = 2
     * - Delivery Order     = 3
     * - Invoice            = 4
     * - Credit Note        = 5
     * - Physical Inventory = 6
     * - Write Off          = 7
     * - Return             = 8
     * - Internal Delivery  = 9
     * - Internal Receipt   = 10
     * - Discharge          = 11
     */ 
}
