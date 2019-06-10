using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public struct InvoiceContentInfo
    {

        internal String ItemNo;
        internal int Quantity;
        internal int Backorder;
        internal String SpecialNotes;
        internal String BackOrderSpecialNotes;

        public InvoiceContentInfo(String itemNo, int quantity, int backorder, String specialNotes, String backOrderSpecialNotes)
        {
            ItemNo = itemNo;
            Quantity = quantity;
            Backorder = backorder;
            SpecialNotes = specialNotes;
            BackOrderSpecialNotes = backOrderSpecialNotes;

        }
    }
}
