using System;
using System.Collections.Generic;
using System.Text;

namespace eLibrary.Services
{
    public enum Result
    {
        Success,
        NotFound,
        NoPermission
    }

    public enum BorrowResult
    {
        Success,
        NotAvailable,
    }
}
