﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening04_ISP_OPG;
public interface IOrder
{
    void Purchase();
    void ProcessCreditCard();
}