﻿using System;

namespace Funcionality.ViewModels
{
    public class MasterDetailPageMenuItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}